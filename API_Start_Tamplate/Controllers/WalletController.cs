using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Start_Template.Modals;
using API_Start_Template.Modals.Request;
using API_Start_Template.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Start_Template.Controllers
{
    [Route("api/mywallet")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private WalletService _service;

        public WalletController()
        {
            _service = new WalletService();
        }


        [Route("{name}"), HttpGet]
        public Wallet Get(string name)
        {
            Wallet wallet = new Wallet();
            bool success = true;
            (success, wallet) = _service.Get(name);

            if (success)
            {
                Response.StatusCode = 200;
                return wallet;
            }

            Response.StatusCode = 404;
            return null;
        }
        
        [Route("list"),HttpGet]
        public List<Wallet> GetAll()
        {
            List<Wallet> wallets = new List<Wallet>();
            wallets = _service.GetAll();

            Response.StatusCode = 200;
            return wallets;
        }


        [HttpPost]
        public string Create(WalletRequest requestBody)
        {
            Exception x = new Exception();
            bool success = true;
            (success, x) = _service.Create(requestBody);
            if (success)
            {
                Response.StatusCode = 200;
                return "Created";
            }
            else
            {
                Response.StatusCode = 500;
                Console.WriteLine(x.Message);
                return "ServerError";
            }
        }
    }
}
