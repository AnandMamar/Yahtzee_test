using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Yahtzee
{
    static class Global
    {
        public static int ThisScore { get; set; }
        public static List<Player> players = new List<Player>();
    }
}
