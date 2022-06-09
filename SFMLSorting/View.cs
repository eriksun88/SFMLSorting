using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace SFMLSorting
{
    public class View
    {
        public Controller myController;
        public RenderWindow window;
        public RectangleShape[] shapeArray;
        Font f = new Font(@"C:\\Windows\Fonts\Arial.ttf");
        public View (Controller controller)
        {
            myController = controller;
            window = new RenderWindow(new VideoMode(1200, 800), "SFML SORTING");
            shapeArray = new RectangleShape[myController.rndArr.Length];
        }
        public void InitWindow()
        {           
            window.SetFramerateLimit(90);
            window.Closed += Window_Closed;
            window.MouseButtonPressed += Window_MouseButtonPressed;
            window.KeyPressed += Window_KeyPressed;

            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(new Color(204, 204, 204));
                window.Draw(GenerateButton(10, 10));
                window.Draw(GenerateButtonText("Generate Random Array", 15, 15));
                window.Draw(GenerateButton(370, 10));
                window.Draw(GenerateButtonText("Quicksort", 375, 15));
                window.Draw(GenerateButton(730, 10));
                window.Draw(GenerateButtonText("Bubblesort", 735, 15));
                ArrayToShapeArray(myController.rndArr);
                RenderArray();
                window.Display();
            }
        }

        public void RenderArray()
        {
            shapeArray.ToList().ForEach(l => window.Draw(l));
        }

        public void Redraw()
        {
            window.Clear(new Color(204, 204, 204));
            RenderArray();
            window.Display();
        }

        public void ArrayToShapeArray(int[] array)
        {
            for (int i = 0; i < 50; i++)
            {
                RectangleShape rs = new RectangleShape(new SFML.System.Vector2f(20, array[i]));
                rs.FillColor = new Color(100, 100, 100);
                rs.Position = new SFML.System.Vector2f(100 + 20 * i, 700 - array[i]);
                rs.OutlineColor = new Color(51, 51, 51);
                rs.OutlineThickness = 1;
                shapeArray[i] = rs;
            }
        }

        public void ShapeArrayHeighlight(int index1, int index2)
        {
            ArrayToShapeArray(myController.rndArr);
            shapeArray[index1].FillColor = new Color(102, 255, 255);
            shapeArray[index2].FillColor = new Color(102, 255, 255);
        }

        public void ShapeArrayHeightlightRed(int index)
        {
            ArrayToShapeArray(myController.rndArr);
            shapeArray[index].FillColor = new Color(255, 153, 128);
        }

        private Text GenerateButtonText(String content, int posX, int posY)
        {
            Text btntxt = new Text();
            btntxt.Position = new SFML.System.Vector2f(posX, posY);
            btntxt.CharacterSize = 30;
            btntxt.DisplayedString = content;
            btntxt.FillColor = new Color(51, 51, 51);
            btntxt.Font = f;
            return btntxt;
        }

        private RectangleShape GenerateButton(int posX, int posY)
        {
            RectangleShape btn = new RectangleShape(new SFML.System.Vector2f(350, 50));
            btn.FillColor = new Color(179, 217, 255);
            btn.Position = new SFML.System.Vector2f(posX, posY);
            btn.OutlineColor = new Color(51, 51, 51);
            btn.OutlineThickness = 1;
            return btn;
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Close();
        }

        private void Window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            if (x >= 10 && x <= 360 && y >= 10 && y <= 60)
            {
                myController.GenerateRadnomArray();
            }
            if (x >= 370 && x <= 530 && y >= 10 && y <= 60)
            {
                myController.RunQuickSort();
            }
            if (x >= 730 && x <= 1080 && y >= 10 && y <= 60)
            {
                myController.RunBubbleSort();
            }
        }

        private void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            var window = (Window)sender;
            if (e.Code == Keyboard.Key.Escape)
            {
                window.Close();
            }
        }
    }
}
