using Microsoft.AspNetCore.Mvc;
using Proyecto1_1_1471_0550.Models;
using Newtonsoft.Json;
using System.Text;

namespace Proyecto1_1_1471_0550.Controllers
{
    public class ProcedimientosController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProcedimientosController()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7279/api/")
            };
        }

        // ✅ GET: Procedimientos
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("procedimientos");
            if (!response.IsSuccessStatusCode)
                return View(new List<Procedimiento>());

            var json = await response.Content.ReadAsStringAsync();
            var procedimientos = JsonConvert.DeserializeObject<List<Procedimiento>>(json);
            return View(procedimientos);
        }

        // ✅ GET: Procedimientos/Create
        public IActionResult Create() => View();

        // ✅ POST: Procedimientos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Procedimiento procedimiento)
        {
            if (!ModelState.IsValid)
                return View(procedimiento);

            var json = JsonConvert.SerializeObject(procedimiento);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("procedimientos", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "❌ Error al registrar el procedimiento.");
            return View(procedimiento);
        }

        // ✅ GET: Procedimientos/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"procedimientos/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var procedimiento = JsonConvert.DeserializeObject<Procedimiento>(json);
            return View(procedimiento);
        }

        // ✅ POST: Procedimientos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Procedimiento procedimiento)
        {
            if (!ModelState.IsValid)
                return View(procedimiento);

            var json = JsonConvert.SerializeObject(procedimiento);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"procedimientos/{id}", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "❌ Error al editar el procedimiento.");
            return View(procedimiento);
        }

        // ✅ GET: Procedimientos/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"procedimientos/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var procedimiento = JsonConvert.DeserializeObject<Procedimiento>(json);
            return View(procedimiento);
        }

        // ✅ GET: Procedimientos/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"procedimientos/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var procedimiento = JsonConvert.DeserializeObject<Procedimiento>(json);
            return View(procedimiento);
        }

        // ✅ POST: Procedimientos/DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"procedimientos/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "❌ Error al eliminar el procedimiento.");
            return RedirectToAction(nameof(Index));
        }
    }
}
