using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Data.Models
{
    public class TaskList
    {
        public TaskList()
        {
            Tasks = new HashSet<Tasks>();
        }
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        [Range(4, 50, ErrorMessage = "Name must be between 4 and 50!")]
        public string Name { get; set; }
        [Required]
        [MaxLength(260)]
        [Range(0, 260, ErrorMessage = "Description cannot exceed 260 words!")]
        public string Description { get; set; }
       
        public int UserId { get; set; }
        public Users User { get; set; }
        
        public string OwnerName { get; set; }

        public virtual ICollection<Tasks>Tasks { get; set; }

    }
}
