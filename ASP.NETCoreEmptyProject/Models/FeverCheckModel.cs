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

            if (temperature >= 37.5)
            {
                message = Name + " " + "You have Fever! You need to see your doctor!";
            }
            else if (temperature <= 35 && temperature >= 32)
            {
                message = Name + " " + "You temperature is below average, You have Mild Hypothermia!";
            }
            else if (temperature <= 27)
            {
                message = Name + " " + "You have severe Hypothermia! You need to see your doctor!";
            }
            else if(temperature >= 35.5 && temperature == 37)
            {
                message = Name + " " + "Your temperature is normal!";
            }
            else
            {
                message = Name + " " + "Re-enter your temperature!";
            }
            return message;
            

        }
    }
}
