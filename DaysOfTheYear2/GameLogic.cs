using System;

/*
 * Class that handles all the logics of the game
 */
namespace DaysOfTheYear2
{
    public class GameLogic
    {
        private static readonly int FIRST_DAY = 1;
        private static readonly int DAYS_IN_FEBRUARY = 28;
        private static readonly int DAYS_IN_SHORT_MONTH = 30;
        private static readonly int DAYS_IN_LONG_MONTH = 31;
        private static readonly int JANUARY = 1;
        private static readonly int FEBRUARY = 2;
        private static readonly int DECEMBER = 12;
        private static readonly int[] MONTH_WITH_THIRTY_DAYS = { 4, 6, 9, 11 };
        private static readonly int[] FIRST_SPECIAL_DAY_SUFFIXES = { 1, 21, 31 };
        private static readonly int[] SECOND_SPECIAL_DAY_SUFFIXES = { 2, 22 };
        private static readonly int[] THIRD_SPECIAL_DAY_SUFFIXES= { 3, 23 };

        //checking date repeatedly until correct date is entered
        public static int CheckDate(int currentDate, int currentMonth)
        {
            Console.WriteLine("Input Date:");
            int date;
            while (!int.TryParse(Console.ReadLine(), out date) || !IsValidDate(date, currentMonth))
            {
                Console.WriteLine("Invalid date. Please input a sensible date.");
            }
            return date;
        }

        //checking month repeatedly until correct onth is entered
        public static int CheckMonth(int currentDate, int currentMonth)
        {
            Console.WriteLine("Input Month:");
            int month;
            while (!int.TryParse(Console.ReadLine(), out month) || !IsValidMonth(month))
            {
                Console.WriteLine("Invalid month. Please input a sensible month.");
            }
            return month;
        }

        //checkin gif the entered date is correct by separating based on the length of the month
        private static bool IsValidDate(int date, int month)
        {
            if (month == FEBRUARY) {
                return date >= FIRST_DAY && date <= DAYS_IN_FEBRUARY;
            } else if (Array.Exists(MONTH_WITH_THIRTY_DAYS, exisitingMonth => exisitingMonth == month))
            {
                return date >= FIRST_DAY && date <= DAYS_IN_SHORT_MONTH;
            }
            else {
                return date >= FIRST_DAY && date <= DAYS_IN_LONG_MONTH;
            }
        }

        //checking if the entered month is corect
        private static bool IsValidMonth(int month)
        {
            return month >= JANUARY && month <= DECEMBER;
        }

        // adding suffix to the dates
        public static String OrdinalNumber(int date)
        { 
            //using lambda expression
            if (Array.Exists(FIRST_SPECIAL_DAY_SUFFIXES, existingDate => existingDate == date))
            {
                return "'st";
            }else if(Array.Exists(SECOND_SPECIAL_DAY_SUFFIXES , existingDate => existingDate == date))
            {
                return "'nd";
            }
            else if (Array.Exists(THIRD_SPECIAL_DAY_SUFFIXES, existingDate => existingDate == date))
            {
                return "'rd";
            }
            else
            {
                return "'th";
            }
        }

        // making sure the input is not null
        public static String InputCheck()
        {
            String? inputChoice = Console.ReadLine();
           if(inputChoice == null)
            {
                throw new Exception("Input cannot be null!");
            }
            return inputChoice;
        }
    }
}
