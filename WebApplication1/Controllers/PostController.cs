using Microsoft.AspNetCore.Mvc;
using project.application.Posts.Interfaces;
using project.application.Posts.Models;
using System.Net;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {

        //Tarea basada en el Proyecto Final del Grupo 1

        private readonly ILogger<PostController> _logger;
        private readonly IPostService _postService;
        public PostController(ILogger<PostController> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Post(PostCreationDto nuevopost)
        {

            try
            {
                var createdPost = await _postService.Create(nuevopost);
                return StatusCode((int)HttpStatusCode.Created, createdPost);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPut("Update")]
        public async Task<IActionResult> Update(PostReadDto post)
        {
            try
            {
                var postActualizado = await _postService.Update(post);
                return new OkObjectResult(postActualizado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var result = await _postService.Delete(id);
                return new OkObjectResult(new { deleted = result });
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest($"Could not delete post with {id}");
            }

        }
        
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var posts = await _postService.GetAll();
                return new OkObjectResult(posts);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}