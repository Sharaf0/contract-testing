```bash
docker build -t provider-service .
```

```bash
docker run -p 8080:8080 --rm provider-service  
```

```bash
dotnet run --project ProviderService
```

```bash
dotnet test
```