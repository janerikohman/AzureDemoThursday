using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

using Microsoft.WindowsAzure.Storage.Table;
using System.Text.Json;

namespace cybercom.com
{
    public static class jeodemoqtrigger
    {
        [FunctionName("jeodemoqtrigger")]
        [return: Queue("activitychain2")]
        public static BaseActivity Run(
            [QueueTrigger("activity", Connection = "jeo4cyberdemostorage_STORAGE")]BaseActivity myQueueItem, 
            [Table("tblActivity", Connection = "jeo4cyberdemostorage_STORAGE")] CloudTable table,
            ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem.Iatiidentifier}");

            var tabEntity = new MyEntity() {
                PartitionKey = "DZ",
                RowKey = myQueueItem.Iatiidentifier,
                Title = myQueueItem.Title,
                Activity = JsonSerializer.Serialize(myQueueItem)
            };

            TableOperation insertReplace = TableOperation.InsertOrReplace(tabEntity);
            table.ExecuteAsync(insertReplace).ConfigureAwait(true);

            return myQueueItem;
        }
    }

    public class MyEntity: TableEntity
    {
        public string Title { get; set; }
        public string Activity { get; set; }
    }

    public    class BaseActivity
    {
        public string Iatiidentifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BaseSector Sector { get; set; }
    }

    public     class BaseSector
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
