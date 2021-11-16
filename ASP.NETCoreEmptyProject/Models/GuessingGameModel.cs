using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreEmptyProject.Models
{
    public class GuessingGameModel
    {
        public int RndNum { get; set; }
        
        public int GuessedNum { get; set; }

       

        public static string WriteGameMessage()
        {
            return "Guess a Number between 1 and 100! You have 5 tries!";
        }

        public void RandomNumber()
        {
            Random random = new Random();
            RndNum = random.Next(1, 100);
        }

        public static string CheckNumber(int guessedNum)
        {
            GuessingGameModel gmodel = new GuessingGameModel();

            int random = gmodel.RndNum;
          
            string message;

            if (guessedNum == random)
            {
                message = "Your guess was correct!";
            }
            else if (guessedNum > random)
            {
                message = "Your guess was too high.";
            }
            else if (guessedNum < random)
            {
                message = "Your guess was too low.";
            }
            else
            {
                message = "Game Over!";
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