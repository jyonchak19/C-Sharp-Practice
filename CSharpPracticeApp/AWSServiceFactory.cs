using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticeApp
{
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
