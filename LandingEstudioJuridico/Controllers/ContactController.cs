using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using LandingEstudioJuridico.Services;
using System.ComponentModel.DataAnnotations; // Para validar el modelo


namespace LandingEstudioJuridico.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly EmailSettings _emailSettings;

        // Inyectamos el servicio Y la configuración para saber tu email
        public ContactController(IEmailService emailService, IOptions<EmailSettings> emailSettings)
        {
            _emailService = emailService;
            _emailSettings = emailSettings.Value;
        }

        [HttpGet] // Para mostrar el formulario
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost] // Para recibir los datos
        public async Task<IActionResult> Enviar(ContactViewModel model)
        {
            // 1. Si los datos están mal, volvemos al Home
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Por favor completá todos los campos.";
                return RedirectToAction("Index", "Home"); // <--- Volver al Home
            }

            try
            {
                // 2. Enviamos el mail (Lógica que ya tenés)
                await _emailService.SendEmailAsync(
                   _emailSettings.ReceiverEmail,
                   $"Contacto: {model.Nombre}",
                   model.Mensaje,
                   model.Email
               );

                // 3. ÉXITO: Guardamos mensaje y volvemos al Home
                TempData["MensajeExito"] = "¡Gracias! Tu mensaje fue enviado.";

                // ESTA ES LA CLAVE: Redirigir a la acción "Index" del controller "Home"
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Hubo un error al enviar el mensaje, intente nuevamente";
                return RedirectToAction("Index", "Home");
            }
        }

        // El modelo de datos del formulario (ViewModel)
        public class ContactViewModel
        {
            [Required(ErrorMessage = "El nombre es obligatorio")]
            public string Nombre { get; set; }

            [Required(ErrorMessage = "El email es obligatorio")]
            [EmailAddress(ErrorMessage = "Formato de email incorrecto")]
            public string Email { get; set; }

            [Required(ErrorMessage = "El mensaje no puede estar vacío")]
            public string Mensaje { get; set; }
        }
    }
}

