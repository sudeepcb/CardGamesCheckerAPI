# CardGamesCheckerAPI 

## Completed Microservices [PokerGameCheckerMicroservice](#PokerGameCheckerMicroservice)
## Pending Microservices (BlackJackCheckerMicroservice)

## PokerGameCheckerMicroservice

![GitHub License](https://img.shields.io/badge/license-MIT-blue.svg)

## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Swagger Documentation](#swagger-documentation)
- [Documentation](#documentation)
- [Testing](#testing)
- [Contributing](#contributing)
- [License](#license)

## Introduction
The Poker Game Checker Microservice is an API that allows users to determine the winner of a Poker game. It calculates the winner based on Poker hand rankings, taking into account the number of players and their card hands.

## Features
- Calculate the winner of a Poker game.
- API documentation with Swagger.
- Error handling for various scenarios.
- Easily extensible for future enhancements.

## Getting Started
To get started with this microservice, follow these steps:

1. **Clone the repository:**
   ```shell
   git clone https://github.com/sudeepcb/CardGamesCheckerAPI.git
   cd CardGamesCheckerAPI/PokerGameCheckerMicroservice
   ```

2. **Build and Run:**
   - Open the project in your favorite development environment.
   - Build and run the solution.
   - The API will be available at `http://localhost:PORT/pokergame` (replace `PORT` with the appropriate port).

3. **API Usage:**
   - Use your preferred API testing tool (e.g., [Postman](https://www.postman.com/)) to send requests to the API.
   - Refer to the [API Endpoints](#api-endpoints) section for details on the available endpoints.

4. **Testing:**
   - Write and run unit tests to ensure the application behaves as expected.

## API Endpoints
- **Calculate Winner of Poker Game**
  - Endpoint: `POST /pokergame`
  - Request Body: JSON containing Poker game data (e.g., number of players and their card hands).
  - Response: JSON with the winning player's details.

## Swagger Documentation
Swagger is integrated into the project for API documentation. To explore the API, follow these steps:

1. Start the microservice.
2. Open a web browser and navigate to `http://localhost:PORT/swagger/index.html` (replace `PORT` with the appropriate port).
3. Swagger provides a user-friendly interface to interact with the API, view endpoints, and understand the input and output data models.

## Documentation
Documentation is located in the documents folder in the REPO.

[Documentation]([https://github.com/sudeepcb/CardGamesCheckerAPI/tree/054071bac7812fe6e58df965b54726edc2042183/Documentation](https://github.com/sudeepcb/CardGamesCheckerAPI/tree/7ef550dacb18883d2a350dbd7bd5d9e08dc42452/PokerGameCheckerMicroservice%20-%20Documentation))

## Testing
For now testing has been done for main functionally but more tests related to during the process of creating models, as well as testing different test cases should be performed in the future.

Tests: 
```C#
PokerGameChecker_CalculateWinner_ReturnsIActionResult()
CardConstants_CheckIfCardRankingIsCorrectForGame_ReturnsRankWithGivenCards()
```


To run the tests, use your development environment's testing framework.

## Contributing
Contributions are welcome! If you'd like to contribute to this project, please follow these guidelines:
- Fork the repository.
- Create a feature branch.
- Make your changes.
- Write unit tests if necessary.
- Submit a pull request.

## License
This project is licensed under the [MIT License](LICENSE). Feel free to use, modify, and distribute it according to the terms of the license.

---

