using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_02_21_MongoDb_acquaintance_project._program_data.models
{
    class KeysModel
    {
        [BsonId]  // _id
        public Guid Id { get; set; }
        [BsonElement("_DigitsKeys")]
        public List<int> NumKeysValuesList { get; set; }

    }
}
