import unittest
import requests
from pact import Consumer, Provider

class WeatherConsumerPact(unittest.TestCase):
    def test_get_weather(self):
        pact = Consumer('ConsumerService1').has_pact_with(Provider('ProviderService'), host_name='localhost', port=1234, pact_dir='./pacts', log_dir='./logs')
        pact.start_service()

        expected = {"TemperatureC": 25, "Summary": "Sunny"}

        (pact
         .given('Weather data is available')
         .upon_receiving('A request for weather')
         .with_request('get', '/weatherforecast')
         .will_respond_with(200, body=expected))

        with pact:
            result = requests.get('http://localhost:1234/weatherforecast')
            self.assertEqual(result.json(), expected)
            pact.verify()

        pact.stop_service()

if __name__ == '__main__':
    unittest.main()