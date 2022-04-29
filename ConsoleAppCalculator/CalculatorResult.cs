using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ConsoleAppCalculatorHttp
{
    public class CalculatorResult
    {
        public decimal? OperationResult { get; set; }
        public string? Error { get; set; }
    }
}
