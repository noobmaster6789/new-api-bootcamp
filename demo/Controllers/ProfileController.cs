using demo.Repository;
using demo.Repository.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private const string _prefix = "api/";
        private readonly IRepository _repository;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ProfileController> _logger;

        public ProfileController(ILogger<ProfileController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        //
        // [HttpGet(Name = "GetWeatherForecast")]
        // public IEnumerable<WeatherForecast> Get()
        // {
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //         TemperatureC = Random.Shared.Next(-20, 55),
        //         Summary = Summaries[Random.Shared.sNext(Summaries.Length)]
        //     })
        //     .ToArray();
        // }

        [HttpGet(_prefix+"get-profile")]
        public async Task<ProfileDTO> GetDataProfile()
        {
            var data = await _repository.GetProfile();
            var skillList = await _repository.GetSkills();
            var projectList = await _repository.GetProjects();
            data.Skills = skillList;
            data.Projects = projectList;
            return data;
        }
    }
}
