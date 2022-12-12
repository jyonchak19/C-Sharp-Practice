using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticeApp
{
    // This is the interface that we are using for the factory pattern.
    public interface IAWSServer
    {
        void Compute();
        void Storage();
        void Analytics();
    }
}
