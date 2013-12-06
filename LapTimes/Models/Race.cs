using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LapTimes.Models
{
  [Table("Races")]
  public class Race
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RaceId { get; set; }

    [Display(Name = "Completed")]
    public bool IsComplete { get; set; }

    [Display(Name = "Start Time")]
    public DateTime? StartTime { get; set; }

    [Display(Name = "End Time")]
    public DateTime? EndTime { get; set; }

    public List<CurrentDriver> Drivers { get; set; } 
  }
}