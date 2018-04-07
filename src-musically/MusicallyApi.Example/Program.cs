using System;
using System.IO;
using System.Threading.Tasks;
using MusicallyApi.Cache.Handlers;
using MusicallyApi.Data.Responses;

namespace MusicallyApi.Example
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            // Get user credentials from environment variables.
            //      Environment is used for this example because it makes it easier to rest the library.
            var username = Environment.GetEnvironmentVariable("USERNAME");
            var password = Environment.GetEnvironmentVariable("PASSWORD");

            // Initialize cache.
            //      This makes sure there is consistency between device identifiers per user and gets rid of
            //      repeated authentications.
            var cacheDirectory = Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), "Cache");
            var cacheHandler = new FileCacheHandler(cacheDirectory);

            // Create a musical.ly client.
            //      Using to dispose properly.
            using (var client = new MusicallyApi(username, cacheHandler))
            {
                DiscoverUserMe profile = null;

                // Check if this instance is not logged in yet.
                //      ALWAYS do this check, because the access token gets cached and loaded when the client is created.
                if (!client.IsLoggedIn())
                {
                    var login = await client.LoginAsync(password);
                    if (login.success)
                    {
                        profile = await client.DiscoverUserMeAsync();
                    }
                }
                else
                {
                    profile = await client.DiscoverUserMeAsync();
                }

                // Sanity check.
                if (profile == null)
                {
                    throw new Exception("Profile was null..?");
                }

                // We are now properly authenticated.
                if (client.IsLoggedIn())
                {
                    Console.WriteLine($"Logged in as {profile.result.displayName}.");

                    // Do stuff with client.*
                }
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
