using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Start_Template.Modals;
using API_Start_Template.Modals.Request;
using API_Start_Template.ServerModals;
using API_Start_Template.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Start_Template.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("api/wallet")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private WalletService _service;

        public WalletController()
        {
            _service = new WalletService();
        }


        [Route("{name}"), HttpGet]
        public ItemResponse<Wallet> Get(string name)
        {
            var responseBody = new ItemResponse<Wallet>();
            bool success = true;
            (success, responseBody.Item) = _service.Get(name);

            if (success)
            {
                Response.StatusCode = 200;
                responseBody.IsSuccessful = true;
                return responseBody;
            }

            Response.StatusCode = 404;
            responseBody.IsSuccessful = false;
            return responseBody;
        }

        [Route("list"), HttpGet]
        public ItemResponse<List<Wallet>> GetAll()
        {
            var responseBody = new ItemResponse<List<Wallet>>();

            responseBody.Item = _service.GetAll();
            responseBody.IsSuccessful = true;

            Response.StatusCode = 200;
            return responseBody;
        }


        [HttpPost]
        
        public ItemResponse<string> Create(WalletRequest requestBody)
        {
            Exception x = new Exception();
            var responseBody = new ItemResponse<string>();
            bool success = true;
            (success, x) = _service.Create(requestBody);
            if (success)
            {
                Response.StatusCode = 200;
                responseBody.Item = "Created";
                responseBody.IsSuccessful = true;
            }
            else
            {
                Response.StatusCode = 500;
                Console.WriteLine(x.Message);
                responseBody.IsSuccessful = false;
            }
            return responseBody;
        }

        [Route("{name}"), HttpDelete]
        public ItemResponse<object> Delete(string name)
        {
            bool success = true;
            var responseBody = new ItemResponse<object>();
            success = _service.Delete(name);
            if (success)
            {
                Response.StatusCode = 200;
                responseBody.IsSuccessful = true;
            }
            else
            {
                Response.StatusCode = 404;
                responseBody.IsSuccessful = false;
            }
            return responseBody;
        }
    }
}
