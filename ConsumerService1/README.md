```bash
docker build -t consumer-service-1 .
```

```bash
docker run -p 8000:8000 --rm consumer-service-1
```