using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Technoloshe20173CSeriesMVC.Models
{
    public class Serie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Summary { get; set; }
        public DateTime CreationDate { get; set; }
        public int Episodes { get; set; }
        public Genre Genre { get; set; }
    }
}