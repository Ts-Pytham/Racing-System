using SampSharp.GameMode.Definitions;
using System;
namespace Racing_System.RaceUtils;

public enum RaceCategory
{
    Normal = VehicleCategory.Station,
    Sports = VehicleCategory.Sport,
    Monsters = VehicleModelType.Monster,
    Lowriders = VehicleCategory.Lowrider,
    Motorcycles_Bikes = VehicleCategory.Bike,
    Personalized = 4,
}
