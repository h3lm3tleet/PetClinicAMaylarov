using Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using System.Threading;

namespace Client
{
    class Client
    {
        static void Main(string[] args)
        {
            Thread.Sleep(500);
            var serviceAddress = "127.0.0.1:10000";
            var serviceName = "MyService";

            Uri tcpUri = new Uri($"net.tcp://{serviceAddress}/{serviceName}");
            EndpointAddress address = new EndpointAddress(tcpUri);
            NetTcpBinding clientBinding = new NetTcpBinding();
            ChannelFactory<ITransferObject> factory = new ChannelFactory<ITransferObject>(clientBinding, address);
            var service = factory.CreateChannel();

            while (true)
            {
                {
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("1. Вывести список всех таблиц");
                    Console.WriteLine("2. Вывести всю таблицу");
                    Console.WriteLine("3. Добавить клиента - требуется перед добавлением питомца");
                    Console.WriteLine("4. Добавить питомца");
                    Console.WriteLine(new String('-', 50));
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            List<string> tableNames = service.ShowAllTables();
                            foreach (string tableName in tableNames)
                            {
                                Console.WriteLine(tableName);
                            }
                            break;

                        case 2:
                            Console.WriteLine("Введите название таблицы: ");
                            string tableChoosenName = Console.ReadLine();
                            DataTable dataTable = service.GetTable(tableChoosenName);
                            int[] columnWidths = new int[dataTable.Columns.Count];
                            for (int i = 0; i < dataTable.Columns.Count; i++)
                            {
                                columnWidths[i] = dataTable.Columns[i].ColumnName.Length;
                                foreach (DataRow row in dataTable.Rows)
                                {
                                    if (row[i].ToString().Length > columnWidths[i])
                                    {
                                        columnWidths[i] = row[i].ToString().Length;
                                    }
                                }
                            }

                            for (int i = 0; i < dataTable.Columns.Count; i++)
                            {
                                Console.Write(dataTable.Columns[i].ColumnName.PadRight(columnWidths[i] + 2));
                            }
                            Console.WriteLine();

                            foreach (DataRow row in dataTable.Rows)
                            {
                                for (int i = 0; i < dataTable.Columns.Count; i++)
                                {
                                    Console.Write(row[i].ToString().PadRight(columnWidths[i] + 2));
                                }
                                Console.WriteLine();
                            }
                            break;
                        case 3:
                            {
                                Console.WriteLine(" Введите значения для таблицы Owners, разделенные запятыми: \n " +
                                                 "OwnerID, FirstName, LastName, PhoneNumber");
                                string owners = Console.ReadLine();
                                string[] ownersTable = owners.Split(',');
                                service.AddOwner(ownersTable);
                                break;
                            }

                        case 4:
                            {
                                Console.WriteLine(" Введите значения для таблицы Animals, разделенные запятыми: \n " +
                                                 "AnimalID, AnimalName, Species, Breed, OwnerID");
                                string pets = Console.ReadLine();
                                string[] petsTable = pets.Split(',');
                                service.AddPet(petsTable);
                                break;
                            }
                        default:
                            Console.WriteLine("Неверное число, попробуйте снова");
                            break;
                    }
                }
                Console.WriteLine(new String('-', 50));
            }
        }
    }
}
