using System.Collections.Generic;

namespace Testing.Domain.Interfaces.Services
{
    public interface IOpenService
    {
        List<string> GetBaseInstalada(string idDiagnostico, string idSubscriber, string idDomicilio);
        List<string> GetInventario(string idDiagnostico, List<string> productList);
        List<string> GetSigma(string idDiagnostico, List<string> productList);
        List<string> GetProductMinerva(string idDiagnostico);
    }
}
