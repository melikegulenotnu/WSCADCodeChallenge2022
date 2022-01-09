using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSCADCodeChallange2022.Shapes
{
    /// <summary>
    /// Concrete class that creates and return the shape object
    /// </summary>
    public class ShapeFactory
    {
        /// <summary>
        /// creates and return the specific shape object
        /// </summary>
        /// <param name="shapeItem"></param>
        /// <returns></returns>
        public Shape getShape(dynamic shapeItem)
        {
            if (shapeItem.type == "circle")
            {
                Shape circle = new Circle(shapeItem);
                return circle;
            }
            else if (shapeItem.type == "line")
            {
                Shape line = new Line(shapeItem);
                return line;    
            }
            else if (shapeItem.type == "triangle")
            {
                Shape triangle = new Triangle(shapeItem);
                return triangle;
            }
            return null;
        }
    }
}
