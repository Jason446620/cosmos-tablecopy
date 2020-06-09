using System;
using System.Collections.Generic;

namespace CosmosTableSamples
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Cosmos.Table;
    using Model;

    class AdvancedSamples
    {
        public async Task RunSamples()
        {
            Console.WriteLine("Azure Cosmos DB Table - Advanced Samples\n");
            Console.WriteLine();

            string tableName = "demo" + Guid.NewGuid().ToString().Substring(0, 5);

            // Create or reference an existing table
            //source table name
            tableName = "Customer";
            string destinationtablename = "demo" + Guid.NewGuid().ToString().Substring(0, 5);

            CloudTable sourcetable = await Common.CreateTableAsync(tableName);
            CloudTable desttable = await Common.CreateTableAsync(destinationtablename);

            try
            {
                List<CustomerEntity> listSource = sourcetable.ExecuteQuery(new TableQuery<CustomerEntity>()).ToList();
                foreach (CustomerEntity item in listSource)
                {
                    await AddEntity(desttable,item);
                }

            }
            finally
            {

            }
        }
        private static async Task BasicDataOperationsAsync(CloudTable table)
        {
            // Create an instance of a customer entity. See the Model\CustomerEntity.cs for a description of the entity.
            CustomerEntity customer = new CustomerEntity("Jason", "Pan")
            {
                Email = "jasonp@contoso.com",
                PhoneNumber = "425-555-0145",
                Age=20
            };

            // Demonstrate how to insert the entity
            Console.WriteLine("Insert an Entity.");
            await SamplesUtils.InsertOrMergeEntityAsync(table, customer);
        }
        private static async Task AddEntity(CloudTable table, CustomerEntity entity)
        {
            Console.WriteLine("Insert an Entity.");
            await SamplesUtils.InsertOrMergeEntityAsync(table, entity);
        }
    }
}
