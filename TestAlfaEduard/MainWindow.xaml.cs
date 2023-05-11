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


namespace TestAlfaEduard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IEnumerable<Channel> channelList;
        private Push push;
        private WriteAdd writeAdd;

        public MainWindow()
        {
            InitializeComponent();
            push = new Push();
            writeAdd = new WriteAdd();

        }

        private void XMLDataBase(object sender, RoutedEventArgs e)
        ///Read data from a file using a data model.
        {
            channelList = push.ReadXMLDataBase();

        }

        private void XMLRegular(object sender, RoutedEventArgs e)
        ///Read data from a file using regular expressions
        {
            channelList = push.ReadXMLRegular();
        }

        private async void AddExel(object sender, RoutedEventArgs e)
        ///Write data to excel
        {
            await writeAdd.WriteAddExcelAsync(channelList);
        }

        private async void AddWord(object sender, RoutedEventArgs e)
        ///Write data to word
        {
            await writeAdd.WriteAddWordAsync(channelList);
        }
        private async void AddJson(object sender, RoutedEventArgs e)
        ///Write data to txt
        {
            await writeAdd.WriteAddJsonAsync(channelList);
        }
    }

}

