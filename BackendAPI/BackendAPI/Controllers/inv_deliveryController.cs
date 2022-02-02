﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendAPI.Models;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class inv_deliveryController : ControllerBase
    {
        private readonly LobContext _context;

        public inv_deliveryController(LobContext context)
        {
            _context = context;
        }

        // GET: api/inv_delivery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<inv_delivery>>> Getinv_Deliveries()
        {
            return await _context.inv_Deliveries.ToListAsync();
        }

        // GET: api/inv_delivery/5
        [HttpGet("{id}")]
        public async Task<ActionResult<inv_delivery>> Getinv_delivery(int id)
        {
            var inv_delivery = await _context.inv_Deliveries.FindAsync(id);

            if (inv_delivery == null)
            {
                return NotFound();
            }

            return inv_delivery;
        }

        // PUT: api/inv_delivery/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putinv_delivery(int id, inv_delivery inv_delivery)
        {
            if (id != inv_delivery.Id)
            {
                return BadRequest();
            }

            _context.Entry(inv_delivery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!inv_deliveryExists(id))
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

        // POST: api/inv_delivery
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        [HttpPost]
        public async Task<ActionResult<int>> Postinv_delivery(inv_delivery inv_delivery)
        {
            _context.inv_Deliveries.Add(inv_delivery);
            await _context.SaveChangesAsync();

            return _context.inv_Deliveries.Find(inv_delivery.Id).Id;
        }

        // DELETE: api/inv_delivery/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteinv_delivery(int id)
        {
            var inv_delivery = await _context.inv_Deliveries.FindAsync(id);
            if (inv_delivery == null)
            {
                return NotFound();
            }

            _context.inv_Deliveries.Remove(inv_delivery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool inv_deliveryExists(int id)
        {
            return _context.inv_Deliveries.Any(e => e.Id == id);
        }
    }
}
