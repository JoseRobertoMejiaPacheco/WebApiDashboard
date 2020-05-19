using LibMdx;
using LibMdx.Model;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiNortwind.Controllers
{
    //Todos los otigenes, todas las cabeceras y todos los verbos de metodos(get, put, post)
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("isscjrmp/nortwind")]
    public class NortwindDBController : ApiController
    {


        [HttpGet]
        [Route("GetClients")]
        public HttpResponseMessage GetClients()
        {
            QueryMdx queryMdx = new QueryMdx();
            return Request.CreateResponse(HttpStatusCode.OK, queryMdx.GetClientsQueryMdx());
        }

        [HttpPost]
        [Route("GetDataPie")]
        public HttpResponseMessage GetDataPie([FromBody] FilterModel filterModel)
        {
            QueryMdx queryMdx = new QueryMdx();
            return Request.CreateResponse(HttpStatusCode.OK, queryMdx.GetChartDataPieQueryMdx(filterModel.Clients, filterModel.Months, filterModel.Years));
        }



        [HttpPost]
        [Route("GetDataBar")]
        public HttpResponseMessage GetDataBar([FromBody] FilterModel filterModel)
        {

            QueryMdx queryMdx = new QueryMdx();
            return Request.CreateResponse(HttpStatusCode.OK, queryMdx.GetChartDataBarQueryMdx(filterModel.Clients, filterModel.Months, filterModel.Years));
        }

        [HttpPost]
        [Route("GetLabelsBar")]
        public HttpResponseMessage GetLabelsBar([FromBody] FilterModel filterModel)
        {
            QueryMdx queryMdx = new QueryMdx();
            return Request.CreateResponse(HttpStatusCode.OK, queryMdx.GetChartLabelsDataBarQueryMdx(filterModel.Clients, filterModel.Months, filterModel.Years));
        }
    }
}
