using Domain.ViewModels;
using Repository.Entities;

namespace Domain.Helpers.Mappers
{
    public static class ProfileMappers
    {
        public static ProfileResponseDto ToResponseDto(this ProfileParameter profileModel)
        {
            return new ProfileResponseDto
            {
                ProfileName = profileModel.ProfileName,
                Parameters = profileModel.Parameters
            };
        }
        public static ProfileParameter ToModel(this ProfileRequestDto request)
        {
            return new ProfileParameter
            {
                ProfileName = request.ProfileName,
                Parameters = request.Parameters
            };
        }

        public static ProfileParameter ToModel(this UpdateProfileRequestDto request)
        {
            return new ProfileParameter
            {
                Parameters = request.Parameters
            };
        }
    }
}
