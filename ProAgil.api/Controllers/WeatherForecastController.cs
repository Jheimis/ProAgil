using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.api.Data;
using ProAgil.api.Model;

namespace ProAgil.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //Usado para passar informação do banco
        public DataContext Context { get; }
        public WeatherForecastController(DataContext context)
        {
            this.Context = context;

        }
        //Lista tudo que esta no banco
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           try
           {    
               var results = await Context.Eventos.ToListAsync();
               return Ok(results);
           }
           catch (System.Exception)
           {
             return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou.");
           }
           
            
        }

        //Consulta com ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
           {    
               var results = await Context.Eventos.FirstOrDefaultAsync(x => x.eventoId == id);
               return Ok(results);
           }
           catch (System.Exception)
           {
             return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou.");
           }
            
        }
    }
}
