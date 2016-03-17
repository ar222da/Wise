using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum ViewChoice
{
    newMember,
    editMember,
    deleteMember,
    newBoat,
    editBoat,
    deleteBoat,
    quit
}

namespace workshop_2_senaste
{
    class MemberView
    {

        ViewChoice choice;
       
        public MemberView()
        {
        }

        public ViewChoice Grid(int memberGridSize, int boatGridSize, ModelMemberList memberList)
        {
            int memberCursorCounter = 0;
            int boatCursorCounter = 0;
            int selectedMember = 0;
            int view = 0;
            int boatGrids;
            bool quit = false;
            
            Console.ForegroundColor = ConsoleColor.White;

            if (memberList.Members.Count < memberGridSize)
            {
                memberGridSize = memberList.Members.Count;
            }

            string[] gridNameColumns = new string[memberGridSize];
            string[] gridMIDColumns = new string[memberGridSize];
            string[] gridNumberOfBoatsColumns = new string[memberGridSize];
                    
            do
            {
                Console.Clear();
                //Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(" Medlem: ");
                Console.Write("1=Ny");
                Console.Write(" 2=Ändra");
                Console.Write(" 3=Ta bort ");
                Console.Write("Båt: ");
                
                Console.Write("4=Ny");
                Console.Write(" 5=Ändra");
                Console.Write(" 6=Ta bort");
                Console.WriteLine(" 7=Avsluta");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("{0,-10} {1,30} {2,20}", " Namn", "Medlemsnummer", "Antal båtar");
                Console.WriteLine("----------------------------------------------------------------------");
                    
                for (int i = 0; i < gridNameColumns.Length; i++)
                {
                    int memberGridSection = memberCursorCounter / gridNameColumns.Length;

                    if (i + memberGridSection * gridNameColumns.Length >= memberList.Members.Count)
                    {
                        break;
                    }

                    gridNameColumns[i] = memberList.Members[i + memberGridSection * gridNameColumns.Length].Name.ToString();
                    gridMIDColumns[i] = memberList.Members[i + memberGridSection * gridNameColumns.Length].MID.ToString();
                    gridNumberOfBoatsColumns[i] = memberList.Members[i + memberGridSection * gridNumberOfBoatsColumns.Length].Boats.Count.ToString();

                    if (i == memberCursorCounter)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        selectedMember = i;
                    }

                    else if (i == (memberCursorCounter - (gridNameColumns.Length * memberGridSection)))
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        selectedMember = memberCursorCounter;
                    }

                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine("{0,-33} {1,-22} {2,0}", " " + gridNameColumns[i], gridMIDColumns[i], gridNumberOfBoatsColumns[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("----------------------------------------------------------------------");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(" Båtar tillhörande ");
                Console.Write(memberList.Members[memberCursorCounter].Name.ToString());
                Console.Write(" ");
                Console.Write(memberList.Members[memberCursorCounter].MPIN.ToString());
                Console.WriteLine(memberList.Members[memberCursorCounter].MID.ToString());
                Console.BackgroundColor = ConsoleColor.Black;

                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("{0,-10} {1,30} {2,20}", " Båttyp", "Längd i meter", "");
                Console.WriteLine("----------------------------------------------------------------------");
                
                if (memberList.Members[memberCursorCounter].NumberOfBoats < boatGridSize)
                {
                    boatGrids = memberList.Members[memberCursorCounter].NumberOfBoats;
                }

                else
                {
                    boatGrids = boatGridSize;
                }
               
            
                string[] gridBoatTypeColumns = new string[boatGrids];
                string[] gridBoatLengthColumns = new string[boatGrids];
                
                for (int j = 0; j < gridBoatTypeColumns.Length; j++)
                {
                    
                    int boatGridSection = boatCursorCounter / gridBoatTypeColumns.Length;

                    if (j + boatGridSection * gridBoatTypeColumns.Length >= memberList.Members[selectedMember].Boats.Count)
                    {
                        break;
                    }

                    gridBoatTypeColumns[j] = memberList.Members[selectedMember].Boats[j + boatGridSection * gridBoatTypeColumns.Length].Type.ToString();
                    gridBoatLengthColumns[j] = memberList.Members[selectedMember].Boats[j + boatGridSection * gridBoatTypeColumns.Length].Length.ToString();
                    
                    if (j == boatCursorCounter || (j == (boatCursorCounter - (gridBoatTypeColumns.Length * boatGridSection))))
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }

                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine("{0,-33} {1,-1}", " " + gridBoatTypeColumns[j], gridBoatLengthColumns[j]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (view == 0)
                        {
                            if (memberCursorCounter < memberList.Members.Count - 1)
                            {
                                memberCursorCounter++;
                            }
                        }
                        else if (view == 1)
                        {
                            if (boatCursorCounter < memberList.Members[selectedMember].Boats.Count - 1)
                            {
                                boatCursorCounter++;
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (view == 0)
                        {
                            if (memberCursorCounter > 0)
                            {
                                memberCursorCounter--;
                            }
                        }
                        else if (view == 1)
                        {
                            if (boatCursorCounter > 0)
                            {
                                boatCursorCounter--;
                            }
                        }
                        break;
                    case ConsoleKey.Tab:
                        if (view == 0)
                        {
                            view = 1;
                        }
                        else if (view == 1)
                        {
                            view = 0;
                        }
                        break;
                    case ConsoleKey.D1:
                        return (ViewChoice)ConsoleKey.D1; 
                    case ConsoleKey.D2:
                        return (ViewChoice)ConsoleKey.D2;
                    case ConsoleKey.D3:
                        return (ViewChoice)ConsoleKey.D3;
                    case ConsoleKey.D4:
                        return (ViewChoice)ConsoleKey.D4;
                    case ConsoleKey.D5:
                        return (ViewChoice)ConsoleKey.D5;
                    case ConsoleKey.D6:
                        return (ViewChoice)ConsoleKey.D6;
                    case ConsoleKey.D7:
                        quit = true;
                        break;
                }
                      
            }
            while (quit == false);
            return ViewChoice.newMember;
        }
        
    
    
    }
}
