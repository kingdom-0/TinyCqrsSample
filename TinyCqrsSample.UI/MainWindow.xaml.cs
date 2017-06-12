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
using TinyCqrsSample.Configuration;
using TinyCqrsSample.Core.Commands;
using TinyCqrsSample.Core.Reporting;

namespace TinyCqrsSample.UI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        private Guid _id;
        public MainWindow()
        {
            InitializeComponent();
            _id = Guid.NewGuid();
            ServiceLocator.CommandBus.Send(new CreateItemCommand(_id, "first item", "first des", 1, DateTime.Now.AddDays(-1), DateTime.Now));
            Logs.ItemsSource = ServiceLocator.ReportDatabase.GetItems();
        }

        private void OnLoadButtonClick(object sender, RoutedEventArgs e)
        {
            //Logs.ItemsSource = ServiceLocator.ReportDatabase.GetItems();
        }

        private void OnEditButtonClick(object sender, RoutedEventArgs e)
        {
            var log = ServiceLocator.ReportDatabase.GetById(_id);
            ServiceLocator.CommandBus.Send(new ChangeItemCommand(_id, "new title", "new description", 2, DateTime.Now, DateTime.Now));
            var newSource = ServiceLocator.ReportDatabase.GetItems();
            Logs.ItemsSource = null;
            Logs.ItemsSource = newSource;
        }

        private void OnDeleteButtonClick(object sender, RoutedEventArgs e)
        {
            ServiceLocator.CommandBus.Send(new DeleteItemCommand(_id, 1));
            Logs.ItemsSource = null;
            Logs.ItemsSource = ServiceLocator.ReportDatabase.GetItems();
        }
    }
}
