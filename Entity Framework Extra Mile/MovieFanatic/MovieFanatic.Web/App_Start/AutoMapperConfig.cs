using MovieFanatic.Web.App_Start;
using MovieFanatic.Web.Infrastructure.AutoMapper;
using WebActivatorEx;

[assembly: PostApplicationStartMethod(typeof(AutoMapperConfig), "RegisterAutoMapper")]
namespace MovieFanatic.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterAutoMapper()
        {
            AutoMapperConfiguration.Initialize();
        }
    }
}