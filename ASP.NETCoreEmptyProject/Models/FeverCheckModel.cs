using System;
namespace ASP.NETCoreEmptyProject.Models
{
    public class FeverCheckModel
    {
        public string Name { get; set; }

        public float Temperature { get; set; }

        public static string WriteMessage()
        {
            return "Please enter your name and temperature!";
        }

        public string CheckTemperature(float temperature)
        {
            string message;

            if (temperature >= 38.5)
            {
                message = "You have Fever!";
            }
            else
            {
                message = "Your  temperature is normal!";
            }
            return message;

        }
    }
}
