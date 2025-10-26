using Microsoft.AspNetCore.Mvc;
using Proyecto1_1_1471_0550.Models;
using Newtonsoft.Json;
using System.Text;

namespace Proyecto1_1_1471_0550.Controllers
{
    public class ClientesController : Controller
    {
        private readonly HttpClient _httpClient;

        public ClientesController()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7279/api/") // 👈 usa tu puerto del API
            };
        }

        // ✅ GET: Clientes
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("clientes");
            if (!response.IsSuccessStatusCode)
                return View(new List<Cliente>());

            var json = await response.Content.ReadAsStringAsync();
            var clientes = JsonConvert.DeserializeObject<List<Cliente>>(json);
            return View(clientes);
        }

        // ✅ GET: Clientes/Create
        public IActionResult Create() => View();

        // ✅ POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (!ModelState.IsValid)
                return View(cliente);

            var json = JsonConvert.SerializeObject(cliente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("clientes", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "❌ Error al registrar el cliente.");
            return View(cliente);
        }

        // ✅ GET: Clientes/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"clientes/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var cliente = JsonConvert.DeserializeObject<Cliente>(json);
            return View(cliente);
        }

        // ✅ POST: Clientes/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cliente cliente)
        {
            if (!ModelState.IsValid)
                return View(cliente);

            var json = JsonConvert.SerializeObject(cliente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"clientes/{id}", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "❌ Error al editar el cliente.");
            return View(cliente);
        }

        // ✅ GET: Clientes/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"clientes/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var cliente = JsonConvert.DeserializeObject<Cliente>(json);
            return View(cliente);
        }

        // ✅ GET: Clientes/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"clientes/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var cliente = JsonConvert.DeserializeObject<Cliente>(json);
            return View(cliente);
        }

        // ✅ POST: Clientes/DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"clientes/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "❌ Error al eliminar el cliente.");
            return RedirectToAction(nameof(Index));
        }
    }
}
