using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        [StringLength(60)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(60, MinimumLength = 1, ErrorMessage = "First name cannot be longer than 60 characters.")]
        // La propiedad seguirá llamandose "FirstMidName", sin embargo el nuevo nombre de la columna va a ser "FirstName"
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        // La propiedad Enrollments es de navegación
        // Se define como 'virtual' para que pueda aprovechar ciertas funcionalidades del Entity Framework, como la carga diferida (lazy loading)
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}