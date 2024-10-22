using NewClassroomsTrial.Dtos;
using System.Reflection;

namespace NewClassroomsTrial.Services
{
    public class UserStatisticsService
    {
        public UserStatisticsResultDto GenerateStatistics(List<UserResult> results)
        {
            var statistics = new UserStatisticsResultDto
            {
                GenderPercentage = CalculateGenderPercentage(results),
                FirstNamePercentage = CalculateFirstNamePercentage(results),
                LastNamePercentage = CalculateLastNamePercentage(results),
                StatePercentage = CalculateStatePercentage(results),
                FemaleStatePercentage = CalculateGenderStatePercentage(results, "female"),
                MaleStatePercentage = CalculateGenderStatePercentage(results, "male"),
                AgeRangePercentage = CalculateAgeRangePercentage(results)
            };

            return statistics;
        }

        private GenderPercentage CalculateGenderPercentage(List<UserResult> results)
        {
            var total = results.Count;
            var maleCount = results.Count(r => r.Gender == "male");
            var femaleCount = total - maleCount;

            return new GenderPercentage
            {
                Male = (maleCount / (double)total) * 100,
                Female = (femaleCount / (double)total) * 100
            };
        }

        private NamePercentage CalculateFirstNamePercentage(List<UserResult> results)
        {
            var total = results.Count;
            var aToMCount = results.Count(r => r.Name.First[0] >= 'A' && r.Name.First[0] <= 'M');
            var nToZCount = total - aToMCount;

            return new NamePercentage
            {
                AtoM = (aToMCount / (double)total) * 100,
                NtoZ = (nToZCount / (double)total) * 100
            };
        }

        private NamePercentage CalculateLastNamePercentage(List<UserResult> results)
        {
            var total = results.Count;
            var aToMCount = results.Count(r => r.Name.Last[0] >= 'A' && r.Name.Last[0] <= 'M');
            var nToZCount = total - aToMCount;

            return new NamePercentage
            {
                AtoM = (aToMCount / (double)total) * 100,
                NtoZ = (nToZCount / (double)total) * 100
            };
        }

        private List<StatePercentage> CalculateStatePercentage(List<UserResult> results)
        {
            var total = results.Count;
            return results.GroupBy(r => r.Location.State)
                          .OrderByDescending(g => g.Count())
                          .Take(10)
                          .Select(g => new StatePercentage
                          {
                              State = g.Key,
                              Percentage = (g.Count() / (double)total) * 100
                          })
                          .ToList();
        }

        private List<StatePercentage> CalculateGenderStatePercentage(List<UserResult> results, string gender)
        {
            var total = results.Count(r => r.Gender == gender);
            return results.Where(r => r.Gender == gender)
                          .GroupBy(r => r.Location.State)
                          .OrderByDescending(g => g.Count())
                          .Take(10)
                          .Select(g => new StatePercentage
                          {
                              State = g.Key,
                              Percentage = (g.Count() / (double)total) * 100
                          })
                          .ToList();
        }

        private List<AgeRangePercentage> CalculateAgeRangePercentage(List<UserResult> results)
        {
            var total = results.Count;

            var ageRanges = new List<AgeRangePercentage>
            {
                new AgeRangePercentage { AgeRange = "0-20", Percentage = (results.Count(r => r.Dob.Age >= 0 && r.Dob.Age <= 20) / (double)total) * 100 },
                new AgeRangePercentage { AgeRange = "21-40", Percentage = (results.Count(r => r.Dob.Age >= 21 && r.Dob.Age <= 40) / (double)total) * 100 },
                new AgeRangePercentage { AgeRange = "41-60", Percentage = (results.Count(r => r.Dob.Age >= 41 && r.Dob.Age <= 60) / (double)total) * 100 },
                new AgeRangePercentage { AgeRange = "61-80", Percentage = (results.Count(r => r.Dob.Age >= 61 && r.Dob.Age <= 80) / (double)total) * 100 },
                new AgeRangePercentage { AgeRange = "81-100", Percentage = (results.Count(r => r.Dob.Age >= 81 && r.Dob.Age <= 100) / (double)total) * 100 },
                new AgeRangePercentage { AgeRange = "100+", Percentage = (results.Count(r => r.Dob.Age > 100) / (double)total) * 100 }
            };

            return ageRanges;
        }
    }
}
