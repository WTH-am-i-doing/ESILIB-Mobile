using ESILib.Models;
using LiteDB;
using System.Collections.Generic;

namespace ESILib.Data
{
    public class LiteDBHelper
    {
        public LiteCollection<Book> Bks;

        public LiteDBHelper(string dbPath)
        {
            var db = new LiteDatabase(dbPath);
            Bks = (LiteCollection<Book>)db.GetCollection<Book>("Books");

        }
    }
}
