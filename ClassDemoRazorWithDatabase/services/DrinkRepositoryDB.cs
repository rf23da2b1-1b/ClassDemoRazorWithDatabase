using ClassDemoRazorWithDatabase.model;
using Microsoft.Data.SqlClient;

namespace ClassDemoRazorWithDatabase.services
{
    public class DrinkRepositoryDB : IDrinkRepo
    {

        private const String insertSql = "insert into Drink values(@name,@alc)";
        public Drink Add(Drink newDrink)
        {
            SqlConnection connection = new SqlConnection(Secret.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(insertSql, connection);
            cmd.Parameters.AddWithValue("@name", newDrink.Name);
            cmd.Parameters.AddWithValue("@alc", newDrink.Alc);

            int row = cmd.ExecuteNonQuery();
            Console.WriteLine("Rows affected " + row);

            connection.Close();
            return newDrink;
        }

        public Drink Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Drink> GetAll()
        {
            List<Drink> drinks = new List<Drink>();

            SqlConnection connection = new SqlConnection(Secret.ConnectionString);
            connection.Open();

            String sql = "select * from Drink";
            SqlCommand cmd = new SqlCommand(sql, connection);

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

        public Drink GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Drink Update(int id, Drink updatedDrink)
        {
            throw new NotImplementedException();
        }
    }
}
