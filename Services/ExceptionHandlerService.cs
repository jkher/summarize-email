class ExceptionHandlerService
{
    public static void HandleException(string errorCode, string errorMessage)
    {
        Console.WriteLine($"ERROR : {errorCode} - {errorMessage}");
    }
}