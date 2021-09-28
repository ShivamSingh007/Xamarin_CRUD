using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using CRUD.Models;
using System.Threading.Tasks;

namespace CRUD
{
    public class SQLiteHelper
    {
        private SQLiteAsyncConnection Con;
        public SQLiteHelper()
        {
            Con = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XamarinSqlite.db3"));
            Con.CreateTableAsync<Person>().Wait();
        }
        public Task<int> AddNewRecord(Person p)
        {
            Task<int> n = Con.InsertAsync(p);
            return n;
        }
        public Task<int> UpdateRecord(Person p)
        {
            Task<int> u = Con.UpdateAsync(p);
            return u;
        }
        public Task<int> DeleteRecord(Person p)
        {
            Task<int> d = Con.DeleteAsync(p);
            return d;
        }
        public async Task<Person> GetSingleRecord(int pid)
        {
            Task<Person> u = Con.Table<Person>().Where(x => x.id == pid).FirstOrDefaultAsync();
            return await u;
        }
        public Task<List<Person>> GetAllRecord()
        {
            return Con.Table<Person>().ToListAsync();
        }
    }
}
