using KomodoInsurance_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_DTM_App
{
    public class Program_UI
    {
        private DevTeam _devRepo = new DevTeam();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();
        

        //Method that runs/starts the application
        public void Run()
        {
            SeedContentList();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                // Display our options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add a developer\n" +
                    "2. View All developers\n" +
                    "3. Delete Exisitng developer\n" +
                    "4. Add a new team\n" +
                    "5. View all teams\n" +
                    "6. Remove a team from the list\n" +
                    "7. Remove developer from team\n" +
                    "8. Add developer to Team\n" +
                    "9. List of developers who need PL\n" +
                    "10. Exit");

                
                string input = Console.ReadLine();

               
                switch (input)
                {
                    case "1":
                        
                        AddDeveleporToList();
                        break;
                    case "2":
                        
                        DisplayDeveleporList();
                        break;
                    case "3":

                        RemoveDeveleporFromList();
                        break;
                    case "4":
                        
                        AddNewTeamToList();
                        break;
                    case "5":

                        DisplayTeamList();
                        break;
                    case "6":
                        
                        RemoveTeamFromList();
                        break;
                    case "7":

                        RemoveDevFromTeam();
                        break;
                    case "8":

                        AddDevToTeam();
                        break;
                    case "9":
                        DisplayDeveleporWhoNeedPL();
                        break;
                    case "10":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    

                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }

                Console.WriteLine("Please press any key to continue... ");
                Console.ReadLine();
                Console.Clear();
            }
        }


        private void AddDeveleporToList()
        {
            Console.Clear();
            Developer newContent = new Developer();

            
            Console.WriteLine("Enter the First Name for the developer:");
            newContent.FirstName = Console.ReadLine();


            
            Console.WriteLine("Enter the Last Name for the developer:");
            newContent.LastName = Console.ReadLine();

            
            Console.WriteLine("Enter the ID for the developer):");
            string IdAsString = Console.ReadLine();
            newContent.IdentificationNumber = int.Parse(IdAsString);


            Console.WriteLine("Does the developer us Plural Sight Software? (y/n):");
            string pluraString = Console.ReadLine().ToLower();

            if (pluraString == "y")
            {
                newContent.PluralSight = true;
            }
            else
            {
                newContent.PluralSight = false;
            }

            _devRepo.AddDevToList(newContent);
            DisplayDeveleporList();

        }

        private void DisplayDeveleporList()
        {
            Console.Clear();
            List<Developer> listOfDevs = _devRepo.GetDevList();

            foreach (Developer content in listOfDevs)
            {
                Console.WriteLine($"First Name: {content.FirstName}\n" +
                    $"Last Name: {content.LastName}\n" +
                    $"ID: {content.IdentificationNumber}\n" +
                    $"PluralSight User: {content.PluralSight}\n");
            }
        }


        private void DisplayDeveleporWhoNeedPL()
        {
            Console.Clear();
            List<Developer> listOfDevsPL = _devRepo.GetDevListWhoNeedPluralSight();

            foreach (Developer content in listOfDevsPL)
            {
                Console.WriteLine($"First Name: {content.FirstName}\n" +
                    $"Last Name: {content.LastName}\n" +
                    $"ID: {content.IdentificationNumber}\n" +
                    $"PluralSight User: {content.PluralSight}\n");
            }
        }

        private void RemoveDeveleporFromList()
        {

            DisplayDeveleporList();

            Console.WriteLine("\nEnter the ID of the developer you'd like to remove:");

            string input = Console.ReadLine();
            int inputAsInt = int.Parse(input);

            bool wasDeleted = _devRepo.RemoveDevFromList(inputAsInt);

            if (wasDeleted)
            {
                Console.WriteLine("Developer was successfully deleted.");
                DisplayDeveleporList();
            }
            else
            {
                Console.WriteLine("The developer could not be deleted.");
                DisplayDeveleporList();
            }

        }

        private void AddNewTeamToList()
        {
            Console.Clear();
            DevTeam newContent = new DevTeam();


            Console.WriteLine("Enter the Name for the Team:");
            newContent.TeamName = Console.ReadLine();



            Console.WriteLine("Enter the Team ID:");
            string TeamIDAsString = Console.ReadLine();
            newContent.TeamIdentificationNumber = int.Parse(TeamIDAsString);

            
            
            Console.WriteLine("\nWould you like to add a developer to the team? (y/n)\n");
            string responseToAddDev = Console.ReadLine().ToLower();

            if (responseToAddDev == "y")
            {
                bool res = true;
                while (res)
                {
                    Console.WriteLine("\nWould you like to add a developer from the existing list? (y/n)");

                    string responseToAddDevAnother = Console.ReadLine().ToLower();

                    if (responseToAddDevAnother == "y")
                    {

                        DisplayDeveleporList();

                        Console.WriteLine("Please enter developer ID to add:");
                        string userinp = Console.ReadLine();

                        int inpAsInt = int.Parse(userinp);
                        Developer devToAdd = _devRepo.GetDevById(inpAsInt);
                        bool wasadded = newContent.AddDevToList(devToAdd);
                        if (wasadded)
                        {
                            Console.WriteLine("Developer was successfully added.");
                            DisplayTeamList();
                        }
                        else
                        {
                            Console.WriteLine("The developer could not be added.");
                            DisplayTeamList();
                        }
                    }
                    else if (responseToAddDevAnother == "n")
                    {
                        Console.WriteLine("Would you like to add a new developer to the team? (y/n)");
                        string inputF = Console.ReadLine().ToLower();

                        if (inputF == "y")
                        {
                            Console.Clear();
                            Developer newDev = new Developer();


                            Console.WriteLine("Enter the First Name for the developer:");
                            newDev.FirstName = Console.ReadLine();



                            Console.WriteLine("Enter the Last Name for the developer:");
                            newDev.LastName = Console.ReadLine();


                            Console.WriteLine("Enter the ID for the developer):");
                            string IdAsString = Console.ReadLine();
                            newDev.IdentificationNumber = int.Parse(IdAsString);


                            Console.WriteLine("Does the developer us Plural Sight Software? (y/n):");
                            string pluraString = Console.ReadLine().ToLower();

                            if (pluraString == "y")
                            {
                                newDev.PluralSight = true;
                            }
                            else
                            {
                                newDev.PluralSight = false;
                            }

                            _devRepo.AddDevToList(newDev);
                            bool wadded = newContent.AddDevToList(newDev);
                            if (wadded)
                            {
                                Console.WriteLine("Developer was successfully added.");
                                DisplayTeamList();
                            }
                            else
                            {
                                Console.WriteLine("The Developer could not be added.");
                                DisplayTeamList();
                            }

                        }

                        Console.WriteLine("\nWould you like to add another developer to the team? (y/n)\n");
                        string finalres = Console.ReadLine().ToLower();

                        if (finalres == "y")
                        {
                            res = true;
                        }
                        else
                        {
                            res = false;
                        }
                    }
                   
                }
            }
            else
            {
                newContent.AddDevToList(null);
                DisplayTeamList();
            }


            _devTeamRepo.AddTeamToList(newContent);

        }

        private void DisplayTeamList()
        {
            Console.Clear();
            List<DevTeam> listOfTeam = _devTeamRepo.GetTeamList();

            foreach (DevTeam content in listOfTeam)
            {
                Console.WriteLine($"----------------------------\n" +
                    $"Team Name: {content.TeamName}\n" +
                    $"Team ID: {content.TeamIdentificationNumber}\n" +
                    $"Number of develepors in team: {content.GetDevList().Count}\n");

                List<Developer> listOfDevsinthisteam = content.GetDevList();
                foreach (Developer x in listOfDevsinthisteam)
                {
                    Console.WriteLine($"First Name: {x.FirstName}\n" +
                        $"Last Name: {x.LastName}\n" +
                        $"ID: {x.IdentificationNumber}\n" +
                        $"PluralSight User: {x.PluralSight}\n");
                }
            }
        }

        private void RemoveTeamFromList()
        {

            DisplayTeamList();

            Console.WriteLine("\nEnter the team name you'd like to remove:");

            string input = Console.ReadLine();

            bool wasDeleted = _devTeamRepo.RemoveTeamFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("Team was successfully deleted.");
                DisplayTeamList();
            }
            else
            {
                Console.WriteLine("The Team could not be deleted.");
                DisplayTeamList();
            }


        }

        private void RemoveDevFromTeam()
        {

            DisplayTeamList();

            Console.WriteLine("\nEnter the team name you'd like to remove developer from:");

            string input = Console.ReadLine();

            DevTeam content = _devTeamRepo.GetTeamByName(input);

            if (content!=null)
            {
                Console.WriteLine("\nTeam was successfully selected, Here is the list of developers:\n");
                List<Developer> listOfDevsinthisteam = content.GetDevList();
                foreach (Developer x in listOfDevsinthisteam)
                {
                    Console.WriteLine($"----------------------------\n" +
                        $"First Name: {x.FirstName}\n" +
                        $"Last Name: {x.LastName}\n" +
                        $"ID: {x.IdentificationNumber}\n" +
                        $"PluralSight User: {x.PluralSight}\n");
                }
                
                Console.WriteLine("\nEnter the ID of the developer you'd like to remove:");

                string userin = Console.ReadLine();
                int inputAsInt = int.Parse(userin);

                bool wasDeleted = content.RemoveDevFromList(inputAsInt);
                if (wasDeleted)
                {
                    Console.WriteLine("Developer was successfully deleted.");
                    DisplayTeamList();
                }
                else
                {
                    Console.WriteLine("The developer could not be deleted.");
                    DisplayTeamList();
                }

            }
            else
            {
                Console.WriteLine("The Team could not be selected.");
            }


        }

        private void AddDevToTeam()
        {

            DisplayTeamList();

            Console.WriteLine("\nEnter the team name you'd like to add developer to:");

            string input = Console.ReadLine();

            DevTeam content = _devTeamRepo.GetTeamByName(input);

            if (content != null)
            {
                Console.WriteLine("\nTeam was successfully selected, here is the list of developers in the team:\n");
                List<Developer> listOfDevsinthisteam = content.GetDevList();
                foreach (Developer x in listOfDevsinthisteam)
                {
                    Console.WriteLine($"----------------------------\n" +
                        $"First Name: {x.FirstName}\n" +
                        $"Last Name: {x.LastName}\n" +
                        $"ID: {x.IdentificationNumber}\n" +
                        $"PluralSight User: {x.PluralSight}\n");
                }

                Console.WriteLine("\nWould you like to add a developer from the existing list? (y/n)");

                string responseToAddDevAnother = Console.ReadLine().ToLower();

                if (responseToAddDevAnother == "y")
                {

                    DisplayDeveleporList();

                    Console.WriteLine("Please enter developer ID to add:");
                    string userinp = Console.ReadLine();

                    int inpAsInt = int.Parse(userinp);
                    Developer devToAdd = _devRepo.GetDevById(inpAsInt);
                    bool wasadded = content.AddDevToList(devToAdd);
                    if (wasadded)
                    {
                        Console.WriteLine("Developer was successfully added.");
                        DisplayTeamList();
                    }
                    else
                    {
                        Console.WriteLine("The developer could not be added.");
                        DisplayTeamList();
                    }
                }
                else if (responseToAddDevAnother == "n")
                {
                    Console.WriteLine("Would you like to add a new developer to the team? (y/n)");
                    string inputF = Console.ReadLine().ToLower();

                    if (inputF == "y")
                    {
                        Console.Clear();
                        Developer newContent = new Developer();


                        Console.WriteLine("Enter the First Name for the developer:");
                        newContent.FirstName = Console.ReadLine();



                        Console.WriteLine("Enter the Last Name for the developer:");
                        newContent.LastName = Console.ReadLine();


                        Console.WriteLine("Enter the ID for the developer):");
                        string IdAsString = Console.ReadLine();
                        newContent.IdentificationNumber = int.Parse(IdAsString);


                        Console.WriteLine("Does the developer us Plural Sight Software? (y/n):");
                        string pluraString = Console.ReadLine().ToLower();

                        if (pluraString == "y")
                        {
                            newContent.PluralSight = true;
                        }
                        else
                        {
                            newContent.PluralSight = false;
                        }

                        _devRepo.AddDevToList(newContent);
                        bool wadded = content.AddDevToList(newContent);
                        if (wadded)
                        {
                            Console.WriteLine("Developer was successfully added.");
                            DisplayTeamList();
                        }
                        else
                        {
                            Console.WriteLine("The Developer could not be added.");
                            DisplayTeamList();
                        }
                        
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid input");
                }

            }
            else
            {
                Console.WriteLine("The Team could not be selected.");
            }


        }

        private void SeedContentList()
            {
                Developer Rich = new Developer("Richard", "Smith", 1, true);
                Developer Sam = new Developer("Sam", "Thompson", 2, false);
                Developer Michelle = new Developer("Michelle", "Gold", 3, true);
                Developer Irene = new Developer( "Irene", "Matts", 4, false);
                DevTeam fullStackSquad = new DevTeam("Full Stack Squad", 1, new List <Developer>() { Rich, Sam } );
                DevTeam frameworkForce = new DevTeam("Framework Force", 2, new List<Developer>() { Michelle, Irene } );



            _devRepo.AddDevToList(Rich);
            _devRepo.AddDevToList(Sam);
            _devRepo.AddDevToList(Michelle);
            _devRepo.AddDevToList(Irene);
            _devTeamRepo.AddTeamToList(fullStackSquad);
            _devTeamRepo.AddTeamToList(frameworkForce);
        }
        }
    }

