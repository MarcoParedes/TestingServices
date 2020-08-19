using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Testing.Business;
using Testing.Domain.Enums;
using Testing.Domain.Interfaces.Business;

namespace WebApplication.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DiagnosticosController : ControllerBase
    {
        private readonly IOpenBiz openBiz;
        private readonly IFanBiz fanBiz;

        public DiagnosticosController(IOpenBiz openBiz, IFanBiz fanBiz)
        {
            this.openBiz = openBiz;
            this.fanBiz = fanBiz;
        }

        /// <summary>
        /// Obtener diagnóstico
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpGet, Route("")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<string>))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetData([FromQuery] string customer)
        {
            var data = customer.ToUpper().Equals(CustomerEnum.OPEN.ToString()) 
                        ? openBiz.GetDiagnostic()
                        : fanBiz.GetDiagnostic();

            //IDiagnostico diagnostico = GetStrategy(customer);
            //var data = diagnostico.GetDiagnostic();

            return Ok(data);
        }

        //private IDiagnostico GetStrategy(string customer)
        //{
        //    IDiagnostico strategy = null;

        //    if (customer.ToUpper().Equals(CustomerEnum.OPEN.ToString()))
        //        strategy = new OpenBiz();
        //    else if (customer.ToUpper().Equals(CustomerEnum.FAN.ToString()))
        //        strategy = new FanBiz();
        //    //else if (customer.ToUpper().Equals(CustomerEnum.TOOLBOX.ToString()))
        //    //    strategy = new ToolBoxStrategy();

        //    return strategy;
        //}

    }
}