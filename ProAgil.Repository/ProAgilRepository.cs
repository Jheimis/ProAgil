using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        private readonly ProAgilContext _context;
        public ProAgilRepository(ProAgilContext context)
        {
            _context = context;
        }
        //GERAIS
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
           _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
           _context.Remove(entity);
        }

         public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //EVENTOS
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false )
        {
            IQueryable<Evento> query = _context.eventos.Include(c => c.lotes).Include(c => c.redesSociais);

            if (includePalestrantes)
            {
                query = query.Include(pe => pe.palestrantesEventos).ThenInclude(p => p.palestrante);
            }

            query =query.OrderByDescending(c => c.dataEvento);

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetAllEventosAsyncById(int eventoId, bool includePalestrantes)
        {
           IQueryable<Evento> query = _context.eventos.Include(c => c.lotes).Include(c => c.redesSociais);

            if (includePalestrantes)
            {
                query = query.Include(pe => pe.palestrantesEventos).ThenInclude(p => p.palestrante);
            }

            query =query.OrderByDescending(c => c.dataEvento).Where(c => c.id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosAsyncByTema(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.eventos.Include(c => c.lotes).Include(c => c.redesSociais);

            if (includePalestrantes)
            {
                query = query.Include(pe => pe.palestrantesEventos).ThenInclude(p => p.palestrante);
            }

            query =query.OrderByDescending(c => c.dataEvento).Where(c => c.tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        //PALESTRANTES
        public async Task<Palestrante> GetAllPalestrantesAsync(int palestranteId, bool includeEventos = false)
        {
           IQueryable<Palestrante> query = _context.palestrantes.Include(c => c.redesSociais);

            if (includeEventos)
            {
                query = query.Include(pe => pe.palestrantesEventos).ThenInclude(e => e.evento);
            }

            query =query.OrderBy(p => p.nome).Where(c => c.id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsyncByName(string name, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.palestrantes.Include(c => c.redesSociais);

            if (includeEventos)
            {
                query = query.Include(pe => pe.palestrantesEventos).ThenInclude(e => e.evento);
            }

            query =query.Where(p => p.nome.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}