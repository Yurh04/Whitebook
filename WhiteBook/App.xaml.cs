using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WhiteBook.Database;
using System.Data.SQLite;
using System.IO;

namespace WhiteBook
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // 确保数据库目录存在
            EnsureDatabaseDirectoryExists();

            // 在这里初始化其他需要在启动时执行的代码
            // 比如初始化数据库
        }

        public void OnUserLogin(string username)
        {
            // Initialize database for the logged-in user
            DatabaseManager.InitializeDatabaseForUser(username);
        }
        private void EnsureDatabaseDirectoryExists()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string databaseDirectory = Path.Combine(basePath, "sqlite");

            if (!Directory.Exists(databaseDirectory))
            {
                Directory.CreateDirectory(databaseDirectory);
            }
        }
    }
}
