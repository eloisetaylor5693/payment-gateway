describe('/payment-gateway/api/pay', () => {
    describe('When making a valid payment request', () => {
        it('Then it succeeds', () => {
            const request = {
                "transactionDate": new Date(),
                "merchantId": "123456789012345",
                "terminalId": "12345678",
                "paymentAmount": 32.93,
                "isoCurrencyCode": "GBP",
                "paymentReference": "Order#2325",
                "card": {
                    "nameOnCard": "Miss Anne Other",
                    "cardIssuer": "Mastercard",
                    "cardNumber": "5105105105105100",
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
                });
        });
    });

    describe("When the accound doesn't have enough funds to make the payment", () => {
        it('then payment fails', () => {
            const request = {
                "transactionDate": new Date(),
                "merchantId": "123456789012345",
                "terminalId": "12345678",
                "paymentAmount": 556.93,
                "isoCurrencyCode": "GBP",
                "paymentReference": "Order#2325",
                "card": {
                    "nameOnCard": "Miss Anne Other",
                    "cardIssuer": "American Express",
                    "cardNumber": "371449635398431",
                    "expiryDate": "05/55",
                    "cvv": 123
                }
            };

            cy.request({
                method: 'POST',
                url: '/pay',
                body: request,
                failOnStatusCode: false
            }).then(response => {
                expect(response.status).to.equal(400);

                expect(response.body.transactionSucessful).to.be.false;
                expect(response.body.transationId).to.not.be.null;
                expect(response.body.message).to.equal("Not enough funds to make the payment");
            });
        });
    });

    describe('when I repeat the same payment', () => {
        it('then payment is rejected', () => { });
    });
});