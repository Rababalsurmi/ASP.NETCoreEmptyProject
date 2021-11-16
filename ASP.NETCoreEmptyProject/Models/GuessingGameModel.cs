using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreEmptyProject.Models
{
    public class GuessingGameModel
    {
        public int RndNum { get; set; }
        
        
        public int GuessedNum { get; set; }

        public bool ShowResult { get; set; }

        public bool Success { get; set; }



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
            GuessedNum = guessedNum;

            int allowedTries = 5;
            int numberOfTries = 0;
            
            string message;

            allowedTries--;
            numberOfTries++;


            if (guessedNum == RndNum)
            {
                message = $"Your guess was correct!" + $"You used { numberOfTries} tries.";
            }
            else if (guessedNum > RndNum)
            {
                message = $"Your guess was too high." + $" You have {allowedTries} tries left. Enter another number: ";
            }
            else
            {
                message = $"Your guess was too low." + $" You have {allowedTries} tries left. Enter another number: ";
            }

            return message;
        }
    }
}






//    //while (running)
//    //{

//    //    allowedTries--;
//    //    numberOfTries++;

//    //    if (guessedNum == RndNum)
//    //    {
//    //        message = $"Your guess was correct!" + $"You used { numberOfTries} tries.";
//    //        running = false;
//    //    }
//    //    else if (guessedNum > RndNum)
//    //    {
//    //        message = $"Your guess was too high." + $" You have {allowedTries} tries left. Enter another number: ";
//    //        break;
//    //    }
//    //    else if (guessedNum < RndNum)
//    //    {
//    //        message = $"Your guess was too low." + $" You have {allowedTries} tries left. Enter another number: ";
//    //        break;
//    //    }
//    //    else
//    //    {
//    //        message = $"Game Over! The number was: {RndNum}";
//    //        running = false;
//    //    }
//    //}