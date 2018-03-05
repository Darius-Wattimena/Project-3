namespace ProjectData.Database.Entities
{
    public class Regio : IEntity
    {
        public int RegioId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int GetId()
        {
            return RegioId;
        }
    }
}
