## SpottyMotor: A Microservice-Based Automotive Marketplace

This repository contains the source code for SpottyMotor, a modern automotive marketplace built on a microservice architecture using ASP.NET Core, Blazor Server, JWT authentication, and deployed with Docker Compose.

### Project Overview

SpottyMotor aims to provide a seamless and secure platform for car buyers and sellers. The system consists of:

- API Gateway:
    - The central point of entry for all requests to the system.
    - Handles routing to appropriate microservices, authentication, and authorization.
    - Provides API documentation with Swagger UI.
- Microservices:
    - Each microservice represents a specific functionality, promoting independent development and deployment.
    - Examples: User service, Vehicle service, Listing service, Order service, Payment service.
- Blazor Server UI:
    - Built with Blazor Server, rendering on the server-side for a responsive and secure user experience.
    - Utilizes the API Gateway for data fetching and communication with microservices.
    - Implements robust JWT authentication for secure user management.

### Key Features

- Microservice Architecture: Enables modularity, scalability, and flexibility.
- API Gateway: Simplifies client interactions and provides a secure entry point.
- Blazor Server UI: Offers a rich user interface with interactive features.
- JWT Authentication: Provides secure user authentication and authorization.
- Docker Compose: Enables effortless development and deployment with single command execution.

### Technologies Used

- ASP.NET Core 6
- Blazor Server
- Docker Compose
- JWT Authentication 

### Setup and Run

1. Prerequisites:
    - .NET 6 SDK
    - Docker
    - Docker Compose

2. Clone the repository:
        git clone <repository-url>
    

3. Build the project:
        cd <project-directory>
    dotnet build
    

4. Start the application:
        docker-compose up -d
    

5. Access the application:
    - Open your web browser and navigate to: http://localhost:5000

### Documentation

- API Gateway documentation is available at: http://localhost:5000/swagger
- Each microservice includes detailed documentation within its respective project folder.

### Contributing

Contributions are welcome! Feel free to open an issue or submit a pull request.

### License

SpottyMotor is licensed under the MIT License.

### Future Enhancements

- Search and filtering: Implement advanced search and filtering options for vehicle listings.
- Image uploads: Allow users to upload vehicle images.
- Payment integration: Integrate a secure payment gateway for online transactions.
- User ratings and reviews: Enable buyers to rate and review sellers.
- Chat functionality: Allow users to communicate directly with sellers.


This README provides a comprehensive overview of the SpottyMotor project. If you have any questions or require further information, feel free to reach out.
