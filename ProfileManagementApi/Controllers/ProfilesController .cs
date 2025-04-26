using Domain.Services.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace ProfileManagementApi.Controllers
{
    [ApiController]
    [Route("api/profiles")]
    public class ProfilesController(IProfileService profileService) : ControllerBase
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

            return Ok(profiles);
        }

        [HttpGet("{profileName}")]
        [SwaggerOperation(Summary = "Get a specific profile by its name.")]
        [ProducesResponseType(typeof(ProfileResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProfileResponseDto> Get(string profileName)
        {
            var profile = _profileService.Get(profileName);
            if (profile == null)
                return NotFound();

            var response = new ProfileResponseDto
            {
                ProfileName = profile.ProfileName,
                Parameters = profile.Parameters
            };

            return Ok(response);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new profile.")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add([FromBody] ProfileRequestDto request)
        {
            if (request == null)
                return BadRequest();

            var newProfile = new ProfileParameter
            {
                ProfileName = request.ProfileName,
                Parameters = request.Parameters
            };

            _profileService.Add(request.ProfileName, newProfile);

            return CreatedAtAction(nameof(Get), new { profileName = request.ProfileName }, newProfile);
        }


        [HttpPut("{profileName}")]
        [SwaggerOperation(Summary = "Update the parameters of an existing profile.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(string profileName, [FromBody] Dictionary<string, string> parameters)
        {
            var existing = _profileService.Get(profileName);
            if (existing == null)
                return NotFound();

            _profileService.Update(profileName, parameters);
            return NoContent();
        }

        [HttpDelete("{profileName}")]
        [SwaggerOperation(Summary = "Delete a profile.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(string profileName)
        {
            var existing = _profileService.Get(profileName);
            if (existing == null)
                return NotFound();

            _profileService.Delete(profileName);
            return NoContent();
        }

        [HttpGet("{profileName}/validate")]
        [SwaggerOperation(Summary = "Validate if a profile has permission for a specific action.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ValidatePermission(string profileName, [FromQuery] string action)
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
