using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PruebaTecnicaAFP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PruebaTecnicaAFP.Controllers
{
    public class VehiculosController : Controller
    {
        const string urlVehiculos = "https://localhost:44333/api/Vehiculos";
        const string urlTipoTramite = "https://localhost:44333/api/TipoTramites";
        HttpClient client = null;
        public async Task<IActionResult> Index()
        {
            List<Vehiculo> clientes = new List<Vehiculo>();
            using (var http = new HttpClient())
            {
                var response = await http.GetStringAsync(urlVehiculos);
                clientes = JsonConvert.DeserializeObject<List<Vehiculo>>(response);
            }
            return View(clientes);
        }

        public async Task<IActionResult> Create()
        {
            List<TipoTramite> tipoTramites = new List<TipoTramite>();
            using (var http = new HttpClient())
            {
                var response = await http.GetStringAsync(urlTipoTramite);
                tipoTramites = JsonConvert.DeserializeObject<List<TipoTramite>>(response);
            }
            ViewData["TipoTramites"] = tipoTramites;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                client = new HttpClient();
                var data = JsonConvert.SerializeObject(vehiculo);
                HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(urlVehiculos, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(vehiculo);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = urlVehiculos + "/" + id;
            client = new HttpClient();
            var response = await client.GetStringAsync(url);
            var vehiculo = JsonConvert.DeserializeObject<Vehiculo>(response);

            if (vehiculo == null)
            {
                return NotFound();
            }

            List<TipoTramite> tipoTramites = new List<TipoTramite>();
            using (var http = new HttpClient())
            {
                var responseV = await http.GetStringAsync(urlTipoTramite);
                tipoTramites = JsonConvert.DeserializeObject<List<TipoTramite>>(responseV);
            }
            ViewData["TipoTramites"] = tipoTramites;

            return View(vehiculo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    client = new HttpClient();
                    var url = urlVehiculos + "/" + (vehiculo.Id).ToString();
                    var data = JsonConvert.SerializeObject(vehiculo);
                    HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                    var response = await client.PutAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

            }
            return View(vehiculo);
        }

        public async Task<IActionResult> DeleteVehiculo(int id)
        {
            client = new HttpClient();
            var url = urlVehiculos + "/" + id;
            var response = await client.DeleteAsync(url);

            return Ok();
        }
    }
}
