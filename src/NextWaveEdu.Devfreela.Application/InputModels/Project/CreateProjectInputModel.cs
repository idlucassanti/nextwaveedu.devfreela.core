namespace NextWaveEdu.Devfreela.Application.InputModels.Project
{
    public class CreateProjectInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }
        public int OwnerId { get; set; }
        public int FreelancerId { get; set; }
    }
}
