using System;
using System.Collections;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Exceptions
{
    class Program
    {
        private static ILogger<Program> _logger = new Logger<Program>(new LoggerFactory());

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static void TryCatchExample()
        {
            try
            {
                // Do something.
            }
            catch (Exception ex)
            {
                // Handle exception here.
            }
            finally
            {
                // Code that executes no matter what.
            }
        }

        private static async Task<HttpResponseMessage> HandleHttpException()
        {
            const int maxRetries = 2;
            int retries = 0;
            HttpClient client = new HttpClient();

            while (true)
            {
                try
                {
                    return await client.GetAsync("https://programhappy.net");
                }
                catch (HttpRequestException httpRqException)
                {
                    if (retries <= maxRetries)
                    {
                        retries++;
                    }

                    if (httpRqException.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        retries++;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        private static async Task<HttpResponseMessage> HandleHttpExceptionSimplified()
        {
            const int maxRetries = 2;
            int retries = 0;
            HttpClient client = new HttpClient();

            while (true)
            {
                try
                {
                    return await client.GetAsync("https://programhappy.net");
                }
                catch (HttpRequestException httpRqException) when (httpRqException.StatusCode == HttpStatusCode.ServiceUnavailable)
                {
                    if (retries <= maxRetries)
                    {
                        retries++;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        private static void ReleaseResourceWithTryCatch()
        {
            var connection = new SqlConnection("connection string here");
            try
            {
                connection.Open();

                // Do some logic here

                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
        }

        private static void ReleaseResourceWithFinally()
        {
            var connection = new SqlConnection("connection string here");
            try
            {
                connection.Open();

                // Do some logic here
            }
            finally
            {
                connection.Close();
            }
        }

        private static void ReleaseResourceWithUsing()
        {
            using (var connection = new SqlConnection("connection string here"))
            {
                connection.Open();

                // Do some logic here
            }
        }

        private static void RevertOperationWithTryCatch()
        {
            using (var connection = new SqlConnection("connection string here"))
            {
                connection.Open();
                var transaction = connection.BeginTransaction("transaction name here");
                try
                {
                    // Do some write here

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        private static void RevertOperationWithUsing()
        {
            using (var connection = new SqlConnection("connection string here"))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction("transaction name here"))
                {
                    // Do some write here

                    transaction.Commit();
                }
            }
        }

        private static void CustomExceptions()
        {
            try
            {
                // Do something that may throw SqlException.
            }
            catch (SqlException sqlEx)
            {
                throw new MyCustomException("Error while doing so and such.", sqlEx);
            }
        }

        private static void LoggingException()
        {
            try
            {
                // Do something that may throw SqlException.
            }
            catch (SqlException sqlEx)
            {
                _logger.LogError(sqlEx, "Error while doing so and such.");
                throw;
            }
        }
    }

    public class MyCustomException : Exception
    {
        public MyCustomException()
        { }

        public MyCustomException(string message)
            : base(message)
        { }

        public MyCustomException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
