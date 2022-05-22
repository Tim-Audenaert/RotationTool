using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Rotation_WPF
{
    internal class GameManager
    {
        public int animationTime { get; private set; } = 500;
        private FrameworkElement fe;
        private Rotator rotator = new Rotator();
        private Swapper swapper = new Swapper();
        private PlayerManager pm;

        public GameManager(FrameworkElement f, PlayerManager playerManager)
        {
            fe = f;
            pm = playerManager;
        }

        internal void Defend()
        {
            rotator.Rotate(fe, Direction.Left);
            pm.Rotate(Direction.Left);
        }

        internal void Attack()
        {
            rotator.Rotate(fe, Direction.Right);
            pm.Rotate(Direction.Right);
        }

        internal async Task DefendCrossAsync()
        {
            Control c1 = pm.GetPlayerTextBox(Role.Playmaker);
            Control c2 = pm.GetPlayerTextBox(Role.Defender);

            await swapper.SwapAsync(c1, c2);
            pm.Swap(Role.Playmaker,Role.Defender);
        }

        internal async Task AttackCrossAsync()
        {
            Control c1 = pm.GetPlayerTextBox(Role.Playmaker);
            Control c2 = pm.GetPlayerTextBox(Role.Attacker);

            await swapper.SwapAsync(c1, c2);
            pm.Swap(Role.Playmaker, Role.Attacker);
        }

        internal async Task Swap2And3Async()
        {
            Control c1 = pm.GetPlayerTextBox(Role.Attacker);
            Control c2 = pm.GetPlayerTextBox(Role.Defender);

            await swapper.SwapAsync(c1, c2);
            pm.Swap(Role.Attacker, Role.Defender);
        }
    }
}
