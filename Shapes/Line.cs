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
     /// Line class that derived from Shape interface 
     /// </summary>
    internal class Line : Shape
    {
        public string type { get; set; }
        public SolidColorBrush color { get; set; }
        private string a { get; set; }  
        private string b { get; set; }
        private double X1 { get; set; }
        private double Y1 { get; set; }
        private double X2 { get; set; }
        private double Y2 { get; set; }

        /// <summary>
        /// Parameterized Constructor for Line
        /// </summary>
        /// <param name="c_object"></param>
        public Line(dynamic c_object)
        {
            this.type = c_object.type;
            this.color = Helper.ConvertArgbToColor(Convert.ToString(c_object.color));  
            this.a = c_object.a;
            this.b = c_object.b;

            // property a seperated with ;
            string[] X1Y1Array = Regex.Split(Convert.ToString(c_object.a), "; ",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(500));

            // property b seperated with ;
            string[] X2Y2Array = Regex.Split(Convert.ToString(c_object.b), "; ",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(500));

            this.X1 = Convert.ToDouble(X1Y1Array[0]);
            this.Y1 = Convert.ToDouble(X1Y1Array[1]);

            this.X2 = Convert.ToDouble(X2Y2Array[0]);
            this.Y2 = Convert.ToDouble(X2Y2Array[1]);
        }

        /// <summary>
        /// Drawer method for Line
        /// </summary>
        public void DrawWithPoints()
        {
            LineGeometry line = new LineGeometry();
            line.StartPoint = new Point(this.X1,this.Y1);
            line.EndPoint = new Point(this.X2, this.Y2);

            Path path = new Path();
            path.Stroke = this.color;

            path.Data = line;
            path.MouseDown += new MouseButtonEventHandler(line_MouseDown);

            //Adding it to the canvas
        
            Helper.DrawToMainWindow(path);

            return;
        }

        /// <summary>
        /// MouseDown Event for Line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void line_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show("This is a : " + this.type + Environment.NewLine +
                            "From point : A(" + this.a +")" +" B(" + this.b +")" + Environment.NewLine +
                            "The color of it: " + Helper.ConvertToKnownColorName(this.color.ToString()));
        }
    }
}
