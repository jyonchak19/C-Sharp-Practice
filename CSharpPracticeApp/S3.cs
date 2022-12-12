using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticeApp
{
    // This is an example class for the factory design pattern.
    public class S3 : IAWSServer
    {
        void IAWSServer.Analytics()
        {
            Console.WriteLine("Storage Usage: Z");
        }

        void IAWSServer.Compute()
        {
            Console.WriteLine("No compute available. Consider other services.");
        }

        void IAWSServer.Storage()
        {
            Console.WriteLine("M instances for storage available.");
        }
    }
}
