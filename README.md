# DDDQuestion
Questioning Domain-Driven Concepts, am I doing right? Help me :)

First of all:
We assume
- [Anemic Domain Model is an Anti-Pattern] (www.martinfowler.com/bliki/AnemicDomainModel.html)
- [Service Locator is an Anti-Pattern](http://blog.ploeh.dk/2010/02/03/ServiceLocatorisanAnti-Pattern/) (in most cases, [Martin says: Not everytime an Anti-Pattern](http://martinfowler.com/articles/injection.html#UsingAServiceLocator) )
  - and [it violates SOLID] (http://blog.ploeh.dk/2014/05/15/service-locator-violates-solid/)
  - and [it violates encapsulation] (http://blog.ploeh.dk/2015/10/26/service-locator-violates-encapsulation/)

I am trying to en-Rich Domain Model.

I am confused it a repository can access to [User Information] (HRSystem.Domain/Repositories/EmployeeRepository.cs#L20)

I am not happy with Vacation model's [Approve method] (HRSystem.Domain/Models/Vacation.cs#L40). Because it takes each Dependency as Parameter. 
 - Parameter injection is changing methods' signature, I don't like it.
 - Property injection and Constructer injection is not avaliable because Entity Framework creates the object and don't give me a factory method.
 - I don't like Domain Event thing, because it pushes me to Anemic Model again.

Can you help me ?
