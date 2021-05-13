﻿using MediatR;
using PaymentGateway.BankPayment;
using PaymentGateway.Models;
using PaymentGateway.Requests;
using Serilog.Context;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.RequestHandlers
{
    public sealed class MakeAPaymentRequestHandler : IRequestHandler<MakeAPaymentRequest, PaymentResponse>
    {
        private readonly IMakeBankPaymentAdapter _bankPaymentAdapter;

        public MakeAPaymentRequestHandler(IMakeBankPaymentAdapter bankPaymentAdapter)
        {
            _bankPaymentAdapter = bankPaymentAdapter;
        }

        public async Task<PaymentResponse> Handle(MakeAPaymentRequest request, CancellationToken cancellationToken)
        {
            using (LogContext.PushProperty("transactionId", request.TransationId))
            {
                // validate request 

                // have I made the payment before?

                var response = await _bankPaymentAdapter.PayAsync(request);

                // store payment + result

                return new PaymentResponse
                {
                    TransactionSucessful = response.TransactionSucessful,
                    TransationId = request.TransationId,
                    Message = response.Message
                };
            }
        }
    }
}
