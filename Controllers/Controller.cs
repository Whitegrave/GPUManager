using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;
using Views;

namespace Controllers
{
    public class Controller
    {
        private View GPU_View;
        private Repo GPU_Repo;
        int inputInt;
        string inputString;

        // Constructor
        public Controller()
        {
            GPU_View = new View();
            GPU_Repo = new Repo();
        }

        public void Run()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                // Reset console to main menu and get next menu choice from user
                Console.Clear();
                GPU_View.PromptForNextMenu(MenuPage.MainMenu);

                switch (GPU_View.GetMenu())
                {
                    case MenuPage.Create:
                        Create();
                        break;
                    case MenuPage.ReadAll:
                        DisplayAll();
                        break;
                    case MenuPage.ReadID:
                        Search();
                        break;
                    case MenuPage.Update:
                        Edit();
                        break;
                    case MenuPage.Delete:
                        Remove();
                        break;
                    case MenuPage.ExitApp:
                        //Exit Application
                        keepRunning = false;
                        break;
                }

            }
        }
        private void Create()
        {
            Console.WriteLine("Create");
        }

        private void DisplayAll()
        {
            // Cycle through each GPU in the array. If the element is populated, display it
            for (int i = 0; i < GPU_Repo.GPU_Data.Length; i++)
            {
                if (GPU_Repo.GetIsIndexValid(GPU_Repo.GPU_Data, i))
                {
                    GPU_View.Display(GPU_Repo.GPU_Data[i]);
                }
            }
            // Finished displaying, prompt to reset menus
            Console.WriteLine("\n Press any key to return to menu.");
            Console.ReadKey();
            GPU_View.SetMenu(MenuPage.MainMenu);
        }

        private void Search()
        {
            Console.WriteLine("Search");
        }

        private void Edit()
        {
            Console.WriteLine("Edit");
        }

        private void Remove()
        {
            Console.WriteLine("Delete");
        }
    }
}
