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
using System.Windows.Shapes;
using WhiteBook.Database;
using System.Data.SQLite;

namespace WhiteBook
{
    /// <summary>
    /// Register_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Register_Window : Window
    {
        public Register_Window()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        //固定写法，控件与变量相互绑定
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
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
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // 获取用户输入的用户名和密码
            string username = usernameTextBox.Text;
            string password = Code; // 使用PasswordBox为密码输入提供安全性
            int result;
            // 插入用户信息到数据库
            result=DatabaseManager.AddUser(username, password);

            // 显示消息提示用户注册成功
            if (result > 0)
            {
                var regisuccess = new RegiSuccess();
                regisuccess.Show();
                // 关闭注册窗口，返回登录窗口
                this.Close();
            }
            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // 简单地关闭当前窗口
            this.Close();
        }
    }
}
