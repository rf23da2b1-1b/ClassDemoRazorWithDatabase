namespace ClassDemoRazorWithDatabase.model
{
    public class DrinkRepo : IDrinkRepo
    {
        private List<Drink> _drinks;

        public DrinkRepo(bool mockData = false)
        {
            _drinks = new List<Drink>();

            if (mockData)
            {
                PopulateDrinks();
            }
        }

        private void PopulateDrinks()
        {
            _drinks.Add(new Drink(1, "vand", false));
            _drinks.Add(new Drink(2, "fanta", false));
            _drinks.Add(new Drink(5, "øl", true));
            _drinks.Add(new Drink(7, "vin", true));
        }

        public List<Drink> GetAll()
        {
            return new List<Drink>(_drinks);
        }

        public Drink GetById(int id)
        {
            Drink? drink = _drinks.Find(d => d.Id == id);
            if (drink is null)
            {
                throw new KeyNotFoundException();
            }
            return drink;
        }

        public Drink Add(Drink drink)
        {
            _drinks.Add(drink);
            return drink;
        }

        public Drink Delete(int id)
        {
            Drink deleteDrink = GetById(id);

            _drinks.Remove(deleteDrink);
            return deleteDrink;
        }

        public Drink Update(int id, Drink updatedDrink)
        {
            if (id != updatedDrink.Id)
            {
                throw new ArgumentException("kan ikke opdatere id og obj.Id er forskellige");
            }

            Drink updateThisDrink = GetById(id);

            updateThisDrink.Name = updatedDrink.Name;
            updateThisDrink.Alc = updatedDrink.Alc;

            return updateThisDrink;
        }
    }
}
