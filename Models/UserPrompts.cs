using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public static class UserPrompts
    {
        public const string MainMenu = "*****************************************\n" +
                                       "**                                     **\n" +
                                       "**              GPU Manager            **\n" +
                                       "**                                     **\n" +
                                       "*****************************************\n\n" +
                                       "Welcome to the GPU Manager.\n\n" +
                                       "Please select an option below:\n\n" +
                                       "1 Submit a new GPU\n" +
                                       "2 Display all GPUs\n" +
                                       "3 Search for a GPU\n" +
                                       "4 Edit a GPU\n" +
                                       "5 Remove a GPU\n" +
                                       "6 Exit Application\n\n" +
                                       "Please choose an option 1 through 6: ";

        public const string MenuGreeting_Search = "Welcome to the GPU search menu.\nYou may use this menu to search for a GPU by ID.\n\nEnter \"quit\" to return to the main menu.\n\n";

        public const string MenuGreeting_Edit = "Welcome to the GPU Edit Menu.\nYou may use this menu to modify an existing GPU by entering its ID. \n\nEnter \"quit\" to return to the main menu.\n\n";

        public const string PressToReturn = "\nPress any key to return to menu.";

        public const string NoIDMatch = "The ID entered was not found. Press any key to try again.";

        public const string IDMatchSuccess = "The matching GPU is displayed above.";

        public const string GPUAddSuccess = "The GPU was successfully added to the database.";

        public const string GPUAddFail_Full = "The GPU database is full. Please delete an entry and try again.";

        public const string GPUEditSuccess = "The GPU was successfully updated with your changes.";

        public const string GPUDeleteSuccess = "The GPU was successfully removed.";
    }
}
