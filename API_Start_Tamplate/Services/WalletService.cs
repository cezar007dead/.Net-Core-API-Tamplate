using API_Start_Template.Modals;
using API_Start_Template.Modals.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace API_Start_Template.Services
{
    public class WalletService
    {
        const string fileName = "StaticData/Wallets.json";

        public (bool, Wallet) Get(string name)
        {
            string jsonString = File.ReadAllText(fileName);

            List<Wallet> rootObject = new List<Wallet>();
            rootObject = JsonSerializer.Deserialize<List<Wallet>>(jsonString);

            foreach (Wallet item in rootObject)
            {
                if (item.Name == name)
                {
                    item.LastTimeAccess = DateTime.Now;
                    jsonString = JsonSerializer.Serialize(rootObject);
                    File.WriteAllText(fileName, jsonString);
                    return (true, item);
                }
            }

            return (false, null);
        }

        public List<Wallet> GetAll()
        {
            string jsonString = File.ReadAllText(fileName);

            List<Wallet> rootObject = new List<Wallet>();
            rootObject = JsonSerializer.Deserialize<List<Wallet>>(jsonString);

            foreach (Wallet item in rootObject)
            {
                    item.LastTimeAccess = DateTime.Now;
            }

            jsonString = JsonSerializer.Serialize(rootObject);
            File.WriteAllText(fileName, jsonString);

            return rootObject;
        }

        public (bool, Exception) Create(WalletRequest requestBody)
        {
            try
            {

                string jsonString = File.ReadAllText(fileName);

                List<Wallet> rootObject = new List<Wallet>();
                rootObject = JsonSerializer.Deserialize<List<Wallet>>(jsonString);
                rootObject.Add(requestBody);
                jsonString = JsonSerializer.Serialize(rootObject);
                File.WriteAllText(fileName, jsonString);
                return (true,null);
            }
            catch (Exception e)
            {
                return (false, e);
            }
        }

        public bool Delete(string name)
        {
            string jsonString = File.ReadAllText(fileName);

            List<Wallet> rootObject = new List<Wallet>();
            rootObject = JsonSerializer.Deserialize<List<Wallet>>(jsonString);

            foreach (Wallet item in rootObject)
            {
                if (item.Name == name)
                {
                    rootObject.Remove(item);
                    jsonString = JsonSerializer.Serialize(rootObject);
                    File.WriteAllText(fileName, jsonString);
                    return true;
                }
            }

            return false;
        }
    }
}
