using System.Collections.Generic;

namespace Testing.Domain.Interfaces.Services
{
    public interface IOutageService
    {
        List<string> GetOutage(string idDiagnostico, string idDomicilio);
    }
}
