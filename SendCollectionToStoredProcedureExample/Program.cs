using System;

namespace SendCollectionToStoredProcedureExample
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseContext db = new BaseContext("localhost");
            var db1New = db.setDatabase("MOE");
  
            var sql = "usp_GameAction_{GameProviderCode}_GetUnprocessedBetData {0},{1}";
            var result = db.Database.SqlQuery<PlayerData>(sql, SearchParameter);

        }
    }

    class PlayerData
    {
        public Guid Id { get; set; }
        public string name { get; set; }
    }
}
