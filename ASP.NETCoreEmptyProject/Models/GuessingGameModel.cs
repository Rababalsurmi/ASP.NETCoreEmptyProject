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

        //public void GetGuessNumber()
        //{
        //    var random = new Random();
        //    RndNum = random.Next(1, 100);
        //}

        public string CheckNumber(int guessedNum)
        {
            var random = new Random();
            int RndNum = random.Next(1, 100);

            int win = 5;
            int guess = 1;

            string message = "You are Awesome!" ;

            while (win <= 5)
            {
                if (guessedNum == RndNum)
                {
                    if (guess == 1)
                    {
                        message = "wow In 1st chance you got the number";
                    }
                    else
                        message = "you got the number and no of chance you took are " + guess;
                    break;
                }
                else if(guessedNum < RndNum)
                {
                    message = "Too Low and number of guesses left are " + (5 - guess);
                }
                else if(guessedNum > RndNum)
                {
                    message = "Too High and number of guesses left are " + (5 - guess);
                }
                guess++;

               

                break;
            }
            if (guess == 6)
            {
                message = "You loose,Correct Guess is " + RndNum;
            }
            return message;
        }  

        //    while (guessedNum != RndNum)
        //    {
        //         if (guessedNum < RndNum)
        //         {
        //            message = "Too Low !";
        //         }
        //        else
        //        {
        //            message = "Too High !";
        //        }

        //    }
        //    return message;
        //}

    }
}
