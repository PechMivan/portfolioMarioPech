using Portafolio.Models;

namespace Portafolio.Services
{

    public interface IProjectRepository
    {
        List<Project> getProjects();
    }

    public class ProjectRepository : IProjectRepository
    {
        public List<Project> getProjects()
        {
            return new List<Project>()
            {
                    new Project
                {
                    title = "YelpCamp Service",
                    description = "Website that helps creating and finding campgrounds.",
                    link = "https://www.youtube.com/",
                    imageUrl = "/images/dt2.jpg"
                },

                    new Project
                {
                    title = "YelpCamp Service 2",
                    description = "Website that helps creating and finding campgrounds.",
                    link = "https://www.youtube.com/",
                    imageUrl = "/images/dt2.jpg"
                },
            };
        }
    }
}
