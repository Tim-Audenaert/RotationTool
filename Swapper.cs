using Rotation_WPF.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Rotation_WPF
{
    internal class Swapper
    {
        private Animator animator = new Animator();
        public async Task SwapAsync(Control c1, Control c2)
        {
            var storyboard = animator.CreateSwapStoryBoard(c1, c2);
            await storyboard.BeginAsync();
        }
    }
}
