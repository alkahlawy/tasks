namespace Demo.PL.ViewModels.DepartmentViewModel
{
    public class DepartmentEditViewModel
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateOnly CreatedAt { get; set; }
        public string? Description { get; set; }
    }
}
