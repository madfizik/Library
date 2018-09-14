using Library.DAL.Interfaces;
using Library.Entities.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Library.DAL.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private SqlConnection connection;

        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LibraryContext"].ToString();
            connection = new SqlConnection(connectionString);
        }

        public bool Add(Book book)
        {
            Connection();
            SqlCommand command = new SqlCommand("AddNewBook", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@Name", book.Name);
            command.Parameters.AddWithValue("@Author", book.Author);
            command.Parameters.AddWithValue("@YearOfPublishing", book.YearOfPublishing);
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

        public List<Book> GetAll()
        {
            Connection();
            List<Book> bookList = new List<Book>();
            SqlCommand command = new SqlCommand("GetBooks", connection)
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
                bookList.Add(
                    new Book
                    {
                        /*Id = Convert.ToInt32(dataRow["BookId"]),*/
                        Name = Convert.ToString(dataRow["Name"]),
                        Author = Convert.ToString(dataRow["Author"]),
                        YearOfPublishing = Convert.ToInt32(dataRow["YearOfPublishing"])
                    }
                    );
            }
            return bookList;
        }

        public bool Edit(Book book)
        {
            Connection();
            SqlCommand command = new SqlCommand("UpdateBookDetails", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@BookId", book.Id);
            command.Parameters.AddWithValue("@Name", book.Name);
            command.Parameters.AddWithValue("@Author", book.Author);
            command.Parameters.AddWithValue("@YearOfPublishing", book.YearOfPublishing);
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
            SqlCommand command = new SqlCommand("DeleteBookById", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@BookId", Id);
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