# Payment Gateway
[![Build](https://github.com/eloisetaylor5693/payment-gateway/actions/workflows/build.yml/badge.svg)](https://github.com/eloisetaylor5693/payment-gateway/actions/workflows/build.yml) [![e2e tests](https://github.com/eloisetaylor5693/payment-gateway/actions/workflows/run-e2e-tests.yml/badge.svg)](https://github.com/eloisetaylor5693/payment-gateway/actions/workflows/run-e2e-tests.yml)

## Assumptions

- [Merchant ID](https://tidalcommerce.com/learn/merchant-id-number)
- [Terminal ID](https://www.opayo.co.uk/support/28/36/terminal-id-s)
- Only handling card payments. Other payment methods are "phase 2" of the project

## What I would do differently

- Instead of relying on datetime, I might use a library such as noda time for more reliable dates