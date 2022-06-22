namespace GeocachingJDProject.Models
{
    public class GeocachingContainers
    {
        //primary key -- GeocachingContainers.Id
        public long Id { get; set; }
        public string? ContainerName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
