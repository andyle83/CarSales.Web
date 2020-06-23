const ENDPOINT = '/api/VehicleType';

class VehicleTypeService {

    async getVehicleTypeListAsync() {
        const url = `${ENDPOINT}`;

        const response = await fetch(url, {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
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

    async getVehicleTypeDetailsAsync(id) {
        const url = `${ENDPOINT}/${id}`;

        const response = await fetch(url, {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        });
        
        if (!response.ok) {
            throw new Error(`VehicleTypeService.getVehicleTypeDetailsAsync failed, HTTP status ${response.status}`);
        }
        
        const data = await response.json();
        
        return data;
    }
}

export const vehicleTypeService = new VehicleTypeService();