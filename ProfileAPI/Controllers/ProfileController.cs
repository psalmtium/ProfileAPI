using Microsoft.AspNetCore.Mvc;
using ProfileAPI.Models;
using System.Text.Json;

[ApiController]
[Route("")]
public class ProfileController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ProfileController> _logger;

    public ProfileController(IHttpClientFactory httpClientFactory, ILogger<ProfileController> logger)
    {
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.Timeout = TimeSpan.FromSeconds(5);
        _logger = logger;
    }

    [HttpGet("me")]
    public async Task<ActionResult<ProfileResponse>> GetProfile()
    {
        try
        {
            string catFact = await FetchCatFact();

            var response = new ProfileResponse
            {
                Status = "success",
                User = new UserInfo
                {
                    Email = "samuelakinyemi.f@gmail.com",
                    Name = "Samuel Akinyemi",
                    Stack = "C#/ASP.NET Core"
                },
                Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd THH:mm:ss.fffZ"),
                Fact = catFact
            };

            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching profile");
            return StatusCode(500, new { status = "error", message = "Failed to fetch profile data" });
        }
    }

    private async Task<string> FetchCatFact()
    {
        try
        {
            var response = await _httpClient.GetStringAsync("https://catfact.ninja/fact");
            var catFactResponse = JsonSerializer.Deserialize<CatFactResponse>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return catFactResponse?.Fact ?? "Cats sleep 70% of their lives.";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to fetch cat fact");
            return "Cats sleep 70% of their lives.";
        }
    }
}