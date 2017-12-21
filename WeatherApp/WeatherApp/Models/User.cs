using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApp.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "La contraseña debe ser mayor o igual a 6 caracteres.")]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public virtual ICollection<Voting> UserVotes { get; set; }
    }
}