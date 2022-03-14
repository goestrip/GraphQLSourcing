using ArangoDBNetStandard;
using ArangoDBNetStandard.CollectionApi.Models;
using ArangoDBNetStandard.DocumentApi.Models;
using ArangoDBNetStandard.Transport.Http;

namespace GraphAPI.DAL
{
    public class ApplicationDbContext: IApplicationDbContext
    {
        private readonly ILogger<ApplicationDbContext> m_logger;
        private readonly ArangoDBClient m_dbClient;

        public ApplicationDbContext(ILogger<ApplicationDbContext> logger)
        {
            m_logger = logger;

            m_logger.LogInformation("Db initialized");

            var transport = HttpApiTransport.UsingBasicAuth(
                            new Uri("http://graphDb:8529"),
                            "GraphApiDb",
                            "graphApiUser",
                            "123456");
            m_dbClient = new ArangoDBClient(transport);
           
        }


        public async Task<List<Document>> GetDocumentsOfCollection<Document>(string collectionName)
        {
            try
            {
                var response = await m_dbClient.Cursor.PostCursorAsync<Document>(
                        $@"FOR doc IN {collectionName} 
                          RETURN doc");
                return response.Result.ToList();
            }
            catch (Exception e)
            {
                m_logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<PostDocumentResponse<Document>?> CreateInCollection<Document>(string collectionName, Document document)
        {
            try
            {
                var response = await m_dbClient.Document.PostDocumentAsync(collectionName, document);
                return response;
            }
            catch (Exception e)
            {
                m_logger.LogError(e.Message);
                return null;
            }
        }


        public async Task<List<ResultType>>RunAqlQuery<ResultType>(string aqlQuery)
        {
            var response = await m_dbClient.Cursor.PostCursorAsync<ResultType>(aqlQuery);
            return response.Result.ToList();
        }
    }
}
