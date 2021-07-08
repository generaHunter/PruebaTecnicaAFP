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
    public class ClientesController : Controller
    {
        const string urlClientes = "https://localhost:44333/api/Clientes";
        HttpClient client = null;
        public async Task<IActionResult> Index()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (var http = new HttpClient())
            {
                var response = await http.GetStringAsync(urlClientes);
                clientes = JsonConvert.DeserializeObject<List<Cliente>>(response);
            }
            return View(clientes);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                client = new HttpClient();
                var data = JsonConvert.SerializeObject(cliente);
                HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(urlClientes, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(cliente);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = urlClientes + "/" + id;
            client = new HttpClient();
            var response = await client.GetStringAsync(url);
            var cliente = JsonConvert.DeserializeObject<Cliente>(response);

            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    client = new HttpClient();
                    var url = urlClientes + "/" + (cliente.Id).ToString();
                    var data = JsonConvert.SerializeObject(cliente);
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
            return View(cliente);
        }

        public async Task<IActionResult> DeleteCliente(int id)
        {
            client = new HttpClient();
            var url = urlClientes + "/" + id;
            var response = await client.DeleteAsync(url);

            return Ok();
        }

    }
}
