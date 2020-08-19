using System.Collections.Generic;
using Testing.Domain.Interfaces.Business;

namespace Testing.Business
{
    public class FanBiz : IFanBiz
    {
        public List<string> GetDiagnostic()
        {
            return new List<string>() { "fan 1", "fan 2" };
        }
    }
}
