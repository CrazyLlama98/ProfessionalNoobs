using System;
using System.Collections.Generic;
using System.Text;

namespace Symbiose.Data.Models.Application
{
    public class TopicMessage : Entity
    {
        public int TopicId { get; set; }

        public int AuthorId { get; set; }

        public string Message { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateModified { get; set; }

        public int? ReplyToId { get; set; }
    }
}
