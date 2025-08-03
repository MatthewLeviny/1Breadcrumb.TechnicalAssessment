import type { Book } from "../models/Book";
import apiClient from "./ApiClient";

export async function fetchBooks(): Promise<Book[]> {
    const response = await apiClient.get('/book');
    if (response.status !== 200) {
        throw new Error('Failed to fetch books');
    }
    return response.data as Book[];
}

export async function updateBookAvailability(bookId: string, newAvailable: boolean): Promise<void> {
    const response = await apiClient.patch(`/book/${bookId}/availability`, newAvailable);
    if (response.status !== 204) {
        throw new Error('Failed to update book availability');
    }
}