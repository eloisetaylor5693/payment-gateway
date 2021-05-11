﻿using Microsoft.AspNetCore.Mvc;
using System;

namespace PaymentGateway.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        [HttpPost]
        [Route("make-a-payment")]
        public ActionResult MakePayment()
        {
            return Ok("Payment received");
        }

        [HttpGet]
        [Route("get-transaction")]
        public ActionResult GetPaymentInformation([FromQuery] string paymentId)
        {
            return Ok("Here's your payment information");
        }
    }
}
