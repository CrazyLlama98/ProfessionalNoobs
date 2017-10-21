using System;
using System.Collections.Generic;
using System.Text;

namespace Symbiose.Data.Models.Application
{
    public class TaskComment : Entity
    {
        public int TaskId { get; set; }

        public int AuthorId { get; set; }

        public string Comment { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateModified { get; set; }

        public int? ReplyToId { get; set; }
    }
}
