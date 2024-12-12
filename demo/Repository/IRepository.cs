using demo.Repository.DTOs;

namespace demo.Repository;

public interface IRepository
{
    public Task<ProfileDTO> GetProfile();
    public Task<List<SkillDTO>> GetSkills();
    public Task<List<ProjectDTO>> GetProjects();
}