import { Pact } from '@pact-foundation/pact';
import path from 'path';

const provider = new Pact({
    consumer: 'ConsumerService2',
    provider: 'ProviderService',
    port: 1234,
    log: path.resolve(process.cwd(), 'logs', 'mockserver.log'),
    dir: path.resolve(process.cwd(), 'pacts'),
    logLevel: 'info',
});

describe('Pact with ProviderService', () => {
    beforeAll(() => provider.setup());
    afterAll(() => provider.finalize());

    it('should receive weather data', async () => {
        const expected = { TemperatureC: 25, Summary: 'Sunny' };

        await provider.addInteraction({
            state: 'Weather data is available',
            uponReceiving: 'a request for weather',
            withRequest: {
                method: 'GET',
                path: '/weatherforecast',
            },
            willRespondWith: {
                status: 200,
                body: expected,
            },
        });

        const response = await fetch('http://localhost:1234/weatherforecast');
        const responseJson = await response.json();
        expect(responseJson).toEqual(expected);

        await provider.verify();
    });
});
