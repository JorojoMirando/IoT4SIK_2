using IoT4SIK.Util;
using IoT4SIK.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IoT4SIK.Service
{
    class ApiUserDataStore : IDataStore<User>
    {
        private const string API_BASE_URL = "https://mongooficialv3.azurewebsites.net/";
        private const string API_PESSOAS = "api/pessoas";
        public ApiUserDataStore()
        {
            MobileUtil.SetApiUrl(API_BASE_URL);
        }

        public async Task<bool> AddItemAsync(User item)
        {
            var retorno = await MobileUtil.CallApi(HttpMethod.Post, API_PESSOAS, item);
            return retorno.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var retorno = await MobileUtil.CallApi(HttpMethod.Delete, $"{API_PESSOAS}/{id}");
            return retorno.IsSuccessStatusCode;
        }

        public async Task<User> GetItemAsync(string id)
        {
            User retorno = null;
            var resposta = await MobileUtil.CallApi(HttpMethod.Get, $"{API_PESSOAS}/{id}");
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<User>(content);
            }
            return retorno;
        }

        public async Task<IEnumerable<User>> GetItemsAsync()
        {
            List<User> lista = new List<User>();
            var resposta = await MobileUtil.CallApi(HttpMethod.Get, API_PESSOAS);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<List<User>>(content);
                lista.AddRange(retorno);
            }
            return lista;
        }

        public async Task<bool> UpdateItemAsync(User item)
        {
            var retorno = await MobileUtil.CallApi(HttpMethod.Put, $"{API_PESSOAS}/{item._id}", item);
            return retorno.IsSuccessStatusCode;
        }
    }
}
