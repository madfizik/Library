using Library.DAL.Interfaces;
using Library.Entities.Models;
using Library.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Library.DAL.SQLRepositories
{
    public class BrochureRepository : IRepository<Brochure>
    {
        private SqlConnection connection;

        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LibraryContext"].ToString();
            connection = new SqlConnection(connectionString);
        }

        public bool Add(Brochure brochure)
        {
            Connection();
            SqlCommand command = new SqlCommand("AddNewBrochure", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@Name", brochure.Name);
            command.Parameters.AddWithValue("@TypeOfCover", brochure.TypeOfCover);
            command.Parameters.AddWithValue("@NumberOfPages", brochure.NumberOfPages);
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

        public List<Brochure> GetAll()
        {
            Connection();
            List<Brochure> brochureList = new List<Brochure>();
            SqlCommand command = new SqlCommand("GetBrochures", connection)
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
                TypeOfCover cover = TypeOfCover.None;
                foreach (var type in Enum.GetValues(typeof(TypeOfCover)))
                    {
                    if (type.ToString() == Convert.ToString(dataRow["TypeOfCover"]))
                    {
                        cover = (TypeOfCover)type;
                    }
                }
                brochureList.Add(
                    new Brochure
                    {
                        Id = Convert.ToInt32(dataRow["BrochureId"]),
                        Name = Convert.ToString(dataRow["Name"]),
                        TypeOfCover = cover,
                        NumberOfPages = Convert.ToInt32(dataRow["NumberOfPages"])
                    }
                    );
            }
            return brochureList;
        }

        public bool Edit(Brochure brochure)
        {
            Connection();
            SqlCommand command = new SqlCommand("UpdateBrochureDetails", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@BrochureId", brochure.Id);
            command.Parameters.AddWithValue("@Name", brochure.Name);
            command.Parameters.AddWithValue("@TypeOfCover", brochure.TypeOfCover);
            command.Parameters.AddWithValue("@NumberOfPages", brochure.NumberOfPages);
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
            SqlCommand command = new SqlCommand("DeleteBrochureById", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@BrochureId", Id);
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