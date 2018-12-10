using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace phone_number
{
    class Program
    {
        static void Main(string[] args)
        {
            // get phone number and then write it out properly formatted
            Console.Write("Input phone number: ");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine(formatPhone(phoneNumber));
        }
        static string formatPhone(string unusable)
        {
            // delete all non numberic characters
            string numbers = Regex.Replace(unusable, "[^.0-9]", "");
            //set formated phone number as blank
            string phone = "";
            //check for country code or raise exception if the numbers aren't right
            if (numbers.Length == 11) {
                phone = "+" + numbers[0] +" ";
                //remove country code so that the rest of the parsing code runs
                numbers = numbers.Remove(0, 1);

            } else if(numbers.Length != 10) {
                throw new System.ArgumentException("Phone number cannot be parsed");
            }
            // format phone number by using sub strings
            phone += "(" + numbers.Substring(0, 3) +") " +numbers.Substring(3, 3)+ "-"+numbers.Substring(6);

            return phone;
        }
    }
}
