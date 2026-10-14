// Назначение: окно «О программе» с данными разработчика и формулировкой задания.
// Дата создания: 08.10.2026
// Автор создания: Вагин Владислав Игоревич

using System.Windows;

namespace PRAKTOS_5_vagin
{
    /// <summary>
    /// Окно сведений о программе.
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}