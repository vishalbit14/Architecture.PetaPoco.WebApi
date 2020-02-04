# Architecture.PetaPoco.WebApi
Project Architecture is designed to using the ASP.NET Web API 5.2.7, PetaPoco ORMs, and can able to work with multiple databases. Also, added a custom token-based Authentication using the action filter attribute and handling the exceptions.


**1. Architecture.WebApi** - Architecture.WebApi holds the routing and configuration of the projects.

**2. Architecture.Core** - Architecture.Core holds the API controllers, the business logic of the system and mapped to the Entity to ViewModel and sends the result to the Controllers to source and vice versa. Currently, the Core project holds Attributes, IDataPRovider, and DataProvider. You can add Attributes under the Core projects which is for the business logic and create Data Provider and Interface Data Provider for every controller.

**3. Architecture.Data** - Architecture.Data holds the database logic and created the multiple common functions into the BaseDataProvider.cs which can be inherited from the PetaPoco methods and easy to use in multiple scenarios. Also, added Entity and Attributes which depend on the database logics. The data project is the mediator of the database and business logic.

**4. Architecture.Generic** - Architecture.Generic holds all view models, common functions, helpers, enumerations, extensions, configs, constants, and resources.
