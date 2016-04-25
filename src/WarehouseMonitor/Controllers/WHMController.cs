using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WarehouseMonitor.Models;
using Microsoft.Extensions.OptionsModel;
using System.Net;
#if DNX451
namespace WarehouseMonitor.Controllers
{
    public class WHMController
        : Controller
    {
        private DataRepository repository;
        private IOptions<DataSettings> dataSettings;

        public WHMController(IOptions<DataSettings> dataSettings)
        {
            this.dataSettings = dataSettings;
            this.repository = new DataRepository(this.dataSettings.Value.ConnectionString);
        }

        [HttpGet]
        [Route("WarehouseMonitor/Test")]
        public IEnumerable<Shipment> OfflineTest()
        {
            if (BasicAuthHttpModule.ApplicationAuthenticateRequest(HttpContext.Request.HttpContext, dataSettings))
            {
                List<Shipment> list = new List<Shipment>();
                list.Add(new Shipment() { Date = DateTime.Now, Shipments = 10, Weight = 5 });
                list.Add(new Shipment() { Date = DateTime.Now, Shipments = 15, Weight = 5 });
                list.Add(new Shipment() { Date = DateTime.Now, Shipments = 15, Weight = 5 });
                list.Add(new Shipment() { Date = DateTime.Now, Shipments = 16, Weight = 5 });
                list.Add(new Shipment() { Date = DateTime.Now, Shipments = 17, Weight = 5 });
                list.Add(new Shipment() { Date = DateTime.Now, Shipments = 10, Weight = 5 });
                list.Add(new Shipment() { Date = DateTime.Now, Shipments = 10, Weight = 5 });
                return list;
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return null;
            }
        }

        [HttpGet]
        [Route("WarehouseMonitor/SEPast")]
        public IEnumerable<Shipment> SEPast()
        {
            if (BasicAuthHttpModule.ApplicationAuthenticateRequest(HttpContext.Request.HttpContext, dataSettings))
            {
                try
                {
                    IEnumerable<Shipment> list = repository.GetSEPast();
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    return list;
                }
                catch (Exception)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return null;
                }
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return null;
            }
        }

        [HttpGet]
        [Route("WarehouseMonitor/SEToday")]
        public IEnumerable<Shipment> SEToday()
        {
            if (BasicAuthHttpModule.ApplicationAuthenticateRequest(HttpContext.Request.HttpContext, dataSettings))
            {
                try
                {
                    IEnumerable<Shipment> list = repository.GetSEToday();
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    return list;
                }
                catch (Exception)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return null;
                }
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return null;
            }
        }

        [HttpGet]
        [Route("WarehouseMonitor/SAPast")]
        public IEnumerable<ShipmentsOutput> SAPast()
        {
            if (BasicAuthHttpModule.ApplicationAuthenticateRequest(HttpContext.Request.HttpContext, dataSettings))
            {
                try
                {
                    IEnumerable<ShipmentsOutput> list = repository.GetSAPast();
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    return list;
                }
                catch (Exception)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return null;
                }
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return null;
            }
        }

        [HttpGet]
        [Route("WarehouseMonitor/SAToday")]
        public IEnumerable<ShipmentsOutput> SAToday()
        {
            if (BasicAuthHttpModule.ApplicationAuthenticateRequest(HttpContext.Request.HttpContext, dataSettings))
            {
                try
                {
                    IEnumerable<ShipmentsOutput> list = repository.GetSAToday();
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    return list;
                }
                catch (Exception)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return null;
                }
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return null;
            }
        }

        [HttpGet]
        [Route("WarehouseMonitor/PickupPast")]
        public IEnumerable<Shipment> PickupPast()
        {
            if (BasicAuthHttpModule.ApplicationAuthenticateRequest(HttpContext.Request.HttpContext, dataSettings))
            {
                try
                {
                    IEnumerable<Shipment> list = repository.GetPickupPast();
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    return list;
                }
                catch (Exception)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return null;
                }
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return null;
            }
        }

        [HttpGet]
        [Route("WarehouseMonitor/PickupTodate")]
        public IEnumerable<Shipment> PickupTodate()
        {
            if (BasicAuthHttpModule.ApplicationAuthenticateRequest(HttpContext.Request.HttpContext, dataSettings))
            {
                try
                {
                    IEnumerable<Shipment> list = repository.GetPickupToday();
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    return list;
                }
                catch (Exception)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return null;
                }
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return null;
            }
        }

        [HttpGet]
        [Route("WarehouseMonitor/DeliveryPast")]
        public IEnumerable<Shipment> DeliveryPast()
        {
            if (BasicAuthHttpModule.ApplicationAuthenticateRequest(HttpContext.Request.HttpContext, dataSettings))
            {
                try
                {
                    IEnumerable<Shipment> list = repository.GetDeliveryPast();
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    return list;
                }
                catch (Exception)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return null;
                }
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return null;
            }
        }

        [HttpGet]
        [Route("WarehouseMonitor/DeliveryTodate")]
        public IEnumerable<Shipment> DeliveryTodate()
        {
            if (BasicAuthHttpModule.ApplicationAuthenticateRequest(HttpContext.Request.HttpContext, dataSettings))
            {
                try
                {
                    IEnumerable<Shipment> list = repository.GetDeliveryToday();
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    return list;
                }
                catch (Exception)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return null;
                }
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return null;
            }
        }
    }
}
#endif
