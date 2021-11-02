using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Rocky.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Display Order")]
        [Range(1,int.MaxValue,ErrorMessage = "Display Order for Category must be grater than 0")]
        public int DisplayOrder { get; set; }
    }
}
