
# TeaShoppe (MVC)


## 1. Project Description
Tea Shop MVC Web Application

This project evolves the console-based Tea Shop application from
Assignment 2 into a server-rendered MVC web application using
ASP.NET Core MVC and SOLID design principles.

### OOD Principles Used
#### SOLID:
- **Single Responsibility Principle (SRP)**: Controllers orchestrate HTTP, Services handle business logic, and Strategies manage payment types.
- **Open/Closed Principle (OCP)**: Added new filters/sorts via Decorators and payment methods via Strategies without modifying core logic.
- **Liskov Substitution Principle (LSP)**: All Strategy and Decorator implementations are safely interchangeable via their respective interfaces.
- **Interface Segregation Principle (ISP)**: Focused interfaces (`IInventory`, `IPaymentStrategy`) prevent clients from depending on unused methods.
- **Dependency Inversion Principle (DIP)**: High-level application services depend on abstractions, not concrete infrastructure or UI details.
- **Dependency Injection**: ASP.NET Core DI container manages object lifecycles and provides dependencies to constructors.

#### Patterns: 
- **Strategy**: Encapsulates interchangeable payment processing algorithms.
- **Factory**: Centralizes the creation logic for payment strategies based on user input.
- **Decorator**: Dynamically composes complex inventory queries at runtime through wrapper classes.
- **Singleton**: `InventoryRepository` is managed as a single in-memory instance by the DI container with thread-safe access.
- **Facade**: `CheckoutService` and `InventoryQueryService` provide simple interfaces to complex subsystem interactions.

#### Web Architecture:
- **MVC (Model-View-Controller)**: Strict separation of data models, UI templates, and request handlers.
- **Post-Redirect-Get (PRG)**: Implemented in `CheckoutController` to prevent duplicate form submissions and handle browser refreshes gracefully.

## 2. How to Run the Application
### Locally:
**Prerequisite:** .NET 10 SDK installed.
```bash
dotnet run --project TeaShoppe.Web/TeaShoppe.Web.csproj
```

### Docker:
**Prerequisite:** Docker Desktop / Docker Engine installed.

From the directory containing the Dockerfile:

```bash
docker build -t tea-shoppe-web .
docker run --rm -p 8080:8080 tea-shoppe-web
```
- To exit at any time:
  ```bash
  Ctrl + C
    ```
## 3. Screenshots
![TeaShoppe.Web](Screenshot1.png)
![TeaShoppe.Web](Screenshot2.png)
![TeaShoppe.Web](Screenshot3.png)

## 4. Validation

This version was validated through manual testing of the MVC workflow, including:

- Search and filter behavior
- Sorting behavior
- Successful checkout
- Invalid quantity handling
- Invalid payment input handling
- Inventory quantity decrease after purchase
- PRG flow after successful checkout