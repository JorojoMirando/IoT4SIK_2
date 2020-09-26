using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IoT4SIK.Model;
using IoT4SIK.Util;

namespace IoT4SIK.Service
{
    public class MockUserDataStore : IDataStore<User>
    {
        readonly List<User> items;

        public MockUserDataStore()
        {
            items = new List<User>()
            {
                new User { _id = Guid.NewGuid().ToString(), typeUser = (TypeUser)1, name="ABC" },
                new User { _id = Guid.NewGuid().ToString(), typeUser = (TypeUser)1, name="DEF" },
                new User { _id = Guid.NewGuid().ToString(), typeUser = (TypeUser)2, name="GHI" },
                new User { _id = Guid.NewGuid().ToString(), typeUser = (TypeUser)2, name="JKL" },
                new User { _id = Guid.NewGuid().ToString(), typeUser = (TypeUser)2, name="MNO" },
                new User { _id = Guid.NewGuid().ToString(), typeUser = (TypeUser)2, name="PQR" }
            };
        }

        public async Task<bool> AddItemAsync(User item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(User item)
        {
            var oldItem = items.FirstOrDefault((User arg) => arg._id == item._id);
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.FirstOrDefault((User arg) => arg._id == id);
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<User> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s._id == id));
        }

        public async Task<IEnumerable<User>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }
    }
}