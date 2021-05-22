using System;
using Controllers;

namespace GPUManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller GPU_Controller = new Controller();
            GPU_Controller.Run(); 
        }
    }
}
