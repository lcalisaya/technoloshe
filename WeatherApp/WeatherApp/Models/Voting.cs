using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApp.Models
{
    public class Voting
    {
        [Key, Column(Order = 0)]
        public int UserID { get; set; }
        [Key, Column(Order = 1)]
        public int WeatherCommentID { get; set; }

        public virtual User User { get; set; }
        public virtual WeatherComment WeatherComment { get; set; }

        public bool Vote { get; set; }
    }
}