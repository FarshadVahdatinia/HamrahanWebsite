using System;

namespace SadrTools.CommonMethods
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringMethods
    {
        // cheat sheet 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public static string ReturnFullName(string firstName , string lastName)
        {
            return firstName + " " + lastName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="seprator"></param>
        /// <returns></returns>
        public static string ReturnFullName(string firstName, string lastName, char seprator)
        {
            return firstName + seprator + lastName;
        }

        public static string MakeItPascal(string word)
        {
            return word.Substring(0, 1).ToUpper() +
                   word.Substring(1).ToLower();
        }

        public static string MakeAbbreviation(string firstName , string lastName )
        {
            return firstName[0].ToString().ToUpper() +
                "." + lastName.Substring(0, 1).ToUpper();
        }

        public static string MakeAbbreviation(string firstName, string lastName , char seprator)
        {
            return firstName[0].ToString().ToUpper() +
                seprator + lastName.Substring(0, 1).ToUpper();
        }


        public static string Help1(string number)
        {
            if (number.Length == 1)
                return "*";

            var length = number.Length;

            var half = length / 2;

            char[] letters = number.ToCharArray();
         
            for (int i = 0; i < half; i++)
                letters[i] = '*';
            
            return new string(letters);
        }

        public static string GetFileName(string name , string ext = ".txt")
        {
            return name + ext;
        }
    }

}
