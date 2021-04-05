using com.TweetApp.DataAccessObject;
using com.TweetApp.Model;
using com.TweetApp.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace com.TweetApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            Configure(services);
            IServiceProvider provider = services.BuildServiceProvider();
            var service = provider.GetService<IUserIntro>();
            service.IntroPageNonLoggedUser();
        }
        private static void Configure(IServiceCollection service)
        {
            service.AddSingleton<IRepository, Repository>();
            service.AddScoped<IUserIntro, UserIntro>();
            //         service.AddDbContext<TweetAppContext>(options =>
            // options.UseInMemoryDatabase()
            //);

        }
    }
}

