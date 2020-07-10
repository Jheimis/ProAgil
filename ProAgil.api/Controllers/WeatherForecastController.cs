using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<IEnumerable<Evento>> Get()
        {
           return Context.Eventos.ToList();
            
        }

        //Consulta com ID
        [HttpGet("{id}")]
        public ActionResult<Evento> Get(int id)
        {
           return Context.Eventos.FirstOrDefault(x => x.eventoId == id);
            
        }
    }
}
