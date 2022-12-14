using APIEmpresaCelulares.Context;
using APIEmpresaCelulares.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace APIEmpresaCelulares.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Clientes
        [HttpGet]
        //assincrono
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: /Clientes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // GET: /Clientes/genero
        [HttpGet("genero/{genero}")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientePorGenero(string genero)
        {
            var cliente = await _context.Clientes.Where(c => c.Genero == genero).ToListAsync();

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // GET: /Clientes/regiao
        [HttpGet("regiao/{regiao}")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientePorRegiao(string regiao)
        {
            var cliente = await _context.Clientes.Where(c => c.Regiao == regiao).ToListAsync();

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }
        
        //GET: /Clientes/{regiao}/{genero}
        [HttpGet("{regiao}/{genero}")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientePorRegiaoGenero(string regiao, string genero)
        {
            var cliente = await _context.Clientes.Where(c => c.Regiao == regiao && c.Genero == genero).ToListAsync();

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // POST: /Clientes
        [HttpPost("/Cadastrar")]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
         

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.ClienteId }, cliente);
        }

        // PUT: /Clientes/{id}     
        [HttpPut("{id}")]
        public async Task<IActionResult> PatchCliente(int id, Cliente cliente)
        
        {
            if (id != cliente.ClienteId)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //delete cliente
        [HttpDelete]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }         
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return Ok();
        }
       
        


    }
}
