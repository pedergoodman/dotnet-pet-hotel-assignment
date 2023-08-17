using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Pet> GetPets()
        {
            return _context.Pets

            .Include(pet => pet.OwnedBy);
        }
        


        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }


        [HttpPost]
        public IActionResult CreatePet(Pet pet)
        {
            _context.Add(pet);
            _context.SaveChanges();

            return CreatedAtAction(nameof(CreatePet), new { id = pet.Id }, pet);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePet(int id)
        {
            Pet pet = _context.Pets.Find(id);

            _context.Remove(pet);
            _context.SaveChanges(); // 204

            return Ok(); // 200
        }

    }
}
