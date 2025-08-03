import type { FunctionComponent } from "react";
import type { Book } from "../../models/Book";
import BookRow from "./BookRow";

interface BookTableProps {
  books: Book[];
  onAvailabilityChange: (bookId: string, newAvailable: boolean) => void;
}

const BookTable: FunctionComponent<BookTableProps> = ({
  books,
  onAvailabilityChange,
}) => {
  return (
    <div className="overflow-x-auto">
      <table className="min-w-full border">
        <thead>
          <tr className="bg-gray-200">
            <th className="p-2 border">Book</th>
            <th className="p-2 border">Owner</th>
            <th className="p-2 border">Availability</th>
            <th className="p-2 border">Actions</th>
          </tr>
        </thead>
        <tbody>
          {books.map((book) => (
            <BookRow
              key={book.id}
              book={book}
              onAvailabilityChange={onAvailabilityChange}
            />
          ))}
        </tbody>
      </table>

      {/* <Pagination /> */}
    </div>
  );
};

export default BookTable;
