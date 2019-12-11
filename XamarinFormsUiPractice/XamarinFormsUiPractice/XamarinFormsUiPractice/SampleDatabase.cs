using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsUiPractice.Models;

namespace XamarinFormsUiPractice
{
    public class SampleDatabase
    {
        private readonly SQLiteAsyncConnection database;

        public SampleDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<EventItem>().Wait();
        }

        public async Task<List<EventItem>> GetItemsAsync()
        {
            return await database.Table<EventItem>().ToListAsync();
        }

        public Task<EventItem> GetItemAsync(string id)
        {
            return database.Table<EventItem>().Where(i => i.Id==id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(EventItem item)
        {
            if (!string.IsNullOrEmpty(item.Id))
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(EventItem item)
        {
            return database.DeleteAsync(item);
        }
    }
}
