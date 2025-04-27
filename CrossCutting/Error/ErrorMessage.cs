namespace CrossCutting.Error;

public static class ErrorMessage
{
    public static string GetMessage(ErrorType errorType)
    {
        switch (errorType)
        {
            case ErrorType.InvalidProfileName:
                return "Invalid user ProfileName.";
            case ErrorType.ProfileNotFound:
                return "ProfileName not found.";
            default:
                return "An error occurred. Please try again.";
        }
    }
}
