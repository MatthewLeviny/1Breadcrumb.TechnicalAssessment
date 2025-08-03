import axios from "axios";

const API_KEY = import.meta.env.VITE_API_KEY; // use .env file
const API_BASE_URL = import.meta.env.VITE_API_BASE_URL;

const apiClient = axios.create({
    baseURL: API_BASE_URL,
    headers: {
        "X-API-KEY": `${API_KEY}`,
        "Content-Type": "application/json",
    },
});

export default apiClient;