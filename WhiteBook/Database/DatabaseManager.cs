using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;
using System.IO;

namespace WhiteBook.Database
{
    //创建用户独立数据库
    public static class DatabaseManager
    {
        private static string GetDatabasePath(string username)
        {
            // 获取应用程序目录
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            // 构建数据库文件路径
            string databaseFileName = $"{username}_diary.db";
            string databasePath = Path.Combine(basePath, "sqlite", databaseFileName);

            return $"Data Source={databasePath};";
        }

        public static void InitializeDatabaseForUser(string username)
        {
            // 获取数据库的连接字符串
            string dbPath = GetDatabasePath(username);
            using (SQLiteConnection connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    // 创建 Diary 表
                    command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Diary (
                        Date TEXT NOT NULL PRIMARY KEY,
                        Title TEXT NOT NULL,
                        Mood TEXT,
                        Content TEXT NOT NULL
                    );";
                    command.ExecuteNonQuery();

                    // 创建 Memo 表
                    command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Memo (
                        Thing TEXT NOT NULL PRIMARY KEY,
                        Details TEXT NOT NULL,
                        Done INTEGER NOT NULL
                    );";
                    command.ExecuteNonQuery();
                }
            }
        }
        // 添加日记条目
        public static int AddEntry(string username, string date, string title, string mood, string content)
        {
            string dbPath = GetDatabasePath(username);
            try
            {
                using (var connection = new SQLiteConnection(dbPath))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"INSERT INTO Diary (Date, Title, Mood, Content) VALUES (@Date, @Title, @Mood, @Content)";
                        command.Parameters.AddWithValue("@Date", date);
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Mood", mood);
                        command.Parameters.AddWithValue("@Content", content);
                        command.ExecuteNonQuery();
                    }
                }
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add diary: " + ex.Message);
                return 0;
            }
        }
        
        //获取日记
        public static List<DiaryEntry> GetAllEntries(string username)
        {
            var entries = new List<DiaryEntry>();
            string dbPath = GetDatabasePath(username);
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Diary ORDER BY Date DESC", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        entries.Add(new DiaryEntry
                        {
                            Date = DateTime.Parse(reader["Date"].ToString()),
                            Title = reader["Title"].ToString(),
                            Mood = reader["Mood"].ToString(),
                            Content = reader["Content"].ToString()
                        });
                    }
                }
            }
            return entries;
        }
        //修改日记数据
        public static void UpdateEntry(string username, string date, string title, string mood, string content)
        {
            string dbPath = GetDatabasePath(username);
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var command = new SQLiteCommand("UPDATE Diary SET Title=@Title, Mood=@Mood, Content=@Content WHERE Date=@Date", connection);
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Mood", mood);
                command.Parameters.AddWithValue("@Content", content);
                command.ExecuteNonQuery();
            }
        }
        public static void DeleteEntry(string username, string date)
        {
            string dbPath = GetDatabasePath(username); // 获取用户的数据库路径
            try
            {
                using (var connection = new SQLiteConnection(dbPath))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(connection))
                    {
                        // 删除指定日期的日记条目
                        command.CommandText = "DELETE FROM Diary WHERE Date=@Date";
                        command.Parameters.AddWithValue("@Date", DateTime.Parse(date).ToString("yyyy-MM-dd"));

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Diary entry deleted successfully!");
                        }
                        else
                        {
                            MessageBox.Show("No diary entry found for the specified date.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete diary entry: " + ex.Message);
            }
        }

        //增加备忘录条目
        public static void AddMemo(string username, string thing, string details, int done)
        {
            string dbPath = GetDatabasePath(username);
            try
            {
                using (var connection = new SQLiteConnection(dbPath))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"INSERT INTO Memo (Thing, Details, Done) VALUES (@Thing, @Details, @Done)";
                        command.Parameters.AddWithValue("@Thing", thing);
                        command.Parameters.AddWithValue("@Details", details);
                        command.Parameters.AddWithValue("@Done", done);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add Memo: " + ex.Message);
            }
        }
        public static void UpdateMemo(string username, string thing, string details, int done)
        {
            string dbPath = GetDatabasePath(username);
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var command = new SQLiteCommand("UPDATE Memo SET Done=@Done, Details=@Details WHERE Thing=@Thing", connection);
                command.Parameters.AddWithValue("@Thing", thing);
                command.Parameters.AddWithValue("@Details", details);
                command.Parameters.AddWithValue("@Done", done);
                command.ExecuteNonQuery();
            }
        }
        //获取备忘录
        public static List<MemoEntry> GetMemos(string username)
        {
            var Memos = new List<MemoEntry>();
            string dbPath = GetDatabasePath(username);
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Memo", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Memos.Add(new MemoEntry
                        {
                            Thing = reader["Thing"].ToString(),
                            Details = reader["Details"].ToString(),
                            Done = reader.GetInt32(reader.GetOrdinal("Done"))
                        });
                    }
                }
            }
            return Memos;
        }
        //增加用户信息
        public static int AddUser(string username, string password)
        {
            //用户名和密码非空
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password cannot be empty.");
                return 0;
            }
            // 连接数据库
            string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sqlite", "Sqlite_whitebook.db");
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={databasePath}"))
                {
                    connection.Open();

                    // 创建命令
                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "INSERT INTO UserID (Username, Password) VALUES (@username, @password)";
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        command.ExecuteNonQuery();
                    }
                }
                return 1;
            }
            catch
            {
                MessageBox.Show("Failed to register, try again!");
                return 0;
            }
        }

        //登录用户名和密码验证
        public static bool ValidateUser(string username, string password)
        {
            string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sqlite", "Sqlite_whitebook.db");

            try
            {
                using (var connection = new SQLiteConnection($"Data Source={databasePath}"))
                {
                    connection.Open();
                    var command = new SQLiteCommand("SELECT COUNT(1) FROM UserID WHERE Username = @username AND Password = @password", connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    int result = Convert.ToInt32(command.ExecuteScalar());
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                // 记录或显示异常信息
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

    }
}


