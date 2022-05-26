using RpgMvc.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace RpgMvc.Controllers
{
    public class UsuariosController : Controller
    {
        public string uriBase = "xyz/Usuarios";
        //xyz tem que ser substituido pelo endereço da sua API
        
    [HttpGet]

        public  ActionResult IndexLogin()
        {
            return View("CadastrarUsuario"); 
        }

    [HttpPost]
        public async Task<ActionResult> RegistrarAsync(UsuarioViewModel u)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string uriComplementar = "Registrar";

                var content = new StringContent(JsonConvert.SerializeObject(u));
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplementar, content);

                string Serialized = await response.Content.ReadAsStringAsync();

                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TempData["Mensagem"] =
                    string.Format("Usuário {0} Registrado com sucesso! Faça o login para acessar.", u.Username);
                    return View("AutenticarUsuario");
                }
                else
                {
                    throw new System.Exception(Serialized);
                }
               
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");

                 var content = new StringContent(JsonConvert.SerializeObject(u));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplementar, content);
                
                 string Serialized = await response.Content.ReadAsStringAsync();

                 if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    HttpContext.Session.SetString("SessionTokenUsuario", Serialized);
                    TempData["Mensagem"] = string.Format("Bem-Vindo {0}!!!", u.Username);
                    return RedirectToAction("Index", "Personagens");
                }
                else
                {
                    throw new System.Exception(Serialized);
                }
               


            }

        }

        [HttpPost]

        public async Task<ActionResult> AutenticarAsync(UsuarioViewModel u)
        {
            try{
                //Proximo Código
                 HttpClient httpClient = new HttpClient();
                string uriComplementar = "Autenticar";
            }

             catch (System.Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");
            }

        }
































    }
}