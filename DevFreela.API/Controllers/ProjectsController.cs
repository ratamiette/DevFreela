using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly OpeningTimeOption _openingTimeOption;
        public ProjectsController(IOptions<OpeningTimeOption> openingTimeOption)
        {
            _openingTimeOption = openingTimeOption.Value;
        }

        // GET api/projects
        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok();
        }

        // GET api/projects/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //return NotFound();

            return Ok();
        }

        // POST api/projects
        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel createProjectModel)
        {
            if(createProjectModel.Title.Length > 50)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { id = createProjectModel .Id }, createProjectModel);
        }

        // PUT api/projects/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProjectModel)
        {
            if (updateProjectModel.Description.Length > 200)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // POST api/projects/{id}/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentModel createCommentModel)
        {
            return NoContent();
        }

        // PUT api/projects/{id}/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        // PUT api/projects/{id}/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            return NoContent();
        }
    }
}
