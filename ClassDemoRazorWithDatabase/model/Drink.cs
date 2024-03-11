namespace ClassDemoRazorWithDatabase.model
{
    public class Drink
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public bool  Alc { get; set; }

        public Drink(int id, string name, bool alc)
        {
            Id = id;
            Name = name;
            Alc = alc;
        }

        public Drink():this(-1,"dummy",false)
        {
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Alc)}={Alc.ToString()}}}";
        }
    }
}
