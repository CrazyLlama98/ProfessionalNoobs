using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Symbiose.Services;
using Symbiose.Data.Models.Application;
using Symbiose.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Symbiose.Controllers
{
    [Route("api/[controller]")]
    public class TopicsController : Controller
    {
        protected ITopicService TopicService { get; set; }

        public TopicsController(ITopicService topicService)
        {
            TopicService = topicService;
        }

        // GET: /api/topics
        [HttpGet]
        public async Task<IActionResult> GetTopicsAsync()
        {
            try
            {
                var topics = await TopicService.GetAllAsync<Topic>();
                if (topics.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(await TopicService.GetAllAsync<Topic>());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: /api/topics/{topicId}
        [HttpGet("{topicId}")]
        public async Task<IActionResult> GetTopicById(int topicId)
        {
            try
            {
                var topic = await TopicService.GetByIdAsync<Topic>(topicId);
                if (topic == null)
                {
                    return NotFound();
                }

                return Ok(topic);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //POST: /api/topics/AddNewTopic
        [HttpPost("AddNewTopic")]
        public async Task<IActionResult> AddNewTopic([FromBody] Topic topic)
        {
            try
            {
                await TopicService.AddAsync(topic);
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Successful, Text = "Topic Added!" });
            }
            catch
            {
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Failed, Text = "Error!" });
            }
        }

        // GET: /api/topics/pagination?take&skip
        [HttpGet("pagination")]
        public async Task<IActionResult> GetTopicsAsync(int take, int skip = 0)
        {
            try
            {
                var topics = await TopicService.Set<Topic>().Skip(skip).Take(take).ToListAsync();
                if (topics.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(topics);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST: /api/Topics/edit/{topicId}
        [HttpPost("edit/{messageId}")]
        public async Task<IActionResult> EditTopic(int topicId, [FromBody] Topic topic)
        {
            try
            {
                await TopicService.UpdateAsync(topicId, topic);
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Successful, Text = "Topic Edited!" });
            }
            catch
            {
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Failed, Text = "Error!" });
            }
        }

    }
}
