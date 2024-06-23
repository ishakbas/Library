using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Library.Pages
{
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
        }
        // нажатие на кнопку удаления заказа
        private void DelButtonClick(object sender, RoutedEventArgs e)
        {
            // получения списка выделенных заказов
            var productsForRemove = OrdersGrid.SelectedItems.Cast<Заказы>().ToList();
            // если пользователь действительно хочет удалить заказы
            if (MessageBox.Show($"Вы действительно хотите удалить {productsForRemove.Count} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    // удалеине
                    Basyrov_diplomEntities.Instance().Заказы.RemoveRange(productsForRemove);
                    Basyrov_diplomEntities.Instance().SaveChanges();
                    MessageBox.Show("Успешно!");
                    OrdersGrid.ItemsSource = Basyrov_diplomEntities.Instance().Заказы.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
        // нажатие на кнопку редактирования заказа
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new EditOrderPage((sender as Button).DataContext as Заказы));
        }

        // обновления списка заказов при каждом отображении страницы
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Basyrov_diplomEntities.Instance().ChangeTracker.Entries().ToList().ForEach(entry => entry.Reload());
                OrdersGrid.ItemsSource = Basyrov_diplomEntities.Instance().Заказы.ToList();
            }
        }
    }
}
