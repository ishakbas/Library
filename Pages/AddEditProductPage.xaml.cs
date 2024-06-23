using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Library.Pages
{

    public partial class AddEditProductPage : Page
    {
        // определение экземпляра для контекста
        Книги _currentBook = new Книги();
        public AddEditProductPage(Книги book)
        {
            InitializeComponent();

            // загрузка данных в элемент combobox
            GenresComboBox.ItemsSource = Basyrov_diplomEntities.Instance().Жанры.ToList();
            PublisherComboBox.ItemsSource = Basyrov_diplomEntities.Instance().Издатели.ToList();

            // если страница была загружена с передачей экземпляра
            if (book != null)
            {
                // контекст = переданный экземпляр
                _currentBook = book;
                PageLabel.Text = "Редактирование товара";
            }
            else
            {
                PageLabel.Text = "Добавление товара";

            }
            // выставление контекста
            DataContext = _currentBook;
        }
        // нажатие на кнопку сохранения
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // объект для хранения ошибок
            StringBuilder _err = new StringBuilder();

            // если название продукта не введено
            if (string.IsNullOrWhiteSpace(_currentBook.Название))
            {
                _err.AppendLine("Не введено название товара");
            }
            // если цена не введена
            if (string.IsNullOrWhiteSpace(_currentBook.Цена.ToString()))
            {
                _err.AppendLine("Не введена цена товара");
            }
            // если дата не выбрана
            if (string.IsNullOrWhiteSpace(_currentBook.Год_издания.ToString()))
            {
                _err.AppendLine("Не введена дата изготовления");
            }
            // если единица измерения не выбрана
            if (string.IsNullOrWhiteSpace(_currentBook.Единица_измерения))
            {
                _err.AppendLine("Не введена единица измерения товара");
            }
            // если присутсвуют ошибки
            if (_err.Length > 0)
            {
                MessageBox.Show(_err.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // если в данный момент происходит добавление товара
            if (_currentBook.Артикул_книги == 0)
            {
                Basyrov_diplomEntities.Instance().Книги.Add(_currentBook);
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
