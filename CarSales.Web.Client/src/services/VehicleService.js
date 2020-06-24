const ENDPOINT = '/api/Vehicle';

class VehicleService {

    async createVehicleAsync(vehicle) {
        const url = `${ENDPOINT}`;

        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(vehicle)
        });

        if (!response.ok) {
            throw new Error(`Server request is failed with HTTP status ${response.status}`);
        }

        const data = await response.json();

        if (!data.success) {
            throw new Error(`Server request is failed with error message ${data.message}`);
        }

        return data.resource;
    }
}

export const vehicleService = new VehicleService();