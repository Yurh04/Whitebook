using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;
using WhiteBook.Database;

namespace WhiteBook
{
    public partial class Window_1 : Window, INotifyPropertyChanged
    {
        private DateTime _currentDateTime;
        public event PropertyChangedEventHandler PropertyChanged;
        private string Mood = ""; // 全局字段用来存储选中的心情
        private string selectedEntryDate;// 用于存储选中的日记的日期
        private string _username;//用户名
        private int doneCount;

        public Window_1(string username)
        {
            InitializeComponent();
            _username = username;
            this.DataContext = this;
            CurrentDateTime = DateTime.Now;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
            Memosearch();
        }
        private string _memoCount;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public string MemoCount
        {
            get { return _memoCount; }
            set
            {
                _memoCount = value;
                RaisePropertyChanged("MemoCount");
            }
            
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            CurrentDateTime = DateTime.Now;
        }
        public DateTime CurrentDateTime
        {
            get => _currentDateTime;
            set
            {
                _currentDateTime = value;
                OnPropertyChanged(nameof(CurrentDateTime));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void NewEntry_Click(object sender, RoutedEventArgs e)
        {
            if (DiaryBotton.Visibility == Visibility.Hidden)
            {
                newButton.Content = " 返回       ";
                DiaryBotton.Visibility = Visibility.Visible;
            }
            else
            {
                newButton.Content = " 新建       ";
                DiaryBotton.Visibility = Visibility.Hidden;
            }
            // 使得点击 New Entry 按钮时显示 New Entry 标签界面
            //mainTabControl.SelectedItem = newEntryTab;
        }
        private void newMemo_Click(object sender, RoutedEventArgs e)
        {
            newMemoStackPanel.Visibility = Visibility.Visible;
            newMemoButton.Visibility = Visibility.Collapsed;
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {
            string thing = newMemoTextbox.Text;
            string details = newDetailsTextbox.Text;
            DatabaseManager.AddMemo(_username, thing, details,1);
            newMemoButton.Visibility = Visibility.Visible;
            newMemoStackPanel.Visibility = Visibility.Collapsed;
            Memosearch();
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            newMemoStackPanel.Visibility = Visibility.Collapsed;
            newMemoButton.Visibility = Visibility.Visible;
            Memosearch();
        }
        private void Diary_Click(object sender, RoutedEventArgs e)
        {
            mainTabControl.SelectedItem = newEntryTab;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            mainTabControl.SelectedItem = mainTab;
        }

        public void moodComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (moodComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                // 检查是否选择了 "Custom..." 选项
                if (selectedItem.Content.ToString() == "你的心情......")
                {
                    CustomInputDialog inputDialog = new CustomInputDialog();
                    if (inputDialog.ShowDialog() == true) // 显示对话框，并等待用户输入
                    {
                        string customMood = inputDialog.InputText;

                        if (!string.IsNullOrWhiteSpace(customMood))
                        {
                            // 将自定义心情添加到 ComboBox 中，并设置为选中项
                            var newCustomItem = new ComboBoxItem { Content = customMood };
                            moodComboBox.Items.Insert(moodComboBox.Items.Count - 1, newCustomItem); // 在 Custom... 前面插入新的选项
                            moodComboBox.SelectedItem = newCustomItem; // 选中新的自定义心情
                            Mood = customMood; // 更新 Mood 变量
                            Console.WriteLine("Selected custom mood: " + Mood);
                        }
                        else
                        {
                            // 如果用户取消或未输入内容，恢复默认选择
                            moodComboBox.SelectedIndex = 0;
                        }
                    }
                }
                else
                {
                    // 检查是否是使用了 StackPanel 结构的 ComboBoxItem
                    var stackPanel = selectedItem.Content as StackPanel;
                    if (stackPanel != null)
                    {
                        // 在 StackPanel 中查找 TextBlock 并获取其文本
                        var textBlock = stackPanel.Children.OfType<TextBlock>().FirstOrDefault();
                        if (textBlock != null)
                        {
                            Mood = textBlock.Text; // 更新 Mood 变量
                            Console.WriteLine("Selected mood: " + Mood);
                        }
                    }
                    else
                    {
                        // 处理非 StackPanel 结构的 ComboBoxItem
                        Mood = selectedItem.Content.ToString();
                        Console.WriteLine("Selected mood: " + Mood);
                    }
                }
            }
        }

        private void TitleTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // 当用户点击 TextBox 时，清空内容
            if (titleTextBox.Text == "在此输入......")
            {
                titleTextBox.Text = "";
                titleTextBox.Foreground = Brushes.Black; // 将文本颜色设置为黑色，表示正常输入
            }
        }
        private void thing_Focus(object sender, RoutedEventArgs e)
        {
            if(newMemoTextbox.Text=="添加提醒事项")
            {
                newMemoTextbox.Text = "";
                newMemoTextbox.Foreground = Brushes.Black;
            }
        }
        private void details_Focus(object sender, RoutedEventArgs e)
        {
            if(newDetailsTextbox.Text=="添加备注")
            {
                newDetailsTextbox.Text = "";
            }
        }
        private void TitleTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // 如果用户没有输入任何内容，恢复默认文本
            if (string.IsNullOrWhiteSpace(titleTextBox.Text))
            {
                titleTextBox.Text = "在此输入......";
                titleTextBox.Foreground = Brushes.Gray; // 设置为灰色，表示占位符文本
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            string date = datePicker.SelectedDate?.ToString("yyyy-MM-dd") ?? DateTime.Now.ToString("yyyy-MM-dd");
            string title = titleTextBox.Text;
            string mood = Mood;// 获取ComboBox选中项的Content属性，并转换为字符串
            string content = GetRichTextBoxText(contentRichTextBox);

            int result = DatabaseManager.AddEntry(_username,date, title, mood, content);
            if (result>0)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDialog();  // 显示为模态对话框
                mainTabControl.SelectedItem = mainTab;
            }
            LoadEntries();
        }

        private string GetRichTextBoxText(RichTextBox richTextBox)
        {
            TextRange textRange = new TextRange(
                richTextBox.Document.ContentStart,
                richTextBox.Document.ContentEnd);

            return textRange.Text;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            LoadEntries();
        }
        private void LoadEntries()
        {
            List<DiaryEntry> entries = DatabaseManager.GetAllEntries(_username);
            if (entries.Count > 0)
            {
                entriesListView.ItemsSource = entries;
                entriesListView.Visibility = Visibility.Visible;
                HideBotton.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("没有找到日记条目。");
                entriesListView.Visibility = Visibility.Collapsed; // 如果没有条目，继续保持不可见
            }
        }
        private void Memosearch()
        {
            List<MemoEntry> memoEntries = DatabaseManager.GetMemos(_username);
            double totalcount = memoEntries.Count;
            doneCount = memoEntries.Count(entry => entry.Done == 0);
            int NotdoneCount = memoEntries.Count(entry => entry.Done == 1);
            if (memoEntries.Count > 0)
            {
                reminderListView.ItemsSource = memoEntries;
                reminderListView.Visibility = Visibility.Visible;
            }
            else
            {
                reminderListView.Visibility = Visibility.Collapsed; // 如果没有条目，隐藏ListView
            }
            double rate = ((double)doneCount / totalcount)*100;
            string formattedRate = rate.ToString("F1");
            DoneCount.Text = $"完成率：{formattedRate} % ,{doneCount}项已完成, {NotdoneCount}项待完成";
        }
        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            entriesListView.Visibility = Visibility.Collapsed;
            HideBotton.Visibility = Visibility.Hidden;
        }
        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            if (ExitButton.Visibility == Visibility.Visible && TurnoffButton.Visibility == Visibility.Visible)
            {
                ExitButton.Visibility = Visibility.Hidden;
                TurnoffButton.Visibility = Visibility.Hidden;
            }
            else
            {
                ExitButton.Visibility = Visibility.Visible;
                TurnoffButton.Visibility = Visibility.Visible;
            }
        }

        private void entriesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
        private void Turnoff_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void contentRichTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var richTextBox = sender as RichTextBox;

            // 获取 RichTextBox 中的当前文本
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            string currentText = textRange.Text.Trim();

            // 如果当前文本是默认提示文本，则清空
            if (currentText == "从这里开始写你的日记......")
            {
                richTextBox.Document.Blocks.Clear(); // 清空内容
            }
        }

        // 处理编辑日记的点击事件
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var diaryEntry = button?.Tag as DiaryEntry;

            if (diaryEntry != null)
            {
                selectedEntryDate = diaryEntry.Date.ToString("yyyy-MM-dd");
                editTitleTextBox.Text = diaryEntry.Title;
                editMoodTextBox.Text = diaryEntry.Mood;

                // 设置 RichTextBox 的内容
                editContentRichTextBox.Document.Blocks.Clear();
                editContentRichTextBox.Document.Blocks.Add(new Paragraph(new Run(diaryEntry.Content)));

                // 显示编辑区域
                editArea.Visibility = Visibility.Visible;
            }
        }
        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            string title = editTitleTextBox.Text;
            string mood = editMoodTextBox.Text;
            string content = new TextRange(editContentRichTextBox.Document.ContentStart, editContentRichTextBox.Document.ContentEnd).Text;

            DatabaseManager.UpdateEntry(_username, selectedEntryDate, title, mood, content);

            MessageBox.Show("Entry updated successfully!");

            // 隐藏编辑区域
            editArea.Visibility = Visibility.Collapsed;

            // 重新加载日记条目
            LoadEntries();
        }

        // 处理删除日记的点击事件
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var diaryEntry = button?.Tag as DiaryEntry;

            selectedEntryDate = diaryEntry.Date.ToString("yyyy-MM-dd");
            if (diaryEntry != null)
            {
                // 删除日记确认
                if (MessageBox.Show("Are you sure you want to delete this entry?", "Delete Entry", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    // 删除数据库中的日记条目
                    DatabaseManager.DeleteEntry(_username, selectedEntryDate);

                    // 重新加载日记列表
                    LoadEntries();
                }
            }
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var memoEntry = button?.Tag as MemoEntry;
            if (memoEntry != null)
            {
                string thing = memoEntry.Thing;
                string details = memoEntry.Details;
                DatabaseManager.UpdateMemo(_username, thing, details, 0);
                Memosearch();
            }
        }
            
    }
}
