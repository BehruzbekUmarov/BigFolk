namespace BigFolk.Api.Models.DTO.Habit
{
    public class AddHabitRequestDto
    {
        public string Name { get; set; }
        public string Frequency { get; set; }

        public Guid GeniusId { get; set; }
    }
}
