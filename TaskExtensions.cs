using System;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLiberty.Http
{
    public static class TaskExtensions
    {
        public static void WaitOrUnwrapException(this Task task)
        {
            try
            {
                task.Wait();
            }
            catch (AggregateException e)
            {
                throw e.InnerException;
            }
        }

        public static T AwaitResultOrUnwrapException<T>(this Task<T> task)
        {
            try
            {
                task.Wait();
                return task.Result;
            }
            catch (AggregateException e)
            {
                if (e.Flatten().InnerExceptions.Any())
                {
                    foreach (var innerException in e.Flatten().InnerExceptions)
                    {
                        throw innerException;
                    }
                }
                throw e.InnerException;
            }
        }
    }
}