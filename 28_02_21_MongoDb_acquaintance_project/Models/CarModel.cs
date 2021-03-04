using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_02_21_MongoDb_acquaintance_project.Models
{
    class CarModel
    {
        [BsonId]  // _id
        public Guid Id { get; set; }
        [BsonElement("Manufacturer")]
        public string Manufacturer { get; set; }
        [BsonElement("LicenseNumber")]
        public string LicenseNumber { get; set; }

        [BsonElement("Drivers")]
        public List<Guid> DriverIds { get; set; }
    }
}
