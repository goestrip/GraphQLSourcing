using EventStore.Client;
using System.Text.Json;

namespace GraphAPI.DAL.EventStore
{

    public class EventStoreContext
    {
        private EventStoreClient m_client;
        private readonly ILogger<EventStoreContext> m_logger;

        public EventStoreContext(IConfiguration config, ILogger<EventStoreContext> logger)
        {
            m_logger = logger;
            string? eventDBConnectionString = config.GetConnectionString("eventStore.db");
            if(eventDBConnectionString is not null)
            {
                var settings = EventStoreClientSettings.Create(eventDBConnectionString);
                m_client = new EventStoreClient(settings);

                SendTimeEvent();
            }
            else throw new ArgumentNullException("eventDBConnectionString");
        }

        public async void SendTimeEvent()
        {
            try
            {
                var evt = new StartupEvent();
                var eventData = new EventData(
                    Uuid.NewUuid(),
                    "StartupEvent",
                    JsonSerializer.SerializeToUtf8Bytes(evt));

                await m_client.AppendToStreamAsync("startupStream",
                    StreamState.Any,
                    new[] { eventData });
            }
            catch (Exception e)
            {
                m_logger.LogError(message: e.Message);
                //throw;
            }
          
        }


        private class StartupEvent
        {
            public DateTime StartupDate { get; set; } = DateTime.Now;
        }
    }
}
