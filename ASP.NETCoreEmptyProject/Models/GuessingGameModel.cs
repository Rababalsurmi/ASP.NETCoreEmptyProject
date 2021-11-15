using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreEmptyProject.Models
{
    public class GuessingGameModel
    {
        public int RndNum { get; set; }

        [Required]
        [Range(0, 101, ErrorMessage = "The number is between 0 and 100.")]

        private int guessedNum;
        public int GuessedNum { get { return guessedNum; } set { guessedNum = value; } }

        public bool ShowResult { get; set; }
        public bool Success { get; set; }


        public static string WriteMessage()
        {
            return "Guess a number between 1 and 100";
        }

        public string CheckNumber(int guessedNum)
        {
            string message = "";

            bool run = true;
            int allowedTries = 5;
            int numberOfTries = 0;
            var random = new Random();
            

            while (run)
            {
                int RndNum = random.Next(1, 100);
                numberOfTries++;
                if (guessedNum == RndNum)
                {
                    message = "Your guess was correct!";
                    break;
                }
                else if (guessedNum > RndNum)
                {
                    message = "Your guess was too high";
                }
                else if (guessedNum < RndNum)
                {
                    message = "Your guess was too low";
                }
                else if (numberOfTries == allowedTries)
                {
                    message = $"The number was: {RndNum}";
                    break;
                }
                else
                {
                    message = $"You have {allowedTries - numberOfTries} tries left. Enter another number: ";
                }
                run = false;
            }

            return message ;
        }
        
    }
}
