using Microsoft.AspNetCore.Mvc;
using Proyecto1_1_1471_0550.Models;
using Newtonsoft.Json;
using System.Text;

namespace Proyecto1_1_1471_0550.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly HttpClient _httpClient;

        public EmpleadosController()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7279/api/") // 🔗 URL del Proyecto2_API
            };
        }

        // ✅ GET: Empleados (Index)
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("empleados");

            if (!response.IsSuccessStatusCode)
            {
                // Si el API no responde, devolvemos lista vacía
                return View(new List<Empleado>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var empleados = JsonConvert.DeserializeObject<List<Empleado>>(json);

            return View(empleados);
        }

        // ✅ GET: Empleados/Create
        public IActionResult Create()
        {
            return View();
        }

        // ✅ POST: Empleados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empleado empleado)
        {
            if (!ModelState.IsValid)
                return View(empleado);

            var json = JsonConvert.SerializeObject(empleado);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("empleados", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "Error al registrar el empleado.");
            return View(empleado);
        }

        // ✅ GET: Empleados/Edit/{cedula}
        public async Task<IActionResult> Edit(string cedula)
        {
            var response = await _httpClient.GetAsync($"empleados/{cedula}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var empleado = JsonConvert.DeserializeObject<Empleado>(json);

            return View(empleado);
        }

        // ✅ POST: Empleados/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string cedula, Empleado empleado)
        {
            if (!ModelState.IsValid)
                return View(empleado);

            var json = JsonConvert.SerializeObject(empleado);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"empleados/{cedula}", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "Error al editar el empleado.");
            return View(empleado);
        }

        // ✅ GET: Empleados/Details/{cedula}
        public async Task<IActionResult> Details(string cedula)
        {
            var response = await _httpClient.GetAsync($"empleados/{cedula}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var empleado = JsonConvert.DeserializeObject<Empleado>(json);

            return View(empleado);
        }

        // ✅ GET: Empleados/Delete/{cedula}
        public async Task<IActionResult> Delete(string cedula)
        {
            var response = await _httpClient.GetAsync($"empleados/{cedula}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var empleado = JsonConvert.DeserializeObject<Empleado>(json);

            return View(empleado);
        }

        // ✅ POST: Empleados/DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string cedula)
        {
            var response = await _httpClient.DeleteAsync($"empleados/{cedula}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "Error al eliminar el empleado.");
            return RedirectToAction(nameof(Index));
        }
    }
}

