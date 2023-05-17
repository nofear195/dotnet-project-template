namespace dotnet_project_template.DataContext
{
    public class AppContext:DbContext
    {
        public AppContext(){}
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }
    }
}