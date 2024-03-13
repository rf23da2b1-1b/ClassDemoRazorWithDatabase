using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassDemoRazorWithDatabase.model;
using static ClassDemoRazorWithDatabase.model.Drink;

namespace ClassDemoRazorWithDatabase.Pages.Drinks
{
    public class IndexModel : PageModel
    {
        private readonly IDrinkRepo _repo;

        public IndexModel(IDrinkRepo repo)
        {
            _repo = repo;
        }


        public List<Drink> Drinks { get; set; }

        public void OnGet()
        {
            Drinks = _repo.GetAll();
        }

        public void OnPost()
        {
            Drinks = _repo.GetAll();

            Drinks.Sort(new DrinkSortByIdReverse());
;        }

        public void OnPostSortName()
        {
            Drinks = _repo.GetAll();

            Drinks.Sort();
        }
    }

}

