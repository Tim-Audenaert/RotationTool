using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace Rotation_WPF
{
    internal class Rotator
    {
        private int currentAngle;
        private Animator animator = new Animator();

        public void Rotate(FrameworkElement f, Direction d)
        {
            int endAngle = GetEndAngle(d);
            Storyboard sb = animator.CreateRotationStoryBoard(f, currentAngle, endAngle);

            sb.Begin();

            currentAngle = endAngle;
        }

        private int GetEndAngle(Direction d)
        {
            switch (d)
            {
                default:
                    throw new ArgumentException();

                case Direction.Left: 
                    return currentAngle - 120;

                case Direction.Right: 
                    return currentAngle + 120;
            }
        }
    }
}
