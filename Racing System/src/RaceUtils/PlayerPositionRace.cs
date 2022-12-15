using Racing_System.PropertiesPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing_System.src.RaceUtils
{
    public class PlayerPositionRace : IComparable<PlayerPositionRace>
    {
        public double TotalTime { get; set; }
        public Player Player { get; set; }

        public int CompareTo(PlayerPositionRace other)
        {
            if (TotalTime > other.TotalTime)
            {
                return 1;
            }
            else if (TotalTime == other.TotalTime)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public override string ToString()
        {
            return $"{Player.Name} - {TimeSpan.FromMilliseconds(TotalTime):mm':'ss}";
        }
    }
}
