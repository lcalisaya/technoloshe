using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class OfficeAssignment
    {
        // El atributo ForeignKey se aplica a la clase dependiente para establecer la relación
        // cuando hay una relación 'de uno a cero o uno' o 'de uno a uno' entre dos entidades
        [Key,ForeignKey("Instructor")]
        public int InstructorID { get; set; }

        [StringLength(50),Display(Name = "Office Location")]
        public string Location { get; set; }

        public virtual Instructor Instructor { get; set; }
    }
}