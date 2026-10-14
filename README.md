# Сравнение троек: операторы `==` и `!=`

Учебное WPF-приложение по теме **перегрузка операторов сравнения**: класс `Triad`
научен сравниваться с другой тройкой и с отдельным числом.

**Разработчик:** Вагин Владислав Игоревич, группа ИСП-31

## Задание

Доработать класс `Triad` — тройку положительных чисел. Разработать операции определения
равенства и неравенства чисел с возвратом `true`/`false`. Разработать операции проверки
полного равенства и неравенства чисел в триадах: `(a1, b1, c1) == (a2, b2, c2)`.

## Стек

- C#, .NET 8
- WPF (`net8.0-windows`) для приложения, `net8.0` для библиотеки
- `Nullable` и `ImplicitUsings` включены

## Сборка и запуск

Нужен Windows и .NET SDK 8.0 или новее. Собрано и проверено на SDK 9.0.318 —
предупреждений и ошибок нет.

```powershell
dotnet build "PRAKTOS 5 vagin.sln"
dotnet run --project "PRAKTOS 5 vagin\PRAKTOS 5 vagin.csproj"
```

Либо открыть `PRAKTOS 5 vagin.sln` в Visual Studio 2022 и нажать F5.

## Структура

```
praktos-5/
├── Lib_5/                        библиотека с классом Triad
│   ├── Lib_5.csproj              net8.0
│   └── Triad.cs
├── PRAKTOS 5 vagin/              WPF-приложение
│   ├── PRAKTOS 5 vagin.csproj    net8.0-windows, UseWPF
│   ├── MainWindow.xaml(.cs)      главное окно
│   └── AboutWindow.xaml(.cs)     окно «О программе»
├── PRAKTOS 5 vagin.sln
└── .gitignore
```

## Класс `Triad`

`Lib_5/Triad.cs` — продолжение работы с тройкой чисел.

### Сравнение с числом

| Член | Возвращает `true`, когда |
|---|---|
| `bool EqualNumber(int number)` | **все три** числа тройки равны `number` |
| `bool NotEqualNumber(int number)` | **ни одно** из трёх чисел не равно `number` |

### Сравнение с другой тройкой

```csharp
public static bool operator ==(Triad? firstTriad, Triad? secondTriad)
public static bool operator !=(Triad? firstTriad, Triad? secondTriad)
```

Тройки равны, только если совпадают все три числа попарно: `(1, 2, 3) == (1, 2, 3)`, но
`(1, 2, 3) == (3, 2, 1)` — уже нет. Порядок важен.

Обработка `null` в операторе `==` идёт в три шага: сначала проверяется ссылка на тот же
объект, затем `null`, и только потом сравниваются поля. Поэтому `null == null` даёт
`true`, а `null == new Triad(1, 1, 1)` — `false`.

### Согласованность с `Equals` и `GetHashCode`

Перегруженный `operator ==` обязан быть дополнен переопределением `Equals`, иначе
`triad1.Equals(triad2)` и `triad1 == triad2` могут разойтись. В классе переопределены
`Equals` (через `this == obj as Triad`) и `GetHashCode` (через `HashCode.Combine`), поэтому
равные тройки попадают в одну корзину `HashSet<Triad>` и `Dictionary<Triad, T>`.

### Остальные члены класса

| Член | Сигнатура | Назначение |
|---|---|---|
| Свойства | `int First`, `int Second`, `int Third` | доступ только на чтение |
| Конструктор | `Triad(int first = 1, int second = 1, int third = 1)` | значения по умолчанию — единицы |
| Перегрузка | `void SetParams(int first, int second, int third)` | три числа по отдельности |
| Перегрузка | `void SetParams(int[] values)` | массив ровно из трёх чисел |
| Перегрузка | `void SetParams(Triad triad)` | копирование из другой тройки |
| Метод | `int GetSum()` | сумма трёх чисел |
| Переопределение | `string ToString()` | строка вида `a; b; c` |

Отрицательные и нулевые числа не принимаются: `SetParams` бросает
`ArgumentOutOfRangeException`.

## Интерфейс

Две группы полей — «Первая тройка» и «Вторая тройка», плюс поле «Число для сравнения»:

| Кнопка | Обработчик | Что проверяет |
|---|---|---|
| Проверить тройки | `btnCompareTriads_Click` | `==`, `!=` и равенство сумм двух троек |
| Сравнить с числом | `btnCompareNumber_Click` | `EqualNumber` и `NotEqualNumber` |
| Очистить | `btnClear_Click` | — |
| О программе | `btnAbout_Click` | окно «О программе» |
| Выход | `btnExit_Click` | закрытие |

Результат каждого нажатия пишется в список «Результат». Если в поле не целое число или
число неположительное, приложение показывает сообщение об ошибке.