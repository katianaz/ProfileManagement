namespace CrossCutting.Error;

public static class ErrorMessage
{
    public static string GetMessage(ErrorType errorType)
    {
        switch (errorType)
        {
            case ErrorType.InvalidProfileName:
                return "Invalid profile name.";
            case ErrorType.ActionNotFoundForProfile:
                return "Action for profile not found.";
            case ErrorType.ProfileNotFound:
                return "Profile not found.";
            default:
                return "An error occurred. Please try again.";
        }
    }
}
