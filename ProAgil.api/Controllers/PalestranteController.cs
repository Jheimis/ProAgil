using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Repository;

namespace ProAgil.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalestranteController : ControllerBase
    {
        public IProAgilRepository _repo { get; }
        public PalestranteController(IProAgilRepository repo)
        {
            _repo = repo;

        }

        [HttpGet ("{palestranteId}")]
        public async Task<IActionResult> Get(int palestranteId){

            try
            {
                var results = await _repo.GetAllPalestrantesAsync(palestranteId, true);
                return Ok(results);
            }
            catch (System.Exception)
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou.");
            }
        }

        [HttpGet ("{name}")]
        public async Task<IActionResult> Get(string name){
            
            try
            {
                var results = await _repo.GetAllPalestrantesAsyncByName(name, true);
                return Ok(results);
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }
    }
}