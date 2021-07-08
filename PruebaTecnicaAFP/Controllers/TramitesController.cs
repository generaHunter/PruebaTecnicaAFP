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
    public class TramitesController : Controller
    {
        const string urlVehiculos = "https://localhost:44333/api/Vehiculos";
        const string urlTipoTramite = "https://localhost:44333/api/TipoTramites";
        const string urlClientes = "https://localhost:44333/api/Clientes";
        const string urlFacturas = "https://localhost:44333/api/Facturas";
        HttpClient client = null;
        public async Task<IActionResult> Index()
        {
            List<Factura> facturas = new List<Factura>();
            using (var http = new HttpClient())
            {
                var response = await http.GetStringAsync(urlFacturas);
                facturas = JsonConvert.DeserializeObject<List<Factura>>(response);
            }
            return View(facturas);
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

            List<Vehiculo> vehiculos = new List<Vehiculo>();
            using (var http = new HttpClient())
            {
                var responseV = await http.GetStringAsync(urlVehiculos);
                vehiculos = JsonConvert.DeserializeObject<List<Vehiculo>>(responseV);
            }
            ViewData["Vehiculos"] = vehiculos;

            List<Cliente> clientes = new List<Cliente>();
            using (var http = new HttpClient())
            {
                var responseC = await http.GetStringAsync(urlClientes);
                clientes = JsonConvert.DeserializeObject<List<Cliente>>(responseC);
            }
            ViewData["Clientes"] = clientes;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Factura factura)
        {
            if (ModelState.IsValid)
            {
                client = new HttpClient();
                var data = JsonConvert.SerializeObject(factura);
                HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(urlFacturas, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(factura);
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

        public async Task<IActionResult> GetVehiculoByTramite(int id)
        {
            client = new HttpClient();
            var url = urlVehiculos + "/GetVehiculoByTramite/" + id;
   
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            using (var http = new HttpClient())
            {
                var responseV = await http.GetStringAsync(url);
                vehiculos = JsonConvert.DeserializeObject<List<Vehiculo>>(responseV);
            }

            return Ok(vehiculos);
        }

        public async Task<IActionResult> GetVehiculoById(int id)
        {
            client = new HttpClient();
            var url = urlVehiculos + "/" + id;

            Vehiculo vehiculos = new Vehiculo();
            using (var http = new HttpClient())
            {
                var responseV = await http.GetStringAsync(url);
                vehiculos = JsonConvert.DeserializeObject<Vehiculo>(responseV);
            }

            return Ok(vehiculos);
        }
    }
}
