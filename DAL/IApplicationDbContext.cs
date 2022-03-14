using ArangoDBNetStandard.CollectionApi.Models;
using ArangoDBNetStandard.DocumentApi.Models;

namespace GraphAPI.DAL
{
    public interface IApplicationDbContext
    {
        public Task<List<Document>> GetDocumentsOfCollection<Document>(string collectionName);
        public Task<PostDocumentResponse<Document>> CreateInCollection<Document>(string collectionName, Document document);

        public Task<List<ResultType>> RunAqlQuery<ResultType>(string aqlQuery);
    }
}
