namespace ClassDemoRazorWithDatabase.model
{
    public interface IDrinkRepo
    {
        Drink Add(Drink newDrink);
        List<Drink> GetAll();
        Drink GetById(int id);
        Drink Delete(int id);
        Drink Update(int id, Drink updatedDrink);


    }
}