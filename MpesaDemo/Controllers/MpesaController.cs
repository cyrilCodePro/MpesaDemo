using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MpesaService.ServiceModels;
using MpesaService.Services;

namespace MpesaDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MpesaController : ControllerBase
    {
        private readonly IMpesa _mPesa;
        private readonly Credentials _credentials;

        public MpesaController(IMpesa mPesa, IOptions< Credentials> credentials)
        {
            _mPesa = mPesa;
            _credentials = credentials.Value;
        }

        [HttpGet]
        public async Task<IActionResult> C2bStkPush(LipaNaMpesaResponse lipaNaMpesaResponse)
        {
            var time = _mPesa.Totime();
            var test = await _mPesa.InitiateStkPush(new LipaNaMpesaModelPost
            {
                AccountReference = "13455",
                Amount = "5",
                BusinessShortCode = _credentials.C2bshortCode,
                CallBackURL = "https://mobile.cemascore.com/api/v1/cemascore/c2b/stk-push-validation",
                PartyA = "254706394137",
                PartyB = _credentials.C2bshortCode,
                Password = _mPesa.GenerateBase64(string.Format("{0}{1}{2}", _credentials.C2bshortCode, _credentials.LipaNaMpesaPassKey, time)),
                Timestamp = time,
                PhoneNumber = "254706394137",
                TransactionDesc = "Deposit",
                TransactionType = "CustomerPayBillOnline",
            });
            return Ok(test);
        }
    }
}