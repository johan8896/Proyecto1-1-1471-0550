using Microsoft.AspNetCore.Mvc;
using Proyecto1_1_1471_0550.Models;
using Newtonsoft.Json;
using System.Text;

namespace Proyecto1_1_1471_0550.Controllers
{
    public class MascotasController : Controller
    {
        private readonly HttpClient _httpClient;

        public MascotasController()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7279/api/") // 👈 Cambia el puerto si tu API usa otro
            };
        }

        // ✅ GET: Mascotas
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("mascotas");
            if (!response.IsSuccessStatusCode)
                return View(new List<Mascota>());

            var json = await response.Content.ReadAsStringAsync();
            var mascotas = JsonConvert.DeserializeObject<List<Mascota>>(json);
            return View(mascotas);
        }

        // ✅ GET: Mascotas/Create
        public IActionResult Create() => View();

        // ✅ POST: Mascotas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Mascota mascota)
        {
            if (!ModelState.IsValid)
                return View(mascota);

            var json = JsonConvert.SerializeObject(mascota);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("mascotas", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "Error al crear la mascota.");
            return View(mascota);
        }

        // ✅ GET: Mascotas/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"mascotas/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var mascota = JsonConvert.DeserializeObject<Mascota>(json);

            return View(mascota);
        }

        // ✅ POST: Mascotas/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Mascota mascota)
        {
            if (!ModelState.IsValid)
                return View(mascota);

            var json = JsonConvert.SerializeObject(mascota);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"mascotas/{id}", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "Error al editar la mascota.");
            return View(mascota);
        }

        // ✅ GET: Mascotas/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"mascotas/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var mascota = JsonConvert.DeserializeObject<Mascota>(json);

            return View(mascota);
        }

        // ✅ GET: Mascotas/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"mascotas/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var mascota = JsonConvert.DeserializeObject<Mascota>(json);

            return View(mascota);
        }

        // ✅ POST: Mascotas/DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"mascotas/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "Error al eliminar la mascota.");
            return RedirectToAction(nameof(Index));
        }
    }
}
