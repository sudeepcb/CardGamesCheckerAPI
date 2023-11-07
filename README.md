Poker Game Checker Microservice

[GitHub License](https://img.shields.io/badge/license-MIT-blue.svg)

 Table of Contents
- [Introduction](introduction)
- [Features](features)
- [Getting Started](getting-started)
- [API Endpoints](api-endpoints)
- [Swagger Documentation](swagger-documentation)
- [Testing](testing)
- [Contributing](contributing)
- [License](license)

Introduction
The Poker Game Checker Microservice is an API that allows users to determine the winner of a Poker game. It calculates the winner based on Poker hand rankings, taking into account the number of players and their card hands.

Features
- Calculate the winner of a Poker game.
- API documentation with Swagger.
- Error handling for various scenarios.
- Easily extensible for future enhancements.

Getting Started
To get started with this microservice, follow these steps:

1. Clone the repository:
   ```shell
   git clone https://github.com/your-username/poker-game-checker-microservice.git
   cd poker-game-checker-microservice
   ```

2. Build and Run:
   - Open the project in your favorite development environment.
   - Build and run the solution.
   - The API will be available at `http://localhost:PORT/pokergame` (replace `PORT` with the appropriate port).

3. API Usage:
   - Use your preferred API testing tool (e.g., [Postman](https://www.postman.com/)) to send requests to the API.
   - Refer to the [API Endpoints](api-endpoints) section for details on the available endpoints.

4. Testing:
   - Write and run unit tests to ensure the application behaves as expected.

 API Endpoints
- Calculate Winner of Poker Game
  - Endpoint: `POST /pokergame`
  - Request Body: JSON containing Poker game data (e.g., number of players and their card hands).
  - Response: JSON with the winning player's details.

 Swagger Documentation
Swagger is integrated into the project for API documentation. To explore the API, follow these steps:

1. Start the microservice.
2. Open a web browser and navigate to `http://localhost:PORT/swagger/index.html` (replace `PORT` with the appropriate port).
3. Swagger provides a user-friendly interface to interact with the API, view endpoints, and understand the input and output data models.

 Testing
Make sure to write unit tests to validate the functionality of the microservice. Tests help ensure that the components work as expected and that the API functions correctly in various scenarios.

To run the tests, use your development environment's testing framework.

 Contributing
Contributions are welcome! If you'd like to contribute to this project, please follow these guidelines:
- Fork the repository.
- Create a feature branch.
- Make your changes.
- Write unit tests if necessary.
- Submit a pull request.

 License
This project is licensed under the [MIT License](LICENSE). Feel free to use, modify, and distribute it according to the terms of the license.
