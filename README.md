#### ASP NET Core

> Developing with .NET 6, C# 10, Sqlite 3 v3.10.1, EF Core

[![CI](https://github.com/trungIsOnGithhub/gcsharpRPC/actions/workflows/ci.yml/badge.svg)](https://github.com/trungIsOnGithhub/gcsharpRPC/actions/workflows/ci.yml)

A simple .NET event booking planner with OpenID Connect integration(future, currently used web session), to be hosted within a Docker container(future).

![UI image](/assets/image.png)

#### Features

Admin interface for creating polls where other guests to see the current result and vote for their avaialability timeslot.

### Project Setup

```dotnet restore```

```dotnet tool restore```

```dotnet dev-certs https --trust```

```dotnet run```

## Restrictions (Current version)

- Only the administrator can create events.
- Every authenticated user is currently an administrator (no claim checks).
- Every site visitor can view the list of events
