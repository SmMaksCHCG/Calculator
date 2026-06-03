using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calculator1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _accumulator = 0;
        private string? _currentOperator = null;
        private bool _isEnteringNumber = false;
        private bool _justCalculated = false;

        public MainWindow()
        {
            InitializeComponent();
            this.PreviewKeyDown += MainWindow_PreviewKeyDown;
        }

        // Обновить дисплей с заданным текстом
        private void SetDisplay(string text)
        {
            Display.Text = text;
        }

        private void Digit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                var digit = b.Content?.ToString();
                if (string.IsNullOrEmpty(digit)) return;

                if (_justCalculated)
                {
                    // начать новый ввод после результата
                    SetDisplay("0");
                    _justCalculated = false;
                }

                if (!_isEnteringNumber || Display.Text == "0")
                {
                    SetDisplay(digit);
                    _isEnteringNumber = true;
                }
                else
                {
                    SetDisplay(Display.Text + digit);
                }
            }
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            if (!_isEnteringNumber)
            {
                SetDisplay("0,");
                _isEnteringNumber = true;
                return;
            }

            if (!Display.Text.Contains(","))
            {
                SetDisplay(Display.Text + ",");
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _accumulator = 0;
            _currentOperator = null;
            _isEnteringNumber = false;
            _justCalculated = false;
            SetDisplay("0");
            HistoryListBox.Items.Clear();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (!_isEnteringNumber || Display.Text.Length == 0) return;
            if (Display.Text.Length == 1)
            {
                SetDisplay("0");
                _isEnteringNumber = false;
                return;
            }
            SetDisplay(Display.Text.Substring(0, Display.Text.Length - 1));
        }

        private void Negate_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Display.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var val))
            {
                val = -val;
                SetDisplay(val.ToString(System.Globalization.CultureInfo.CurrentCulture));
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                var op = b.Content?.ToString();
                if (string.IsNullOrEmpty(op)) return;

                ApplyPendingOperation();
                _currentOperator = op;
                _isEnteringNumber = false;
                _justCalculated = false;
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            ApplyPendingOperation();
            _currentOperator = null;
            _justCalculated = true;
        }

        private void ApplyPendingOperation()
        {
            if (!_isEnteringNumber && _currentOperator == null)
            {
                // ничего не вводилось
                return;
            }

            // получить текущее число
            if (!double.TryParse(Display.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var current))
            {
                // некорректный ввод
                return;
            }

            if (_currentOperator == null)
            {
                _accumulator = current;
                _isEnteringNumber = false;
                return;
            }

            double result = _accumulator;
            try
            {
                switch (_currentOperator)
                {
                    case "+":
                        result = _accumulator + current;
                        break;
                    case "-":
                        result = _accumulator - current;
                        break;
                    case "*":
                        result = _accumulator * current;
                        break;
                    case "/":
                        if (current == 0)
                        {
                            MessageBox.Show("Деление на ноль невозможно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        result = _accumulator / current;
                        break;
                }
            }
            finally
            {
            }

            // Добавить запись в историю
            HistoryListBox.Items.Insert(0, $"{_accumulator} {_currentOperator} {current} = {result}");

            _accumulator = result;
            SetDisplay(result.ToString(System.Globalization.CultureInfo.CurrentCulture));
            _isEnteringNumber = false;
        }

        // Обработка клавиатуры
        private void MainWindow_PreviewKeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                var digit = (e.Key - Key.D0).ToString();
                SetDisplayForKey(digit);
                e.Handled = true;
            }
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                var digit = (e.Key - Key.NumPad0).ToString();
                SetDisplayForKey(digit);
                e.Handled = true;
            }
            else if (e.Key == Key.OemComma || e.Key == Key.Decimal || e.Key == Key.OemPeriod)
            {
                Decimal_Click(null!, null!);
                e.Handled = true;
            }
            else if (e.Key == Key.Add || e.Key == Key.OemPlus)
            {
                SimulateOperator("+"); e.Handled = true;
            }
            else if (e.Key == Key.Subtract || e.Key == Key.OemMinus)
            {
                SimulateOperator("-"); e.Handled = true;
            }
            else if (e.Key == Key.Multiply)
            {
                SimulateOperator("*"); e.Handled = true;
            }
            else if (e.Key == Key.Divide || e.Key == Key.Oem2)
            {
                SimulateOperator("/"); e.Handled = true;
            }
            else if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                Equals_Click(null!, null!); e.Handled = true;
            }
            else if (e.Key == Key.Escape)
            {
                Clear_Click(null!, null!); e.Handled = true;
            }
            else if (e.Key == Key.Back)
            {
                Back_Click(null!, null!); e.Handled = true;
            }
        }

        private void SetDisplayForKey(string digit)
        {
            if (_justCalculated)
            {
                SetDisplay("0");
                _justCalculated = false;
            }

            if (!_isEnteringNumber || Display.Text == "0")
            {
                SetDisplay(digit);
                _isEnteringNumber = true;
            }
            else
            {
                SetDisplay(Display.Text + digit);
            }
        }

        private void SimulateOperator(string op)
        {
            ApplyPendingOperation();
            _currentOperator = op;
            _isEnteringNumber = false;
        }
    }
}