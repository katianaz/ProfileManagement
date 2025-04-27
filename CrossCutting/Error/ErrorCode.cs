using Microsoft.AspNetCore.Http;

namespace CrossCutting.Error;

public static class ErrorCode
{
    public static int GetStatusCode(ErrorType errorType)
    {
        switch (errorType)
        {
            case ErrorType.ProfileNotFound:
                return StatusCodes.Status404NotFound;

            case ErrorType.InvalidProfileName:
                return StatusCodes.Status400BadRequest;
            default:
                return StatusCodes.Status500InternalServerError;
        }
    }
}
