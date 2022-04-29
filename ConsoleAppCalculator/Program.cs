using ConsoleAppCalculatorHttp;

class Program
{
    static void Main()
    {
        decimal a, b;
        string opp;
        do
        {
            Console.WriteLine("\n Enter 'z' to exit!\n Select an operation (+,-,*,/)\n".ToUpper());
            opp = Console.ReadLine();
            if (opp != "z")
            {
                Console.Write("a = ");
                a = decimal.Parse(Console.ReadLine());
                Console.Write("b = ");
                b = decimal.Parse(Console.ReadLine());
                switch (opp)
                {
                    case "+": { HttpAdapterCalculator.ResultCalc("add", a, b); }; break;
                    case "-": { HttpAdapterCalculator.ResultCalc("sub", a, b); }; break;
                    case "*": { HttpAdapterCalculator.ResultCalc("mul", a, b); }; break;
                    case "/": { HttpAdapterCalculator.ResultCalc("div", a, b); }; break;
                    default: opp = "z"; break;

                }
            }

        } while (opp != "z");
        Console.ReadLine();
    }
}