namespace Racing_System.PropertiesPlayer;


public partial class Player : BasePlayer
{
    public PlayerDataRace Data { get; set; } = new();


    public bool Equals(Player player, string msg)
    {
        if (this == player)
        {
            SendClientMessage(Color.Red, "Error: " + msg);
            return true;
        }
        
        return false;
    }

    public static Player Find(Player player, int playerid)
    {
        Player player1 = (Player)Find(playerid);
        if (player1 == null || !player1.IsConnected)
        {
            player.SendClientMessage(Color.Red, "Error: El jugador no se encuentra conectado.");
            throw new Exception();
        }
        return player1;
    }



}