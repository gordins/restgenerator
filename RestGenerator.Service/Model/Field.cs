using System;

namespace RestGenerator.Service.Model
{
    public class Field
    {
        public Guid Id { get; set; }
        public Guid ResourceId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public bool IsEncrypted { get; set; }
        public bool IsRequired { get; set; }
        public bool IsUnique { get; set; }
    }
}
