using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Data.Models
{
    using Enums;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Tasks
    {
        public Tasks()
        {
            CreatedDate = DateTime.Now;
            Status = Status.inProgress;
        }
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        //[Range(5, 50, ErrorMessage = "Name must be between 5 and 50!")]
        public string? Name { get; set; }
        [Required]
        [MaxLength(200)]
        [MinLength(10)]

        [Range(10, 265, ErrorMessage = "Name must be between 10 and 265!")]
        public string? Description { get; set; }
        [DisplayName("Due Date")]
        public DateTime DueDate { get; set; }
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Priority Level")]
        public PrioirtyLevel PrioirtyLevel { get; set; }
        public Status Status { get; set; }
        public int TaskListId { get; set; }
        public TaskList TaskList{ get; set; }


    }
}
