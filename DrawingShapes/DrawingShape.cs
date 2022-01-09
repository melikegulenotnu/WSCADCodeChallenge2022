using WSCADCodeChallange2022.Shapes;

namespace DrawingShapes
{
    public class DrawingShape
    {
        public IDrawingShapeLogic DrawLogic { get; set; }
        private Shape ShapeData { get; set; }
        public DrawingShape(Shape _shape)
        {
            ShapeData = _shape;
        }
        public void drawWithPoints()
        {
            DrawLogic.DrawShapesWithPoints(ShapeData);
        }

    }
}

