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
            SendClientMessage($"Index: {IndexCP}, total: {CoordsCP.Count}, actual: {CoordsCP[IndexCP]}");
            if(IndexCP != CoordsCP.Count - 1)
            {
                SetRaceCheckpoint(CheckpointType.Normal, CoordsCP[IndexCP++], CoordsCP[IndexCP], 10f);
            }
            else
            {
                SetRaceCheckpoint(CheckpointType.Finish, CoordsCP[IndexCP++], new(0,0,0), 10f);           
                IndexCP = 0;
                CoordsCP = new();
            }
            
            
        }
   

        #endregion


    }
}
