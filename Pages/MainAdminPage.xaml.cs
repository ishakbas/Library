using System.Windows;
using System.Windows.Controls;

namespace Library.Pages
{
    public partial class MainAdminPage : Page
    {
        public MainAdminPage(bool admin)
        {
            InitializeComponent();
            if (admin)
            {
                ManagerAdminLabel.Text = "Панель Администратора";
                AddUsersButton.Visibility = Visibility.Visible;
            }
            else
            {
                ManagerAdminLabel.Text = "Панель Менеджера";
                AddUsersButton.Visibility = Visibility.Hidden;
            }
        }

        // навигация в список товаров
        private void NavigateProducts(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new ProductsPage());
        }

        // навигация в оформление заказа
        private void NavigateNewOrder(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new OrderPage());
        }

        // навигация в добавление пользователей
        private void NavigateAddUser(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new AddUserPage());
        }

        // навигация в регистрацию в промо-кампанию
        private void NavigateRegisterPromo(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new RegisterPromoPage());
        }

        //навигация в список заказов
        private void NavigateOrders(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new OrdersPage());
        }
    }
}
