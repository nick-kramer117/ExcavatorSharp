using RestSharp;
using System.Net;
using System;

namespace Test4.Models
{
    public class ParsModel
    {
        private RestClient Client;
        private RestRequest Request;
        private IRestResponse Result;

        public string Info { get; set; }

        public ParsModel(string u)
        {
            try
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

                Client = new RestClient();
                Request = new RestRequest(u);
                Result = Client.Execute(Request);

                Info = Result.Content;

                if (Result.StatusCode != HttpStatusCode.OK)
                {
                    throw new ArgumentException("Невозможно скачать страницу. Что-то пошло не так.");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}