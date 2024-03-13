namespace ClassDemoRazorWithDatabase.model
{
    public class Drink: IComparable<Drink>
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

        public int CompareTo(Drink? other)
        {
            if (other is null)
            {
                return -1;
            }

            //if (other.Name == Name)
            //{
            //    return 0;
            //}
            //else if (other.Name < Name)
            //{
            //    return +1;
            //}

            //return -1;

            return Name.CompareTo(other.Name);
        }

        public class DrinkSortByIdReverse : IComparer<Drink>
        {
            public int Compare(Drink? x, Drink? y)
            {
                if (x is null)
                {
                    return 1;
                }

                if(y is null)
                {
                    return -1;
                }

                return y.Id.CompareTo(x.Id);


            }

        }
    }
}
