# Solution Architecture

Following is described the solution architecture for a Simple Calculator Demo:

## Context View

##### Data flow diagram

![context-view](https://lh3.googleusercontent.com/drive-viewer/AFGJ81pxCvs0t9ttv6NqGcoeQY4ZooILoV77U0oNzr-dbtEbS8G79ZNHHtHlecqEQ8oZD0FF6gp7Z_8sxp3amH6n6MBPCNZAzQ=w1366-h653)

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

![seq-diagram](https://www.websequencediagrams.com/cgi-bin/cdraw?lz=dGl0bGUgQ2FsY3VsYXRvci1kZW1vIHNlcXVlbmNlCgphY3RvciBVc2VyClVzZXItPldlYiBBcHA6IEFjY2VzcyB0byAADAcKABQHLT5TaWduYWxSOiBTdGFibGlzaCAACwcgQ29ubmVjdGlvbgA_EFJlcXVlc3QgbmV3AIEGCWlvbgBKC2VydmljZSBCdXM6IFNlbmQgTWVzc2FnZSgAJA8pCgAgCy0-RnVuYwCBLAZRdWV1ZSB0cmlnZ2VycwoAEQgAFwwAggEIZSBvcGVyAHwGAB4KRGF0YWJhc2U6IFNhdgCCLAoAFw4AgXMKAIEZCwoAggwHAII1C05vdGlmeQCBYAwgUmVzdWx0AII-ClVzZXI6IFNob3cAghIFABgHAIJ5D0xlYXZlAIJpG0Nsb3NlAIJtFA&s=modern-blue)

### Development view

The development view illustrates a system from a programmer's perspective and is concerned with software management. This view is also known as the implementation view. UML Diagrams used to represent the development view include the Package diagram and the Component diagram.

##### Component diagram

![component-diagram](https://lh3.googleusercontent.com/u/0/drive-viewer/AFGJ81qBBGaEizte0DBGbhFRwPkbHI90P2P3M5xdWJqQb5Z7yIHmZBzjjT6xQyyamQ8ew-pdebx3EuRVkPTn8rxBJEuJe_yRhw=w1920-h904)

### Physical view

The physical view (aka the deployment view) depicts the system from a system engineer's point of view. It is concerned with the topology of software components on the physical layer as well as the physical connections between these components. UML diagrams used to represent the physical view include the deployment diagram.

##### Deployment diagram

![deployment-diagram](https://lh3.googleusercontent.com/u/0/drive-viewer/AFGJ81paNBSDAE86aiv7OEKR59_WcT64JelyluIozWbHPHWmJ8G5ELa6TBDiUdC6GFI4XMoXtCHB-r-WFERVJgajQ7ynFGrd6Q=w1920-h904)

> [TODO: refine diagrama]

### Scenarios

The description of an architecture is illustrated using a small set of use cases, or scenarios, which become a fifth view. The scenarios describe sequences of interactions between objects and between processes. They are used to identify architectural elements and to illustrate and validate the architecture design. They also serve as a starting point for tests of an architecture prototype. This view is also known as the use case view.

##### Use cases diagram

![use-cases](https://lh3.googleusercontent.com/u/0/drive-viewer/AFGJ81oigleVo-P0QXQiOE6F7U3w8WC6Lf9lE-f_06rukvli1aWwQHc4xfo2NKngIdVIsF_E2LXFP1mbdW6ZtPf1u8Nt7gfF=w1920-h904)

## References

[1] https://en.wikipedia.org/wiki/4+1_architectural_view_model
