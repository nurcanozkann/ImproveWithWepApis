using ImproveWithWepApis.Models;
using RestSharp;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ImproveWithWepApis.Controllers
{
    public class PharmacyController : Controller
    {
        //GET: Pharmacy
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost()]
        public JsonResult Index(string city)
        {
            if (city != null)
            {
                var client = new RestClient("https://api.collectapi.com/health/dutyPharmacy?il=" + city);
                var request = new RestRequest(Method.GET);
                request.AddHeader("authorization", "apikey 6acifm7q1TjSGhRlPMX4FE:0qo3cQgs0d5yJ6uhrr0PqQ");
                request.AddHeader("content-type", "application/json");
                IRestResponse response = client.Execute(request);
                var content = response.Content;
                char[] ayrac = { '{', '}' };
                char[] ayrac2 = { ':', '[', '{', '\\', '"' };
                var result = content.Split(ayrac);
                List<OpenPharmacyModel> collectData = new List<OpenPharmacyModel>();
                foreach (var item in result)
                {
                    if (item != "" && item != "," && item != "\"success\":true,\"result\":[" && item != "]")
                    {
                        var totalInfos = item.Split(ayrac2);
                        var model = new OpenPharmacyModel()
                        {
                            Name = totalInfos[4],
                            Dist = totalInfos[9],
                            Address = totalInfos[14] + totalInfos[15],
                            Phone = totalInfos[20]
                        };
                        collectData.Add(model);
                    }
                }
                return Json(collectData, JsonRequestBehavior.AllowGet);
                //return PartialView("_OpenPharmacy",collectData);
            }
            return Json(city);
        }
    }
}