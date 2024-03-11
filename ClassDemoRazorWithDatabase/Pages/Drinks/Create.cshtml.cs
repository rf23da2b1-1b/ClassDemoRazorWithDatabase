using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassDemoRazorWithDatabase.model;

namespace ClassDemoRazorWithDatabase.Pages.Drinks
{
    public class CreateModel : PageModel
    {
        private readonly IDrinkRepo _repo;

        public CreateModel(IDrinkRepo repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public int Id { get; set; }
        [BindProperty] 
        public String  Name { get; set; }
        [BindProperty] 
        public bool Alkohol { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Drink drink = new Drink(Id,Name, Alkohol);
            _repo.Add(drink);

            return RedirectToPage("Index");
        }
    }
}
