using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Library.Pages
{
    public partial class AddUserPage : Page
    {
        // создание экземпляра таблицы для контекста
        private Пользователи _users = new Пользователи();

        public AddUserPage()
        {
            InitializeComponent();

            // присвоение контексту экземпляра
            DataContext = _users;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AdminCheckBoxLabel.Content = "Да";
        }

        private void AdminCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            AdminCheckBoxLabel.Content = "Нет";
        }
        // нажатие кнопки сохранения
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // объект для хранения ошибок
            StringBuilder _err = new StringBuilder();

            // если логин не введен
            if (string.IsNullOrWhiteSpace(_users.Логин))
            {
                _err.AppendLine("Не введен логин");
            }

            // если пароль не введен
            if (string.IsNullOrWhiteSpace(_users.Пароль))
            {
                _err.AppendLine("Не введен пароль");
            }
            // если присутсвуют ошибки
            if (_err.Length > 0)
            {
                MessageBox.Show(_err.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // если в данный момент происходит добавление пользователя
            if (_users.Код_пользователя == 0)
            {
                Basyrov_diplomEntities.Instance().Пользователи.Add(_users);
                _users.Администратор = (bool)AdminCheckBox.IsChecked;
            }
            // сохранение изменений и навигация на страницу назад
            try
            {
                Basyrov_diplomEntities.Instance().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                FrameManager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
