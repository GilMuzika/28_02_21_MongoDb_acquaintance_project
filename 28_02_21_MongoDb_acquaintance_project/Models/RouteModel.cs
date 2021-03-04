using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_02_21_MongoDb_acquaintance_project.Models
{
    class RouteModel
    {
        [BsonId]  // _id
        public Guid Id { get; set; }
        [BsonElement("DepartureAddress")]
        public string DepartureAddress { get; set; }
        [BsonElement("DestinationAddress")]
        public string DestinationAddress { get; set; }
    }
}
