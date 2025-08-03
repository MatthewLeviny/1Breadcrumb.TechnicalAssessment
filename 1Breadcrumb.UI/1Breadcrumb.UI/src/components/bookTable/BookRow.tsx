import type { FunctionComponent } from "react";
import type { Book } from "../../models/Book";

interface BookRowProps {
  book: Book;
  onAvailabilityChange: (bookId: string, newAvailable: boolean) => void;
}

const BookRow: FunctionComponent<BookRowProps> = ({
  book,
  onAvailabilityChange,
}) => {
  const handleToggle = async () => {
    await onAvailabilityChange(book.id, !book.isAvailable);
  };
  return (
    <tr className="border-t">
      <td className="p-2 border">{book.title}</td>
      <td className="p-2 border">{book.owner}</td>
      <td className="p-2 border">
        <button
          onClick={handleToggle}
          className={`px-2 py-1 rounded ${
            book.isAvailable ? "bg-green-500" : "bg-red-500"
          } text-white`}
        >
          {book.isAvailable ? "Available" : "Unavailable"}
        </button>
      </td>
      <td className="p-2 border text-center">delete placeholder</td>
    </tr>
  );
};

export default BookRow;
