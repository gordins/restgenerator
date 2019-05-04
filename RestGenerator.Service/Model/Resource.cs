using System;
using System.Collections.Generic;

namespace RestGenerator.Service.Model
{
    public class Resource
    {
        public Guid Id { get; set; }
        public Guid ApiId { get; set; }
        public string Name { get; set; }
        public List<Field> Fields { get; set; }
    }
}
