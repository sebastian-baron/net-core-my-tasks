using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasksNetCore.Core.Models
{
    public class FilterTasks
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }

        [Display(Name = "Only realized")]
        public bool IsExecuted { get; set; }
    }
}
