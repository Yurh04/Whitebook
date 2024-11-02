using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Data.SQLite;
using WhiteBook.Database;

namespace WhiteBook
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;

        }
        //固定写法，控件与变量相互绑定
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler= PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        //用户名
        private string _Username;

        public string Username
        {
            get { return _Username; }
            set 
            { 
                _Username = value;
                RaisePropertyChanged("Username");
            }
        }

        private string _Code;
        public string Code
        {
            get { return _Code; }
            set
            {
                _Code = value;
                RaisePropertyChanged("Code");
            }
        }
        //Binding前后断绑定 实现分离
        //public string Username { get; set; }

        //public string Code { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = Username;
            string password = PasswordBox.Password; // 假设使用 PasswordBox 来输入密码

            bool isValidUser = DatabaseManager.ValidateUser(username, password);
            if (isValidUser)
            {
                //初始化数据库
                var app = Application.Current as App;
                app.OnUserLogin(username);

                // 登录成功，转到首页
                var logWindow = new LogWindow(username);
                logWindow.Show();

                //隐藏登录界面
                this.Hide();  //当前的界面this
            }
            else//wrong
            {
                MessageBox.Show("Wrong username or code");
                //getUsername.Text = "";
                //getCode.Text = "";
                //需要同步控件
                Username = "";
                PasswordBox.Password = "";
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, e);
            }
        }

        private void Register_Click(object sender,RoutedEventArgs e)
        {
            Register_Window register_Window = new Register_Window();
            register_Window.Show();
            //this.Hide();
        }
    }
}
