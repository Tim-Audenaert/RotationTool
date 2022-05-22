using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Rotation_WPF
{
    internal class PlayerManager
    {
        private Dictionary<Role, Player> players;

        public PlayerManager(TextBox txt1, TextBox txt2, TextBox txt3)
        {
            players = new Dictionary<Role, Player>
            {
                {Role.Playmaker, new Player(txt1, Position.Top, Role.Playmaker) },
                {Role.Attacker, new Player (txt2, Position.BottomRight, Role.Attacker) },
                {Role.Defender, new Player (txt3, Position.BottomLeft, Role.Defender) }
            };
        }

        internal Player GetPlayer(Role role)
        {
            if (!players.ContainsKey(role)) 
                throw new KeyNotFoundException();

            return players[role];
        }

        internal TextBox GetPlayerTextBox(Role role)
        {
            return GetPlayer(role).TextBox;
        }

        internal void Swap(Player p1, Player p2)
        {
            if (p1 == p2)
                throw new ArgumentException("Positions should not be equal");
            var temprole = p1.Role;
            var temppos = p1.Position;

            p1.SetRole(p2.Role);
            p1.SetPosition(p2.Position);
            p2.SetRole(temprole);
            p2.SetPosition(temppos);

            players[p1.Role] = p1;
            players[p2.Role] = p2;

        }

        internal void Swap(Role r1, Role r2)
        {
            Swap(players[r1], players[r2]);
        }

        internal void Rotate(Direction direction)
        {
            if (direction == Direction.Left)
                players = RotateLeft(players);
            else
                players = RotateRight(players);
        }

        private Dictionary<Role, Player> RotateRight(Dictionary<Role, Player> dic)
        {
            var temp = new Dictionary<Role, Player>();

            players[Role.Attacker].SetRole(Role.Playmaker);
            players[Role.Defender].SetRole(Role.Attacker);
            players[Role.Playmaker].SetRole(Role.Defender);

            temp.Add(Role.Playmaker, players[Role.Attacker]);
            temp.Add(Role.Attacker, players[Role.Defender]);
            temp.Add(Role.Defender, players[Role.Playmaker]);

            return temp;
        }

        private Dictionary<Role, Player> RotateLeft(Dictionary<Role, Player> dic)
        {
            var temp = new Dictionary<Role, Player>();

            players[Role.Playmaker].SetRole(Role.Attacker);
            players[Role.Attacker].SetRole(Role.Defender);
            players[Role.Defender].SetRole(Role.Playmaker);

            temp.Add(Role.Attacker, players[Role.Playmaker]);
            temp.Add(Role.Defender, players[Role.Attacker]);
            temp.Add(Role.Playmaker, players[Role.Defender]);

            return temp;
        }
    }
}
