# Calculator (Калькулятор)

Простой WPF-калькулятор на C# (.NET 10).

Инструкции по созданию удалённого репозитория, ветвлению и запуску проекта.

1. Создать репозиторий на GitHub
- Через веб-интерфейс: github.com → New repository → имя: `Calculator`.
- Или через GitHub CLI (gh): `gh repo create Calculator --public`.

2. Подключить локальный репозиторий и отправить код
- Убедитесь, что в корне проекта есть .sln (если нет, создайте: `dotnet new sln -n Calculator` и `dotnet sln Calculator.sln add calculator1\calculator1.csproj`).
- Инициализировать git: `git init`.
- Добавить удалённый origin: `git remote add origin https://github.com/<USER>/Calculator.git`.
- Сделать первый коммит:
  - `git add .`
  - `git commit -m "Initial commit: Simple Calculator"`
  - `git branch -M main`
  - `git push -u origin main`

3. Создать параллельную ветку разработки
- `git checkout -b feature/ui`
- После изменений: `git add . && git commit -m "Feature: UI" && git push -u origin feature/ui`.

4. Пригласить участников/преподавателя
- На GitHub: Settings → Collaborators and teams → Add people.

5. Запуск проекта
- Откройте решение в Visual Studio 2026 и запустите проект Simple Calculator.
- Или в PowerShell: `dotnet build` и `dotnet run --project calculator1\calculator1.csproj`.

6. Диаграмма классов
- В Visual Studio: Project → Add New Item → Class Diagram → добавить классы.
- Альтернатива: PlantUML (файл классов добавлен plantuml/diagram.puml).
