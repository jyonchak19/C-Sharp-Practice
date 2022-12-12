using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticeApp
{
    // This is an implementation of the factory design pattern, one of the most used design patterns.
    // This design pattern allows us to create objects without exposing the creation logic to the client.
    // In this example, we are creating AWSServers at a very high level.
    public class AWSServiceFactory
    {
        public IAWSServer GetAWSServer(String serverType)
        {
            switch(serverType)
            {
                case "COMPUTE":
                    return new EC2();
                case "STORAGE":
                    return new S3();
                default:
                    return new EC2();
            }
        }
    }
}
