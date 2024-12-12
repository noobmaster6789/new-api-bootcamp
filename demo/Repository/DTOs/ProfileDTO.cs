namespace demo.Repository.DTOs;

public class ProfileDTO
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public List<SkillDTO> Skills { get; set; }
    public List<ProjectDTO> Projects { get; set; }
}