describe('/payment-gateway/api/pay/get-transaction', () => {
    describe('Given a payment ID that exists', () => {
        it('Then payment information is returned', () => {
            const request = {
                transactionId: "6fa85f64-5717-4562-b3fc-2c963f66afa9"
            };

            cy.request('POST', '/pay/get-transaction', request)
                .then(response => {
                    expect(response.status).to.equal(200);
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