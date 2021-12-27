using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        public PageMain()
        {
            InitializeComponent();
            var prodHist = Connect0Db.conDb.Products.ToList();
            CmBSearch.Items.Add("По возврастанию");
            CmBSearch.Items.Add("По убыванию");
            CmBSearch.SelectedIndex = 0;
            ProdView.ItemsSource = prodHist;
        }

        private void TextSerch_TextChanged(object sender, TextChangedEventArgs e)
        {

            FindProduct();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            FindProduct();
        }


        public void FindProduct()
        {
            List<Products> products = Connect0Db.conDb.Products.Where(x => x.ProdName.Contains(TextSerch.Text)).ToList();
            switch (CmBSearch.SelectedIndex)
            {
                case 0: break;

                case 1 : products = products.OrderBy(x => x.ProdName).ToList(); break;

                case 2: products = products.OrderByDescending(x => x.ProdName).ToList(); break;
            }
            ProdView.ItemsSource = products;
        }
    }
}

       
