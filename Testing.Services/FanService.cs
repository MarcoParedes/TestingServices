using System.Collections.Generic;
using Testing.Domain.Interfaces.Services;

namespace Testing.Services
{
    public class FanService : IFanService
    {
        public List<string> GetData()
        {
            return new List<string>() { "Fan 1", "Fan 2", "Fan 3" };
        }
    }
}
