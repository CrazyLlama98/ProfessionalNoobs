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
    class TopicService : GenericDbService, ITopicService
    {
        public TopicService(SymbioseContext context)
            : base(context)
        { }

        public IQueryable<Topic> GetTopicsOfProject(int projectId)
        {
            return Context.Set<Topic>().Where(p => p.ProjectId == projectId);
        }

        public IQueryable<TopicMessage> GetMessagesOfTopic(int topicId)
        {
            return Context.Set<TopicMessage>().Where(p => p.TopicId == topicId);
        }
    }
}
