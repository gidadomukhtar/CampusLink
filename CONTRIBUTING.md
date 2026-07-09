# Contributing to CampusLink

Thanks for contributing to CampusLink.

## Development conventions
- Keep architecture boundaries explicit: Domain → Application → Infrastructure → Presentation.
- Add XML documentation comments for public APIs.
- Use dependency injection via composition root extension methods.
- Prefer constructor injection and avoid service locator usage.
- Validate input at API and application boundaries.
- Keep pull requests focused, small, and buildable.

## Local workflow
1. Restore and build:
   ```bash
   dotnet restore
   dotnet build CampusLink.slnx
   ```
2. Run API:
   ```bash
   dotnet run --project src/CampusLink.Presentation.Api/CampusLink.Presentation.Api.csproj
   ```

## Pull request checklist
- [ ] Build passes locally
- [ ] Public API docs are updated
- [ ] No secrets introduced
- [ ] Validation and error handling considered
