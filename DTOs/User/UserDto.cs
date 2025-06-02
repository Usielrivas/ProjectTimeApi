namespace ProjectTimeApi.DTOs

{
    public class UserDto
    {
        public required int Id { get; set; }
        public required string Email { get; set; }
        public required bool Active { get; set; }
    }
}
