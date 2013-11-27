using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LapTimes.Models
{
  [Table("Racers")]
  public class Racer
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RacerId { get; set; }

    [Required]
    public string Name { get; set; }

    [Display(Name = "Raw Best Time (ms)")]
    public int RawBestTime { get; set; }

    public int ClassId { get; set; }
    [ForeignKey("ClassId")]
    [Display(Name = "Class Name", Description = "The class you are representing")]
    public ClassName ClassName { get; set; }

    public int LeagueId { get; set; }
    [ForeignKey("LeagueId")]
    public League League { get; set; }
  }

  [Table("Drivers")]
  public class CurrentDriver: Racer
  {
    public int RaceId { get; set; }
    [ForeignKey("RaceId")]
    public Race Race { get; set; }

    public int Lane { get; set; }

    public int CarId { get; set; }
    [ForeignKey("CarId")]
    [Display(Name = "Chosen car for the race")]
    public Car Car { get; set; }

    [Display(Name = "Raw Race Time (ms)")]
    public int RawRaceTime { get; set; }
  }
}