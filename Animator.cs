using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Rotation_WPF
{
    internal class Animator
    {
        public Storyboard CreateRotationStoryBoard(FrameworkElement f, int startAngle, int endAngle)
        {                        
            DoubleAnimation myAnimation = CreateDoubleAnimation(startAngle, endAngle);

            Storyboard.SetTarget(myAnimation, f);
            Storyboard.SetTargetProperty(myAnimation, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));

            return new Storyboard
            {
                Children = new TimelineCollection { myAnimation }
            };
        }

        public Storyboard CreateSwapStoryBoard(Control c1, Control c2)
        {
            var c1pos = GetPoint(c1);
            var c2pos = GetPoint(c2);

            var tlc1 = Create2DAnimation(c1pos, c2pos);
            var tlc2 = Create2DAnimation(c2pos, c1pos);

            Register2DAnimation(c1, tlc1);
            Register2DAnimation(c2, tlc2); 

            var tc = MergeTimelineCollections(tlc1, tlc2);

            return new Storyboard()
            {
                Children = tc
            };
        }

        void Register2DAnimation(Control c, TimelineCollection tlc)
        {
            for (int i = 0; i < tlc.Count; i++)
            {
                Timeline t = tlc[i];
                t.SetValue(Storyboard.TargetProperty, c);
                
                if (i % 2 == 0)
                    t.SetValue(Storyboard.TargetPropertyProperty, new PropertyPath(Canvas.LeftProperty));               
                else 
                    t.SetValue(Storyboard.TargetPropertyProperty, new PropertyPath(Canvas.TopProperty));              
            }            
        }

        public TimelineCollection MergeTimelineCollections(params TimelineCollection[] timelinecollections)
        {
            var tc = new TimelineCollection();

            foreach (TimelineCollection tl in timelinecollections)
                foreach (Timeline timeline in tl)
                    tc.Add(timeline);

            return tc;
        }

        DoubleAnimation CreateDoubleAnimation(int from, int to)
        {
            return new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = new Duration(TimeSpan.FromMilliseconds(500))
            };
        }

        TimelineCollection Create2DAnimation(Point from, Point to)
        {
            return new TimelineCollection
            {
                CreateDoubleAnimation((int)from.X, (int)to.X),
                CreateDoubleAnimation((int)from.Y, (int)to.Y),
            };
            

        }


        public Point GetPoint(Control control)
        {
            int x = (int)Canvas.GetLeft(control);
            int y = (int)Canvas.GetTop(control);

            return new Point(x, y);
        }
    }
}
