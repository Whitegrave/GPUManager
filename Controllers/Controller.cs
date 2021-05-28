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
                UserInput.DisplayToUser("", false, true); // Used only to clear log
                GPU_View.SetMenu(UserInput.GetIntFromUser(UserPrompts.MainMenu, false, false, 0, 6, true));
                UserInput.DisplayToUser("", false, true); // Used only to clear log

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
            for (int i = 0; i < GPU_Repo.GetLength(); i++)
            {
                if (GPU_Repo.ReadID(i) == null)
                {
                    // An unallocated index was found, flag and store its index value
                    firstOpenIndex = i;
                    break;
                }
            }

            // Array was full, inform and abort
            if (firstOpenIndex < 0)
            {
                UserInput.DisplayToUser(UserPrompts.GPUAddFail_Full, false, false);
                UserInput.DisplayToUser(UserPrompts.PressToReturn, true, false);
                return;
            }

            // Prompt user for GPU fields, populate the GPU
            string gpuBrand = UserInput.GetStringFromUser("Enter Brand Name (max 12 characters): ", 1, 12, true, true);
            string gpuName = UserInput.GetStringFromUser("Enter GPU Name (max 20 characters): ", 1, 20, false, true, true);
            int gpuMemory = UserInput.GetIntFromUser("Enter GB of memory (max 16)", false, false, 0, 16);
            int gpuClock = UserInput.GetIntFromUser("Enter clock speed in Hz (max 2048)", false, false, 0, 2048);
            int gpuCores = UserInput.GetIntFromUser("Enter number of Cuda Cores/Stream Processors (max 16384)", false, false, 0, 16384);
            GPU_Repo.Create(firstOpenIndex, gpuBrand, gpuName, gpuMemory, gpuClock, gpuCores);

            // Inform user of success, return to menu
            UserInput.DisplayToUser(UserPrompts.GPUAddSuccess, false, false);
            UserInput.DisplayToUser(UserPrompts.PressToReturn, true, false);
        }

        private void DisplayAll()
        {
            // Cycle through each GPU in the array. If the element is populated, display it
            for (int i = 0; i < GPU_Repo.GetLength(); i++)
            {
                GPU selectedGPU = GPU_Repo.ReadID(i);
                if (selectedGPU != null)
                {
                    GPU_View.Display(selectedGPU);
                }
            }
            // Finished displaying, prompt to reset menus
            UserInput.DisplayToUser(UserPrompts.PressToReturn, true, false);
        }

        private void Search()
        {
            UserInput.DisplayToUser(UserPrompts.MenuGreeting_Search, false, false);
            string inputString = UserInput.GetStringFromUser("ID: ", 1, 4, false, true, true).ToLower();
            GPU selectedGPU = GPU_Repo.GetGPUFromUserInput(inputString);

            // if "quit", abort
            if (inputString == "quit")
                return;

            // Input was not valid
            if (selectedGPU == null)
            {
                UserInput.DisplayToUser(UserPrompts.NoIDMatch, true, true);
                Search();
                return;
            }

            // GPU is populated, display it
            GPU_View.Display(selectedGPU);
            UserInput.DisplayToUser(UserPrompts.IDMatchSuccess, false, false);
            UserInput.DisplayToUser(UserPrompts.PressToReturn, true, false);
        }

        private void Edit()
        {
            UserInput.DisplayToUser(UserPrompts.MenuGreeting_Search, false, false);
            string inputString = UserInput.GetStringFromUser("ID: ", 1, 4, false, true, true).ToLower();
            GPU selectedGPU = GPU_Repo.GetGPUFromUserInput(inputString);

            // if "quit", abort
            if (inputString == "quit")
                return;

            // Input was not valid
            if (selectedGPU == null)
            {
                UserInput.DisplayToUser(UserPrompts.NoIDMatch, true, true);
                Edit();
                return;
            }

            // GPU is populated, begin modification
            string gpuBrand = UserInput.GetStringFromUser("Enter Brand Name (max 12 characters): ", 1, 12, true, true);
            string gpuName = UserInput.GetStringFromUser("Enter GPU Name (max 20 characters): ", 1, 20, false, true, true);
            int gpuMemory = UserInput.GetIntFromUser("Enter GB of memory (max 16)", false, false, 0, 16);
            int gpuClock = UserInput.GetIntFromUser("Enter clock speed in Hz (max 2048)", false, false, 0, 2048);
            int gpuCores = UserInput.GetIntFromUser("Enter number of Cuda Cores/Stream Processors (max 16384)", false, false, 0, 16384);
            GPU_Repo.Update(selectedGPU, gpuBrand, gpuName, gpuMemory, gpuClock, gpuCores);

            // Inform user of success, return to menu
            UserInput.DisplayToUser(UserPrompts.GPUEditSuccess, false, false);
            UserInput.DisplayToUser(UserPrompts.PressToReturn, true, false);
        }

        private void Remove()
        {
            UserInput.DisplayToUser(UserPrompts.MenuGreeting_Search, false, false);
            string inputString = UserInput.GetStringFromUser("ID: ", 1, 4, false, true, true).ToLower();
            GPU selectedGPU = GPU_Repo.GetGPUFromUserInput(inputString);

            // if "quit", abort
            if (inputString == "quit")
                return;

            // Input was not valid
            if (selectedGPU == null)
            {
                UserInput.DisplayToUser(UserPrompts.NoIDMatch, true, true);
                Remove();
                return;
            }

            // GPU is populated, clear it
            GPU_Repo.Delete(selectedGPU);

            // Inform user of success, return to menu
            UserInput.DisplayToUser(UserPrompts.GPUDeleteSuccess, false, false);
            UserInput.DisplayToUser(UserPrompts.PressToReturn, true, false);
        }       
    }
}
