using Symbiose.Data.Models.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiose.Services.Interfaces
{
    interface ITopicService : IGenericDbService
    {
        IQueryable<Topic> GetTopicsOfProject(int projectId);

        IQueryable<TopicMessage> GetMessagesOfTopic(int topicId);
    }
}
