describe('/payment-gateway/api/pay/get-transaction', () => {
    describe('Given a payment ID that exists', () => {
        it('Then payment information is returned', () => {
            const request = {
                transactionId: "6fa85f64-5717-4562-b3fc-2c963f66afa9"
            };

            cy.request('POST', '/pay/get-transaction', request)
                .then(response => {
                    expect(response.status).to.equal(200);

                    const actualPayment = {
                        ...response.body,
                        transactionDate: null
                    };

                    expect(actualPayment).to.deep.equal({
                        merchantId: '123456789012345',
                        terminalId: '12345678',
                        transactionId:'6fa85f64-5717-4562-b3fc-2c963f66afa9',
                        paymentAmount:275.69,
                        isoCurrencyCode:'GBP',
                        paymentReference: 'Order#9876',
                        transactionSucessful: true,
                        paymentStatus: 1,
                        transactionDate: undefined,
                        bankTransactionId: '12a3d345-5717-4562-b3fc-2c963f66afa9',
                        bankTransactionMessage: null,
                        card: {
                            nameOnCard: "Miss Anne Other",
                            cardIssuer: "Visa",
                            cardNumber: "**** **** **** 1881",
                            expiryDate: "05/25",
                            cvv: 123
                          }
                    });
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