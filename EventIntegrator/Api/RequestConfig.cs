using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventIntegrator.Api
{
    public abstract class RequestConfig
    {
        public abstract string Url { get;  }
        public abstract string Entity { get; }      

    }
}
