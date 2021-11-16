using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreEmptyProject.Models
{
    public class GuessingGameModel
    {
        public int RndNum { get; set; }
        
        private int guessedNum;
        public int GuessedNum { get { return guessedNum; } set { guessedNum = value; } }

        public bool ShowResult { get; set; }
        public bool Success { get; set; }
        public string Message { get; set;}


        public static string WriteMessage()
        {
            return "Guess a Number between 1 and 100! You have 5 tries!";
        }

        public void RandomNumber()
        {
            Random random = new Random();
            RndNum = random.Next(1, 100);
        }

        public string CheckNumber(int guessedNum)
        {
            int allowedTries = 5;
            int numberOfTries = 0;

            string message = "";

            while (guessedNum != RndNum && allowedTries <= 5 && allowedTries >= 0)
            {
                
                allowedTries--;
                numberOfTries++;

                if (guessedNum == RndNum)
                {
                    message = $"Your guess was correct!" + $"You used { numberOfTries} tries.";
                    break;
                }
                else if (guessedNum != RndNum)
                {
                    if (guessedNum > RndNum)
                    {
                        message = $"Your guess was too high." + $" You have {allowedTries} tries left. Enter another number: ";
                        break;
                    }
                    else if (guessedNum < RndNum)
                    {
                        message = $"Your guess was too low." + $" You have {allowedTries} tries left. Enter another number: ";
                        break;
                    }
                    else
                    {
                        message = $"Game Over! The number was: {RndNum}";
                        break;
                    }
                }
            }

            return message ;
        }
        
    }
}
