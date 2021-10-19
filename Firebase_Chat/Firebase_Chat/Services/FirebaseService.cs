using Firebase.Database;
using Firebase.Database.Query;
using Firebase_Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firebase_Chat.Services
{
    public class FirebaseService
    {
        public static FirebaseClient firebase = new FirebaseClient("https://dbteste-cbb09-default-rtdb.firebaseio.com/");
        public async static Task<bool> AddMessage(OutboundMessage message, string groupKey)
        {
            try
            {
                message.Key = await GetKey(groupKey);
                await UpdateUserAsync(message.Key, groupKey, message);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public async static Task<string> GetKey(string value)
        {
            //Esse método cria um documento vazio e retorna uma chave
            var doc = await firebase
               .Child("Chat")
               .Child(value)
                  .PostAsync(new OutboundMessage());
            return doc.Key;
        }
        public async static Task<string> GetNewChatGroupKey()
        {
            //Esse método cria um documento vazio e retorna uma chave
            var doc = await firebase
               .Child("Chat")
                  .PostAsync(new OutboundMessage());
            return doc.Key;
        }
        public async static Task<bool> UpdateUserAsync(string key, string groupKey, OutboundMessage message)
        {
            try
            {
                await firebase
                    .Child("Chat")
                    .Child(groupKey)
                    .Child(key)
                    .PutAsync(message);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async static Task<List<OutboundMessage>> GetMessages(string groupKey)
        {
            try
            {
                return (await firebase
                .Child("Chat")
                .Child(groupKey)
                .OnceAsync<OutboundMessage>()).Select(item => new OutboundMessage
                {
                    Author = item.Object.Author,
                    Content = item.Object.Content
                }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
