﻿using GenericCollectionsExtension.SortedList;
using Racing_System.PropertiesPlayer;
using Racing_System.RaceUtils;
using Racing_System.src.RaceUtils;
using SampSharp.GameMode;
using SampSharp.GameMode.World;
namespace Racing_System.RaceUtils;

public class Race
{
    public int MaxCapacity { get; set; }
    public int MinCapacity { get; set; }
    public List<Vector3> RaceCPs { get; set; } = new();
    public SortedList<PlayerPositionRace> Players { get; set; } = new();
    public List<BaseVehicle> Vehicles { get; set; } = new();
    public string Name { get; set; }
    public int Money { get; set; }
    public bool Initiated { get; set; }
    public int VirtualWorld { get; set; }
    public int ID { get; set; }
    public RaceState State { get; set; } = RaceState.WaitingPlayers;
    public RaceCategory Category { get; set; } = RaceCategory.Normal;

    public static string GetRaces(List<Race> races)
    {
        if (races == null || races.Count == 0) return "";

        return races.Select(x => x.ToString()).Aggregate((x, y) => x + "\n" + y);
    }

    public void LoadingRace(Player player)
    {
        if(MaxCapacity <= Players.Count)
        {
            Players.Add(new PlayerPositionRace { Player = player, TotalTime = 0 });
            foreach(var veh in Vehicles)
            {
                if (veh.Driver == null)
                {
                    player.PutInVehicle(veh);
                    
                }
            }
        }
        else
        {
            player.SendClientMessage("Ya está llena la carrera!");
        }
    }
    public static IEnumerable<string> GetRacesIEnumerable(List<Race> races)
    {
        if (races == null || races.Count == 0) return new List<string>();
        return races.Select(x => x.ToString());
    }
    public override string ToString()
    {
        return $"{Name}: {Players.Count} / {MaxCapacity}, amount: {Money}";
    }
}
