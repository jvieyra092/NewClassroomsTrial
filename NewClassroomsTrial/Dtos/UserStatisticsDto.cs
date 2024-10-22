namespace NewClassroomsTrial.Dtos
{
    public class UserStatisticsDto
    {
        public List<UserResult> Results { get; set; }
        public string Format { get; set; }
    }

    public class UserResult
    {
        public string Gender { get; set; }
        public Name Name { get; set; }
        public Location Location { get; set; }
        public Dob Dob { get; set; }
    }

    public class Name
    {
        public string Title { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }

    public class Location
    {
        public string Country { get; set; }
        public string State { get; set; }
    }

    public class Dob
    {
        public int Age { get; set; }
    }

}
