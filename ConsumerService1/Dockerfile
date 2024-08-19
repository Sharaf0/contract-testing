FROM python:3.12.5-alpine3.20

WORKDIR /app
COPY . .
RUN pip install -r requirements.txt

ENTRYPOINT [ "python3" ]
CMD [ "app.py" ]
