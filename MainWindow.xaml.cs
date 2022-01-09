using System.Windows;
using WSCADCodeChallange2022.Shapes;

namespace WSCADCodeChallange2022
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Read and parse Json
            string data = Helper.ReadJson();
            dynamic parsedData = Helper.ParseJson(data);

            foreach (var item in parsedData)
            {
                ShapeFactory shapeFactory = new ShapeFactory();
                //get an object of concrete object 
                Shape concreteShape = shapeFactory.getShape(item);

                //Draws with points the concrete shape object to the mainwindow
                DrawingShapes.DrawingShape drawObject = new DrawingShapes.DrawingShape(concreteShape);
                drawObject.DrawLogic = new DrawingShapes.DrawingShapeWithPoints();
                drawObject.drawWithPoints();

            }
        }
    }
}
