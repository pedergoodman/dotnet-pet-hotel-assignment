using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.AspNetCore.SignalR;

namespace pet_hotel
{
    public enum PetBreedType
    {
        Shepherd,
        Poodle,
        Bulldog,
        Terrier,
        Boxer,
        Labrador,
        Retriever,
    }
    public enum PetColorType
    {
        Black,
        White,
        Golden,
        Tricolor,
        Spotted,
    }
    public class Pet
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Color { get; set; }
        public string Breed {get; set;}
        public bool CheckIn { get; set; }
        [ForeignKey("OwnedBy")]
        public int OwnerId { get; set; }
        public PetOwner OwnedBy { get; set; }

    }
}
