using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebApplication1.Modelo;
using WebApplication1.Repositorios;
using Formatting = Newtonsoft.Json.Formatting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
   

   [Route("api/[controller]")]
   [ApiController]
    public class ClienteController : Controller
    {

        private readonly ClienteRepo cliRepo;

        public ClienteController(IConfiguration configuration) {

            cliRepo = new ClienteRepo(configuration);
        
        }

        // GET: api/Cliente
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            IEnumerable<Cliente> clientes = cliRepo.FindAll().ToList();
            return clientes;


        }

        // GET api/Cliente/5
        [HttpGet("{id}")]
        public void Get(int id)
        {
           // using (System.Data.IDbConnection db = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].DevConection)) ;
        }

        // POST api/Cliente
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Cliente/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Cliente/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
