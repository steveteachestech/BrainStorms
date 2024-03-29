using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FeatureToggleExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IFeatureManager featureManager = GetFeatureManager();

            // Check the status of the feature
            if (await featureManager.IsEnabledAsync("FeatureX"))
            {
                // Implement the feature
                Console.WriteLine(FeatureX());
            }
            else
            {
                // Disable the feature
                Console.WriteLine("Feature X is disabled");
            }
        }

        static IFeatureManager GetFeatureManager()
        {
            var builder = new FeatureManagerBuilder().WithDefaultFilter().WithFilter(new DatabaseFeatureFilter(GetDbContext()));
            return builder.Build();
        }

        static DbContext GetDbContext()
        {
            // return a DbContext instance connected to your database
            return new DbContext();
        }

        static string FeatureX()
        {
            return "Feature X is enabled";
        }
    }

    public class DbContext
    {
        // code to connect to your database
    }

    public class DatabaseFeatureFilter : IFeatureFilter
    {
        private readonly DbContext _dbContext;

        public DatabaseFeatureFilter(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            // implement code to read the feature toggle status from your database using the DbContext instance
            return Task.FromResult(GetFeatureStatusFromDb(context.FeatureName));
        }

        private bool GetFeatureStatusFromDb(string featureName)
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection("Data Source=(local);Initial Catalog=FeatureToggles;Integrated Security=True"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Enabled FROM FeatureToggles WHERE Name = @featureName", connection))
                {
                    command.Parameters.AddWithValue("@featureName", featureName);
                    result = (bool)command.ExecuteScalar();
                }
            }
            return result;
        }
    }
}
