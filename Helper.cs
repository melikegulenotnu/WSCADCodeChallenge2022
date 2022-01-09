using Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;


namespace WSCADCodeChallange2022
{

    internal class Helper
    {
        /// <summary>
        /// Converts ARGB value to SolidColorBrush
        /// </summary>
        /// <param name="Argb"></param>
        /// <returns>SolidColorBrush</returns>
        public static SolidColorBrush ConvertArgbToColor(string Argb)
        {
            string[] ArgbArray = Regex.Split(Argb, "; ",
                                RegexOptions.IgnoreCase,
                                TimeSpan.FromMilliseconds(500));
            return new SolidColorBrush(Color.FromArgb(Convert.ToByte(ArgbArray[0]), Convert.ToByte(ArgbArray[1]), Convert.ToByte(ArgbArray[2]), Convert.ToByte(ArgbArray[3])));
        }

        /// <summary>
        /// Convert hexadecimal code to known color if it is exists
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string ConvertToKnownColorName(string color)
        {
            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml(color.ToString());
            if (col.IsKnownColor == true)
                return col.ToKnownColor().ToString();
            else
                return color.ToString();

        }
        /// <summary>
        /// Draws the path object to the mainwindow
        /// </summary>
        /// <param name="path"></param>
        public static void DrawToMainWindow(System.Windows.Shapes.Path path)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).Canvas.Children.Add(path);
        }

        /// <summary>
        /// rReads the json filev
        /// </summary>
        /// <returns></returns>
        public static string ReadJson()
        {
            var filePath = Path.Combine(@"C:\Users\User\source\repos\WSCADCodeChallange2022\WSCADCodeChallange2022\JsonFile.json");
            var reader = new StreamReader(filePath);
            var jsonData = reader.ReadToEnd();
            return jsonData;
        }

        /// <summary>
        /// Parses the json data with using strategy pattern
        /// </summary>
        /// <returns>dynamic</returns>
        public static dynamic ParseJson(string jsonData)
        {
            Parser parser = new Parser(jsonData);
            parser.ParseLogic = new JsonParser();
            dynamic parsedData = parser.Parse();

            return parsedData;
        }

    
    }    
}

