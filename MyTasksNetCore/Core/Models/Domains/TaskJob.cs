using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MyTasksNetCore.Core.Models.Domains
{
    public class TaskJob
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Field Title is required")]
        public string Title { get; set; }

        [MaxLength(250)]
        [Required(ErrorMessage = "Field Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Field Category is required")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Field Term is required")]
        public DateTime? Term { get; set; }

        [Display(Name = "Realized")]
        public bool IsExecuted { get; set; }

        public string UserId { get; set; }

        public Category Category { get; set; }

        public ApplicationUser User { get; set; }

    }
}
