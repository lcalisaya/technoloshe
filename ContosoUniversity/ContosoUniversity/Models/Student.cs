using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        // La propiedad Enrollments es de navegación
        // Se define como 'virtual' para que pueda aprovechar ciertas funcionalidades del Entity Framework, como la carga diferida (lazy loading)
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}