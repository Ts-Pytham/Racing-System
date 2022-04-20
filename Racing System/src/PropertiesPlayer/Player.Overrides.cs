using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing_System.PropertiesPlayer
{
    public partial class Player : BasePlayer
    {



        #region Overrides
        public override void OnEnterRaceCheckpoint(EventArgs e)
        {
            DisableRaceCheckpoint();
        }
   
        #endregion




    }
}
