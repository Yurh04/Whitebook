using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SQLite;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WhiteBook.Database;

namespace WhiteBook
{
    /// <summary>
    /// LogWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LogWindow : Window
    {
        private string _username;
        public LogWindow(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            Window_1 window_1 = new Window_1(_username);
            window_1.Show();//创建实例
            this.Close();

        }
    }
}
