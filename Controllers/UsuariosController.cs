using Microsoft.AspNetCore.Mvc;

namespace RpgMvc.Controllers
{
    public class UsuariosController : Controller
    {
        public string uriBase = "xyz/Usuarios";
        //xyz tem que ser substituido pelo endereço da sua API
        
    [HttpGet]

    public  ActionResult Index()
    {
        return View("CadastrarUsuario"); 
    }

    }
}