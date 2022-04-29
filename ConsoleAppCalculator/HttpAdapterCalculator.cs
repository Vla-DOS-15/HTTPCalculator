using System.Text.Json;

namespace ConsoleAppCalculatorHttp
{
    public class HttpAdapterCalculator : ICalculator
    {
        public async Task<CalculatorResult> Operation(string opp, decimal a , decimal b)
        {
            var client = new HttpClient();

            var result = await client.GetAsync($"http://localhost:65031/api/calculator?opp={opp}&a={a}&b={b}");
            if ((int)result.StatusCode == 200)
            {
                var str = await result.Content.ReadAsStringAsync();
                var calcResult = JsonSerializer.Deserialize<CalculatorResult>(str, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return calcResult;
            }
            return null;
        }
        public static async void ResultCalc(string opp, decimal a, decimal b)
        {
            HttpAdapterCalculator httpAdapter = new HttpAdapterCalculator();
            var result = await httpAdapter.Operation(opp, a, b);
            if (result != null && result.OperationResult != null)
                Console.WriteLine($"Result: {a} {Opp(opp)} {b} = {result.OperationResult:f3}");
            if (result != null && result.OperationResult == null)
                Console.WriteLine($"Result: {a} {Opp(opp)} {b} = {result.Error}");
        }
        private static string Opp(string opp)
        {
            if (opp == "add")
                opp = "+";
            else if (opp == "div")
                opp = "/";
            else if (opp == "mul")
                opp = "*";
            else if (opp == "sub")
                opp = "-";
            return opp;
        }
    }
}
