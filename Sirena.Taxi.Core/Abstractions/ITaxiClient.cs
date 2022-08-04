using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sirena.Taxi.Core.Domain;

namespace Sirena.Taxi.Core.Abstractions
{
    public interface ITaxiClient
    {
        void RequestData(BaseEntity entity); 
    }
}
