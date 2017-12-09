using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        
        // El signo '?' puede ser null, lo que significa que una calificación (Grade) se puede dejar sin asignar
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }

        // Propiedades de navegación
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
