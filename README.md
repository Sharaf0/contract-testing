
#  0. What is the Problem?

-  We  are  building  a  set  of  services  that  communicate  with  each  other.

-  We  need  to  ensure  that  the  services  are  compatible  and  that  they  can  communicate  effectively.

-  We  need  to  detect  issues  early  in  the  development  process, before  they  become  more  difficult  and  expensive  to  fix.

-  We  need  to  avoid  using  integration  testing  because  it  is  expensive, slow, and  complex.

  

#  1. What  is  Contract  Testing?
- Contract testing verifies that two services (a consumer and a provider) interact correctly according to a shared contract.

- The contract is a document that describes the interactions between the consumer and the provider. It specifies the request and response formats, the expected behavior, and the error handling.

- Contract testing is service-agnostic, meaning that it can be used to test any type of service, such as RESTful APIs, message queues, or databases.

- Contract testing is different from integration testing, which tests the interactions between multiple services in a real-world environment.

- Contract testing represents a living document that can be shared between the consumer and provider services to ensure that they are compatible and can communicate effectively.

  

#  2. Why  is  Contract  Testing  Important?

-  Compatibility.

-  Early  Detection.

-  Cost-Effective.

  

#  3. Why  don't  we  use  Integration  Testing?

-  Integration  testing  is  expensive, slow, complex  and  can  easily  be  flaky.

-  Contract  Testing  is  more  stable  and  reliable.

  

#  4. How  does  Contract  Testing  work?

-  Consumer  Driven  Contract  Testing.

-  Provider  Driven  Contract  Testing.

  

#  5. How  to  implement  Contract  Testing?

-  Use  a  Contract  Testing  Tool.

-  Write  Contract  Tests.

-  Run  Contract  Tests.

![alt text](https://docs.pact.io/img/how-pact-works/summary.png "Title")

  

#  6. How  does  a  pact  file  look  like?
```json
{
    "consumer": {
        "name": "Consumer Service"
    },
    "provider": {
        "name": "Provider Service"
    },
    "interactions": [
        {
            "description": "a request for something",
            "request": {
                "method": "GET",
                "path": "/something"
            },
            "response": {
                "status": 200,
                "headers": {
                    "Content-Type": "application/json"
                },
                "body": {
                    "something": "something"
                }
            }
        }
    ]
}
```
  

#  7. How to use Pact for Contract Testing (Consumer Driven Contract Testing)?

-  Let's assume:

-  We  have  three  services: C1, C2  and  P.

-  Consumer  Service  C1  and  C2  are  the  services  that  consume  the  Provider  Service  P.

-  We  have  a  central  git  repository (SSOT) to  store  the  Pact  files, which  will  be  shared  between  the  Consumer  Services  and  Provider  Service, won't use Pact broker.

-  We  will  utilize  pipelines  of  all  services  to  generate  and  verify  the  Pact  files.

-  Steps:

-  Consumer  Service  C1  will  write  the  contract  tests  and  generate  the  Pact  files.

-  In  the  pipeline  of  Consumer  Service  C1, the  Pact  files  will  be  generated  and  pushed  to  the  central  git  repository.

-  Provider  Service  P  will  verify  the  Pact  files  in  its  pipeline.

-  We  can  have  conventions  to  name  the  Pact  files, like  "c1-p.json".

-  Consumer  Service  C2  will  write  the  contract  tests  and  generate  the  Pact  files.

-  In  the  pipeline  of  Consumer  Service  C2, the  Pact  files  will  be  generated  and  pushed  to  the  central  git  repository.

-  Provider  Service  P  will  verify  the  Pact  files  in  its  pipeline.

-  We  can  have  conventions  to  name  the  Pact  files, like  "c2-p.json".

-  How  to  enforce  consumer  tests  to  be  realistic?

	-  Provider's stubs can be used to verify the consumer tests.
	-  Tests  can  be  run  against  live  services, but  it  is  not  recommended.
	- Optimistic flow
	- Pactflow

  

#  8. Why do we have to have multiple Pact files for the same consumer?

-  Different  requirements.

-  Overcomplicated  contracts.

-  Granularity.

-  Avoid  having  a  single  point  of  failure.