using SampSharp.GameMode.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing_System.Dialogs
{
    public class ListDialogEx : ListDialog
    {
        public List<int> IDs { get; } = new List<int>();
        public ListDialogEx(string caption, string button1, string button2 = null) : base(caption, button1, button2)
        {

        }

        public void AddItem(int id, string item)
        {
            AddItem(item);
            IDs.Add(id);
        }

    }
}
