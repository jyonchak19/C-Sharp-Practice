using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticeApp
{
    public class EC2 : IAWSServer
    {
        void IAWSServer.Analytics()
        {
            Console.WriteLine("CPU Usage: X, Memory Usage: Y, Storage Usage: Z");
        }

        void IAWSServer.Compute()
        {
            Console.WriteLine("N instances for computing available.");
        }

        void IAWSServer.Storage()
        {
            Console.WriteLine("M instances for storage available.");
        }
    }
}
