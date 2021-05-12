describe('/payment-gateway/api/pay/get-transaction', () => {
    describe('Given a payment ID that exists', () => {
        it('Then payment information is returned', () => {
            const request = {
                transactionId: ''
            };

            cy.request('POST', '/pay/get-transaction', request)
                .then(response => {
                    expect(response.status).to.equal(200);
                })
        });
    });

    describe("Given a payment ID that doesn't exist", () => {
        it('then response advises the ID is not found', () => { });
    });
});