﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Symbiose.Data.Models.Application
{
    public class Topic : Entity
    {
        public int ProjectId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
