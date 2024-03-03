namespace BeerLibrary
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private double _abv;

        public double Abv
        {
            get { return _abv; }
            set
            {
                if (value < 0 || value > 67)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "ABV must be between 0 and 67.");
                }
                _abv = value;
            }
        }

        public Beer(int id, string name, double abv)
        {
            Id = id;
            Name = name;
            Abv = abv;
        }

        public override string ToString()
        {
            return $"Beer: Id={Id}, Name={Name}, ABV={Abv}";
        }

        public void ValidateId()
        {
            if (Id <= 0)
            {
                throw new ArgumentException("Id must be a positive number.", nameof(Id));
            }
        }

        public void ValidateName()
        {
            if (string.IsNullOrEmpty(Name) || Name.Length < 3)
            {
                throw new ArgumentException("Name must be at least 3 characters long and cannot be null or empty.", nameof(Name));
            }
        }
    }
}
