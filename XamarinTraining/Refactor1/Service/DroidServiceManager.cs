﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Refactor1.Service.Request;
using Refactor1.Model;
using Newtonsoft.Json;

namespace Refactor1.Service
{
    public class DroidServiceManager : BaseServiceManager, IServiceManager
    {
        protected override string BaseUrl => "https://ft-ductuu138.oraclecloud2.dreamfactory.com/";

        public async Task<User> Authenticate(string email, string password)
        {
            var url = BaseUrl + "api/v2/user/session";
            var request = new AuthenticationRequest() { Email = email, Password = password };
            var response = await InvokeService(HttpMethod.Post, url, request);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(responseBody);
                return user;
            }
            else
            {
                return null;
            }
        }

        #region Android platform code
        protected override bool HasNetworkConnection()
        {
            // TODO: Check network connection
            return true;
        }

        protected override void HideLoadingProgress()
        {
            // TODO: Hide Progress Dialog
            Console.WriteLine("Done");
        }

        protected override void ShowLoadingProgress()
        {
            // TODO: Show Progress Dialog
            Console.Write("Loading...");
        }
        #endregion
    }
}
