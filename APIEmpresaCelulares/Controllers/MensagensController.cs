﻿using APIEmpresaCelulares.Context;
using APIEmpresaCelulares.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIEmpresaCelulares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensagensController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MensagensController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Mensagens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mensagem>>> GetMensagens()
        {
            return await _context.Mensagens.ToListAsync();
        }

        // GET: api/Mensagens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mensagem>> GetMensagem(int id)
        {
            var mensagem = await _context.Mensagens.FindAsync(id);

            if (mensagem == null)
            {
                return NotFound();
            }

            return mensagem;
        }

        // PUT: api/Mensagens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMensagem(int id, Mensagem mensagem)
        {
            if (id != mensagem.MensagemId)
            {
                return BadRequest();
            }

            _context.Entry(mensagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MensagemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Mensagens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mensagem>> PostMensagem(Mensagem mensagem)
        {
            _context.Mensagens.Add(mensagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMensagem", new { id = mensagem.MensagemId }, mensagem);
        }

        // DELETE: api/Mensagens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMensagem(int id)
        {
            var mensagem = await _context.Mensagens.FindAsync(id);
            if (mensagem == null)
            {
                return NotFound();
            }

            _context.Mensagens.Remove(mensagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MensagemExists(int id)
        {
            return _context.Mensagens.Any(e => e.MensagemId == id);
        }

        
    }
}
