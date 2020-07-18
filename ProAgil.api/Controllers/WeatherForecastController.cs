using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.Repository;

namespace ProAgil.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //Usado para passar informação do banco
        public ProAgilContext _context { get; }
        public WeatherForecastController(ProAgilContext context)
        {
            this._context = context;

        }
        //Lista tudo que esta no banco
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           try
           {    
               var results = await _context.eventos.ToListAsync();
               return Ok(results);
           }
           catch (System.Exception)
           {
             return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou.");
           }
           
            
        }

        //Consulta com ID
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
           {    
               var results = await _context.eventos.FirstOrDefaultAsync(x => x.id == Id);
               return Ok(results);
           }
           catch (System.Exception)
           {
             return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou.");
           }
            
        }
    }
}
