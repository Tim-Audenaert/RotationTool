using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Rotation_WPF
{
    internal class Player
    {
        public TextBox TextBox { get; set; }
        public Position Position { get; private set; } 
        public Role Role {get; private set;}
        public string Name => TextBox.Text;
        public Player(TextBox txt, Position tpos, Role gpos)
        {
            Position = tpos;
            Role = gpos;
            TextBox = txt;
        }

        internal void SetPosition(Position tpos)
        {
            Position = tpos;
        }

        internal void SetRole(Role gpos)
        {
            Role = gpos;
        }
    }
}
