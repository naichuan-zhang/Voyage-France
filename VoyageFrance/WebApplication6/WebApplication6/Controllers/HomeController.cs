using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
           
            return View();
        }

        public ActionResult Contact()
        {
           
            return View();
        }

        public ActionResult GetWeather()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetWeather(string city)
        {
            Weather.WeatherWebService ws = new Weather.WeatherWebService();
            var strlist = ws.getWeatherbyCityName(city);
            if (strlist[8] == "")
            {
                ViewBag.Msg = "The city you inquire for is not supported currently!";
            }
            else
            {
                ViewBag.ImgUrl = @"/Content/weather/a_" + strlist[8];
                ViewBag.CityName = strlist[1];
                ViewBag.Temp = strlist[5];
                ViewBag.General = strlist[6];
                ViewBag.Wind = strlist[7];
                ViewBag.Actual = strlist[10];
                ViewBag.Life = strlist[11];
                ViewBag.CityDetails = strlist[22];
            }
            return View();
        }
    }
}