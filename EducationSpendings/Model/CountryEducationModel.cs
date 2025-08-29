namespace EducationSpendings
{
    public class CountryEducationModel
    {
        public string? Country { get; set; }
        public string? Region { get; set; }
        public int Year { get; set; }
        public double GDPSpent { get; set; } // X value
        public double GovtSpent { get; set; } // Y value
    }
}

