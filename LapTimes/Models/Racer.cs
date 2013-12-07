using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

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

    [Display(Name = "Has Paid for a Race?")]
    public bool IsWaitingForRace { get; set; }

    [Display(Name = "Class Name", Description = "The class you are representing")]
    public int ClassId { get; set; }
    [ForeignKey("ClassId")]
    [Display(Name = "Class Name", Description = "The class you are representing")]
    public ClassName ClassName { get; set; }

    [Display(Name = "League")]
    public int LeagueId { get; set; }
    [ForeignKey("LeagueId")]
    [Display(Name = "League")]
    public League League { get; set; }
  }

  [Table("RaceDrivers")]
  public class CurrentDriver
  {
    public int Lane { get; set; }

    [Display(Name = "Racer")]
    [Key, Column(Order = 0)]
    public int RacerId { get; set; }
    [ForeignKey("RacerId")]
    public Racer Racer { get; set; }

    [Display(Name = "Race")]
    [Key, Column(Order = 1)]
    public int RaceId { get; set; }
    [ForeignKey("RaceId")]
    [JsonIgnore]
    public Race Race { get; set; }

    [Display(Name = "Chosen car for the race")]
    public int CarId { get; set; }
    [ForeignKey("CarId")]
    [Display(Name = "Chosen car for the race")]
    public Car Car { get; set; }

    [Display(Name = "Raw Race Time (ms)")]
    public int RawRaceTime { get; set; }

    public bool Winner { get; set; }

    [NotMapped]
    public bool NewPersonalBest { get; set; }
  }
}