# TeaShoppe

Console-based Tea Shoppe application that allows users to search, filter, sort, and purchase tea from an inventory.

## OOD Principles Used
- Single Responsibility Principle (SRP)
- Open/Closed Principle (OCP)
- Strategy Pattern (payment processing)
- Decorator Pattern (tea search filters)
- Encapsulation
- Polymorphism / dynamic dispatch

## How to Run the Application (Docker)
**Prerequisite:** Docker Desktop / Docker Engine installed.

From the repository root (the folder containing the `Dockerfile`):

```bash
docker build -t teashoppe .
docker run -it teashoppe
```
- To exit at any time:
  ```bash
  Ctrl + C
    ```
  
