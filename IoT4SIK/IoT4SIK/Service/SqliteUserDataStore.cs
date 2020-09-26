using IoT4SIK.Util;
using IoT4SIK.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoT4SIK.Service
{
    class SqliteUserDataStore : IDataStore<User>
    {
        public SqliteUserDataStore()
        {
            MobileUtil.GetSqliteConnection().CreateTableAsync<User>().Wait();
        }
        public async Task<bool> AddItemAsync(User item)
        {
            return await MobileUtil.GetSqliteConnection().InsertAsync(item) == 1;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            return await MobileUtil.GetSqliteConnection().DeleteAsync<User>(id) == 1;
        }

        public async Task<User> GetItemAsync(string id)
        {
            return await MobileUtil.GetSqliteConnection().Table<User>().FirstOrDefaultAsync(r => r._id == id);
        }

        public async Task<IEnumerable<User>> GetItemsAsync()
        {
            var list = await MobileUtil.GetSqliteConnection().Table<User>().OrderBy(r => r._id).ToListAsync();
            return list;
        }

        public async Task<bool> UpdateItemAsync(User item)
        {
            return await MobileUtil.GetSqliteConnection().UpdateAsync(item) == 1;
        }
    }
}
