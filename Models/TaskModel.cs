using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerZUwierzytelnieniem.Models
{
    [Table("Table")]
    public class TaskModel
    {
        [Key]
        public int TaskId { get; set; }
        [DisplayName("Nazwa")]
        [Required(ErrorMessage = "Pole nazwa jest wymagane.")]
        [MaxLength(50)]
        public string Name { get; set; }
        [DisplayName("Opis")]
        [MaxLength(1000)]
        public string Description { get; set; }
        public bool Done { get; set; }


    }
}
