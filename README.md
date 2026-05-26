# Geometry App

Программа для работы с геометрическими фигурами: создание, отрисовка и вычисление пересечений.

## 📋 Описание

Приложение читает текстовый файл с описанием геометрических фигур, создаёт объекты соответствующих типов, выводит их параметры и вычисляет пересечения между последовательными парами фигур.

### Поддерживаемые фигуры

| Тип    | Формат ввода              | Пример                   |
|--------|---------------------------|--------------------------|
| Point  | `point x y`               | `point 1 2`              |
| Rect   | `rect x1 y1 x2 y2`        | `rect 1 2 3 4`           |
| Line   | `line x1 y1 x2 y2`        | `line 10 10 20 20`       |
| Circle | `circle x y radius`       | `circle 10 10 5`         |

### Пример входного файла (`input.txt`)
point 1 2
rect 1 2 3 4
line 10 10 20 20
circle 10 10 5

text

### Пример вывода
=== DRAW ===
point at (1.00, 2.00)
rect at (1.00, 2.00), (3.00, 4.00)
line from (10.00, 10.00) to (20.00, 20.00)
circle at (10.00, 10.00), radius = 5

=== INTERSECTIONS ===
The point cannot intersect the rect
rect and line do not have intersections
The line and the circle have intersection at (13.54, 13.54)

text

---

## 🏗️ Архитектура проекта
petroGM-test/
├── GeometryApp/ # Консольное приложение (.exe)
│ ├── Program.cs
│ └── input.txt
├── GeometryLib/ # Библиотека классов (.dll)
│ ├── Core/ # Базовые типы (IShape, PointD, IntersectionResult)
│ ├── Features/ # Фигуры (Point, Rect, Line, Circle)
│ ├── Services/ # Логика пересечений (IntersectionService)
│ ├── Factory/ # Фабрика создания фигур
│ └── Extensions/ # Методы расширения
├── GeometryTest/ # Модульные тесты (xUnit)
└── GeometryApp.sln # Файл решения

text

---

## 🚀 Быстрый старт (без Docker)

### Требования

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

### Сборка и запуск

```bash
# Клонировать репозиторий
git clone https://github.com/your-username/geometry-app.git
cd petroGM-test

# Собрать проект
dotnet build GeometryApp.sln

# Запустить приложение (с файлом по умолчанию)
dotnet run --project GeometryApp

# Запустить со своим файлом
dotnet run --project GeometryApp -- my_shapes.txt

# Запустить тесты
dotnet test GeometryTest/GeometryTest.csproj
🐳 Запуск через Docker
Требования
Docker

Docker Compose (входит в Docker Desktop)

1. Быстрый запуск приложения
bash
# Собрать образы и запустить приложение
docker compose up --build geometry-app

# Или в фоновом режиме
docker compose up --build -d geometry-app
Что произойдёт:

Соберётся библиотека GeometryLib

Соберётся и запустится консольное приложение

Вывод появится в консоли

2. Запуск тестов
bash
# Запустить тесты
docker compose --profile test up geometry-test
Ожидаемый вывод:

text
geometry-test  | Total tests: 50
geometry-test  |      Passed: 50
geometry-test  |      Failed: 0
geometry-test  |      Skipped: 0
geometry-test exited with code 0
3. Запуск со своим файлом
bash
# Создайте свой файл с фигурами
echo "point 100 200" > my_shapes.txt
echo "circle 500 500 50" >> my_shapes.txt

# Запустите с ним
docker compose --profile custom up geometry-app-custom
Или просто замените содержимое GeometryApp/input.txt и перезапустите:

bash
# Отредактируйте input.txt
nano GeometryApp/input.txt

# Перезапустите приложение
docker compose up geometry-app
4. Интерактивный режим
bash
# Зайти внутрь контейнера
docker compose run --rm geometry-app /bin/bash

# Внутри контейнера
dotnet GeometryApp.dll /app/input.txt
5. Полный цикл: сборка → тесты → запуск
bash
# Всё одной командой
docker compose up --build geometry-lib && \
docker compose --profile test up geometry-test && \
docker compose up geometry-app
📊 Сводка команд Docker
Команда	Описание
docker compose build	Собрать все образы
docker compose up geometry-app	Запустить приложение
docker compose up -d geometry-app	Запустить в фоне
docker compose --profile test up geometry-test	Запустить тесты
docker compose --profile custom up geometry-app-custom	Запустить со своим файлом
docker compose down	Остановить и удалить контейнеры
docker compose logs geometry-app	Посмотреть логи
docker compose run --rm geometry-app /bin/bash	Интерактивный режим
🧪 Тестирование
bash
# Через .NET CLI
dotnet test GeometryTest/GeometryTest.csproj

# Через Docker
docker compose --profile test up geometry-test
