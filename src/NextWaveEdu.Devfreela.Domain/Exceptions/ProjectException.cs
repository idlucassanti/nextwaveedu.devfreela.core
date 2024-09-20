namespace NextWaveEdu.Devfreela.Domain.Exceptions
{
    public class ProjectException : Exception
    {
        public ProjectException()
            :base("Project is already in Started status")
        {
            
        }
    }
}
