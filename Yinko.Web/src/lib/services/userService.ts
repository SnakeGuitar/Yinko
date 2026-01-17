import type { CreateUserRequest } from '$lib/models/userTypes';

const API_URL = "http://localhost:5215/api/Users";

export const userService = {
    async signUp(request: CreateUserRequest): Promise<number> {
        
        const response = await fetch(API_URL, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(request)
        });

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(errorText || `Error ${response.status}`);
        }

        return await response.json();
    }
};