//Date: 12 October 2026
//Programmer:IP Letsogo
// Capstone Project Overview:
// This program is a guessing game with three different challenging levels.
// The quiz is made up of general knowledge questions from different categories.
// Players need to create an account before they can play.
// The game checks the player's age before starting through account creation.
// Points are earned for correct guesses, and those points can be used to buy extra lives.
// When a player has only one life left, the game shows a red warning.
// If all lives are lost, the game ends, but players can buy more lives if they have enough points.


namespace CapstoneProject
{
    class QuestionBank
    {
        public  string[] level1Qs = { "1. Who was the first democratically elected president of South Africa in 1994?  ",
                                      "2. What is the nickname of South Africa’s national soccer team? ",
                                      "3. Which music genre was Lebo Mathosa best known for? ",
                                      "4. Which city is nicknamed the “City of Roses”? "};
       public string[] level1As = { "A. FW De Klerk or B. Nelson Mandela",
                                    "A. Bafana Bafana or B. Siwelele",
                                    "A. Amapiano or B. Kwaito " ,
                                    "A. Polokwane or B. Bloemfontein" };
       public  string[] correctAnswer1s  = { "B", "A", "B", "B" };


        public string[] level2Qs =  { "1.What was the name of the system of racial segregation and discrimination that lasted in South Africa until the early 1990s? ",
                                      "2. Which province is home to Table Mountain? ",
                                      "3. Which mineral made Johannesburg famous in the late 1800s?",
                                      "4. How many colours does the South African National flag have?  "};
        public string[] level2As = { "A. Apartheid or B. Tribalism",
                                     "A. Western Cape or B. Eastern Cape",
                                     "A. Platinum or B. Gold ",
                                     "A. 6 OR B. 5"};
        public string[] correctAnswer2s = { "A", "A", "B", "A" };


         public string[] level3Qs =  { "1.  What is the nickname of South Africa’s national rugby team? ",
                                       "2. Which desert stretches into South Africa from Namibia and Botswana? ",
                                       "3. Who was the South African activist killed in police custody in 1977? ",
                                       "4. What is South Africa’s national flower? "};

        public string[] level3As =  {"A. Cheetahs or B. SpringBoks ",
                                     "A. Kalahari or B. Sahara ",
                                     "A. Steve Biko or B. Winnie Mandela",
                                     "A. Protea or B. Sunflower "};
        public string[] correctAnswer3s = { "B", "A", "A", "A" };

        public string answerInput;
    }
    class Contestant
    {
        public string name;
        public int age, score, lives = 3;


    }
    internal class Program
    {
        static int pointsEarned = 0,  bonusStreakPoint = 0;
        static int menuOption, wrongAnswer = 0;
        static string buyLives;


        static Contestant myContestant = new Contestant();
        static QuestionBank myQuestion = new QuestionBank();

        static void Main(string[] args)
        {
            while (menuOption != 4)
            {
                Menu();
            }
        }
        static void Menu()//A method that displays menu, checks the input and gives the user 3 attempts to enter the correct number

        {
            int limitCounter = 1;
            bool correctMenuOpt = false;

            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine("                 ~ QUIZ RPG ~                ");
            Console.WriteLine("       where correct answers level you up    ");
            Console.WriteLine("=============================================");
            Console.WriteLine("                     MENU                    ");
            Console.WriteLine();
            Console.WriteLine("           1. Create a RPG Account ");
            Console.WriteLine("           2. Play the RPG Quiz    ");
            Console.WriteLine("           3. Exit the Program     ");
            Console.WriteLine();
            Console.WriteLine("=============================================");

            Console.WriteLine("Please enter the number between 1 & 4 to access menu...");
            menuOption = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            if (menuOption >= 1 && menuOption <= 3)
            {
                limitCounter = 3;
                correctMenuOpt = true;

            }
            while (menuOption < 1 && menuOption > 3 || limitCounter < 3)
            {
                Console.WriteLine("Menu option provided was incorrect! Please try again...");
                Console.WriteLine("Please enter the number between 1 & 4 to access menu...");
                menuOption = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine();

                limitCounter++;

                if (menuOption >= 1 && menuOption <= 3)
                {
                    limitCounter = 3;
                    correctMenuOpt = true;

                }
            }

            if (correctMenuOpt == true)
            {
                switch (menuOption)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:
                        PlayQuiz();
                        break;
                    case 3:
                        ExitProgram();
                        break;
                    default:
                        Console.WriteLine("A fatal error has occurred. Press any key to close...");
                        Console.ReadKey();
                        menuOption = 3;
                        break;
                }


            }
            else
            {
                Console.WriteLine("Invalid Menu option was entered 3 times!");
                Console.WriteLine("Attempts exceeded, program will now close. Press any key");
                Console.ReadKey();

                Console.WriteLine();
                menuOption = 4;
            }
        }
        static void CreateAccount()//A method that takes the users details to create an account and it does not allow user under the age of 18
        {
            Console.Write("Please enter your name: ");
            myContestant.name = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Please enter your age: ");
            myContestant.age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            if (myContestant.age < 18)
            {
                Console.WriteLine("Users should be 18 years and older to play the quiz");
                Console.WriteLine("Program will now close...");
                Console.WriteLine();
                Console.ReadKey();
                ExitProgram();
            }

            Console.WriteLine("Thank you {0}, Account Created! ", myContestant.name);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine();


        }

        static void GameOver()//A method that allows the user to buy lives when they run out if they want and if not displays game over
        {

            if (myContestant.lives == 0)
            {
                Console.WriteLine();
                Console.WriteLine("You have ran out of lives ");
                Console.WriteLine("Would you like to buy lives, YES or NO?");
                buyLives = Console.ReadLine();
                Console.WriteLine();

                if (buyLives.ToUpper() == "YES")
                {
                    if (myContestant.score >= 20)
                    {

                        Console.WriteLine("==================================");
                        Console.WriteLine("         LIVES PURCHASE      ");
                        Console.WriteLine();
                        Console.WriteLine("       2 LIVES cost 20 points  ");
                        Console.WriteLine("  Press any key to make a purchase");
                        Console.WriteLine();
                        Console.ReadKey();

                        myContestant.score = myContestant.score - 20;
                        myContestant.lives = myContestant.lives + 2;
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("|  PURCHASE SUCCESSFUL!    |");
                        Console.WriteLine("|                          |");
                        Console.WriteLine("|  Lives: {0}              |", myContestant.lives);
                        Console.WriteLine("|  Score: {0}              |", myContestant.score);
                        Console.WriteLine("----------------------------");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Insufficient points for the LIVES PURCHASE");
                        Console.WriteLine("Press any key to exit.....");
                        Console.ReadKey();
                    }

                }
                else
                {
                    Console.WriteLine("====================================");
                    Console.WriteLine("        GAME OVER!!      ");
                    Console.WriteLine();
                    Console.WriteLine("Thank you for playing RPG Quiz ^-^");
                    Console.WriteLine();

                    Console.WriteLine("====================================");
                    Console.WriteLine("Player Details:");
                    Console.WriteLine("Name: {0}", myContestant.name);
                    Console.WriteLine("Age: {0}", myContestant.age);
                    Console.WriteLine("High Score: {0}", myContestant.score);
                    Console.WriteLine("Lives Remaining: {0}", myContestant.lives);
                    Console.WriteLine("====================================");
                    Console.WriteLine();
                    Console.WriteLine();

                    Console.WriteLine("Press any key to exit.....");
                    Console.ReadKey();
                    ExitProgram();
                }
            }
        }
        static void Warning()//A method that warns the contestant when they are left with one line  
        {
            if (myContestant.lives == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("===========================");
                Console.WriteLine("           !WARNING!       ");
                Console.WriteLine("  You have one life left...");
                Console.WriteLine("===========================");
                Console.ResetColor();
                Console.WriteLine();
            }

        }
        static void PlayQuiz()//A method that allows the contestant to play the game only if they created an account
        {
            if (myContestant.name == null)//An IF statement that checks if the contestant has created an account and if not the program does not allow them to play the quiz
            {
                Console.WriteLine("No account has been found! ");
                Console.WriteLine("Please return to Main Menu and first create an account by using Menu option 1");
                Console.ReadKey();
                Console.WriteLine();

            }
            else
            {
                Console.Clear();
                Console.WriteLine("===============================");
                Console.WriteLine("           QUIZ TIME           ");
                Console.WriteLine();
                Console.WriteLine("Contestant:  {0}  ", myContestant.name);
                Console.WriteLine("Age:         {0}  ", myContestant.age);
                Console.WriteLine();
                Console.WriteLine("How to play: Guess the correct answer based a genre");
                Console.WriteLine("                      You have 3 lives             ");
                Console.WriteLine();



                   //for loops to print different levels questions as the user gets the questions correct and checks if user has a lives before printing the questions
                    for (int one = 0; one < myQuestion.level1Qs.Length && myContestant.lives > 0; one++)
                    {
                        Console.WriteLine("   LEVEL  ONE  ");//Each level has different point allocations as well as the streak points this is because the levels become more challenging as they change
                    Console.WriteLine(myQuestion.level1Qs[one]);
                        Console.WriteLine(myQuestion.level1As[one]);
                        Console.WriteLine();

                        Console.WriteLine("Please choose the correct answer between A and B");
                        myQuestion.answerInput = Console.ReadLine();
                        Console.WriteLine();

                        if (myQuestion.answerInput.ToUpper() == myQuestion.correctAnswer1s[one])
                        {
                            Console.WriteLine("Correct!");
                            myContestant.score = myContestant.score + 5;
                            Console.WriteLine("Score: {0} ", myContestant.score);

                            Console.WriteLine("Press any key for next question");
                            Console.WriteLine();
                            Console.ReadKey();

                            bonusStreakPoint++;

                            if (bonusStreakPoint == 3)
                            {
                                myContestant.score = myContestant.score + 10;
                                Console.WriteLine("Wow! You just earned a Streak Bonus = Double Points");
                                bonusStreakPoint = 0;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Incorrect! The correct answer was " + myQuestion.correctAnswer1s[one]);
                            Console.WriteLine();

                            myContestant.lives--;
                            bonusStreakPoint = 0;
                            Console.WriteLine("-----------------------");
                            Console.WriteLine("| Lives Remaining: {0} |", myContestant.lives);
                            Console.WriteLine("-----------------------");

                            if (myContestant.lives == 1)
                            {
                                Warning();
                            }

                            if (myContestant.lives == 0)
                            {
                                GameOver();
                            }
                        }
                    }
                    
                    for (int two = 0; two < myQuestion.level2Qs.Length && myContestant.lives > 0; two++)
                    {
                        Console.WriteLine("  LEVEL  TWO  ");
                        Console.WriteLine(myQuestion.level2Qs[two]);
                        Console.WriteLine(myQuestion.level2As[two]);
                        Console.WriteLine();

                        Console.WriteLine("Please choose the correct answer between A and B");
                        myQuestion.answerInput = Console.ReadLine();
                        Console.WriteLine();

                        if (myQuestion.answerInput.ToUpper() == myQuestion.correctAnswer2s[two])
                        {
                            Console.WriteLine("Correct!");
                            myContestant.score = myContestant.score + 10;
                            Console.WriteLine("Score: {0} ", myContestant.score);

                            Console.WriteLine("Press any key for next question");
                            Console.WriteLine();
                            Console.ReadKey();

                            bonusStreakPoint++;

                            if (bonusStreakPoint == 3)
                            {
                                myContestant.score = myContestant.score + 20;
                                Console.WriteLine("Wow! You just earned a Streak Bonus = Double Points");
                                bonusStreakPoint = 0;
                            }
                           
                        }
                        else
                        {
                            Console.WriteLine("Incorrect! The correct answer was " + myQuestion.correctAnswer2s[two]);
                            Console.WriteLine();

                            myContestant.lives--;
                            bonusStreakPoint = 0;
                            Console.WriteLine("Lives Remaining: {0} ", myContestant.lives);

                            if (myContestant.lives == 1)
                            {
                                Warning();

                            }

                            if (myContestant.lives == 0)
                            {
                                GameOver();
                            }
                        }

                    }

                    for (int three = 0; three < myQuestion.level3Qs.Length && myContestant.lives > 0; three++)
                    {
                        Console.WriteLine("   LEVEL  THREE  ");
                        Console.WriteLine(myQuestion.level3Qs[three]);
                        Console.WriteLine(myQuestion.level3As[three]);
                        Console.WriteLine();

                        Console.WriteLine("Please choose the correct answer between A and B");
                        myQuestion.answerInput = Console.ReadLine();
                        Console.WriteLine();

                        if (myQuestion.answerInput.ToUpper() == myQuestion.correctAnswer3s[three])
                        {
                            Console.WriteLine("Correct!");
                            myContestant.score = myContestant.score + 15;
                            Console.WriteLine("Score: {0} ", myContestant.score);

                            Console.WriteLine("Press any key for next question");
                            Console.WriteLine();
                            Console.ReadKey();

                            bonusStreakPoint++;

                            if (bonusStreakPoint == 3)
                            {
                                myContestant.score = myContestant.score + 30;
                                Console.WriteLine("Wow! You just earned a Streak Bonus = Double Points");
                                bonusStreakPoint = 0;
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Incorrect! The correct answer was " + myQuestion.correctAnswer3s[three]);
                            Console.WriteLine();

                            myContestant.lives--;
                            bonusStreakPoint = 0;
                            Console.WriteLine("Lives Remaining: {0} ", myContestant.lives);

                            if (myContestant.lives == 1)
                            {
                                Warning();
                            }

                            if (myContestant.lives == 0)
                            {
                                GameOver();
                            }
                        }
                    }
                
            }
        }
            static void ExitProgram()//A method that exits the program
            {
                Console.WriteLine("=========================");
                Console.WriteLine("          GOODBYE        ");
                Console.WriteLine();
                Console.WriteLine("Press any key to close...");
                Console.WriteLine("     Have a nice day     ");
                Console.WriteLine("=========================");
                Console.WriteLine();
                Console.ReadKey();

            }


        
    }
}
