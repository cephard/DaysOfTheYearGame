/*
 *Simple console game that prompts users to input date and month
 *game has two players
 */
using DaysOfTheYear2;

public class Program 
{
    private static readonly int FIRST_DAY = 1;
    private static readonly int JANUARY = 1;
    private static readonly int FEBRUARY = 2;
    private static readonly int LAST_DAY = 31;
    private static readonly int DECEMBER = 12;
    private static readonly int MAX_PLAYER_CHOISE = 2;
    public static void Main(string[] args)
    {
    int date = FIRST_DAY;
        int month = JANUARY;
        int player = MAX_PLAYER_CHOISE;
        String inputChoice;
        String[] months = {"","January","February","March","April","May","June","July",
            "August","September","October","November","December" };


        while (date < LAST_DAY || month < DECEMBER)
        {
            // switching player 1 and 2
            if (player == MAX_PLAYER_CHOISE)
            {
                player--;
            }
            else
            {
                player++;
            }

            Console.WriteLine("The current date is " + date + GameLogic.OrdinalNumber(date)+ " of " + months[month]);
            Console.WriteLine("It's Player " + player + "'s turn, Do you want to choose date or month");
            inputChoice = GameLogic.InputCheck();


            //Making sure the users only choose date or month not just any string
            while (!inputChoice.Equals("date", StringComparison.OrdinalIgnoreCase)
                && !inputChoice.Equals("month", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Wrong choice, Please Try Again");
                inputChoice = GameLogic.InputCheck();
            }

            //inputing the date
            if (inputChoice.Equals("date", StringComparison.OrdinalIgnoreCase))
            {
                date = GameLogic.CheckDate(date, month);
            }

            //inputing the month
            else
            {
                month = GameLogic.CheckMonth(date, month);
            }

        }
        Console.WriteLine("The current date is " + date + " of " + months[month]);
        Console.WriteLine("Player " + player + " is the winner!");
    }
}
