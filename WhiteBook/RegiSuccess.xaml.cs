﻿using System;
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
using System.Windows.Shapes;
using System.Data.SQLite;

namespace WhiteBook
{
    /// <summary>
    /// RegiSuccess.xaml 的交互逻辑
    /// </summary>
    public partial class RegiSuccess : Window
    {
        public RegiSuccess()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender,RoutedEventArgs e)
        {
            
            this.Close();
        }
    }
}
