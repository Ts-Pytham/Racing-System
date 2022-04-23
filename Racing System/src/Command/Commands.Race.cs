using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Racing_System.Dialogs;
using Racing_System.PropertiesGameMode;
using Racing_System.PropertiesPlayer;
using Racing_System.RaceUtils;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.SAMP.Commands;

namespace Racing_System.Command
{
    public partial class Commands
    {
        [Command("createrace", Shortcut = "crace")]
        private static void CreateRace(Player player)
        {
            string name = "", carrera = "Crear Carrera";

            var dialog = new InputDialog(carrera, "Ingrese el nombre de la carrera", false, "Aceptar", "Cancelar");
            dialog.Show(player);
            dialog.Response += (sender, e) =>
            {
                if (e.DialogButton == DialogButton.Left)
                {
                    name = e.InputText;

                    GetDialogs(player, carrera, name);
                    /* TO DO
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
                        VirtualWorld = 50 + GameMode.Races.Count
                    };
                    */
                }

                // var ListVehiclesD = new ListDialogEx<RaceCategory>(carrera, "Aceptar", "Rechazar");

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
            if(GameMode.Races.Count is 0)
            {
                player.SendClientMessage("Actualmente no hay ninguna carrera!");
                return;
            }
            listDialogEx.AddItems(GameMode.Races);
            listDialogEx.Show(player);
            listDialogEx.Response += (sender, e) =>
            {
                var IDItem = listDialogEx.IDs[e.ListItem];
                if(e.DialogButton == DialogButton.Left)
                {
                    GameMode.Races[IDItem].LoadingRace(player);    
                }
            };
        }


        #region Methods

        public static void GetDialogs(Player player, string race, string name)
        {
            GetInputMinValue(player, race, name);
        }
        public static void GetInputMinValue(Player player, string race, string name)
        {
            var minInput = new InputDialog(race, "Ingrese la cantidad mínima de participantes", false, "Aceptar", "Cancelar");
            minInput.Show(player);
            minInput.Response += (sender, e) =>
            {
                if (e.DialogButton != DialogButton.Left)
                {
                    if (e.InputText.Length == 0 || string.IsNullOrWhiteSpace(e.InputText))
                    {
                        player.SendClientMessage("Ingresa una cantidad válida");
                        minInput.Show(player);
                    }
                    if (!int.TryParse(e.InputText, out int min))
                    {
                        player.SendClientMessage("El valor no es numérico!");
                        minInput.Show(player);
                    }
                    else if (min <= 0)
                    {
                        player.SendClientMessage("El valor debe ser positivo y mayor a 0!");
                        minInput.Show(player);
                    }
                    else
                    {
                        GetInputMaxValue(player, race, name, min);
                    }
                }
            };
        }

        private static void GetInputMaxValue(Player player, string race, string name, int min)
        {
                var maxInput = new InputDialog(race, "Ingrese la cantidad mínima de participantes", false, "Aceptar", "Cancelar");
                maxInput.Show(player);
                maxInput.Response += (sender, e) =>
                {
                    if (e.DialogButton == DialogButton.Left)
                    {
                        if (e.InputText.Length == 0 || string.IsNullOrWhiteSpace(e.InputText))
                        {
                            player.SendClientMessage("Ingresa una cantidad válida");
                            maxInput.Show(player);
                        }
                        if (!int.TryParse(e.InputText, out int max))
                        {
                            player.SendClientMessage("El valor no es numérico!");
                            maxInput.Show(player);
                        }
                        else if (min < 0)
                        {
                            player.SendClientMessage("El valor debe ser positivo!");
                            maxInput.Show(player);
                        }
                        else if (min > max)
                        {
                            player.SendClientMessage("El valor mínimo es mayor que el máximo");
                            maxInput.Show(player);
                        }
                        else
                        {
                            GetInputAmountValue(player, race, name, min, max);
                        }
                    }
                };
            }

        private static void GetInputAmountValue(Player player, string race, string name, int min, int max)
        {
            var amountInput = new InputDialog(race, "Ingrese la cantidad de dinero a ganar", false, "Aceptar", "Cancelar");
            amountInput.Show(player);
            amountInput.Response += (sender, e) =>
            {
                if (e.DialogButton == DialogButton.Left)
                {
                    if (e.InputText.Length == 0 || string.IsNullOrWhiteSpace(e.InputText))
                    {
                        player.SendClientMessage("Ingresa una cantidad válida");
                        amountInput.Show(player);
                    }
                    if (!int.TryParse(e.InputText, out int amount))
                    {
                        player.SendClientMessage("El valor no es numérico!");
                        amountInput.Show(player);
                    }
                    else if (amount < 0)
                    {
                        player.SendClientMessage("El valor debe ser positivo!");
                        amountInput.Show(player);
                    }
                    else
                    {
                        GetRaceCategoryDialog(player, race, name, min, max, amount);
                    }
                }

            };
        }

        private static void GetRaceCategoryDialog(Player player, string race, string name, int min, int max, int amount)
        {
            var ListVehiclesD = new ListDialogEx<RaceCategory>(race, "Aceptar", "Rechazar");
            ListVehiclesD.AddItems(Enum.GetValues(typeof(RaceCategory)).Cast<RaceCategory>());
            ListVehiclesD.Show(player);
            ListVehiclesD.Response += (sender, e) =>
            {
                //TODO
            };
        }
        #endregion
    }
}
