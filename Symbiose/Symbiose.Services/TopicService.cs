using Microsoft.EntityFrameworkCore;
using Symbiose.Data;
using Symbiose.Data.Models.Application;
using Symbiose.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiose.Services
{
    public class TopicService : GenericDbService, ITopicService
    {
        public TopicService(SymbioseContext context)
            : base(context)
        { }

        public IQueryable<Topic> GetTopicsOfProject(int projectId)
        {
            return Context.Set<Topic>().Where(p => p.ProjectId == projectId);
        }

        public async Task<IEnumerable<TopicMessage>> GetMessagesOfTopicAsync(int topicId)
        {
            return await Context.Set<TopicMessage>().Where(p => p.TopicId == topicId).ToListAsync();
        }
    }
}
