using System;
using System.Linq;
using System.Threading;
using SFML.Graphics;
using SFML.Window;

namespace SFMLSorting
{ 
    public class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.Start();
        }        
    }
}