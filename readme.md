This readme file serves as a web-based piece of documentation for every single part of the LoanBroker architecture. It's not the most complex sort of description for each piece of the system, but this will have to do.

# Get Credit Score
The first part of the system to be activated is the part that fetches the credit score. it does this by establishing a communication with the preestablished credit bureau, thereby generating a random credit score for us to send further down the messaging pipeline.

# Get Banks
The second part is merely a shell that fetches a list of compatible banks from a soap-made Rule Base we've developed. We send our credit score as well as our loan duration to the base, and then receive a list of acceptable banks.

## Rule Base
The Rule Base is a component that we were forced to make, where it contains a simple pool of possible banks that one user can be subscribed to depending on their credit score as well as the length of their desired loan.

# Recipient List
Once we have the list of banks available in the third part of the system, the Recipient List starts assigning eligible banks to the message that's currently passing through the system. Because of this, the Translator will know what to do with the message.

# Translator
Once the Translator receives the message, it checks what banks have been attached to the message and sends a copy of it to each of the applicable banks, translating the message inside of a single program.

## RabbitMQ Bank
One of the banks that we had to develop ourselves was a RabbitMQ Bank that just used messaging. Because of this, we were allowed to pick the return values after giving it an input.

## Web Service Bank
Like with the RabbitMQ Bank, this bank was ours to customize to our liking, and we decided to make one based on the classic Restful format. This bank takes in a loan amount and duration, and spits a rate back out.

# Normalizer
Upon everything being processed by the various banks, they're sent back into the normalizer where they are converted back into C# formats, so that the aggregator can handle all the relevant information

# Aggregator
With every relevant rate being gathered in one place, the aggregator orders them based on the best to worst, and then spits them all out.
