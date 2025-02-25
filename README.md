# CashMinder

CashMinder is a Web API designed to help users manage their financial transactions efficiently. With CashMinder, users can track their income and expenses, plan their budgets, and gain insights into their financial health.

## Features

- **Transaction Management**: Add, edit, and delete income and expense transactions.
- **Budget Planning**: Set monthly budgets and track spending against planned budgets.
- **Category-Based Tracking**: Organize transactions into different categories for better insights.
- **User Authentication**: Secure user login with JWT-based authentication.
- **Role-Based Authorization**: Manage user roles and permissions.
- **Data Security**: Ensure user data is encrypted and protected.
- **Detailed Reports**: Generate summaries and reports of financial activities.
- **Caching**: Improve performance with Redis caching.
- **Containerization**: Deploy seamlessly using Docker.

## Technologies Used

- **Backend**: .NET (C#)
- **Architecture**: Onion Structure
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core (Code First)
- **Design Pattern**: Generic Repositories
- **CQRS & Mediator Pattern**: Mediatr
- **Object Mapping**: AutoMapper
- **Authentication**: JWT Token
- **Authorization**: Role-Based Authorization
- **Caching**: Redis
- **Containerization**: Docker

## Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/your-repo/cashminder.git
   cd cashminder
   ```
2. Install dependencies:
   ```sh
   dotnet restore
   ```
3. Set up the database:
   - Ensure PostgreSQL is installed and running.
   - Update the `appsettings.json` file with your database connection string.
4. Apply migrations:
   ```sh
   dotnet ef database update
   ```
5. Run the application:
   ```sh
   dotnet run
   ```

## Contributing

Contributions are welcome! Feel free to submit issues or pull requests to improve CashMinder.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For any inquiries, feel free to reach out via email or open an issue on GitHub.

