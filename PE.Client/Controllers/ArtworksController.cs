using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Azure;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;

namespace PE.Client.Controllers
{
    public class ArtworksController : Controller
    {
        private readonly HttpClient client;

        public ArtworksController(IHttpClientFactory client)
        {
            this.client = client.CreateClient("PE.Api");
        }

        // GET: Artworks
        public async Task<IActionResult> Index()
        {
            HttpRequestMessage request  = new(method: HttpMethod.Get, requestUri: "odata/artworks");
            HttpResponseMessage response = await client.SendAsync(request);
            string strData = await response.Content.ReadAsStringAsync();
            dynamic temp = JObject.Parse(strData);

            List<Artworks> model = ((JArray)temp.value).Select(x => new Artworks
            {
                Artwork_Id = (int)x["Artwork_Id"],
                NameAtWork = (string)x["NameAtWork"],
                Description = (string)x["Description"],
                Price = (decimal)x["Price"]
            }).ToList();
            return View(model);
        }

        // GET: Artworks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: $"odata/artworks/{id}");
            HttpResponseMessage response = await client.SendAsync(request);
            string strData = await response.Content.ReadAsStringAsync();
            Artworks artworks = JsonConvert.DeserializeObject<Artworks>(strData);
            foreach(var item in await GetMuseums())
            {
                if(artworks.Museum_Id == item.Museum_Id)
                {
                    ViewData["Museum_Name"] = item.Museum_Name;
                }
            }
            if (artworks == null)
            {
                return NotFound();
            }

            return View(artworks);
        }

        // GET: Artworks/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Museum_Id"] = new SelectList(await GetMuseums(), "Museum_Id", "Museum_Name");
            return View();
        }
        public async Task<List<MuseumsDTO>> GetMuseums()
        {
            HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: "odata/museums");
            HttpResponseMessage response = client.Send(request);
            string strData = await response.Content.ReadAsStringAsync();
            dynamic temp = JObject.Parse(strData);

            List<MuseumsDTO> model = ((JArray)temp.value).Select(x => new MuseumsDTO
            {
                Museum_Id = (int)x["Museum_Id"],
                Museum_Name = (string)x["Museum_Name"],
            }).ToList();
            return model;
        }

        // POST: Artworks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Artwork_Id,NameAtWork,Description,Price,Museum_Id")] Artworks artworks)
        {
            if (ModelState.IsValid)
            {
                HttpRequestMessage request = new(method: HttpMethod.Post, requestUri: $"odata/artworks/");
                request.Content = new StringContent(JsonConvert.SerializeObject(artworks), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["Museum_Id"] = new SelectList(await GetMuseums(), "Museum_Id", "Museum_Name", artworks.Museum_Id);
            return View(artworks);
        }

        // GET: Artworks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: $"odata/artworks/{id}");
            HttpResponseMessage response = await client.SendAsync(request);
            string strData = await response.Content.ReadAsStringAsync();
            Artworks artworks = JsonConvert.DeserializeObject<Artworks>(strData);
            if (artworks == null)
            {
                return NotFound();
            }
            ViewData["Museum_Id"] = new SelectList(await GetMuseums(), "Museum_Id", "Museum_Name", artworks.Museum_Id);
            return View(artworks);
        }

        // POST: Artworks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Artwork_Id,NameAtWork,Description,Price,Museum_Id")] Artworks artworks)
        {
            if (id != artworks.Artwork_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    HttpRequestMessage request = new(method: HttpMethod.Put, requestUri: $"odata/artworks/{id}");
                    request.Content = new StringContent(JsonConvert.SerializeObject(artworks), Encoding.UTF8, "application/json");
                    HttpResponseMessage responsePost = await client.SendAsync(request);
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Museum_Id"] = new SelectList(await GetMuseums(), "Museum_Id", "Museum_Name", artworks.Museum_Id);
            return View(artworks);
        }

        // GET: Artworks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: $"odata/artworks/{id}");
            HttpResponseMessage response = await client.SendAsync(request);
            string strData = await response.Content.ReadAsStringAsync();
            Artworks artworks = JsonConvert.DeserializeObject<Artworks>(strData);
            if (artworks == null)
            {
                return NotFound();
            }

            return View(artworks);
        }

        // POST: Artworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            if (id != null)
            {
                HttpRequestMessage request = new(method: HttpMethod.Delete, requestUri: $"odata/artworks/{id}");
                HttpResponseMessage response = await client.SendAsync(request);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
