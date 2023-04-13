using System;
using MediatR;
using Newtonsoft.Json;
using ECommerce.Application.Configuration.Commands;
using ECommerce.Domain.Payments;

namespace ECommerce.Application.Payments.SendEmailAfterPayment
{
    public class SendEmailAfterPaymentCommand : InternalCommandBase<Unit>
    {
        public PaymentId PaymentId { get; }

        [JsonConstructor]
        public SendEmailAfterPaymentCommand(Guid id, PaymentId paymentId) : base(id)
        {
            this.PaymentId = paymentId;
        }
    }
}