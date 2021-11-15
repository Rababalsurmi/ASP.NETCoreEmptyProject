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

        public static string CheckTemperature(string name, float temperature)
        {
            var fc = new FeverCheckModel();
            fc.Name = name;
            string message;

            if (temperature >= 37.5)
            {
                message = name + " " + "You have Fever! You need to see your doctor!";
            }
            else if (temperature <= 37 && temperature >= 35)
            {
                message = name + " " + "Your temperature is Normal!";
            }
            else if (temperature <= 34.5 && temperature >= 32)
            {
                message = name + " " + "Your temperature is below average, You have Mild Hypothermia!";
            }
            else if (temperature <= 31 && temperature >= 28)
            {
                message = name + " " + "Your temperature is below average, You have moderate Hypothermia!";
            }
            else if (temperature <= 27)
            {
                message = name + " " + "You have severe Hypothermia! You need to see your doctor!";
            }
            else
            {
                message = name + " " + "Re-enter your temperature!";
            }
            return message;
            

        }
    }
}
