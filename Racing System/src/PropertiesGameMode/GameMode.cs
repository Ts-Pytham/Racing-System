using SampSharp.GameMode;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using System;

namespace Racing_System.PropertiesGameMode
{
    public class GameMode : BaseMode
    {
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            Console.WriteLine("\n----------------------------------");
            Console.WriteLine(" Blank game mode by your name here");
            Console.WriteLine("----------------------------------\n");

            SetGameModeText("Blank game mode");

            // TODO: Put logic to initialize your game mode here
        }

        protected override void OnPlayerClickMap(BasePlayer player, PositionEventArgs e)
        {
            player.Position = e.Position;
        }
    }
}