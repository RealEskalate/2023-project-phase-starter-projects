"# Social Media App

Welcome to the Social Media App! This application allows users to connect, share posts, interact with content, and more.

## Features

### User Management

- Registration: Users can create new accounts to join the platform.
- Login: Registered users can log in securely.
- Profile Management: Users can update their profiles, including names, bios, and profile pictures.

### Posts and Interactions

- Create Posts: Users can create and share posts with text, images, and videos.
- Like and Comment: Users can like and comment on posts.
- Hashtags: Posts can be tagged with hashtags for easy discovery.
- View and Edit Posts: Users can view and edit their own posts.

### Social Interactions

- Follow/Followers: Users can follow and be followed by other users.
- Notifications: Users receive notifications for likes, comments, and follows.
- Search: Users can search for other users, posts, and hashtags.

## Architecture

This project follows a Clean Architecture design to ensure modularity and maintainability. It consists of several layers:

### Presentation Layer

- Contains API controllers and models for handling HTTP requests and responses.

### Application Layer

- Implements use cases and business logic.
- Orchestrates interactions between the presentation and domain layers.
- Contains DTOs (Data Transfer Objects) for communication between layers.

### Domain Layer

- Represents the core business logic and entities of the application.
- Defines interfaces and domain models.
- Should be independent of other layers.

### Infrastructure Layer

- Provides implementations for interfaces defined in the domain layer.
- Includes data access, external services integration, and other infrastructure concerns.

## Getting Started

1. Clone this repository.
2. Set up your development environment with the required dependencies.
3. Configure your database connection in the appsettings.json file.
4. Run database migrations to create the required tables.
5. Build and run the application.
"