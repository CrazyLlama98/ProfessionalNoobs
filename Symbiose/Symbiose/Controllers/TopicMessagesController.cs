using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Symbiose.Services.Interfaces;
using Symbiose.Data.Models.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Symbiose.Controllers
{
    [Route("api/[controller]")]
    public class TopicMessagesController : Controller
    {
        protected ITopicService TopicService { get; set; }

        public TopicMessagesController(ITopicService topicService)
        {
            TopicService = topicService;
        }

        // GET: /api/TopicMessages/{topicId}
        [HttpGet("{topicId}")]
        public async Task<IActionResult> GetTopicMessagesAsync(int topicId)
        {
            try
            {
                var messages = await TopicService.GetMessagesOfTopicAsync(topicId);

                if (messages.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: /api/TopicMessages/pagination/?take&skip
        [HttpGet("pagination")]
        public async Task<IActionResult> GetTopicMessagesAsync(int topicId, int take, int skip = 0)
        {
            try
            {
                
                var messages = await TopicService.Set<TopicMessage>().SkipLast(skip).Take(take).ToListAsync();

                if (messages.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST: /api/TopicMessages/AddNewMessage
        [HttpPost("AddNewMessage")]
        public async Task<IActionResult> AddNewMessage([FromBody] TopicMessage message)
        {
            try
            {
                await TopicService.AddAsync(message);
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Successful, Text = "Message Added!" });
            }
            catch
            {
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Failed, Text = "Error!" });
            }
        }

        // GET: /api/TopicMessages/Message/{id}
        [HttpGet("Message/{messageId}")]
        public async Task<IActionResult> GetMessageById(int messageId)
        {
            try
            {
                var message = TopicService.GetByIdAsync<TopicMessage>(messageId);
                if (message != null)
                {
                    return NotFound(new Utils.Models.Response { Status = Utils.Models.ResponseType.Warning, Text = "Message not found!" });
                }

                return Ok(message);
            }
            catch
            {
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Failed, Text = "Error!" });
            }
        }

        // POST: /api/TopicMessages/edit/{messageId}
        [HttpPost("edit/{messageId}")]
        public async Task<IActionResult> EditTopicMessage(int messageId, [FromBody] TopicMessage message)
        {
            try
            {
                await TopicService.UpdateAsync(messageId, message);
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Successful, Text = "Topic Message Edited!" });
            }
            catch
            {
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Failed, Text = "Error!" });
            }
        }
    }
}
