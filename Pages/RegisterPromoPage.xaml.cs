using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Library.Pages
{
    /// <summary>
    /// Interaction logic for RegisterPromoPage.xaml
    /// </summary>
    public partial class RegisterPromoPage : Page
    {
        Клиенты client = new Клиенты();
        public RegisterPromoPage()
        {
            InitializeComponent();
        }

        // функция проверки электронной почты на соответствие
        private bool IsValidEmailAddress(string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }

        private void RegisterPromo(object sender, System.Windows.RoutedEventArgs e)
        {
            // Объект для сборки ошибок и демонстрации их в конце
            StringBuilder _err = new StringBuilder();

            // если логин пустой
            if (string.IsNullOrWhiteSpace(FullNameTextBox.Text))
            {
                // в строку ошибок добавить 
                _err.AppendLine("Не введен ФИО");
            }
            // если почта не введена
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                _err.AppendLine("Не введена почта");
            }
            else
            {
                // ксли почта введена, но не корректно
                if (!IsValidEmailAddress(EmailTextBox.Text))
                {
                    _err.AppendLine("Неккоректная почта");
                }
            }
            // если номер телефона не введен
            if (string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text))
            {
                _err.AppendLine("Не введен номер телефона");
            }
            // если есть ошибки
            if (_err.Length > 0)
            {
                MessageBox.Show(_err.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // присвоение значений экземпляру
            client.ФИО = FullNameTextBox.Text;
            client.Электронная_почта = EmailTextBox.Text;
            client.Телефон = PhoneNumberTextBox.Text;

            try
            {
                Basyrov_diplomEntities.Instance().Регистрация_в_промо(client.ФИО, client.Телефон, client.Электронная_почта);
                Basyrov_diplomEntities.Instance().SaveChanges();
                MessageBox.Show("Информация сохранена!", "Промо", MessageBoxButton.OK, MessageBoxImage.Information);
                FrameManager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
