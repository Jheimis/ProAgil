using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProAgil.api.Model;

namespace ProAgil.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return new Evento[]{
                new Evento(){
                    eventoId = 1 ,
                    tema = "Angular e .NET Core",
                    local = "Belo Horizonte",
                    qtdPessoas = 250,
                    dataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")

                },
                 new Evento(){
                    eventoId = 2 ,
                    tema = "Angular e suas novidades",
                    local = "São Paulo",
                    qtdPessoas = 550,
                    dataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")

                }
            };
        }
    }
}
