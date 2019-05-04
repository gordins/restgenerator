using System;
using System.Collections.Generic;

namespace RestGenerator.Entity
{
    public class Api
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EncryptionKey { get; set; }
        public string DecryptionKey { get; set; }
        public bool IsActive { get; set; }
        public List<Resource> Resources { get; set; }
    }
}
