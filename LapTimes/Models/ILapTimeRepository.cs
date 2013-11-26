using System.Linq;

namespace LapTimes.Models
{
  public interface ILapTimeRepository
  {
    // Leagues
    IOrderedQueryable<League> GetCurrentLeaderBoards();
    void AddLeague(League league);

    // ClassNames
    void GetClass(string name);
    void GetClass(int id);
    void AddClass(ClassName className);
    IOrderedQueryable<ClassName> GetClasses();
      
    // Races
    Race CurrentRace();
    Race GetRace(int id);
    void AddRace(Race race);
    void DeleteRace(int id);
    void DeleteRace(Race race);

    // Racers
    CurrentDriver GetWinner(int raceId);
    CurrentDriver GetWinner(Race race);
    Racer GetRacer(int id);
    IOrderedQueryable<Racer> GetRacers(string nameStartsWith); 
    void AddRacer(Racer racer);
    void Save();
  }
}