using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.Exam.DalEfCodeFirst
{
    public class Details
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }        
        public int Age { get; set; }
        public string Address { get; set; }
        public Users User { get; set; }
    }
}
