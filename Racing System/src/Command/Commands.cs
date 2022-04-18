using Racing_System.PropertiesPlayer;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;
using SampSharp.GameMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing_System.Command
{

    public partial class Commands
    {
        [Command("car", Shortcut ="car", UsageMessage = "/car [idcar] [colour1] [colour2]")]
        private static void GetCar(Player player, int idcar, int colour1, int colour2)
        {
            if (idcar < 0 || colour1 < 0 || colour2 < 0)
                player.SendClientMessage("El id no puede ser negativo!");
            
            BaseVehicle vehicle = new ();
            vehicle.ChangeColor(colour1, colour2);
            vehicle.Position = player.Position;
            
        }
    }
}
