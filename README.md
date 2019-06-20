# TransformersBank
EF6 with separated entity configuration and EF migrations

# Extension to existing solution - WebApi project with DI container (SimpleInjector)

1. Add new project called "Transformers.Bank.WebApi" (ASP.NET Web Application (.NET Framework) - Empty project - select Web API)

2. Add nuget package: Install-package SimpleInjector.Integration.WebApi to WebApi project

3. Add project called "Transformers.Bank.Core" which will contain business logic.

4. Add references of Data, Core projects to WebApi project.

5. Add nuget EF6 to WebApi and Core.

6. Add reference of Data to Core.




