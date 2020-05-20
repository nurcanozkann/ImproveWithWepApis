using ImproveWithWebApi.Models;
using ImproveWithWepApis.Models;
using RestSharp;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ImproveWithWepApis.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ValuesByCountry()
        {
            var client = new RestClient("https://api.collectapi.com/corona/countriesData");
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "apikey 6acifm7q1TjSGhRlPMX4FE:0qo3cQgs0d5yJ6uhrr0PqQ");
            request.AddHeader("content-type", "application/xml");
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            char[] ayrac = { '{', '}' };
            char[] ayrac2 = { ':', '[', '{', '\\', '"' };
            var result = content.Split(ayrac);
            List<ValuesByCountryModel> collectDate = new List<ValuesByCountryModel>();
            foreach (var item in result)
            {
                if (item != "" && item != "," && item != "\"success\":true,\"result\":[" && item != "]")
                {
                    var totalInfos = item.Split(ayrac2);
                    var totalInfo = new ValuesByCountryModel()
                    {
                        Country = totalInfos[4].ToString(),
                        TotalCases = totalInfos[9].ToString(),
                        NewCases = totalInfos[14].ToString(),
                        TotalDeaths = totalInfos[19].ToString(),
                        NewDeaths = totalInfos[24].ToString(),
                        TotalRecovered = totalInfos[29].ToString(),
                        ActiveCases = totalInfos[34].ToString()
                    };
                    collectDate.Add(totalInfo);
                }
            }

            return View(collectDate);
        }

        public ActionResult TotalValues()
        {
            var client = new RestClient("https://api.collectapi.com/corona/totalData");
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "apikey 6acifm7q1TjSGhRlPMX4FE:0qo3cQgs0d5yJ6uhrr0PqQ");
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);
            char[] ayrac2 = { ':', '[', '{', '\\', '"' };
            var content = response.Content.Split(ayrac2);
            var model = new TotalValueModel()
            {
                TotalDeaths = content[12].Split(',')[0] + content[12].Split(',')[1],
                TotalCases = content[17].Split(',')[0] + content[12].Split(',')[1],
                TotalRecovered = content[22].Split(',')[0] + content[12].Split(',')[1]
            };

            return View(model);
        }

        public ActionResult NewsInTurkey()
        {
            var client = new RestClient("https://api.collectapi.com/corona/coronaNews");
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "apikey 6acifm7q1TjSGhRlPMX4FE:0qo3cQgs0d5yJ6uhrr0PqQ");
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            char[] ayrac = { '{', '}' };
            char[] ayrac2 = { ':', '[', '{', '\\', '"' };
            var result = content.Split(ayrac);
            List<NewsInTurkeyModel> collectDate = new List<NewsInTurkeyModel>();
            foreach (var item in result)
            {
                if (item != "" && item != "," && item != "\"success\":true,\"result\":[" && item != "]")
                {
                    var totalInfos = item.Split(ayrac2);
                    var model = new NewsInTurkeyModel()
                    {
                        Url = "https:" + totalInfos[5],
                        Description = totalInfos[10],
                        Image = "https:" + totalInfos[16],
                        Name = totalInfos[21],
                        Source = totalInfos[26],
                        Date = (totalInfos[31] + totalInfos[32] + totalInfos[33]).ToString()
                    };

                    collectDate.Add(model);
                }


            }

            return View(collectDate);
        }
    }
}