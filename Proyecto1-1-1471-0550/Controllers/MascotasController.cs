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
                BaseAddress = new Uri("https://localhost:7279/api/")
            };
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("mascotas");
            if (!response.IsSuccessStatusCode)
                return View(new List<Mascota>());

            var json = await response.Content.ReadAsStringAsync();
            var mascotas = JsonConvert.DeserializeObject<List<Mascota>>(json);
            return View(mascotas);
        }

        public IActionResult Create() => View();

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

        public async Task<IActionResult> Edit(string cedula)
        {
            var response = await _httpClient.GetAsync($"mascotas/{cedula}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var mascota = JsonConvert.DeserializeObject<Mascota>(json);
            return View(mascota);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string cedula, Mascota mascota)
        {
            var json = JsonConvert.SerializeObject(mascota);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"mascotas/{cedula}", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "Error al editar la mascota.");
            return View(mascota);
        }

        public async Task<IActionResult> Details(string cedula)
        {
            var response = await _httpClient.GetAsync($"mascotas/{cedula}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var mascota = JsonConvert.DeserializeObject<Mascota>(json);
            return View(mascota);
        }

        public async Task<IActionResult> Delete(string cedula)
        {
            var response = await _httpClient.GetAsync($"mascotas/{cedula}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var mascota = JsonConvert.DeserializeObject<Mascota>(json);
            return View(mascota);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string cedula)
        {
            var response = await _httpClient.DeleteAsync($"mascotas/{cedula}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "Error al eliminar la mascota.");
            return RedirectToAction(nameof(Index));
        }
    }
}
