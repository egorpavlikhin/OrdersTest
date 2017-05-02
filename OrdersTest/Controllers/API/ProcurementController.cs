using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using OrdersTest.DataAccess;
using OrdersTest.Models;

namespace OrdersTest.Controllers.API
{
    [Authorize]
    [RoutePrefix("api/procurement")]
    public class ProcurementController : ApiController
    {
        private IProcurementRepository procurementRepository;
        private IUserProcurementRepository userProcurementRepository;

        public ProcurementController(IProcurementRepository procurementRepository, IUserProcurementRepository userProcurementRepository)
        {
            this.procurementRepository = procurementRepository ?? throw new ArgumentNullException(nameof(procurementRepository));
            this.userProcurementRepository = userProcurementRepository ?? throw new ArgumentNullException(nameof(userProcurementRepository));
        }
        
        [Route("{id:long}")]
        [ResponseType(typeof(Procurement))]
        public async Task<IHttpActionResult> Get(long id)
        {
            if (id <= 0)
                throw new HttpResponseException(HttpStatusCode.Forbidden);

            string userId = User.Identity.GetUserId();
            var procurement = await userProcurementRepository.GetById(userId, id);
            if (procurement == null)
            {
               throw new HttpResponseException(HttpStatusCode.Forbidden);
            }

            return Ok(procurement);
        }
        
        [Route("{itemsPerPage:int}/{pageNumber:int}")]
        public async Task<IHttpActionResult> Get(int itemsPerPage, int pageNumber)
        {
            if (itemsPerPage <= 0 || pageNumber <= 0)
                throw new HttpResponseException(HttpStatusCode.Forbidden);

            string userId = User.Identity.GetUserId();
            var procurementList = userProcurementRepository.GetByUserId(userId, (pageNumber - 1) * itemsPerPage, itemsPerPage);
            int count = await userProcurementRepository.CountAsync(userId);
            
            return Ok(new { Items = procurementList, Count = count });
        }

        [HttpPost]
        [UnitOfWork]
        [ResponseType(typeof(Procurement))]
        public async Task<IHttpActionResult> Index(ProcurementViewModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }

            string userId = User.Identity.GetUserId();
            var procurement = new Procurement
            {
                Name = model.Name,
                Description = model.Description,
                Total = model.Total
            };

            var userProcurement = new UserProcurement { UserId = userId, Procurement = procurement };

            procurementRepository.Add(procurement);
            userProcurementRepository.Add(userProcurement);

            return Ok(procurement);
        }

        [HttpPut]
        [UnitOfWork]
        [ResponseType(typeof(Procurement))]
        public async Task<IHttpActionResult> Index(long id, ProcurementViewModel model)
        {
            if (id <= 0)
                throw new HttpResponseException(HttpStatusCode.Forbidden);

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }

            string userId = User.Identity.GetUserId();
            var procurement = procurementRepository.GetById(id);
            if (procurement == null)
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }

            procurement.Name = model.Name;
            procurement.Description = model.Description;
            procurement.Total = model.Total;

            procurementRepository.Update(procurement);

            return Ok(procurement);
        }
    }
}
