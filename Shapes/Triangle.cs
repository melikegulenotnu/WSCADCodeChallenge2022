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
    /// Triangle class that derived from Shape interface 
    /// </summary>
    internal class Triangle : Shape
    {
        public string type { get; set; }
        public SolidColorBrush color { get; set; }
        private string a { get; set; }
        private string b { get; set; }
        private string c { get; set; }
        private bool filled { get; set; }
        private double X1 { get; set; }
        private double Y1 { get; set; }
        private double X2 { get; set; }
        private double Y2 { get; set; }
        private double X3 { get; set; }
        private double Y3 { get; set; }

        /// <summary>
        /// Parameterized Constructor for Triangle
        /// </summary>
        /// <param name="c_object"></param>
        public Triangle(dynamic c_object)
        {

            this.a = c_object.a;
            this.b = c_object.b;
            this.c = c_object.c;

            this.type = c_object.type;
            this.color = Helper.ConvertArgbToColor(Convert.ToString(c_object.color));
            this.filled = c_object.filled;

            // property a seperated with ;
            string[] X1Y1Array = Regex.Split(Convert.ToString(c_object.a), "; ",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(500));

            // property b seperated with ;
            string[] X2Y2Array = Regex.Split(Convert.ToString(c_object.b), "; ",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(500));

            // property c seperated with ;
            string[] X3Y3Array = Regex.Split(Convert.ToString(c_object.c), "; ",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(500));

            this.X1 = Convert.ToDouble(X1Y1Array[0]);
            this.Y1 = Convert.ToDouble(X1Y1Array[1]);

            this.X2 = Convert.ToDouble(X2Y2Array[0]);
            this.Y2 = Convert.ToDouble(X2Y2Array[1]);

            this.X3 = Convert.ToDouble(X3Y3Array[0]);
            this.Y3 = Convert.ToDouble(X3Y3Array[1]);
        }

        /// <summary>
        /// Drawer method for Triangle
        /// </summary>
        public void DrawWithPoints()
        {
            LineGeometry line1 = new LineGeometry();
            line1.StartPoint = new Point(this.X1, this.Y1);
            line1.EndPoint = new Point(this.X2, this.Y2);

            LineGeometry line2 = new LineGeometry();
            line2.StartPoint = new Point(this.X2, this.Y2);
            line2.EndPoint = new Point(this.X3, this.Y3);

            LineGeometry line3 = new LineGeometry();
            line3.StartPoint = new Point(this.X3, this.Y3);
            line3.EndPoint = new Point(this.X1, this.Y1);
            
            GeometryGroup geometryGroup = new GeometryGroup();
            geometryGroup.Children.Add(line1);
            geometryGroup.Children.Add(line2);
            geometryGroup.Children.Add(line3);

            Path path = new Path();
            path.Stroke = this.color;
            path.Data = geometryGroup;
      
            path.MouseDown += new MouseButtonEventHandler(triangle_MouseDown);

            Helper.DrawToMainWindow(path);

            return;
        }

        /// <summary>
        /// MouseDown Event for Triangle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void triangle_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show("This is a: " + this.type + Environment.NewLine +
                            "It is between these three points: A(" + this.a + ")" + " B(" + this.b + ")" + " C(" + this.c + ")" + Environment.NewLine +
                            "The filled property is: " + this.filled + Environment.NewLine +
                            "The color of it: " + Helper.ConvertToKnownColorName(this.color.ToString()));
        }
 
    }
}
