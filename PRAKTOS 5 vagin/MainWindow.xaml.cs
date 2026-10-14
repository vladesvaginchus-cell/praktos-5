// Назначение: главное окно программы — демонстрация операций == и != для троек
//              и проверки равенства чисел тройки заданному числу.
// Дата создания: 08.10.2026
// Автор создания: Вагин Владислав Игоревич

using System.Windows;
using System.Windows.Controls;
using Lib_5;

namespace PRAKTOS_5_vagin
{
    /// <summary>
    /// Главное окно программы.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCompareTriads_Click(object sender, RoutedEventArgs e)
        {
            Triad? firstTriad = ReadTriad(tbFirst1, tbSecond1, tbThird1);

            if (firstTriad is null)
            {
                return;
            }

            Triad? secondTriad = ReadTriad(tbFirst2, tbSecond2, tbThird2);

            if (secondTriad is null)
            {
                return;
            }

            WriteMessage(string.Format("({0}) == ({1}) -> {2}", firstTriad, secondTriad, firstTriad == secondTriad));
            WriteMessage(string.Format("({0}) != ({1}) -> {2}", firstTriad, secondTriad, firstTriad != secondTriad));
            WriteMessage(string.Format("Суммы равны: {0}", firstTriad.GetSum() == secondTriad.GetSum()));
        }

        private void btnCompareNumber_Click(object sender, RoutedEventArgs e)
        {
            Triad? triad = ReadTriad(tbFirst1, tbSecond1, tbThird1);

            if (triad is null)
            {
                return;
            }

            int number;

            if (!int.TryParse(tbNumber.Text, out number))
            {
                MessageBox.Show("Поле должно содержать целое число.", "Ошибка");
                return;
            }

            WriteMessage(string.Format("({0}).EqualNumber({1}) -> {2}", triad, number, triad.EqualNumber(number)));
            WriteMessage(string.Format("({0}).NotEqualNumber({1}) -> {2}", triad, number, triad.NotEqualNumber(number)));
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lbLog.Items.Clear();
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow window = new AboutWindow();
            window.Owner = this;
            window.ShowDialog();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Выходные параметры: тройка из полей ввода; null, если введено неверное значение.
        /// </summary>
        private Triad? ReadTriad(TextBox firstBox, TextBox secondBox, TextBox thirdBox)
        {
            int first;
            int second;
            int third;

            if (!int.TryParse(firstBox.Text, out first) ||
                !int.TryParse(secondBox.Text, out second) ||
                !int.TryParse(thirdBox.Text, out third))
            {
                MessageBox.Show("Все поля должны содержать целые числа.", "Ошибка");
                return null;
            }

            if (first <= 0 || second <= 0 || third <= 0)
            {
                MessageBox.Show("Числа тройки должны быть положительными.", "Ошибка");
                return null;
            }

            return new Triad(first, second, third);
        }

        private void WriteMessage(string message)
        {
            lbLog.Items.Add(message);
            lbLog.ScrollIntoView(lbLog.Items[lbLog.Items.Count - 1]);
        }
    }
}