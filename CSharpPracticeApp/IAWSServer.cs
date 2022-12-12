using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticeApp
{
    public interface IAWSServer
    {
        void Compute();
        void Storage();
        void Analytics();
    }
}
