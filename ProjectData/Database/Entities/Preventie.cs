namespace ProjectData.Database.Entities
{
    public class Preventie : IEntity
    {
        public int PreventieId { get; set; }

        public string Regios { get; set; }

        public string Perioden { get; set; }

        public float LichtAfwezig { get; set; }

        public int GetId()
        {
            return PreventieId;
        }
    }
}
