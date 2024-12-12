using System.Data;
using Dapper;
using demo.Database;
using demo.Repository.DTOs;

namespace demo.Repository;

public class Repository: IRepository
{
    private readonly IDapperDbConnection _dapperDbConnection;

    public Repository(IDapperDbConnection dbConnection)
    {
        _dapperDbConnection = dbConnection;
    }
    public async Task<ProfileDTO> GetProfile()
    {
        string sql = @"SELECT name, phoneNumber, email, skills from [Profile]";
        using(IDbConnection db = _dapperDbConnection.CreateConnection())
        {
            var data= await db.QueryAsync<ProfileDTO>(sql);
            return data.FirstOrDefault();
        }   
    }
    public async Task<List<SkillDTO>> GetSkills()
    {
        string sql = @"SELECT icon, name from MasterData where type = 'skills'";
        using(IDbConnection db = _dapperDbConnection.CreateConnection())
        {
            var data= await db.QueryAsync<SkillDTO>(sql);
            return data.ToList();
        }   
    }

    public async Task<List<ProjectDTO>> GetProjects()
    {
        string sql = @"SELECT * from  Projects";
        using (IDbConnection db = _dapperDbConnection.CreateConnection())
        {
            var data = await db.QueryAsync<ProjectDTO>(sql);
            return data.ToList();
        }
    }
}