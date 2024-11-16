using Microsoft.AspNetCore.Mvc;
using SampleApplication.Models.ModelMetadataTypes;
using System.ComponentModel.DataAnnotations;

namespace SampleApplication.Models
{
    [ModelMetadataType(type: typeof(ProductMetadata))]
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen Name kısmını giriniz!!")]
        [StringLength(100,ErrorMessage ="en fazla 100 karakter olmalı.")]
        public string Name { get; set; }
        public string Description { get; set; }

        [EmailAddress(ErrorMessage ="Lütfen email addresini doğru giriniz!!")]
        public string Email { get; set; }
    }
}
