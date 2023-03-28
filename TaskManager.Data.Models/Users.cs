using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Data.Models
{
    public class Users
    {
        public Users()
        {
            this.TaskList = new HashSet<TaskList>();
        }
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        [MinLength(2)]
        [Range(2, 60, ErrorMessage ="Name must be between 2 and 60!")]
        public string? Name { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        [Range(3, 50, ErrorMessage = "Username must be between 3 and 50!")]
        public string? Username { get; set; }
        [Required]
        [MaxLength(70)]
        [MinLength(10)]

        [Range(10, 70, ErrorMessage = "Email must be between 10 and 70!")]
        public string? Email { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(6)]
        public string? Password { get; set; }

        public virtual ICollection<TaskList> TaskList { get; set; }
    }
}
