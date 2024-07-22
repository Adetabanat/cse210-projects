namespace EventPlanning
{
    public class Address
    {
        private string street;
        private string city;
        private string stateProvince;
        private string country;

        public Address(string street, string city, string stateProvince, string country)
        {
            this.street = street;
            this.city = city;
            this.stateProvince = stateProvince;
            this.country = country;
        }

        public string GetFullAddress()
        {
            return $"{street}, {city}, {stateProvince}, {country}";
        }
    }
}
