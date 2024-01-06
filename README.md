#### ASP NET Core

> Developing with .NET 6, C# 10, Sqlite 3 v3.10.1

[![CI](https://github.com/trungIsOnGithhub/gcsharpRPC/actions/workflows/ci.yml/badge.svg)](https://github.com/trungIsOnGithhub/gcsharpRPC/actions/workflows/ci.yml)

A simple .NET event booking planner with OpenID Connect(OAuth) integration, to be hosted within a Docker container.

### Project Setup

```dotnet restore```

```dotnet tool restore```

```dotnet dev-certs https --trust```

```dotnet run```

## Restrictions (Current version)

- Only the administrator can create polls.
- Every authenticated "Edap"-client user is currently an administrator (no claim checks).