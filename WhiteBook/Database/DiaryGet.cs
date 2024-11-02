using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using WhiteBook.Database;

namespace WhiteBook.Database
{
    public class DiaryEntry
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Mood { get; set; }
        public string Content { get; set; }
    }
    public class MemoEntry
    {
        public string Thing { get; set; }
        public string Details { get; set; }
        public int Done { get; set; }
    }
}
