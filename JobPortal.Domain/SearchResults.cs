namespace JobPortal.Domain
{
    public class SearchResults
    {
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<Job> Jobs { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Location> Locations { get; set; }
    }
}