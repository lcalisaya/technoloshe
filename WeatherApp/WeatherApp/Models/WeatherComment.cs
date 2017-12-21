using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApp.Models
{
    public class WeatherComment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Comment { get; set; }

        public string DataSourceComment { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateComment { get; set; }

        public virtual ICollection<Voting> UserVotes { get; set; }
    }
}