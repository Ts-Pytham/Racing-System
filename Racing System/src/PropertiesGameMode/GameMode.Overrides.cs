using Racing_System.PropertiesPlayer;
using SampSharp.GameMode;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing_System.PropertiesGameMode
{
    public partial class GameMode
    {
        protected override void OnPlayerDisconnected(BasePlayer player, DisconnectEventArgs e)
        {
            base.OnPlayerDisconnected(player, e);
        }
    }
}
