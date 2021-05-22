using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Views
{
    public class View
    {
        private MenuPage currentMenu;
        public MenuPage GetMenu()
        {
            return currentMenu;
        }
        public void SetMenu(int menuChoice)
        {
            // Assign this object's menu to a specified Enum based on a user-provided int
            if (menuChoice == 1)
                currentMenu = MenuPage.Create;
            else if (menuChoice == 2)
                currentMenu = MenuPage.ReadAll;
            else if (menuChoice == 3)
                currentMenu = MenuPage.ReadID;
            else if (menuChoice == 4)
                currentMenu = MenuPage.Update;
            else if (menuChoice == 5)
                currentMenu = MenuPage.Delete;
            else
                currentMenu = MenuPage.ExitApp;
        }
        // Overloaded SetMenu to directly dictate menu
        public void SetMenu(MenuPage menuChoice)
        {
            // Assign this object's menu to a specified Enum
            currentMenu = menuChoice;
        }
        private void MakeNew()
        {

        }
        public void Display(GPU GPU_To_Display)
        {
            // Display all fields of a given GPU object
            Console.WriteLine($"ID: {GPU_To_Display.Repo_ID}");
            Console.WriteLine($"Brand: {GPU_To_Display.Brand}");
            Console.WriteLine($"Name: {GPU_To_Display.Name}");
            Console.WriteLine($"Memory: {GPU_To_Display.MemoryGB} GB");
            Console.WriteLine($"Clock Speed: {GPU_To_Display.ClockSpeedHZ} Hz");
            Console.WriteLine($"Cores/Processors: {GPU_To_Display.Cores}");
        }
        private void Edit()
        {

        }
        private void Search()
        {

        }
        private void ConfirmRemoval()
        {

        }
        public void PromptForNextMenu(MenuPage currentMenu)
        {
            // Pivot on current menu, show user a predefined prompt and convert their input into 
            //     a new menu choice.
            switch (currentMenu)
            {
                case MenuPage.MainMenu:
                    SetMenu(UserInput.GetIntFromUser(UserPrompts.MainMenu, false, false, 0, 6));
                    break;
            }
        }
    }
}
