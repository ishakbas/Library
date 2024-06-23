using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Library.Pages
{
    public partial class EditOrderPage : Page
    {
        public Заказы _currentOrder = new Заказы();

        public EditOrderPage(Заказы order)
        {
            InitializeComponent();
            if (order != null)
            {
                _currentOrder = order;
            }
            DataContext = _currentOrder;

            ClientComboBox.ItemsSource = Basyrov_diplomEntities.Instance().Клиенты.ToList();
            EmployeeComboBox.ItemsSource = Basyrov_diplomEntities.Instance().Сотрудники.ToList();
            PaymentMethodComboBox.ItemsSource = Basyrov_diplomEntities.Instance().Способы_оплаты.ToList();
            OrderStatusComboBox.ItemsSource = Basyrov_diplomEntities.Instance().Статусы_заказа.ToList();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
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
