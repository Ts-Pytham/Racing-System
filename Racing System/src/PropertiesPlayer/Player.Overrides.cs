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
            SendClientMessage($"Index: {Data.IndexCP}, total: {Data.CoordsCP.Count}");
            var pos = new Vector2(600.0f, 0); //Change
            var td = new PlayerTextDraw(this, pos, $"{Data.IndexCP}/{Data.CoordsCP.Count}", TextDrawFont.Normal, Color.Aquamarine);
            td.Show();
            if(Data.IndexCP < Data.CoordsCP.Count - 1)
            {
                SetRaceCheckpoint(CheckpointType.Normal, Data.CoordsCP[Data.IndexCP++], Data.CoordsCP[Data.IndexCP], 10f);
                PlaySound(1138);
            }
            else if(Data.IndexCP == Data.CoordsCP.Count - 1)
            {
                SetRaceCheckpoint(CheckpointType.Finish, Data.CoordsCP[Data.IndexCP++], new(0,0,0), 10f);
                PlaySound(1137);
            }
            else
            {
                Data.IndexCP = 0;
                Data.CoordsCP = new();
                DisableRaceCheckpoint();
                PlaySound(1139);
            }
            
        }
   
        
        #endregion


    }
}
