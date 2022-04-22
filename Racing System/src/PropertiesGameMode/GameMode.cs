using Racing_System.src.RaceUtils;
using SampSharp.GameMode;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;

namespace Racing_System.PropertiesGameMode
{
    public partial class GameMode : BaseMode
    {
        public List<Race> Races { get; set; } = new List<Race>();
        protected override void OnInitialized(EventArgs e)
        {
            

            Console.WriteLine("\n----------------------------------");
            Console.WriteLine(" Blank game mode by your name here");
            Console.WriteLine("----------------------------------\n");

            SetGameModeText("Blank game mode");
            DisableInteriorEnterExits();

            base.OnInitialized(e);
            // TODO: Put logic to initialize your game mode here
        }

        protected override void OnPlayerClickMap(BasePlayer player, PositionEventArgs e)
        {
            player.Position = e.Position;
        }

        protected override void OnPlayerSpawned(BasePlayer player, SpawnEventArgs e)
        {
            base.OnPlayerSpawned(player, e);
        }
    }
}