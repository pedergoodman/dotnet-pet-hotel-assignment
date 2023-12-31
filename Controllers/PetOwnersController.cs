using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<PetOwner> GetPetOwners(){
            return _context.PetOwners;
        }

        [HttpPost]
        public IActionResult CreatePetOwner(PetOwner petOwner) {
            _context.Add(petOwner);
            _context.SaveChanges();

            return CreatedAtAction(nameof(CreatePetOwner), new {id = petOwner.Id}, petOwner);
        }


         [HttpDelete("{id}")]
        public IActionResult DeletePetOwner(int id)
        {
            PetOwner petOwner = _context.PetOwners.Find(id);

            _context.Remove(petOwner);
            _context.SaveChanges(); // 204

            return Ok(); // 200 with updated pet 
        }


    }
}
