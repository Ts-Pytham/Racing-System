﻿namespace Racing_System.Command;


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

       BaseVehicle.Create((VehicleModelType)idcar, player.Position, player.Angle, colour1, colour2);

    }
    [Command("getpos", Shortcut = "gpos")]
    private static void GetPos(Player p, int e = 1, string path = "pos.txt")
    {
        if (e != 1)
        {

            var pos = p.Position.ToString().Where(x => x != '(' && x != ')').ToArray();
            byte[] info = new UTF8Encoding(true).GetBytes(new string(pos) + "\n");
            using FileStream fs = !File.Exists(path) ? File.Create(path) : File.OpenWrite(path);

            fs.Seek(0, SeekOrigin.End);
            fs.Write(info, 0, info.Length);
        }
        p.SendClientMessage($"Tu posición actual es: {p.Position}.");
    }

    [Command("tp", UsageMessage = "/tp [x] [y] [z]")]
    private static void TP(Player player, float x, float y, float z)
    {
        player.Position = new Vector3(x, y, z);
        player.SendClientMessage($"Acabas de ir a la posición indicada, {player.Position}.");
        player.SendClientMessage($"Esta fueron ingresadas por el usuario {x},{y},{z} y este es" +
            $"el vector resultante: {new Vector3(x, y, z)}");
    }

    [Command("vw", Shortcut = "vw", UsageMessage = "/vw [idVirtualWorld]")]
    private static void GetVirtualWorld(Player player, int vw)
    {
        if (vw < 0 )
            player.SendClientMessage("El id no puede ser negativo!");
        player.VirtualWorld = vw;
        player.SendClientMessage($"Te has cambiado al Virtual World: {vw}");
        
    }

    [Command("setcp")]
    private static void SetCheckPoint(Player player)
    {
        if (!File.Exists("pos.txt")) return;

        player.Data.CoordsCP = Vector3Extensions.GetCoordinatesFromFile("pos.txt");
        player.Data.IndexCP = 0;
        player.SetRaceCheckpoint(CheckpointType.Normal, player.Data.CoordsCP[player.Data.IndexCP++], player.Data.CoordsCP[player.Data.IndexCP], 10f);
    }
}
