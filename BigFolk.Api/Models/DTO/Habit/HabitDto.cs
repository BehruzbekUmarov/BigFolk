namespace BigFolk.Api.Models.DTO.Habit
{
    public class HabitDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Frequency { get; set; }

        public Guid GeniusId { get; set; }
    }
}
