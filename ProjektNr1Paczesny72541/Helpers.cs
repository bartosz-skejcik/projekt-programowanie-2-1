namespace ProjektNr1Paczesny72541
{

    // create a type that has a success bool and a message string
    public class ValidationResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T ParsedValue { get; set; }
    }
    
    public class Helpers
    {
        public static ValidationResult<int> ValidateInt(string value)
        {
            var result = new ValidationResult<int>();
            result.Success = int.TryParse(value, out int _);
            result.Message = result.Success ? "" : "Wprowadzona wartość nie jest liczbą całkowitą";
            result.ParsedValue = result.Success ? int.Parse(value) : 0;
            return result;
        }
    }
}