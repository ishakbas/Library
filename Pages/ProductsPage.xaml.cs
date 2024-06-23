using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Library.Pages
{
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();
        }
        // добавление нового товара
        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new AddEditProductPage(null));
        }
        // удаление товара или товаров (если выделено несколько товаров)
        private void DelButtonClick(object sender, RoutedEventArgs e)
        {
            // получить список выделенных продуктов
            var productsForRemove = ProductsGrid.SelectedItems.Cast<Книги>().ToList();

            if (MessageBox.Show($"Вы действительно хотите удалить {productsForRemove.Count} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //удаление
                try
                {
                    Basyrov_diplomEntities.Instance().Книги.RemoveRange(productsForRemove);
                    Basyrov_diplomEntities.Instance().SaveChanges();
                    MessageBox.Show("Успешно!", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                    ProductsGrid.ItemsSource = Basyrov_diplomEntities.Instance().Книги.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        // изменение описания товара
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new AddEditProductPage((sender as Button).DataContext as Книги));
        }

        // получать список товаров при каждом отображении старницы
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Basyrov_diplomEntities.Instance().ChangeTracker.Entries().ToList().ForEach(entry => entry.Reload());
                ProductsGrid.ItemsSource = Basyrov_diplomEntities.Instance().Книги.ToList();
            }
        }
        // уменьшить цену товаров на 25%
        private void ChangePriceClick(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show($"Вы действительно хотите уменьшить цену на 25% на товары?", "Внимание",
               MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Basyrov_diplomEntities.Instance().Уменьшить25();
                    Basyrov_diplomEntities.Instance().ChangeTracker.Entries().ToList().ForEach(entry => entry.Reload());
                    ProductsGrid.ItemsSource = Basyrov_diplomEntities.Instance().Книги.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
