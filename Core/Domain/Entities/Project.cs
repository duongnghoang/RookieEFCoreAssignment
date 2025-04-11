namespace Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string? Name { get; set; } = null!;
        public ICollection<ProjectEmployee> ProjectEmployees { get; set; } = null!;
    }
}