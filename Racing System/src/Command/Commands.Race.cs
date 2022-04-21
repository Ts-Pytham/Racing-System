using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Racing_System.Dialogs;
using Racing_System.PropertiesGameMode;
using Racing_System.PropertiesPlayer;
using Racing_System.src.RaceUtils;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP.Commands;

namespace Racing_System.Command
{
    public partial class Commands
    {
        [Command("createrace", Shortcut ="crace")]
        private static void CreateRace(GameMode gm,Player player)
        {
            var dialog = new InputDialog("Crear Carrera", "Ingrese el nombre de la carrera", false, "Aceptar", "Cancelar");
            dialog.Show(player);
            
        }
        [Command("showraces", Shortcut = "sraces")]
        private static void ShowRaces(GameMode gm, Player player)
        {
            var listDialogEx = new ListDialogEx<Race>("Carreras", "Aceptar", "Cancelar");
            listDialogEx.AddItems(gm.Races);
            listDialogEx.Show(player);

        }
    }
}
