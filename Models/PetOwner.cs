using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace pet_hotel
{
    public class PetOwner 
    {  
        //owners Id
        public int Id { get; set; }

        //owners name
        public string Name { get; set; }

        //owners email 
        public string Email { get; set; }

        //the number of pets they own 
        public int PetCount { get; set; }

    }
}
