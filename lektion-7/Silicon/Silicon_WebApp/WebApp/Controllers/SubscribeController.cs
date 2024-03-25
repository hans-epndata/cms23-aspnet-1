using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SubscribeController(HttpClient http) : Controller
    {
        private readonly HttpClient _http = http;

        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeForm form)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(form), Encoding.UTF8, "application/json");
                var response = await _http.PostAsync("https://localhost:7238/api/Subscribers", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["Status"] = "You are new subscribed";
                    return RedirectToAction("Home", "Default", "subscribe");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    TempData["Status"] = "You are already subscribed";
                    return RedirectToAction("Home", "Default", "subscribe");
                }
            }

            TempData["Status"] = "Something went wrong";
            return RedirectToAction("Home", "Default", "subscribe");
        }
    }
}


/*  
 
    fetch("https://localhost:7194/api/Susbscribe", {
        method: 'post',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(data)
    }) 
    .then(res => {
        if (res.status === 201) {
            console.log('subscribed')
        }
    })
 
 
*/