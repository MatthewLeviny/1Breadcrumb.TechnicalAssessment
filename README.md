# 1Breadcrumb Book Discovery Prototype

This is a one-hour prototype for the Crumb-to-Crumb Book Lending Library, built for the 1Breadcrumb technical assessment. The goal was to demonstrate how a simple web app could help team members discover which books are available and who owns them.

---


## ✅ What Was Completed

- **Backend**:
  - Basic C# Web API project setup
  - Implemented `GET /book` to fetch sample book data
  - Implemented `PATCH /book/{id}/Availability` to change the books availability
  - In-memory data store

- **Frontend**:
  - React app created using Vite
  - Displayed list of books in a table
  - Availability toggle visual component

---

## 🔄 Order of Implementation (and Why)

1. **Project scaffolding** – Created a C# Web API and a React app using Vite for fast development.
2. **Backend endpoint** – Added a basic `GET /book` endpoint with mock data to support the core discovery use case.
3. **Ui** – Create corresponding element
4. **Frontend wiring** – Pulled data from the API and rendered it in a usable format.
5. **Backend endpoint** – Added a basic `GET /book{id}/availability` endpoint with mock data to support the core discovery use case.
6. **Ui** – Create corresponding element
7. **Frontend wiring** – Pulled data from the API and rendered it in a usable format.
7. **Light UI polish** – Ensured basic styling and interaction clarity so the UI felt stable.

The order reflects a releasing small increments that provide quick benifit the the customer

---

## 🧪 What I’d Test With More Time

Given more time and the more logic that is added, I would write unit and integration tests for:

- **Backend**
  - Any db logic (id probably move the current db logic up to the service layer)
  - Service layer logic (e.g., filtering available books)
  - potential integration testing with testcontainers and a dummy db - often you can loose sigth of does this all work together

- **Frontend**
  - Component tests for `AvailabilityToggle`
  - Integration test for data fetching and rendering

Currently there is very little if at all any "logic" and testing for coverage sake doesnt help anyone. Good tests should act as a form of documentation


---

## 💬 Notes on API Spec

As the API spec was incomplete, I assumed the following minimal shape for book objects based on the concept sketch:

```json
{
  "id": 1,
  "title": "Clean Code",
  "author": "Robert C. Martin",
  "available": true,
  "owner": "Jane Doe"
}
For this prototype, I kept the data model flat and simple. However, there's a clear opportunity to normalize the schema in future iterations