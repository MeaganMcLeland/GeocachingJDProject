namespace GeocachingJDProject.Models
{
    public class GeocachingItems
    {   
        //primary key -- GeocachingItems.Id
        public long Id { get; set; }
      
        public string? ItemName { get; set; }

        //should be foreign key to GeocachingContainers ContainerIDNumber
        public long? GeocacheContainerID { get; set; }

        public DateOnly StartActiveDate { get; set; }

        public DateOnly EndActiveDate { get; set; }

    }
}
