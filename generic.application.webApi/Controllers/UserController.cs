using System;
using System.Net;
using generic.application.domain.contracts;
using generic.application.domain.entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace generic.application.webApi.Controllers
{
    [Route("api/usuario")]
    public class UserController : Controller
    {
        private IBaseRepository<User> _userRepository;

        public UserController(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }


        /// <summary>
        /// GET com todos os usuarios cadastrados.
        /// </summary>
        /// <remarks>
        /// Exemplo de GET:
        ///
        ///         POST http://localhost:5000/api/usuario
        ///    
        ///         {
        ///             success: true,
        ///             users: []
        ///         }
        /// 
        /// </remarks>
        /// <returns>json com propriedade success com  valor true/false e propriedade users com uma lista dos usuarios cadastrados.</returns>
        /// <response code="200">json com propriedade success com  valor true e propriedade users com uma lista dos usuarios cadastrados.</response>
        /// <response code="400">json informando success com false e erro inesperado da aplicação.</response>

        [HttpGet]
        public IActionResult listarTodos()
        {
            try
            {
                return Json(JsonConvert.SerializeObject(new { success = true, users = _userRepository.ListAll()}));
            }
            catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new {success = false, responseText = ex.Message});
            }
        }
    }
}