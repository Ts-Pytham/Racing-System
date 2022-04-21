using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using SampSharp.GameMode.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampSharp.GameMode;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.Display;

namespace Racing_System.PropertiesPlayer
{
    public partial class Player : BasePlayer
    {



        #region Overrides
        public override void OnEnterRaceCheckpoint(EventArgs e)
        {
            SendClientMessage($"Index: {IndexCP}, total: {CoordsCP.Count}");
            var pos = new Vector2(600.0f, 0); //Change
            var td = new PlayerTextDraw(this, pos, $"{IndexCP}/{CoordsCP.Count}", TextDrawFont.Normal, Color.Aquamarine);
            td.Show();
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
