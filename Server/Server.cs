using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Server
{
    [ServiceContract]
    public interface ITransferObject
    {
        [OperationContract]
        List<string> ShowAllTables();
        [OperationContract]
        DataTable GetTable(string tableChoosenName);
        [OperationContract]
        void AddOwner(string[] ownerTable);
        [OperationContract]
        void AddPet(string[] petsTable);
    }

    [DataContract]
    public class TransferObject : ITransferObject
    {
        public SqlConnection Connection { get; set; }
        public TransferObject()
        {
            string connectionString = "Data Source=H3LM3T\\SQLEXPRESS;Initial Catalog=PetClinicVitakor;Integrated Security=True";
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }


        public List<string> ShowAllTables()
        {
            List<string> tableNames = new List<string>();
            DataTable databaseSchema = Connection.GetSchema("Tables");
            foreach (DataRow row in databaseSchema.Rows)
            {
                tableNames.Add(row["TABLE_NAME"].ToString());
            }
            return tableNames;
        }

        [OperationBehavior]
        public DataTable GetTable(string tableChoosenName)
        {
            string query = $"SELECT * FROM {tableChoosenName}";
            DataTable dataTable = new DataTable("choosenTable");
            using (SqlCommand getTable = new SqlCommand(query, Connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(getTable);
                adapter.Fill(dataTable);
            }
            return dataTable;
        }

        public void AddOwner(string[] ownersTable)
        {
            string insertData = "INSERT INTO Owners VALUES (@value1, @value2, @value3, @value4)";
            SqlCommand insertCommand = new SqlCommand(insertData, Connection);

            insertCommand.Parameters.AddWithValue("@value1", ownersTable[0]);
            insertCommand.Parameters.AddWithValue("@value2", ownersTable[1]);
            insertCommand.Parameters.AddWithValue("@value3", ownersTable[2]);
            insertCommand.Parameters.AddWithValue("@value4", ownersTable[3]);

            insertCommand.ExecuteNonQuery();
        }

        public void AddPet(string[] petsTable)
        {
            string insertData = "INSERT INTO Animals VALUES (@value1, @value2, @value3, @value4, @value5)";
            SqlCommand insertCommand = new SqlCommand(insertData, Connection);

            insertCommand.Parameters.AddWithValue("@value1", petsTable[0]);
            insertCommand.Parameters.AddWithValue("@value2", petsTable[1]);
            insertCommand.Parameters.AddWithValue("@value3", petsTable[2]);
            insertCommand.Parameters.AddWithValue("@value4", petsTable[3]);
            insertCommand.Parameters.AddWithValue("@value5", petsTable[4]);

            insertCommand.ExecuteNonQuery();
        }
    }

    class Server
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server is running...");
            var serviceAddress = "127.0.0.1:10000";
            var serviceName = "MyService";

            var host = new ServiceHost(typeof(TransferObject), new Uri($"net.tcp://{serviceAddress}/{serviceName}"));
            var serverBinding = new NetTcpBinding();
            host.AddServiceEndpoint(typeof(ITransferObject), serverBinding, "");
            host.Open();

            Console.ReadKey();
        }
    }
}