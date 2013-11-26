using System.Linq;

namespace LapTimes.Models
{
  public interface ILapTimeRepository
  {
    IOrderedQueryable<League> GetCurrentLeaderBoards();
    Race CurrentRace();
    Race GetRace(int id);
    CurrentRacer GetWinner(int raceId);
    CurrentRacer GetWinner(Race race);
  }
}