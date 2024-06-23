using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Library.Pages
{
    public partial class AuthPage : Page
    {
        // создание экземпляра пользоватлея
        private Пользователи _users = new Пользователи();
        public AuthPage()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Объект для сборки ошибок и демонстрации их в конце
            StringBuilder _err = new StringBuilder();

            // если логин пустой
            if (string.IsNullOrWhiteSpace(LoginTextBox.Text))
            {
                // в строку ошибок добавить 
                _err.AppendLine("Не введен логин");
            }
            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                _err.AppendLine("Не введен пароль");
            }
            // если есть ошибки
            if (_err.Length > 0)
            {
                MessageBox.Show(_err.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // присвоение полям экземпляра значения из полей вода
            _users.Логин = LoginTextBox.Text;
            _users.Пароль = PasswordTextBox.Text;

            try
            {
                // Поиск пользователя по логину и паролю
                var user = Basyrov_diplomEntities.Instance().Пользователи.Where(x => x.Логин == _users.Логин && x.Пароль == _users.Пароль).FirstOrDefault();
                if (user != null)
                {
                    MessageBox.Show("Успешная авторизация", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                    // навигация в главное меню при успешном логине
                    FrameManager.MainFrame.Navigate(new MainAdminPage(user.Администратор));
                }
                else
                {
                    MessageBox.Show($"Неверный логин или пароль");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
