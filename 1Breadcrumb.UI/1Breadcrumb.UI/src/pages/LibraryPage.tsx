import { useEffect, useState, type FunctionComponent } from "react";
import BookTable from "../components/bookTable/BookTable";
import type { Book } from "../models/Book";
import { fetchBooks, updateBookAvailability } from "../services/BookService";

interface LibraryPageProps {}

const LibraryPage: FunctionComponent<LibraryPageProps> = () => {
  const [books, setBooks] = useState<Book[]>([]);

  useEffect(() => {
    const loadBooks = async () => {
      try {
        const books = await fetchBooks();
        setBooks(books);
      } catch (error) {
        console.error("Error fetching books:", error);
      }
    };
    loadBooks();
  }, []);

  const handleAvailabilityChange = async (
    bookId: string,
    newAvailable: boolean
  ) => {
    try {
      await updateBookAvailability(bookId, newAvailable);
      setBooks((prevBooks) =>
        prevBooks.map((book) =>
          book.id === bookId ? { ...book, isAvailable: newAvailable } : book
        )
      );
    } catch (error) {
      console.error("Error updating book availability:", error);
    }
  };

  return (
    <div className="p-6">
      <h1 className="text-3xl font-bold mb-6">Library</h1>

      <div className="mb-4">
        {/* <BookSearch searchQuery={searchQuery} onSearch={setSearchQuery} /> */}
      </div>

      <BookTable
        books={books}
        onAvailabilityChange={handleAvailabilityChange}
      />

      {/* <FloatingButton onClick={() => setShowModal(true)} />
      {showModal && <AddBookModal onClose={() => setShowModal(false)} />} */}
    </div>
  );
};

export default LibraryPage;
