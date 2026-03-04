# TeaShop

- Console-based Tea Shoppe application that allows users to search, filter, sort, and purchase tea from an inventory.

## OOD Principles Used:
- Single Responsibility Principle
- Open/Closed Principle
- Strategy Pattern (via Payment Processor)
- Decorator Pattern (via Tea Search Filters)
- Encapsulation
- Polymorphism and Dynamic Dispatch

## How to Run the Application (Docker):
- The Tea Shoppe is run via Docker to execute consistently across different environments. 
  - Simply open your CLI and use the commands below:
    ```bash
    docker build -t tea-shoppe . 
    docker run --rm -it tea-shoppe
    ```
  - To exit at any time:
    ```bash
    Ctrl + C
      ```
  
