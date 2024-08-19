import express from 'express';
import * as dotenv from 'dotenv';

dotenv.config();
const app = express();

const providerServiceUrl = process.env.PROVIDER_SERVICE_URL;
if (providerServiceUrl === undefined) {
    throw new Error('PROVIDER_SERVICE_URL is not set');
}

app.get('/hello', (req, res) => {
    res.send('Hello World!');
})

app.get('/weather', async (_, res) => {
    try {
        console.log(`Fetching weather from ${providerServiceUrl}`);
        const response = await fetch(`${providerServiceUrl}/weather`);
        res.send(response.json());
    } catch (error) {
        res.status(500).send('Error fetching weather');
    }
})

app.listen(3000, () => {
    console.log('The application is listening on port 3000!');
})