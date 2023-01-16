namespace Domain
{
    public class Data : EntityBase
    {
        public DateTime SaveAt { get; set; }
        public Elimination Elimination { get; set; }
        public Sequence Sequence { get; set; }
    }
}
