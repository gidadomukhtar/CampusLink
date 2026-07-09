# CampusLink

CampusLink is an open-source student platform focused on real campus workflows and real-world software engineering practice.

## Major changes explained
This refactor introduces a production-ready baseline while keeping behavior minimal and stable:

1. **Layered architecture bootstrap**
   - Added a clean solution layout under `src/` with explicit layers:
     - `CampusLink.Domain`
     - `CampusLink.Application`
     - `CampusLink.Infrastructure`
     - `CampusLink.Presentation.Api`
   - This creates clear extension points for future modules like marketplace, lost & found, profiles, and notifications.

2. **Minimal working vertical slice (Lost & Found)**
   - Added a working API flow for creating and reading lost-item reports.
   - Includes domain model, application use-case service, in-memory infrastructure repository, and API controller.

3. **Dependency Injection composition roots**
   - Added layer-specific extension methods:
     - `AddApplication()`
     - `AddInfrastructure()`
     - `AddPresentation()`
   - Uses explicit lifetimes and constructor injection.

4. **Validation, error handling, and API contracts**
   - Request model validation with data annotations.
   - Guard clauses at application/domain boundaries.
   - Global exception middleware with consistent `ApiErrorResponse` contract.

5. **Security and operational defaults**
   - Added baseline security headers middleware.
   - Added CORS policy with secure default behavior.
   - Added safer configuration structure in `appsettings*` (no hardcoded secrets).
   - Added structured JSON console logging.

6. **Naming/documentation consistency**
   - Replaced placeholder classes with feature-aligned names and namespaces.
   - Added XML documentation comments on public APIs.

7. **Repository hygiene for open source**
   - Added `.gitignore` for build artifacts.
   - Added `CONTRIBUTING.md` with conventions and contributor workflow.

## Architecture

```text
src/
  CampusLink.Domain/
    Common/
    Exceptions/
    LostAndFound/
  CampusLink.Application/
    Abstractions/
    DependencyInjection/
    DTOs/
    Exceptions/
    Services/
  CampusLink.Infrastructure/
    DependencyInjection/
    Repositories/
    Services/
  CampusLink.Presentation.Api/
    Contracts/
    Controllers/
    Extensions/
    Middleware/
```

Dependency direction:

`Presentation -> Application <- Infrastructure -> Domain`

`Application -> Domain`

## Tech stack
- .NET 10
- ASP.NET Core Web API
- In-memory persistence (bootstrap implementation)

## Getting started

### Prerequisites
- .NET SDK 10+

### Build
```bash
dotnet restore
dotnet build CampusLink.slnx
```

### Run API
```bash
dotnet run --project src/CampusLink.Presentation.Api/CampusLink.Presentation.Api.csproj
```

### Example endpoint
- `POST /api/v1/lost-found/reports`
- `GET /api/v1/lost-found/reports/{reportId}`

## Migration notes
- The repository moved from documentation-only to a layered .NET solution scaffold.
- Existing contributor docs are preserved and expanded with architecture and conventions.
- No external runtime secrets were introduced; configuration remains environment-driven.

## Verification checklist
- [x] Solution scaffolded with Domain/Application/Infrastructure/Presentation layers
- [x] Build artifact tracking removed and `.gitignore` added
- [x] Minimal API slice implemented with DI, validation, and logging
- [x] Global exception handling and API error contract added
- [x] Security headers and CORS policy added
- [x] README and CONTRIBUTING docs updated

## Contributing
See [`CONTRIBUTING.md`](CONTRIBUTING.md).

## License
MIT
