namespace SchiaviDelPadel.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public List<Slot>? Slots { get; set; }
    }
}
