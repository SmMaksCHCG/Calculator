Конфигурация приложения SimpleCalculatorMVVM

Файл: SimpleCalculatorMVVM/Config/appsettings.json

Параметры:
- Width, Height: размеры окна (double)
- BackgroundColor, ForegroundColor: строки цвета в формате HEX (например, #FFFFFFFF)
- FontFamily: название шрифта
- FontSize: размер шрифта (double)
- Theme: light / dark
- Accessibility: normal / large
- ConnectionString: опциональная строка подключения к БД

Применение:
1. Отредактируйте appsettings.json в папке Config.
2. Перезапустите приложение — конфигурация будет загружена при старте.

Обработка ошибок:
Если файл не найден или неверный JSON — приложение продолжит работу с значениями по умолчанию и выведет сообщение в консоль.
