using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Library.Pages
{
    public partial class OrderPage : Page
    {
        // создание экземпляра для контекста
        private Заказы _order = new Заказы();

        public OrderPage()
        {
            InitializeComponent();

            // предварительное заполнение данными компонентов
            ClientsComboBox.ItemsSource = Basyrov_diplomEntities.Instance().Клиенты.ToList();
            EmployeesComboBox.ItemsSource = Basyrov_diplomEntities.Instance().Сотрудники.ToList();
            PaymentComboBox.ItemsSource = Basyrov_diplomEntities.Instance().Способы_оплаты.ToList();
            ProductsComboBox.ItemsSource = Basyrov_diplomEntities.Instance().Книги.ToList();
        }
        // обработка нажатия на кнопку сохранить
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_order.Номер_заказа == 0)
            {
                // получение данных из компонтентов 
                var employeeId = EmployeesComboBox.SelectedItem as Сотрудники;
                var clientId = ClientsComboBox.SelectedItem as Клиенты;
                var paymentMethodId = PaymentComboBox.SelectedItem as Способы_оплаты;
                var productId = ProductsComboBox.SelectedItem as Книги;
                var quantity = int.Parse(QuantityTextBox.Text);

                // выполнение хранимой процедуры
                var order = Basyrov_diplomEntities.Instance().Оформление_заказа
                    (
                    employeeId.Код_сотрудника,
                    clientId.Код_клиента,
                    paymentMethodId.Код_способа_оплаты,
                    productId.Артикул_книги,
                    quantity
                    );
            }

            // сохранение изменений 
            try
            {
                Basyrov_diplomEntities.Instance().SaveChanges();
                MessageBox.Show("Информация сохранена!", "Заказ", MessageBoxButton.OK, MessageBoxImage.Information);

                FrameManager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
