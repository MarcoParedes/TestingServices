using System;
using System.Collections.Generic;
using Testing.Domain.Interfaces.Services;

namespace Testing.Services
{
    public class OpenService : IOpenService
    {
        public List<string> GetBaseInstalada(string idDiagnostico, string idSubscriber, string idDomicilio)
        {
            throw new NotImplementedException();
        }

        public List<string> GetInventario(string idDiagnostico, List<string> productList)
        {
            throw new NotImplementedException();
        }

        public List<string> GetProductMinerva(string idDiagnostico)
        {
            throw new NotImplementedException();
        }

        public List<string> GetSigma(string idDiagnostico, List<string> productList)
        {
            throw new NotImplementedException();
        }

    }
}
