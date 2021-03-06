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
        private static int sleepTime = 20;

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
                Thread.Sleep(sleepTime);
                if (myController.rndArr[i] < pivot)
                {
                    int tmp = myController.rndArr[i];
                    myController.rndArr[i] = myController.rndArr[p];
                    myController.rndArr[p] = tmp;
                    p++;
                    myController.ShapeArrayHeightlightRed(i);
                }
                myController.Redraw();
                Thread.Sleep(sleepTime);
            }
            int t = myController.rndArr[p];
            myController.rndArr[p] = myController.rndArr[e];
            myController.rndArr[e] = t;
            return p;
        }

        public void RunBubbleSort()
        {
            myController.rndArr.ToList().ForEach(i => Console.Write(i + " "));
            BubbleSort();
            myController.rndArr.ToList().ForEach(i => Console.Write(i + " "));
            myController.InitView();
        }

        public void BubbleSort()
        {
            int n = myController.rndArr.Length;
            int i, j, temp;
            bool swapped;
            for (i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (j = 0; j < n - i - 1; j++)
                {
                    myController.ShapeArrayHeighlight(j, j + 1);
                    myController.Redraw();
                    Thread.Sleep(sleepTime);
                    if (myController.rndArr[j] > myController.rndArr[j + 1])
                    {
                        // swap arr[j] and arr[j+1]
                        myController.ShapeArrayHeightlightRed(j + 1);
                        myController.Redraw();
                        Thread.Sleep(sleepTime);
                        temp = myController.rndArr[j];
                        myController.rndArr[j] = myController.rndArr[j + 1];
                        myController.rndArr[j + 1] = temp;
                        myController.ShapeArrayHeighlight(j, j + 1);
                        myController.Redraw();
                        Thread.Sleep(sleepTime);
                        swapped = true;
                    }
                }
                if (swapped == false)
                    break;
            }
        }
    }
}
