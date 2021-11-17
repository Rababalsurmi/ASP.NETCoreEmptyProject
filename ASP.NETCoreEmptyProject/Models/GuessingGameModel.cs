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
                return "Guess a Number between 1 and 100!";
            }

            public void RandomNumber()
            {
                Random random = new Random();
                RndNum = random.Next(1, 100);
            }

            public string Success()
            {
                string message = "Your guess was correct!";

                return message;
            }

            public string WasLow()
            {
                string message = "Your guess was too low!";

                return message;
            }

            public string WasHigh()
            {
                string message = "Your guess was too High!";

                return message;
            }

           
        
    }
}
