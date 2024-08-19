from flask import Flask, jsonify
import requests
from dotenv import load_dotenv
import os

app = Flask(__name__)

load_dotenv()
provider_service_url = os.getenv('PROVIDER_SERVICE_URL')
if provider_service_url is None:
    raise Exception("PROVIDER_SERVICE_URL is not set")

@app.route('/weather', methods=['GET'])
def get_weather():
    print(f'Fetching weather from {provider_service_url}')
    response = requests.get(f'{provider_service_url}/weather')
    return jsonify(response.json())

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=8000)