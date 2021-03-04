using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_02_21_MongoDb_acquaintance_project.Models
{
    public class DriverModel
    {
        [BsonId]  // _id
        public Guid Id { get; set; }
        [BsonElement("FirstName")]
        public string FirstName { get; set; }
        [BsonElement("Lastname")]
        public string Lastname { get; set; }
        [BsonElement("IdentityNumber")]
        public string IdentityNumber { get; set; }
        [BsonElement("Image")]
        public byte[] Image { get; set; }

        [BsonElement("Cars")]
        public List<Guid> CarIds { get; set; }
        [BsonElement("Routes")]
        public List<Guid> RouteIds { get; set; }
    }
}
