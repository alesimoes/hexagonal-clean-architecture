
# Hexagonal and Clean Architecture

## Motivation

Build an architecture where the Application and domain layers are free of
frameworks following the design of hexagonal architecture aligned with the practices of Clean architecture

# Hexagonal Architecture
The general idea behind the hexagonal architecture style is that the dependencies (adapters) required by the software to run are used behind an interface (port).

The software is divided into Application and Infrastructure, in which adapters are interchangeable components developed and tested in isolation. The Application is loosely coupled to the Adapters and their implementation details.

<img src = "Images/Hexagonal%20Example2.jpg" width="400"> <img src="Images/2008-onion-architecture5.png" width = "400">

### Ports
Ports are interfaces (Marker interfaces in some cases) defined by the application that must be implemented by the outside world so that the application can receive or send information.
Examples: IOutputPort IUserRepository IEventPublisher

### Adapters
An adapter is the implementation of an interface. It is in the external world of the application and can make use of packages, frameworks and etc.
Example: UserRepositoy.cs using Dapper or EntityFramework.
EventPublisher.cs using kakfa.

## Application Layer
The application layer is responsible for connecting the inputs and outputs to the outside world.
This connection is made through the ports.
Use Cases are the ones who orchestrate the business rules within the application layer.

<img src = "Images/hexagonal-architecture.png" width="300"> <img src="Images/Hexagonal%20Example.jpg" width="400">

### Use Case
Use Case is responsible for orchestrating the business rules defined for application.
The use case receives the Input or Request and from the input it executes the business rules triggering the domain.
After the domain is returned, the Use Case provides the return to the output ports that are connected to that Use Case.

#### Input Port
Input port is where it contains information for executing the use case.
In this architecture it was defined that the Input Port must block inconsistent data to execute the use case.
The idea is to stop the thief at the front door instead of letting him in to ask if he is a thief. ;-)

#### Output Port
The output ports of a Use case can be several. There is no correct number of ports plugged into a Use Case.
Usually the Output ports of an application are implemented by infrastructure or APIs.
An Output port for the API can be a Marker Interface that defines success or failure ports and when implemented, it provides a method for treating success or a method for treating failure.

Example. IOutputPort, IUserRepository, IEventPublisher and etc.

#### Repository
We ask here for a poetic license for Master Eric Evans.

Contrary to what was taught in Eric Evans' book, we identified that the door to the Repository would be better handled by the Application and not by the domain.

**Motivation**

The idea adopted in the domain is that it is capable of solving complex problems related to the domain.
We can make an analogy with complex mathematical formulas.

The domain allows me to have several mathematical formulas correlated that will be encapsulated by functionalities (services) and called by the Application.
These formulas can be executed in different sequences and therefore can produce different results.

The decision to print the result of the operations will be said by the application according to the user's need.
This allows an isolated domain within the application without access to the outside world.

It will continue to perform all the operations necessary for the integrity of the system, but who will decide where to get the data from, whether it is from a database or a message queue coming from a micro service, will be the application.


#### Application Exceptions
Application exceptions are generally thrown when there is an invalid data entry.
The Gateway must ensure that data entry is consistent, remembering that the Application does not know the outer layer and cannot assume that the outer layer has done all integrity checks.
To ensure the integrity of the Application, if there is an invalid data entry, it raises exceptions so that the external layer can handle the failure.

## Domain Layer (DDD)
The domain layer follows the DDD Standard using rich entities, Value Objects, Event Sourcing and Domain Service.

Here, as mentioned above, we broke one of the DDD rules and removed the repository, passing this responsibility to the application. We know that this will generate a lot of divergence;)

This layer is responsible for handling all rules regarding the domain.

We have to keep in mind (for this architecture) that the domain layer does not know the database infrastructure and that is the responsibility of the Application that can use one or more persistence infrastructures as it wishes.


### Value Objects
Entities can be built using value objects.
Value objects are immutable structures that give characteristics to the entity and have internal micro-rules.

### Entities
Entities have a set of properties, methods and events related to it.

The entity is an internal object to the domain and must be responsible for handling all domain rules related to it.

A modification to an entity property must be called by a method that will trigger an event for the change to be applied to the entity.
The triggered event is registered in the entity itself following the Event Sourcing Standard, which may be published later, allowing the reconstruction of all modifications made.

### Events (Event Sourcing)
Each entity may have events and event handling that will be used by it.

When an action is performed on an entity, the event must be triggered for that action to be applied to the entity using the Handler subscribed to that event.

This allows domain rules to be decoupled from the entity and can be shared and organized in separate files.

Example. A product entity had its price readjusted and for that product it has several promotions.
The flow would be Initial Price -> Adjusted Price Event -> Final Price -> Updated Promotions Event -> Final Promotions Price

Following this example in the Product entity, we would have only one method to adjust the price of the Product and the events would be handled by Handlers in the domain layer.

The sequence of events that have occurred can be published to an infrastructure through the Application layer, making it possible to redo the entire price update process perfectly.
Recalling that the domain does not access and has no knowledge of anything beyond itself, that is, the domain does not know the Application layer and does not know the event publishing infrastructure.


### Domain Service
Communication between the Application and the Domain is through a service provided by the domain.

The application must not be able to manipulate entities in written mode without going through a domain service.
This allows decoupling of domain rules by encapsulating calls into domain services, which tend to be more complex.

Domain services encapsulate rules and not domain entities, that is, I do not have a domain service per entity, but a domain service per context.

Ex. In a banking system I can have a domain service for transfers. He should be able to manage transfers between accounts. The account entity must be able to manage account rules, such as receiving money or debiting money.


### Domain Exceptions
Domain exceptions are the domain's way of informing the upper tier that something is wrong, be it data entry or some domain rule that has been broken.
As the domain is not aware of the upper layer (Application) it needs to guarantee the integrity of its objects.

## References
Evans, Eric - Domain Driven Design

Martin C. Robert - Clean Architecture
 
Ivan Paulovich - https://github.com/ivanpaulovich/clean-architecture-manga
