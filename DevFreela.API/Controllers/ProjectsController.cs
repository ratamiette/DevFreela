using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET api/projects?query=netcore
        [HttpGet]
        public IActionResult GetAll(string query)
        {
            var projects = _projectService.GetAll(query);

            return Ok(projects);
        }

        // GET api/projects/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);

            if(project is null)
                return NotFound();

            return Ok(project);
        }

        // POST api/projects
        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectInputModel createProjectInputModel)
        {
            if(createProjectInputModel.Title.Length > 50)
            {
                return BadRequest();
            }

            var id = _projectService.Create(createProjectInputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, createProjectInputModel);
        }

        // PUT api/projects/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel updateProjectInputModel)
        {
            if (updateProjectInputModel.Description.Length > 200)
            {
                return BadRequest();
            }

            _projectService.Update(updateProjectInputModel);

            return NoContent();
        }

        // DELETE api/projects/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);

            return NoContent();
        }

        // POST api/projects/{id}/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentInputModel createCommentInputModel)
        {
            _projectService.CreateComment(createCommentInputModel);

            return NoContent();
        }

        // PUT api/projects/{id}/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);

            return NoContent();
        }

        // PUT api/projects/{id}/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);

            return NoContent();
        }
    }
}
