using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLSorting
{
    public class Sorting
    {
        public Controller myController;

        public Sorting(Controller controller)
        {
            myController = controller;
        }

        public void RunQuickSort()
        {
            myController.rndArr.ToList().ForEach(i => Console.Write(i + " "));
            QuickSort(0, myController.rndArr.Length - 1);
            myController.rndArr.ToList().ForEach(i => Console.Write(i + " "));
            myController.InitView();
        }

        public void QuickSort(int s, int e)
        {
            if (e <= s) return;
            int p = BlockSwitch(s, e);
            QuickSort(s, p - 1);
            QuickSort(p + 1, e);
        }

        private int BlockSwitch(int s, int e)
        {
            int pivot = myController.rndArr[e];
            int p = s;

            for (int i = s; i < e; i++)
            {
                myController.ShapeArrayHeighlight(i, e);
                myController.Redraw();
                Thread.Sleep(20);
                if (myController.rndArr[i] < pivot)
                {
                    int tmp = myController.rndArr[i];
                    myController.rndArr[i] = myController.rndArr[p];
                    myController.rndArr[p] = tmp;
                    p++;
                    myController.ShapeArrayRollBackColor(i);
                }
                myController.Redraw();
                Thread.Sleep(10);
            }
            int t = myController.rndArr[p];
            myController.rndArr[p] = myController.rndArr[e];
            myController.rndArr[e] = t;
            return p;
        }
    }
}
