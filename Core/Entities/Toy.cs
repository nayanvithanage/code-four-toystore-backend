namespace toystore_backend.Core.Entities
{
    public class Toy
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public float Price { get; set; }
    }
}
