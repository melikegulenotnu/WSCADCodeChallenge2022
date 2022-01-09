using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSCADCodeChallange2022.Shapes;

namespace DrawingShapes
{
    public class DrawingShapeWithPoints :IDrawingShapeLogic
    {
        /// <summary>
        /// //Drawing shapes to mainwindow
        /// </summary>
        /// <param name="parsedData"></param>
        public void DrawShapesWithPoints(Shape shape)
        {
            shape.DrawWithPoints();

        }

    }
}