describe('/payment-gateway/api/pay/get-transaction', () => {
    describe('Given a payment ID that exists', () => {
        it('Then payment information is returned', () => {
            const request = {
                transactionId: "6fa85f64-5717-4562-b3fc-2c963f66afa9"
            };

            cy.request('POST', '/pay/get-transaction', request)
                .then(response => {
                    expect(response.status).to.equal(200);

                    expect(response.body.merchantId).to.equal('123456789012345');
                    expect(response.body.terminalId).to.equal('12345678');
                    expect(response.body.transactionId).to.equal('6fa85f64-5717-4562-b3fc-2c963f66afa9');
                    expect(response.body.paymentAmount).to.equal(275.69);
                    expect(response.body.isoCurrencyCode).to.equal('GBP');
                    expect(response.body.paymentReference).to.equal('Order#9876');
                    expect(response.body.paymentStatus).to.equal(1);
                    expect(response.body.transactionSucessful).to.equal(true);
                });
        });
    });

    describe("Given a payment ID that doesn't exist", () => {
        it('then response advises the ID is not found', () => { 
            const request = {
                transactionId: "6fa85f64-5717-4562-abc2-2c963f66afa9"
            };

            cy.request('POST', '/pay/get-transaction', request)
                .then(response => {
                    expect(response.status).to.equal(204);
                });
        });
    });
});