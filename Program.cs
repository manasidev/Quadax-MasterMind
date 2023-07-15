using System;

class MasterMind
{
    static void Main()
    {
        // Variable Declaration
        int userAnswer = 0;
        string randomPassword = "";
        int userInputCount = 0;

        try
        {
            randomPassword = RandomPasswordGenerator();

            Console.Write("Random Password: {0}", randomPassword);

            while (true)
            {
                userAnswer = 0;
                string userChoice = "";
                int invalidEntryCount = 1;
                string hashPasswordString = "";

                //Invalid Entries
                while (userChoice.Length != 4)
                {
                    Console.WriteLine("\nGuess the 4 digit number? ");

                    userChoice = Console.ReadLine();
                    if (userChoice.Length != 4)

                    {
                        Console.WriteLine("Invalid entry. Please try again ");
                        if (invalidEntryCount >= 10)
                        {
                            Console.WriteLine("User exceeded the 10 Invalid attempt limit");
                            return;
                        }
                        invalidEntryCount++;
                    }

                }
                //Valid Entry
                userInputCount++;
                for (int i = 0; i < 4; i++)
                {
                    if (userChoice[i] == randomPassword[i])
                    {
                        userAnswer++;
                        hashPasswordString += "+";
                        if (userAnswer == 4)
                        {
                            Console.WriteLine("\n You Won");
                        }
                    }
                    else
                    {
                        if (randomPassword.Contains(Char.ToString(userChoice[i])))
                            hashPasswordString += "-";
                        else
                            hashPasswordString += "X";


                    }
                }
                Console.WriteLine(hashPasswordString);
                Console.WriteLine("");
                if (userInputCount == 10 || userAnswer == 4)
                    break;

            }
            if (userInputCount == 10 && userAnswer != 4)
                Console.WriteLine("Entry limit exceeded, Total attempts: {0}", userInputCount);

            Console.WriteLine("The correct 4 digit guess is " + randomPassword);
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Invalid entry. Please try again ");
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid entry. Please try again ");
        }
        finally
        {
            Console.ReadLine();
        }

    }

    private static string RandomPasswordGenerator()
    {
        string password = string.Empty;
        //Generating the Random Password
        Random random = new Random();
        for (int i = 0; i < 4; i++)
        {
            password += random.Next(1, 6);
        }
        return password;
    }
}