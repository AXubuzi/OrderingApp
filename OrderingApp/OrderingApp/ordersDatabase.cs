using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderingApp
{
    public class ordersDatabase
    {
        static SQLiteAsyncConnection Database;
        public static readonly AsyncLazy<ordersDatabase> Instance = new AsyncLazy<ordersDatabase>(async () =>
        {  
            var instance = new ordersDatabase();
            CreateTableResult result = await Database.CreateTableAsync<SwagItems>();
            return instance;
        });
        public ordersDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }
        public Task<List<SwagItems>> GetItemsAsync()
        {
            return Database.Table<SwagItems>().ToListAsync();
        }
        public Task<List<SwagItems>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<SwagItems>("SELECT * FROM [SwagItems]");
        }
        public Task<SwagItems> GetItemAsync(int id)
        {
            return Database.Table<SwagItems>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveItemAsync(SwagItems item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }
        public Task<int> DeleteItemAsync(SwagItems item)
        {
            return Database.DeleteAsync(item);
        }
 
    }
}
