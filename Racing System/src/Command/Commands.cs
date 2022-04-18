using Racing_System.PropertiesPlayer;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;
using SampSharp.GameMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampSharp.GameMode.Definitions;

namespace Racing_System.Command
{

    public partial class Commands
    {
        [Command("car", Shortcut ="car", UsageMessage = "/car [idcar] [colour1] [colour2]")]
        private static void GetCar(Player player,int idcar, int colour1, int colour2)
        {

            if (idcar < 0 || colour1 < 0 || colour2 < 0)
            {
                player.SendClientMessage("El id/color1/color2 no puede ser negativo!");
                return;
            }
            if(!(idcar >= 400 && idcar <= 611))
            {
                player.SendClientMessage("El id del vehículo no está en el rango [400-611]!");
                return;
            }
   
           BaseVehicle.Create((VehicleModelType)idcar, player.Position, 90, colour1, colour2);

        }

        [Command("vw", Shortcut = "vw", UsageMessage = "/vw [idVirtualWorld]")]
        private static void GetCar(Player player, int vw)
        {
            if (vw < 0 )
                player.SendClientMessage("El id no puede ser negativo!");
            player.VirtualWorld = vw;
            player.SendClientMessage($"Te has cambiado al Virtual World: {vw}");
        }
    }
}
