using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crud_webapp.Data
{
    public class PictureData
    {
        [Key]
        public int Id { get; set; }

        // [Required]
        public byte[] Image { get; set; }

        public PictureData() { }

        public PictureData(int id, byte[] image)
        {
            this.Id = id;
            this.Image = image;
        }
    }
}
