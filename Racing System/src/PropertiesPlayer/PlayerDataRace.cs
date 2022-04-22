using Racing_System.src.RaceUtils;
using SampSharp.GameMode;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Racing_System.PropertiesPlayer
{
    public class PlayerDataRace
    {
        public List<Vector3> CoordsCP { get; set; } = new List<Vector3>();
        public int IndexCP { get; set; } = 0;
        public bool IsCreatingRace { get; set; } = false;
        public bool IsCPCreated { get; set; } = false;
        public Race RaceTemp { get; set; }
    }
}
