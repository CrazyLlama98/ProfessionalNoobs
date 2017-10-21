using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Symbiose.Services;
using Symbiose.Data.Models.Application;
using Symbiose.Services.Interfaces;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Symbiose.Controllers
{
    [Route("api/[controller]")]
    public class TopicsController : Controller
    {
        protected ITopicService TopicService { get; set; }

        public TopicsController(TopicService topicService)
        {
            TopicService = topicService;
        }

        // GET: /api/topics
        [HttpGet]
        public async Task<IActionResult> GetTopicsAsync()
        {
            try
            {
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
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                return Ok(topic);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //POST: /api/topics
        [HttpPost("AddNewTopic")]
        public async Task<IActionResult> AddNewTopic([FromBody] Topic topic)
        {
            try
            {
                await TopicService.AddAsync<Topic>(topic);
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Successful, Text = "Topic Added!" });
            }
            catch
            {
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Failed, Text = "Error!" });
            }
        }
    }
}
