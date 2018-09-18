using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SendCollectionToStoredProcedureExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            var context = new BaseContext();
            var db = context.setDatabase("duran");

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@playerDataType", SqlDbType.Structured)
                {
                    Value = GetDataTable(),
                    TypeName = "PlayerDataType"
                },
            };

            var sql = "dbo.usp_PlayerData_GetPlayerData @playerDataType";
            var result = await db.Database.SqlQuery<PlayerData>(sql, parameters).ToArrayAsync();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Id}:{item.Name}");
            }
        }

        private static DataTable GetDataTable()
        {
            var playerDataType = new DataTable();
            playerDataType.Columns.Add("Id", typeof(Guid));
            playerDataType.Rows.Add(Guid.NewGuid());
            playerDataType.Rows.Add(Guid.NewGuid());
            return playerDataType;
        }
    }

    class PlayerData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
