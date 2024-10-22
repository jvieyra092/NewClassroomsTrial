namespace NewClassroomsTrial.Dtos
{
    public class UserStatisticsResultDto
    {
        public GenderPercentage GenderPercentage { get; set; }
        public NamePercentage FirstNamePercentage { get; set; }
        public NamePercentage LastNamePercentage { get; set; }
        public List<StatePercentage> StatePercentage { get; set; }
        public List<StatePercentage> FemaleStatePercentage { get; set; }
        public List<StatePercentage> MaleStatePercentage { get; set; }
        public List<AgeRangePercentage> AgeRangePercentage { get; set; }
    }

    public class GenderPercentage
    {
        public double Male { get; set; }
        public double Female { get; set; }
    }

    public class NamePercentage
    {
        public double AtoM { get; set; }
        public double NtoZ { get; set; }
    }

    public class StatePercentage
    {
        public string State { get; set; }
        public double Percentage { get; set; }
    }

    public class AgeRangePercentage
    {
        public string AgeRange { get; set; }
        public double Percentage { get; set; }
    }
}
