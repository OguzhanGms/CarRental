using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.Concrete
{
    public class CarImage : IEntity
    {
        public int CarImageId { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }

        [NotMapped]
        public IFormFile FromFile { get; set; }
    }
}
