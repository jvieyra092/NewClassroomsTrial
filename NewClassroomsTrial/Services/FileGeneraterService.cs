using System.Text;
using System.Xml.Serialization;
using NewClassroomsTrial.Dtos;
namespace NewClassroomsTrial.Services
{
    public class FileGeneraterService
    {
        public string GenerateText(UserStatisticsResultDto statistics)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Percentage female versus male:" + $" {statistics.GenderPercentage.Male:F2}%");
            stringBuilder.AppendLine("Percentage male versus female:" + $" {statistics.GenderPercentage.Female:F2}%");

            stringBuilder.AppendLine("Percentage of first names that start with A-M versus N-Z:" + $" {statistics.FirstNamePercentage.AtoM:F2}%");
            stringBuilder.AppendLine("Percentage of first names that start with N-Z versus A-M:" + $" {statistics.FirstNamePercentage.NtoZ:F2}%");

            stringBuilder.AppendLine("Percentage of first names that start with A-M versus N-Z " + $" {statistics.LastNamePercentage.AtoM:F2}%");
            stringBuilder.AppendLine("Percentage of first names that start with N-Z versus A-M" + $" {statistics.LastNamePercentage.NtoZ:F2}%");

            foreach (var state in statistics.StatePercentage)
            {
                stringBuilder.AppendLine("Percentage of people in state of" + $" {state.State}: {state.Percentage:F2}%");
            }

            foreach (var state in statistics.FemaleStatePercentage)
            {
                stringBuilder.AppendLine("Percentage female versus male in state of" + $" {state.State}: {state.Percentage:F2}%");
            }
            
            foreach (var state in statistics.MaleStatePercentage)
            {
                stringBuilder.AppendLine("Percentage male versus female in state of" + $" {state.State}: {state.Percentage:F2}%");
            }

            foreach (var ageRange in statistics.AgeRangePercentage)
            {
                stringBuilder.AppendLine("Percentage of people in age range" + $" {ageRange.AgeRange}: {ageRange.Percentage:F2}%");
            }

            return stringBuilder.ToString();
        }

        public string GenerateXml(UserStatisticsResultDto statistics)
        {
            var xmlSerializer = new XmlSerializer(statistics.GetType());

            using (var stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, statistics);
                return stringWriter.ToString();
            }
        }

    }
}
