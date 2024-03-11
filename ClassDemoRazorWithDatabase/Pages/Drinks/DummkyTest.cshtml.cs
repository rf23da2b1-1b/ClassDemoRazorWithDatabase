using ClassDemoRazorWithDatabase.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClassDemoRazorWithDatabase.Pages.Drinks
{
    public class DummkyTestModel : PageModel
    {
        private IDrinkRepo _repo;

        public DummkyTestModel(IDrinkRepo repo)
        {
            _repo = repo;
        }

        public void OnGet()
        {
            Drink drink =_repo.GetById(30);

            try
            {
                drink = _repo.GetById(33);
            }
            catch(KeyNotFoundException ex)
            {
                String msg = ex.Message;
            }

            Drink addDrink = new Drink(0, "Sjov", false);
            Drink returnDrink = _repo.Add(addDrink);


            addDrink.Name = "Mere sjov";
            addDrink.Alc = true;

            Drink upDatedDrink = _repo.Update(returnDrink.Id, addDrink);

            Drink deleteDrink = _repo.Delete(30);
        }
    }
}
