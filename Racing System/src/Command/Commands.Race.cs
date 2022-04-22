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
        private static void CreateRace(GameMode gm, Player player)
        {
            string name = "",carrera = "Crear Carrera";
            int min = -1, max = -1, amount = -1;
            var dialog = new InputDialog(carrera, "Ingrese el nombre de la carrera", false, "Aceptar", "Cancelar");
            dialog.Show(player);
            dialog.Response += (sender, e) =>
            {
                name = e.InputText;
                // improve for the future
                while (true) //Min value
                {   
                    var minInput = new InputDialog(carrera, "Ingrese la cantidad mínima de participantes", false, "Aceptar", "Cancelar");
                    minInput.Show(player);
                    minInput.Response += (sender, e) =>
                    {
                        if (e.InputText.Length == 0 || string.IsNullOrWhiteSpace(e.InputText))
                            player.SendClientMessage("Ingresa una cantidad válida");
                        else if(!int.TryParse(e.InputText, out min))
                        {
                            player.SendClientMessage("El valor no es numérico!");
                        }
                        
                    };
                    if (min < 0) 
                    { 
                        player.SendClientMessage("El valor debe ser positivo!");
                        continue;
                    }
                    if (min != -1) break;
                }

                while (true) //Max value
                {
 
                    var maxInput = new InputDialog(carrera, "Ingrese la cantidad máxima de participantes", false, "Aceptar", "Cancelar");
                    maxInput.Show(player);
                    maxInput.Response += (sender, e) =>
                    {
                        if (e.InputText.Length == 0 || string.IsNullOrWhiteSpace(e.InputText))
                            player.SendClientMessage("Ingresa una cantidad válida");
                        else if (!int.TryParse(e.InputText, out max))
                        {
                            player.SendClientMessage("El valor no es numérico!");
                        }

                    };
                    if (max < 0)
                    {
                        player.SendClientMessage("El valor debe ser positivo!");
                        continue;
                    }
                    if (min > max) 
                    { 
                        player.SendClientMessage("El valor mínimo es mayor que el máximo");
                        continue;
                    }    
                    if (max != -1) break;
                }

                while (true) //Amount
                {
   
                    var amountInput = new InputDialog(carrera, "Ingrese la cantidad de dinero a ganar", false, "Aceptar", "Cancelar");
                    amountInput.Show(player);
                    amountInput.Response += (sender, e) =>
                    {
                        if (e.InputText.Length == 0 || string.IsNullOrWhiteSpace(e.InputText))
                            player.SendClientMessage("Ingresa una cantidad válida");
                        else if (!int.TryParse(e.InputText, out amount))
                        {
                            player.SendClientMessage("El valor no es numérico!");
                        }

                    };
                    if (amount < 0)
                    {
                        player.SendClientMessage("El valor debe ser positivo!");
                        continue;
                    }
                    if (amount != -1) break;
                }

                player.SendClientMessage("Ingrese el siguiente comando para obtener las coordenadas " +
                    "de los CheckPoint [createracecp].");
                player.Data.IsCreatingRace = true;
                player.Data.RaceTemp = new Race
                {
                    MaxCapacity = max,
                    MinCapacity = min,
                    Money = amount,
                    Name = name,
                    ID = player.Id,
                    VirtualWorld = 50 + gm.Races.Count
                };

            };
            
        }

        [Command("createracecp", Shortcut = "cracecp")]
        private static void CreateRaceCP(Player player)
        {
            if (!player.Data.IsCreatingRace)
            {
                player.SendClientMessage("No estás creando ninguna carrera!");
                return;
            }
            else if(player.Data.IsCreatingRace && !player.Data.IsCPCreated)
            {
                player.Data.RaceTemp.RaceCPs.Add(player.Position);
                player.SendClientMessage($"Se ha ingresado la coordenada correctamente: {player.Position}");
            }
        }

        //Possible deprecated method 
        [Command("createracecpe", Shortcut = "cracecpe")]
        private static void CreateRaceCPEnd(Player player)
        {
            if (!player.Data.IsCreatingRace)
            {
                player.SendClientMessage("No estás creando ninguna carrera!");
                return;
            }

            player.Data.IsCPCreated = true;

            
        }
        [Command("showraces", Shortcut = "sraces")]
        private static void ShowRaces(GameMode gm, Player player)
        {
            var listDialogEx = new ListDialogEx<Race>("Carreras", "Aceptar", "Cancelar");
            listDialogEx.AddItems(gm.Races);
            listDialogEx.Show(player);
            listDialogEx.Response += (sender, e) =>
            {
                var IDItem = listDialogEx.IDs[e.ListItem];
                if(e.DialogButton == DialogButton.Left)
                {
                    gm.Races[IDItem].LoadingRace(player);    
                }
            };
        }
    }
}
