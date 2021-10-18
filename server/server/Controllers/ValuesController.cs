using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        //this action returns the list of city names from the API in accordance to the user input
        [HttpGet("GetCity/{cityname}")]
        public async Task<List<string>> GetCity(string cityname)
        {
            //the call to the API, and And conversion to cities list
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey=vOffTLvSjCG2KJGNUV2P5yhdaUqAHbHA&q=" + cityname);
            response.EnsureSuccessStatusCode();
            string res = await response.Content.ReadAsStringAsync();
            List<City> cities = System.Text.Json.JsonSerializer.Deserialize<List<City>>(res);

            //create list of cities names
            List<string> listOfNames = new List<string>();
            for (int i = 0; i < cities.Count; i++)
            {
                listOfNames.Add(cities[i].LocalizedName);
            }

            return listOfNames;
        }
    }
}
