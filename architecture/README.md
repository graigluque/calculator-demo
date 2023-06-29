![Calculator-demo-Azure-deployment-view](https://github.com/graigluque/calculator-demo/assets/50812467/b810333f-ae9e-423b-a317-ebe6381bbc80)# Solution Architecture

Following is described the solution architecture for a Simple Calculator Demo:

## Context View

##### Data flow diagram

![context-view](images/Calculator-demo-context.png?raw=true "Context view")

1. User use the Web App to request a new calculation
2. Web App publish a new message in a Queue of the Azure Service Bus
3. The Queue triggers a Function App with the logic to calculate the math operation
4. The Function App store the request and result in an SQL Database
5. Send a message through SignalR to notify to Web App the calculation result

## 4+1 View Model

![4+1-view-model](https://upload.wikimedia.org/wikipedia/commons/thumb/e/e6/4%2B1_Architectural_View_Model.svg/354px-4%2B1_Architectural_View_Model.svg.png)

4+1 is a view model used for "describing the architecture of software-intensive systems, based on the use of multiple, concurrent views".[1] The views are used to describe the system from the viewpoint of different stakeholders, such as end-users, developers, system engineers, and project managers. The four views of the model are logical, development, process and physical view. In addition, selected use cases or scenarios are used to illustrate the architecture serving as the 'plus one' view. Hence, the model contains 4+1 views[1]:

### Logical View

The logical view is concerned with the functionality that the system provides to end-users. UML diagrams are used to represent the logical view, and include class diagrams, and state diagrams.

##### Class diagrams

> [TODO]

### Process view

The process view deals with the dynamic aspects of the system, explains the system processes and how they communicate, and focuses on the run time behavior of the system. The process view addresses concurrency, distribution, integrator, performance, and scalability, etc. UML diagrams to represent process view include the sequence diagram, communication diagram, activity diagram.

##### Sequence diagram

![seq-diagram](images/Calculator-demo-sequence-diagram.png?raw=true "Sequence diagram")

### Development view

The development view illustrates a system from a programmer's perspective and is concerned with software management. This view is also known as the implementation view. UML Diagrams used to represent the development view include the Package diagram and the Component diagram.

##### Component diagram

![component-diagram](images/Calculator-demo-Component-view.png?raw=true "Component view")

### Physical view

The physical view (aka the deployment view) depicts the system from a system engineer's point of view. It is concerned with the topology of software components on the physical layer as well as the physical connections between these components. UML diagrams used to represent the physical view include the deployment diagram.

##### Deployment diagram

![deployment-diagram](images/Calculator-demo-Azure-deployment-view.png?raw=true "Deployment view")

> [TODO: refine diagrama]

### Scenarios

The description of an architecture is illustrated using a small set of use cases, or scenarios, which become a fifth view. The scenarios describe sequences of interactions between objects and between processes. They are used to identify architectural elements and to illustrate and validate the architecture design. They also serve as a starting point for tests of an architecture prototype. This view is also known as the use case view.

##### Use cases diagram

![use-cases](images/Calculator-demo-Use-case.png?raw=true "Uses cases view")

## References

[1] https://en.wikipedia.org/wiki/4+1_architectural_view_model
