using ClassDemoRazorWithDatabase.model;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace ClassDemoRazorWithDatabase.services
{
    public class DrinkRepositoryDB : IDrinkRepo
    {
        /*
         * CREATE
         */
        private const String insertSql = "insert into Drink values(@name,@alc)";
        public Drink Add(Drink newDrink)
        {
            SqlConnection connection = new SqlConnection(Secret.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(insertSql, connection);
            cmd.Parameters.AddWithValue("@name", newDrink.Name);
            cmd.Parameters.AddWithValue("@alc", newDrink.Alc);

            int rows = cmd.ExecuteNonQuery();
            if (rows == 0)
            {
                throw new ArgumentException("Kunne ikke oprette drink =" + newDrink);
            }
            connection.Close();
            return newDrink;
        }

        /*
         * READ
         */
        private const String selectAllSql = "select * from Drink";

        public List<Drink> GetAll()
        {
            List<Drink> drinks = new List<Drink>();

            SqlConnection connection = new SqlConnection(Secret.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(selectAllSql, connection);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Drink drink = ReadDrink(reader);
                drinks.Add(drink);
            }

            connection.Close();
            return drinks;
        }

        private Drink ReadDrink(SqlDataReader reader)
        {
            Drink drink = new Drink();

            drink.Id = reader.GetInt32(0);
            drink.Name = reader.GetString(1);
            drink.Alc = reader.GetBoolean(2);

            return drink;
        }

        private const String selectByIdlSql = "select * from Drink where Id = @Id";
        public Drink GetById(int id)
        {
            SqlConnection connection = new SqlConnection(Secret.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(selectByIdlSql, connection);
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            Drink drink = null;
            if (reader.Read())
            {
                drink = ReadDrink(reader);
            }
            else
            {
                // no row i.e. not found
                throw new KeyNotFoundException();
            }

            connection.Close();
            return drink;
        }

        /*
         * UPDATE
         */

        private const String updateSql = "update Drink set Name=@name, Alk=@alc where Id=@id";
        public Drink Update(int id, Drink updatedDrink)
        {
            if (id != updatedDrink.Id)
            {
                throw new ArgumentException("Kan ikke opdatere id er forskellig fra id i updatedeDrink");
            }

            SqlConnection connection = new SqlConnection(Secret.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(insertSql, connection);
            cmd.Parameters.AddWithValue("@name", updatedDrink.Name);
            cmd.Parameters.AddWithValue("@alc", updatedDrink.Alc);
            cmd.Parameters.AddWithValue("@Id", updatedDrink.Id);

            int row = cmd.ExecuteNonQuery();
            Console.WriteLine("Rows affected " + row);

            connection.Close();
            return updatedDrink;
        }




        /*
         * DELETE
         */
        private const String deleteByIdlSql = "delete from Drink where Id = @Id";
        public Drink Delete(int id)
        {
            Drink drink = GetById(id);

            SqlConnection connection = new SqlConnection(Secret.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(deleteByIdlSql, connection);
            cmd.Parameters.AddWithValue("@id", id);

            int rows = cmd.ExecuteNonQuery();

            if (rows == 0)
            {
                throw new ArgumentException("Kunne ikke slette drink med id=" + id);
            }
            connection.Close();

            return drink;
        }
    }
}
