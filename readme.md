
# 💳 Madiff.CardsPermissionsCalculator

Mikroserwis w .NET 8 do obliczania dozwolonych akcji dla kart użytkownika na podstawie typu, statusu oraz stanu PIN.

---

## 🧩 Architektura

Projekt oparty na wzorcach:
- ✅ CQRS (MediatR)
- ✅ Clean Architecture (Domain, Application, Infrastructure, API)
- ✅ Specification Pattern (logika biznesowa w `IActionRule`)

---

## ⚙️ Technologia

- [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- MediatR
- Minimal API
- xUnit + Moq
- Docker-ready

---

## 📬 Endpoint

**GET** `/cards/{userId}/{cardNumber}/actions`

### 🔧 Przykład:

```http
GET /cards/User1/Card11
```

### ✅ Odpowiedź:

```json
["ACTION3", "ACTION4", "ACTION9"]
```

---

## 🧪 Testowanie

Projekt zawiera testy:
- ✅ jednostkowe: `GetAllowedActionsHandler`
- ✅ integracyjne: symulacja na prawdziwym `CardService` + wszystkie reguły `IActionRule`

Uruchomienie testów:

```bash
dotnet test
```

---

## 🚀 Uruchomienie

### 🔧 Prerekwizyty
- .NET 8 SDK

### 🖥️ Lokalnie

```bash
dotnet run --project Madiff.CardsPermissionsCalculator.API
```

Następnie otwórz przeglądarkę:

```
https://localhost:5001/swagger
```

---

## 🧠 Założenia biznesowe

- Każda karta użytkownika ma `CardType`, `CardStatus`, `IsPinSet`.
- Zestaw akcji (`ACTION1` - `ACTION13`) jest dynamicznie filtrowany przez reguły (`IActionRule`).
- Przykładowe dane generowane są w `CardService`.

---

## 🛡️ Obsługa błędów

- `404 Not Found` – karta nie istnieje
- `500 Internal Server Error` – inne wyjątki