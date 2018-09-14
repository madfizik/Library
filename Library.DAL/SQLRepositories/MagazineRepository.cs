using Library.DAL.Interfaces;
using Library.Entities.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Library.DAL.SQLRepositories
{
    public class MagazineRepository : IRepository<Magazine>
    {
        private SqlConnection connection;

        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LibraryContext"].ToString();
            connection = new SqlConnection(connectionString);
        }

        public bool Add(Magazine magazine)
        {
            Connection();
            SqlCommand command = new SqlCommand("AddNewMagazine", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@Name", magazine.Name);
            command.Parameters.AddWithValue("@Number", magazine.Number);
            command.Parameters.AddWithValue("@YearOfPublishing", magazine.YearOfPublishing);
            connection.Open();
            int success = command.ExecuteNonQuery();
            connection.Close();
            if (success >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Magazine> GetAll()
        {
            Connection();
            List<Magazine> magazineList = new List<Magazine>();
            SqlCommand command = new SqlCommand("GetMagazines", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            connection.Open();
            dataAdapter.Fill(dataTable);
            connection.Close();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                magazineList.Add(
                    new Magazine
                    {
                        Id = Convert.ToInt32(dataRow["MagazineId"]),
                        Name = Convert.ToString(dataRow["Name"]),
                        Number = Convert.ToInt32(dataRow["Number"]),
                        YearOfPublishing = Convert.ToInt32(dataRow["YearOfPublishing"])
                    }
                    );
            }
            return magazineList;
        }

        public bool Edit(Magazine magazine)
        {
            Connection();
            SqlCommand command = new SqlCommand("UpdateMagazineDetails", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@MagazineId", magazine.Id);
            command.Parameters.AddWithValue("@Name", magazine.Name);
            command.Parameters.AddWithValue("@Number", magazine.Number);
            command.Parameters.AddWithValue("@YearOfPublishing", magazine.YearOfPublishing);
            connection.Open();
            int success = command.ExecuteNonQuery();
            connection.Close();
            if (success >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            Connection();
            SqlCommand command = new SqlCommand("DeleteMagazineById", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@MagazineId", Id);
            connection.Open();
            int success = command.ExecuteNonQuery();
            connection.Close();
            if (success >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}