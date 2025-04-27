using Domain.Services.Interfaces;
using Domain.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Domain.Services
{
    public class ProfileBackgroundService(IServiceScopeFactory scopeFactory, ILogger<ProfileBackgroundService> logger) : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory = scopeFactory;
        private readonly ILogger<ProfileBackgroundService> _logger = logger;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("ProfileBackgroundService started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var profileService = scope.ServiceProvider.GetRequiredService<IProfileService>();

                    var profiles = profileService.GetAllProfiles();

                    foreach (var profile in profiles)
                    {
                        if (profile.Value.Parameters.TryGetValue("CanEdit", out string value))
                        {
                            bool currentValue = bool.Parse(value);
                            profile.Value.Parameters["CanEdit"] = (!currentValue).ToString();
                            _logger.LogInformation("Profile {ProfileName}: CanEdit changed to {NewValue}.", profile.Key, (!currentValue).ToString());
                        }

                        var profileRequest = new UpdateProfileRequestDto
                        {
                            Parameters = profile.Value.Parameters
                        };

                        profileService.Update(profile.Key, profileRequest);
                    }
                }

                _logger.LogInformation("ProfileBackgroundService completed update at {Time}.", DateTimeOffset.Now);

                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }
}
