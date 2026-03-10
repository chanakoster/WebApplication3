using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class PersonManager
    {
        private string _connectionString;

        public PersonManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddPerson(string firstName, string lastName, int age)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO People (FirstName, LastName, Age) " +
                "VALUES (@firstName, @lastName, @age)";
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@age", age);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public List<Person> GetPeople()
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM People";
            con.Open();

            List<Person> people = new List<Person>();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                people.Add(new Person
                {
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }
            return people;
        }

        public void DeletePerson(int id)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Cars " + 
                "WHERE PersonId = @id " + 
                "DELETE FROM People " + 
                "WHERE Id = @id " + 
                "DELETE FROM People WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}