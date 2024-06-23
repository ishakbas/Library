using Library.Pages;
using System.Windows;

namespace Library
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // навигация в страницу авторизации
            MainFrame.Navigate(new AuthPage());
            // присвоение компонента полю класса, чтобы навигация была доступна из любой страницы
            FrameManager.MainFrame = MainFrame;
        }

        // нажатие на кнопку назад
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            // навигация на одну страницу назад
            MainFrame.GoBack();
        }

        // событие при каждом отображении окна
        private void MainFrame_ContentRendered(object sender, System.EventArgs e)
        {
            // если есть возможность перейти на страницу назад
            BackButton.Visibility = MainFrame.CanGoBack ? Visibility.Visible : Visibility.Hidden;
        }

        // нажатие на кнопку выхода
        private void ExitButton(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы действительно хотите выйти?", "Внимание",
               MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                this.Close();
        }
    }
}
