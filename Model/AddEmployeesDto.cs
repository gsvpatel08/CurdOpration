namespace CurdOperation.Model
{
    public class AddEmployeesDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? phone { get; set; }
        public decimal salary { get; set; }
    }
}
