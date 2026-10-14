// Назначение: класс Triad хранит тройку положительных чисел, позволяет устанавливать
//              их перегруженными методами, вычислять сумму и сравнивать тройки.
// Дата создания: 08.10.2026
// Автор создания: Вагин Владислав Игоревич

namespace Lib_5
{
    /// <summary>
    /// Тройка положительных чисел.
    /// </summary>
    public class Triad
    {
        private int _first;
        private int _second;
        private int _third;

        public int First { get { return _first; } }

        public int Second { get { return _second; } }

        public int Third { get { return _third; } }

        public Triad(int first = 1, int second = 1, int third = 1)
        {
            SetParams(first, second, third);
        }

        /// <summary>
        /// Входные параметры: три числа тройки, должны быть положительными.
        /// </summary>
        public void SetParams(int first, int second, int third)
        {
            CheckPositive(first, nameof(first));
            CheckPositive(second, nameof(second));
            CheckPositive(third, nameof(third));

            _first = first;
            _second = second;
            _third = third;
        }

        /// <summary>
        /// Входные параметры: массив ровно из трех положительных чисел.
        /// </summary>
        public void SetParams(int[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.Length != 3)
            {
                throw new ArgumentException("Массив должен содержать ровно три числа.", nameof(values));
            }

            SetParams(values[0], values[1], values[2]);
        }

        /// <summary>
        /// Входные параметры: triad - тройка-источник, значения которой копируются.
        /// </summary>
        public void SetParams(Triad triad)
        {
            if (triad == null)
            {
                throw new ArgumentNullException(nameof(triad));
            }

            SetParams(triad.First, triad.Second, triad.Third);
        }

        public int GetSum()
        {
            return _first + _second + _third;
        }

        /// <summary>
        /// Входные параметры: number - число, с которым сравниваются все числа тройки.
        /// Выходные параметры: true, если каждое число тройки равно number.
        /// </summary>
        public bool EqualNumber(int number)
        {
            return _first == number && _second == number && _third == number;
        }

        /// <summary>
        /// Входные параметры: number - число, с которым сравниваются все числа тройки.
        /// Выходные параметры: true, если ни одно число тройки не равно number.
        /// </summary>
        public bool NotEqualNumber(int number)
        {
            return _first != number && _second != number && _third != number;
        }

        /// <summary>
        /// Выходные параметры: true, если числа двух троек попарно равны.
        /// </summary>
        public static bool operator ==(Triad? firstTriad, Triad? secondTriad)
        {
            if (ReferenceEquals(firstTriad, secondTriad))
            {
                return true;
            }

            if (firstTriad is null || secondTriad is null)
            {
                return false;
            }

            return firstTriad._first == secondTriad._first &&
                   firstTriad._second == secondTriad._second &&
                   firstTriad._third == secondTriad._third;
        }

        /// <summary>
        /// Выходные параметры: true, если хотя бы одна пара чисел двух троек различна.
        /// </summary>
        public static bool operator !=(Triad? firstTriad, Triad? secondTriad)
        {
            return !(firstTriad == secondTriad);
        }

        /// <summary>
        /// Оператор == обязан быть дополнен переопределением Equals, иначе проверка
        /// через object.Equals и через == даст разные результаты.
        /// </summary>
        public override bool Equals(object? obj)
        {
            return this == obj as Triad;
        }

        /// <summary>
        /// Выходные параметры: хеш-код, совпадающий у равных троек.
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(_first, _second, _third);
        }

        /// <summary>
        /// Выходные параметры: строка вида "a; b; c".
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0}; {1}; {2}", _first, _second, _third);
        }

        private static void CheckPositive(int value, string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, "Числа тройки должны быть положительными.");
            }
        }
    }
}