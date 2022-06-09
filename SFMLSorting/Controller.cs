using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLSorting
{
    public class Controller
    {
        private static int arrLen = 50;
        public int[] rndArr = new int[arrLen];
        public View view;
        public Sorting sorting;
        public Random rand = new Random();

        public Controller()
        {            
            view = new View(this);
            sorting = new Sorting(this);
        }

        public void Start()
        {
            GenerateRadnomArray();
        }

        public void InitView()
        {
            view.InitWindow();
        }

        public void GenerateRadnomArray()
        {
            for (int i = 0; i < arrLen; i++)
            {
                int r = rand.Next(10, 500);
                rndArr[i] = r;
            }
            view.InitWindow();
        }

        public void Redraw()
        { 
            view.Redraw();
        }

        public void ShapeArrayHeighlight(int index1, int index2)
        { 
            view.ShapeArrayHeighlight(index1, index2);
        }

        public void ShapeArrayHeightlightRed(int index)
        { 
            view.ShapeArrayHeightlightRed(index);
        }

        public void RunQuickSort()
        {
            sorting.RunQuickSort();
        }

        public void RunBubbleSort()
        {
            sorting.RunBubbleSort();
        }
    }
}
