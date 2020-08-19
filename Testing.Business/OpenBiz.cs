using System.Collections.Generic;
using Testing.Domain.Interfaces.Business;
using Testing.Domain.Interfaces.DataAccess;
using Testing.Domain.Interfaces.Services;
using Testing.Domain.Models;

namespace Testing.Business
{
    public class OpenBiz : IOpenBiz
    {
        private readonly IOpenService openService;
        private readonly ISmpService smpService;
        private readonly IOutageService outageService;
        private readonly IDtbService dtbService;
        private readonly IDiagnosticoDal diagnosticoDal;

        public OpenBiz(IOpenService openService, IDiagnosticoDal diagnosticoDal, ISmpService smpService, IOutageService outageService, IDtbService dtbService)
        {
            this.openService = openService;
            this.diagnosticoDal = diagnosticoDal;
            this.smpService = smpService;
            this.outageService = outageService;
            this.dtbService = dtbService;
        }

        public List<string> GetDiagnostic()
        {
            GetBaseInstaladaData();
            GetInventarioData();
            GetSigmaData();
            GetOutageData();
            GetDTBData();
            //GetMinervaData();
            GetRecommendationListData();

            return new List<string>() { "open 1", "open 2" };
        }

        private OpenModel GetBaseInstaladaData()
        {

            diagnosticoDal.SaveInicioDiagnostico();

            openService.GetBaseInstalada("", "", "");

            return new OpenModel();
        }

        private OpenModel GetInventarioData()
        {
            openService.GetInventario("", new List<string>());

            return new OpenModel();
        }

        private OpenModel GetSigmaData()
        {
            openService.GetSigma("", new List<string>());

            return new OpenModel();
        }

        private OpenModel GetOutageData()
        {
            outageService.GetOutage("", "");

            return new OpenModel();
        }

        private OpenModel GetDTBData()
        {
            dtbService.GetDTBData();

            return new OpenModel();
        }

        private OpenModel GetMinervaData()
        {
            openService.GetProductMinerva("");

            return new OpenModel();
        }

        private OpenModel GetRecommendationListData()
        {
            smpService.GetWorkflowListSMP();

            return new OpenModel();
        }

    }
}
