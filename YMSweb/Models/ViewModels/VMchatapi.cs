using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Models.ViewModels
{
    public class WaApi
    {
        private string APIUrl = "https://api.chat-api.com/instance346156/api/chatapi";
        private string token = "lcqok4hwsg4dss6l";

        public WaApi(string aPIUrl, string token)
        {
            APIUrl = aPIUrl;
            this.token = token;
        }
    }
}
