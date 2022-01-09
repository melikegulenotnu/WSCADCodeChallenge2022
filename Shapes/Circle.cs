using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WSCADCodeChallange2022.Shapes
{
    /// <summary>
    /// Circle class that derived from Shape interface 
    /// </summary>
    internal class Circle : Shape
    {
        public string type { get; set; }
        public SolidColorBrush color { get; set; }
        private double radius { get; set; }     
        private string center { get; set; }
        private bool filled { get; set; }
        private double centerX { get; set; }
        private double centerY { get; set; }

        /// <summary>
        /// Parameterized Constructor for Circle
        /// </summary>
        /// <param name="c_object"></param>
        public Circle(dynamic c_object)
        {
            this.type = c_object.type;
            this.color = Helper.ConvertArgbToColor(Convert.ToString(c_object.color)); 
            this.radius = c_object.radius;
            this.center = c_object.center;
            this.filled = c_object.filled;

            string[] centerArray = Regex.Split(Convert.ToString(c_object.center), "; ",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(500));

            this.centerX = Convert.ToDouble(centerArray[0]);
            this.centerY = Convert.ToDouble(centerArray[1]);

        }
        /// <summary>
        /// Drawer method for Circle
        /// </summary>
        public void DrawWithPoints()
        {
            EllipseGeometry ellipse = new EllipseGeometry();

            ellipse.Center = new Point(this.centerX,this.centerY);
            ellipse.RadiusX = this.radius;
            ellipse.RadiusY = this.radius;

            Path path = new Path();
            path.Stroke = this.color;
            path.Fill = this.filled == true ? this.color
                 : new SolidColorBrush(Color.FromArgb(0, 0, 0, 0)); //Transparent

            path.Data = ellipse;
            path.MouseDown += new MouseButtonEventHandler(circle_MouseDown);

            Helper.DrawToMainWindow(path);
            return;
        }

        /// <summary>
        /// MouseDown Event for Circle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void circle_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show("This is a : " + this.type + Environment.NewLine +
                            "The center of it : (" + this.center + ")" +Environment.NewLine +
                            "The Radius of it : " + this.radius + Environment.NewLine +
                            "The filled property is : " + this.filled + Environment.NewLine +
                            "The color of it : " + Helper.ConvertToKnownColorName(this.color.ToString()));
        }
        
    }
}