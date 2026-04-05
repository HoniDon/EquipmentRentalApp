# Equipment Rental System (APBD)

Projekt aplikacji konsolowej w C#, która symuluje uczelnianą wypożyczalnię sprzętu.

Możliwe operacje:
- dodawanie sprzętu
- dodawanie użytkowników
- wypożyczanie sprzętu
- zwrot sprzętu
- sprawdzanie dostępności
- raport stanu systemu

## Struktura projektu

Projekt podzieliłem na kilka części:

Models – klasy domenowe, np. Equipment, User, Rental  
Repositories – przechowywanie danych w pamięci (List)  
Services – logika biznesowa, np. RentalService  
Program.cs – prosty scenariusz pokazujący działanie programu

Każda klasa ma jedną odpowiedzialność:
- modele tylko przechowują dane
- serwis obsługuje logikę wypożyczeń
- repozytoria przechowują dane

## Decyzje projektowe

Projekt zawiera przykładowy scenariusz działania w Program.cs.

Sprzęt dziedziczy po klasie Equipment, ponieważ wszystkie urządzenia mają wspólne cechy jak Id, Name i status dostępności.

Użytkownicy dziedziczą po klasie User, ponieważ Student i Employee różnią się limitem wypożyczeń.

Logika biznesowa znajduje się w RentalService, żeby nie umieszczać wszystkiego w Program.cs.

Reguły takie jak limit wypożyczeń i kara za spóźnienie są zapisane w jednym miejscu, żeby łatwo można było je zmienić.

## Jak uruchomić

dotnet build

dotnet run

## Autor

Damian Walczuk s34713

Projekt wykonany w ramach nadrobienia ćwiczeń APBD.