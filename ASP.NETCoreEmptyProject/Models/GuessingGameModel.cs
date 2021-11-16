﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreEmptyProject.Models
{
    public class GuessingGameModel
    {
        public int RndNum { get; set; }
        public static Random random = new Random();
        

        private int guessedNum;
        public int GuessedNum { get { return guessedNum; } set { guessedNum = value; } }

        public bool ShowResult { get; set; }
        public bool Success { get; set; }


        public static string WriteMessage()
        {
            return "Guess a Number between 1 and 100! You have 5 tries!";
        }

        public string CheckNumber(int guessedNum)
        {
            string message = "";

            bool run = true;
            int allowedTries = 5;
            int numberOfTries = 0;
           
            while (run)
            {
                int RndNum = random.Next(1, 100);
               

                while (true)
                {
                    allowedTries--;
                    numberOfTries++;

                    if (guessedNum == RndNum)
                    {
                        message = $"Your guess was correct!" + $"You used { numberOfTries} tries.";
                       
                        break;
                    }
                    else if (guessedNum > RndNum)
                    {
                        message = $"Your guess was too high." + $" You have {allowedTries} tries left. Enter another number: ";

                        break;
                    }
                    else if (guessedNum < RndNum)
                    {
                        message = $"Your guess was too low." + $" You have {allowedTries} tries left. Enter another number: ";
                        
                        break;

                    }
                    else if (guessedNum != RndNum && allowedTries == 0)
                    {
                        message = $"Game Over! The number was: {RndNum}";
                        break;
                    }
                    else
                    {
                        message = $"You have {allowedTries - numberOfTries} tries left. Enter another number: ";
                        break;
                    }
                }
               

                run = false;
            }

            return message ;
        }
        
    }
}
