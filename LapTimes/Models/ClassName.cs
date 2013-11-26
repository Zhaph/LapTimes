using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LapTimes.Models
{
  [Table("ClassNames")]
  public class ClassName
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClassId { get; set; }

    [Required]
    [Display(Name = "Class Name", Description = "The class you are representing")]
    public string Name { get; set; }

    public List<Racer> Drivers { get; set; } 
  }
}