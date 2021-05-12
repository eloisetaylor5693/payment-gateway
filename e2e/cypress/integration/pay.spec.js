describe('/payment-gateway/api/pay', () => {
    describe('When making a valid payment request', () => {
        it('Then it succeeds', () => {
            const request = {
                "transactionDate": "2021-05-12T16:26:36.246Z",
                "merchantId": 123,
                "terminalId": 5,
                "paymentAmount": 32.93,
                "isoCurrencyCode": "GBP",
                "paymentReference": "Order #2325",
                "card": {
                    "nameOnCard": "Miss Anne Other",
                    "cardIssuer": "Mastercard",
                    "cardNumber": "5574123412341234",
                    "expiryDate": "05/55",
                    "cvv": 123
                }
            };

            cy.request('POST', '/pay', request)
                .then(response => {
                    expect(response.status).to.equal(200);

                    expect(response.body.transactionSucessful).to.be.true;
                    expect(response.body.transationId).to.not.be.null;
                    expect(response.body.message).to.equal("Payment received");
                })
        });
    });

    describe('When making an invalid payment request', () => {
        it('then payment is rejected', () => { });
    });

    describe('when I repeat the same payment', () => {
        it('then payment is rejected', () => { });
    });
});