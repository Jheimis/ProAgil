using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        public IProAgilRepository _repo { get; }
        public EventoController(IProAgilRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           try
           {    
               var results = await _repo.GetAllEventosAsync(true);
               return Ok(results);
           }
           catch (System.Exception)
           {
             return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou.");
           }  
        }

        [HttpGet("{eventoId}")]
        public async Task<IActionResult> Get(int eventoId)
        {
           try
           {    
               var results = await _repo.GetAllEventosAsyncById(eventoId , true);
               return Ok(results);
           }
           catch (System.Exception)
           {
             return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou.");
           }
        }

        [HttpGet("getByTema/{tema}")]
        public async Task<IActionResult> Get(string tema)
        {
           try
           {    
               var results = await _repo.GetAllEventosAsyncByTema(tema , true);
               return Ok(results);
           }
           catch (System.Exception)
           {
             return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou.");
           }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
           try
           {    
              _repo.Add(model);

              if(await _repo.SaveChangesAsync())
              {
                  return Created($"api/evento/{model.id}",model);
              }
           }
           catch (System.Exception)
           {
             return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou.");
           }
           return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Evento model)
        {
           try
           {    
               
               var evento = await _repo.GetAllEventosAsyncById(eventoId, false);
               if(evento == null) return NotFound();
              _repo.Update(model);

              if(await _repo.SaveChangesAsync())
              {
                  return Created($"api/evento/{model.id}",model);
              }
           }
           catch (System.Exception)
           {
             return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou.");
           }
           return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Evento model)
        {
           try
           {    
               
               var evento = await _repo.GetAllEventosAsyncById(eventoId, false);
               if(evento == null) return NotFound();
              _repo.Delete(model);

              if(await _repo.SaveChangesAsync())
              {
                  return Ok();
              }
           }
           catch (System.Exception)
           {
             return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou.");
           }
           return BadRequest();
        }
    }
}