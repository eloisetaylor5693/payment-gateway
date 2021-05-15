# Payment Gateway
[![Build](https://github.com/eloisetaylor5693/payment-gateway/actions/workflows/build.yml/badge.svg)](https://github.com/eloisetaylor5693/payment-gateway/actions/workflows/build.yml) [![e2e tests](https://github.com/eloisetaylor5693/payment-gateway/actions/workflows/run-e2e-tests.yml/badge.svg)](https://github.com/eloisetaylor5693/payment-gateway/actions/workflows/run-e2e-tests.yml)

## Testing
[Test Credit card numbers](https://www.paypalobjects.com/en_AU/vhelp/paypalmanager_help/credit_card_numbers.htm) that will pass validation.

See `e2e\readme.md` for more information on running the Cypress tests.

## Assumptions

- [Merchant ID](https://tidalcommerce.com/learn/merchant-id-number)
- [Terminal ID](https://www.opayo.co.uk/support/28/36/terminal-id-s)
- Only handling card payments. Other payment methods are "phase 2" of the project

## Decisions

I decided to test the API using Cypress because it's quick to configure and easy to use.  Another benefit is that testing an API in 2 languages can highlight issues in the usage of the RESTful API (unit tests in c# and e2e in Javascript).  If I used C# all the way through, I wouldn't see the pain of the different date formats as easily, because I would likely be using `DateTime` all the way through.  

I used fluent validation because it has some useful inbuilt validators such as the card number validator.  I could have also used value types for each of the fields in the request to ensure they are valid values.

I used the mediatr library because I think that the mediator pattern helps create a clean architecture within the app.

I have tried to optimise for readibility of the code

## What I would do differently

- Instead of relying on datetime, I might use a library such as noda time for more reliable dates.      
- I would containerise this API.  My PC is "Windows 10 Home" so it's a bit of a pain to install docker on. 
- I may get rid of the magic strings in the validation logic.  I held off for the time being because I think that some of the messages needed to be customised according to which validation rule triggered the error.