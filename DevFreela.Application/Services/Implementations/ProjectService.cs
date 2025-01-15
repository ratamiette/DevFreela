﻿using Dapper;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;
        public ProjectService(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }
        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _dbContext.Projects;

            var projectsViewModel = projects.Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt)).ToList();

            return projectsViewModel;
        }
        public ProjectDetailsViewModel? GetById(int id)
        {
            var project = _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefault(p => p.Id == id);

            if (project is null)
                return null;

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.FullName,
                project.Freelancer.FullName
            );

            return projectDetailsViewModel;
        }

        // migrated to CQRS
        //public int Create(CreateProjectInputModel inputModel)
        //{
        //    var project = new Project(inputModel.Title, inputModel.Description, inputModel.ClientId, inputModel.FreelancerId, inputModel.TotalCost);

        //    _dbContext.Projects.Add(project);
        //    _dbContext.SaveChanges();

        //    return project.Id;
        //}

        // migrated to CQRS
        //public void CreateComment(CreateCommentInputModel inputModel)
        //{
        //    var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);

        //    _dbContext.ProjectComments.Add(comment);
        //    _dbContext.SaveChanges();
        //}

        // migrated to CQRS
        //public void Update(UpdateProjectInputModel inputModel)
        //{
        //    var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

        //    project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);

        //    _dbContext.SaveChanges();
        //}

        // migrated to CQRS
        //public void Start(int id)
        //{
        //    var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

        //    project.Start();

        //    // using EF Core
        //    //_dbContext.SaveChanges();

        //    // using Dapper
        //    using (var sqlConnection = new SqlConnection(_connectionString))
        //    {
        //        sqlConnection.Open();

        //        var statementSql = "UPDATE Projects SET Status = @status, StartedAt = @startedat WHERE Id = @id";

        //        sqlConnection.Execute(statementSql, new { status = project.Status, startedat = project.StartedAt, id });
        //    }
        //}

        // migrated to CQRS
        //public void Finish(int id)
        //{
        //    var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

        //    project.Finish();

        //    _dbContext.SaveChanges();
        //}

        // migrated to CQRS
        //public void Delete(int id)
        //{
        //    var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

        //    project.Cancel();

        //    _dbContext.SaveChanges();
        //}
    }
}
