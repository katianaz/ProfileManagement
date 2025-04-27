using CrossCutting.Error;
using Domain.Services.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ProfileManagementApi.Controllers
{
    [ApiController]
    [Route("api/profiles")]
    public class ProfilesController(IProfileService profileService, ErrorContext errorContext) : ControllerBase
    {
        private readonly IProfileService _profileService = profileService;

        [HttpGet]
        [SwaggerOperation(Summary = "List all profiles and their parameters.")]
        [ProducesResponseType(typeof(IEnumerable<ProfileResponseDto>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ProfileResponseDto>> GetAll()
        {
            var profiles = _profileService.GetAllProfiles()
                .Select(p => new ProfileResponseDto
                {
                    ProfileName = p.Value.ProfileName,
                    Parameters = p.Value.Parameters
                });

            if (errorContext.HasError)
            {
                return StatusCode(errorContext.StatusCode, errorContext.Message);
            }

            return Ok(profiles);
        }

        [HttpGet("{profileName}")]
        [SwaggerOperation(Summary = "Get a specific profile by its name.")]
        [ProducesResponseType(typeof(ProfileResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProfileResponseDto> Get([FromRoute] string profileName)
        {
            var profile = _profileService.Get(profileName);

            if (errorContext.HasError)
            {
                return StatusCode(errorContext.StatusCode, errorContext.Message);
            }

            return Ok(profile);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new profile.")]
        [ProducesResponseType(typeof(ProfileResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add([FromBody] ProfileRequestDto request)
        {
            var response = _profileService.Add(request.ProfileName, request);

            if (errorContext.HasError)
            {
                return StatusCode(errorContext.StatusCode, errorContext.Message);
            }

            return StatusCode(StatusCodes.Status201Created, response);
        }


        [HttpPut("{profileName}")]
        [SwaggerOperation(Summary = "Update the parameters of an existing profile.")]
        [ProducesResponseType(typeof(ProfileResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update([FromRoute] string profileName, [FromBody] ProfileRequestDto request)
        {
            var response = _profileService.Get(profileName);

            _profileService.Update(profileName, request);

            if (errorContext.HasError)
            {
                return StatusCode(errorContext.StatusCode, errorContext.Message);
            }

            return Ok(response);
        }

        [HttpDelete("{profileName}")]
        [SwaggerOperation(Summary = "Delete a profile.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] string profileName)
        {
            _profileService.Delete(profileName);
            if (errorContext.HasError)
            {
                return StatusCode(errorContext.StatusCode, errorContext.Message);
            }

            return NoContent();
        }

        [HttpGet("{profileName}/validate")]
        [SwaggerOperation(Summary = "Validate if a profile has permission for a specific action.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ValidatePermission([FromRoute] string profileName, [FromBody] string action)
        {
            var isValid = _profileService.ValidatePermission(profileName, action);

            return Ok(new
            {
                ProfileName = profileName,
                Action = action,
                IsValid = isValid
            });
        }
    }
}
