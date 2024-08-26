import { Pact, Matchers } from '@pact-foundation/pact';
import path from 'path';

const { like } = Matchers;

const provider = new Pact({
    consumer: 'ConsumerService2',
    provider: 'ProviderService',
    port: 1234,
    log: path.resolve('./logs'),
    dir: path.resolve('./pacts'),
    logLevel: 'debug',
});

describe('Pact with ProviderService', () => {
    beforeAll(() => provider.setup());
    afterAll(() => provider.finalize());

    it('should receive weather data', async () => {
        const expected = { temperature: like(25), summary: like('Sunny') };

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
        expect(responseJson).toEqual(expect.objectContaining({
            temperature: expect.any(Number),
            summary: expect.any(String),
        }));

        await provider.verify();
    });
});
