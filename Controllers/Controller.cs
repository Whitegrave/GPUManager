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
                // Reset console to main menu and get next menu choice from user prompt
                Console.Clear();
                GPU_View.SetMenu(UserInput.GetIntFromUser(UserPrompts.MainMenu, false, false, 0, 6));
                Console.Clear();

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
            // Cycle through each GPU in the array. If all are populated, abort      
            int firstOpenIndex = -1;
            for (int i = 0; i < GPU_Repo.GPU_Data.Length; i++)
            {
                if (!GPU_Repo.GetIsIndexValid(GPU_Repo, i))
                {
                    // An unallocated index was found, flag and store its index value
                    firstOpenIndex = i;
                    break;
                }
            }

            if (firstOpenIndex < 0)
            {
                // Array was full, inform and abort
                Console.WriteLine("\n The GPU database is full. Please delete an entry and try again.\n Press any key to return to menu.");
                Console.ReadKey();
                GPU_View.SetMenu(MenuPage.MainMenu);
                return;
            }

            // Prompt user for GPU fields, populate the GPU
            string gpuBrand = UserInput.GetStringFromUser("Enter Brand Name (max 12 characters): ", 1, 12, true, true);
            string gpuName = UserInput.GetStringFromUser("Enter GPU Name (max 20 characters): ", 1, 20, false, true, true);
            int gpuMemory = UserInput.GetIntFromUser("Enter GB of memory (max 16)", false, false, 0, 16);
            int gpuClock = UserInput.GetIntFromUser("Enter clock speed in Hz (max 2048)", false, false, 0, 2048);
            int gpuCores = UserInput.GetIntFromUser("Enter number of Cuda Cores/Stream Processors (max 16384)", false, false, 0, 16384);
            GPU_Repo.Create(GPU_Repo, firstOpenIndex, gpuBrand, gpuName, gpuMemory, gpuClock, gpuCores);

            // Inform user of success, return to menu
            Console.WriteLine($"\n\nThe {GPU_Repo.GPU_Data[firstOpenIndex].Name} has been added to the database with record ID {GPU_Repo.GPU_Data[firstOpenIndex].Repo_ID}");
            Console.WriteLine("\n Press any key to return to menu.");
            Console.ReadKey();
            GPU_View.SetMenu(MenuPage.MainMenu);


        }

        private void DisplayAll()
        {
            // Cycle through each GPU in the array. If the element is populated, display it
            for (int i = 0; i < GPU_Repo.GPU_Data.Length; i++)
            {
                if (GPU_Repo.GetIsIndexValid(GPU_Repo, i))
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
            Console.WriteLine("Welcome to the GPU search menu.\nYou may use this menu to search for a GPU by ID.\n\nEnter \"quit\" to return to the main menu.\n\n");
            string inputString;         // User's input
            int castedString = 0;       // Input converted to Int
            bool wasParsed = false;     // Flag for successful conversion (out)

            // Prompt user for ID, attempt to convert it to int
            inputString = UserInput.GetStringFromUser("ID: ", 1, 4, false, true, true).ToLower();
            wasParsed = Int32.TryParse(inputString, out castedString);

            // Input was a valid int, check if its ID exists.
            if (wasParsed && GPU_Repo.GetIsIndexValid(GPU_Repo, castedString))
            {
                // GPU is populated, display it
                GPU_View.Display(GPU_Repo.ReadID(GPU_Repo, castedString));
                Console.Write("\n\nThe matching GPU is displayed above. Press any key to return to main menu.");
                Console.ReadKey();
                GPU_View.SetMenu(MenuPage.MainMenu);
            }
            // Invalid entry, re-run
            else if (inputString != "quit")
            {
                Console.Write("The ID entered was not found. Press any key to try again.");
                Console.ReadKey();
                Console.Clear();
                // Recursively run this method again
                Search();
            }
            // "quit" Escape to menu (prevents being stuck if no GPUs exist in repo
            GPU_View.SetMenu(MenuPage.MainMenu);
        }

        private void Edit()
        {
            Console.WriteLine("Welcome to the edit menu. You may use this menu to modify a GPU entry.\n\nEnter \"quit\" to return to the main menu.\n\n");
        }

        private void Remove()
        {
            Console.WriteLine("Delete");
        }
    }
}
