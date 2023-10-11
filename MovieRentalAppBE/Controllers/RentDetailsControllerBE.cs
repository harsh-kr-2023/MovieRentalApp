using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRentalAppBE.Data;
using MovieRentalAppBE.DTOs;
using MovieRentalAppBE.Models;

namespace MovieRentalAppBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentDetailsControllerBE : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RentDetailsControllerBE(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RentDetailsControllerBE
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentDetail>>> GetRentDetails()
        {
          if (_context.RentDetails == null)
          {
              return NotFound();
          }
            return await _context.RentDetails.ToListAsync();
        }

        // GET: api/RentDetailsControllerBE/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentDetail>> GetRentDetail(Guid id)
        {
          if (_context.RentDetails == null)
          {
              return NotFound();
          }
            var rentDetail = await _context.RentDetails.FindAsync(id);

            if (rentDetail == null)
            {
                return NotFound();
            }

            return rentDetail;
        }

        // PUT: api/RentDetailsControllerBE/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRental(Guid id, RentDetailPutDTO rentalUpdateDTO)
        {
            if (id != rentalUpdateDTO.OrderId)
            {
                return BadRequest();
            }

            // Find the existing rental in the database
            var existingRental = await _context.RentDetails.FindAsync(id);

            if (existingRental == null)
            {
                return NotFound();
            }

            // Update only the fields you want to change
            existingRental.CustomerId = rentalUpdateDTO.CustomerId;
            existingRental.MovieId = rentalUpdateDTO.MovieId;
            existingRental.OrderDate = rentalUpdateDTO.OrderDate;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentDetailExists(id))
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


        // POST: api/RentDetailsControllerBE
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RentDetail>> PostRental(RentDetailDTO rentalDTO)
        {
            if (rentalDTO == null)
            {
                return BadRequest("Invalid movie data.");
            }

            // Map the RentalDTO to your entity model (RentDetail)
            var rental = new RentDetail
            {
                CustomerId = rentalDTO.CustomerId,
                MovieId = rentalDTO.MovieId,
                OrderDate = rentalDTO.OrderDate
            };

            // Add the rental to the database
            _context.RentDetails.Add(rental);
            await _context.SaveChangesAsync();

            // Map the saved rental back to a DTO
            //var savedRentalDTO = new RentDetailDTO
            //{
            //    CustomerId = rental.CustomerId,
            //    MovieId = rental.MovieId,
            //    OrderDate = rental.OrderDate
            //};

            // Return a CreatedAtAction result
            return CreatedAtAction("GetRental", new { id = rental.OrderId }, rental);
        }


        // DELETE: api/RentDetailsControllerBE/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentDetail(Guid id)
        {
            if (_context.RentDetails == null)
            {
                return NotFound();
            }
            var rentDetail = await _context.RentDetails.FindAsync(id);
            if (rentDetail == null)
            {
                return NotFound();
            }

            _context.RentDetails.Remove(rentDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RentDetailExists(Guid id)
        {
            return (_context.RentDetails?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
