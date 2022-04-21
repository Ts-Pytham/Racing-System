using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using SampSharp.GameMode.Definitions;
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
            SendClientMessage($"Index: {IndexCP}, total: {CoordsCP.Count}");
            if(IndexCP < CoordsCP.Count - 1)
            {
                SetRaceCheckpoint(CheckpointType.Normal, CoordsCP[IndexCP++], CoordsCP[IndexCP], 10f);
                PlaySound(1138);
            }
            else if(IndexCP == CoordsCP.Count - 1)
            {
                SetRaceCheckpoint(CheckpointType.Finish, CoordsCP[IndexCP++], new(0,0,0), 10f);
                PlaySound(1137);
            }
            else
            {
                IndexCP = 0;
                CoordsCP = new();
                DisableRaceCheckpoint();
                PlaySound(1139);
            }
            
        }
   
        #endregion


    }
}
