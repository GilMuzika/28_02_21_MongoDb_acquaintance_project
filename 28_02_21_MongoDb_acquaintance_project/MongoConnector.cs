using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_02_21_MongoDb_acquaintance_project
{
    class MongoConnector
    {
        private IMongoDatabase _db;

        public MongoConnector(string connectionString, string databaseName)
        {
            //Create new database connection
            var client = new MongoClient(connectionString);
            _db = client.GetDatabase(databaseName);
        }

        /// <summary>
        /// Gets all the collection names in the database as strings
        /// </summary>
        /// <returns>IEnumerable<string></returns>
        public IEnumerable<string> GetAllCollectionsNames()
        {
            foreach (var item in _db.ListCollectionsAsync().Result.ToListAsync<BsonDocument>().Result)
                yield return BsonSerializer.Deserialize<BsonDocument>(item).Elements.FirstOrDefault().Value.AsString;
        }

        /// <summary>
        /// Add new document into collection
        /// </summary>
        /// <typeparam name="T">Document data type</typeparam>
        /// <param name="collectionName">Collection name</param>
        /// <param name="document">Document</param>
        public void AddDocument<T>(string collectionName, T document)
        {
            var collection = _db.GetCollection<T>(collectionName);
            collection.InsertOne(document);
        }

        /// <summary>
        /// Get all documents in collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public List<T> GetAllDocuments<T>(string collectionName)
        {
            var collection = _db.GetCollection<T>(collectionName);

            return collection.Find(new BsonDocument()).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Collection Model Type</typeparam>
        /// <param name="collectionName">Name of MongoDB collection</param>
        /// <param name="bsonElementName">Name of sought element</param>
        /// <param name="withOrWithout">Determines if the method returns all the elements that their "bsonElementName" property has a value or is null</param>
        /// <returns></returns>
        public List<T> FindAllWithOrWithout<T>(string collectionName, string bsonElementName, bool withOrWithout)
        {

            var collection = _db.GetCollection<T>(collectionName);

            FilterDefinition<T> filter = null;

            switch (withOrWithout)
            {
                case true:
                    filter = Builders<T>.Filter.Eq<List<Guid>>(bsonElementName, null);
                    break;
                case false:
                    filter = !Builders<T>.Filter.Eq<List<Guid>>(bsonElementName, null);
                    break;
            }

            return collection.Find(filter).ToList();
        }

        /// <summary>
        /// Get document by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetDocumentById<T>(string collectionName, Guid id)
        {
            var collection = _db.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("Id", id);

            return collection.Find(filter).FirstOrDefault();
        }

        /// <summary>
        /// Update document
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="id"></param>
        /// <param name="document"></param>
 
        public void UpdateDocument<T>(string collectionName, Guid id, T document)
        {
            var collection = _db.GetCollection<T>(collectionName);

            var result = collection.ReplaceOne(
                //new BsonDocument("_id", new BsonBinaryData(id)),
                new BsonDocument("_id", id),
                document,
                new ReplaceOptions { IsUpsert = true });

            
        }

        /// <summary>
        /// Add document into collection if it does not already exist, or update it if it does
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="id"></param>
        /// <param name="document"></param>
        public void AddOrUpdateDocument<T>(string collectionName, Guid id, T document)
        {
            var collection = _db.GetCollection<T>(collectionName);

            var result = collection.ReplaceOne(
                new BsonDocument("_id", new BsonBinaryData(id)),
                document,
                new ReplaceOptions { IsUpsert = true });
        }


        /// <summary>
        /// Delete document by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="id"></param>
        public void DeleteDocument<T>(string collectionName, Guid id)
        {
            var collection = _db.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("Id", id);
            collection.DeleteOne(filter);

        }










    }
}
