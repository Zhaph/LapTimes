using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LapTimes.Models
{
  [Table("Leagues")]
  public class League
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LeagueId { get; set; }

    [Required]
    [Display(Name = "League Name")]
    public string Name { get; set; }

    [Display(Name = "League Description")]
    public string Description { get; set; }

    public List<Racer> Racers { get; set; } 
  }
}