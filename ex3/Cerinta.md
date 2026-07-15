# Exercitiul 3 — Centru de livrari

## Context

Acelasi truc ca `ImaginePng` din demo, dar acum il construiesti tu de la zero.

O firma de curierat are **doua ierarhii de clase care nu au nicio legatura intre ele**:

1. **Oameni:** `Angajat` (nume, salariu) -> `Curier : Angajat` (are si un rucsac cu capacitate maxima 20 kg)
2. **Masini:** `Vehicul` (marca, autonomie in km) -> `Drona : Vehicul` (poate cara maxim 3 kg; fiecare livrare consuma 5 km de autonomie)

Ambele stiu sa livreze colete. Dar `Drona` nu poate mosteni `Angajat` (deja mosteneste `Vehicul`), iar `Curier` nu poate mosteni `Vehicul`. Singura punte posibila: o **interfata**.

## Contractul

| Interfata | Membri |
|---|---|
| `ILivrator` | `string Identificare()`, `bool PoateLivra(double greutateKg)`, `void Livreaza(string adresa, double greutateKg)` |

- `Identificare()` returneaza ceva de forma `"Curier Andrei"` / `"Drona DJI-200"`.
- `PoateLivra` verifica limita de greutate; la drona verifica si autonomia ramasa (minim 5 km).
- `Livreaza` afiseaza livrarea; la drona scade si autonomia.
- Daca cineva cheama `Livreaza` desi `PoateLivra` ar fi zis `false` -> `InvalidOperationException("This courier cannot deliver the package")`.

## Centrul de livrari

Clasa `CentruDeLivrari` primeste in constructor un `ILivrator[]` si are metoda:

- `void DistribuieColet(string adresa, double greutateKg)` — parcurge livratorii in ordine si il foloseste pe PRIMUL care poate livra; daca niciunul nu poate, afiseaza `"No courier available for <adresa>"`.

`CentruDeLivrari` nu stie nimic despre `Angajat` sau `Vehicul` — vede doar contractul.

## Cerinte

1. Construieste ambele ierarhii de clase (fara interfata inca) si convinge-te singur ca nu ai cum sa pui `Curier` si `Drona` in acelasi array.
2. Adauga `ILivrator` si implementeaz-o in `Curier` si `Drona`.
3. Implementeaza `CentruDeLivrari`.
4. In `Program.cs`: un centru cu 2 curieri si 2 drone; distribuie colete de 1 kg, 2.5 kg, 15 kg si 25 kg la adrese diferite; distribuie destule colete mici incat unei drone sa i se termine autonomia si sa preia urmatorul livrator.

## Constrangeri

- Doar array-uri brute si `for` — fara `List`, `Dictionary`, LINQ.
- Fara `is`, `as`, `GetType()` in `CentruDeLivrari`.
- Mesajele de eroare in engleza.

## Cum rulezi

```bash
cd ex3
dotnet new console
dotnet run
```

## Bonus

- Adauga `Robot` — o clasa FARA nicio clasa de baza, care implementeaza `ILivrator` (maxim 50 kg, dar trebuie sa se reincarce dupa fiecare 3 livrari: la a 4-a `PoateLivra` returneaza `false` o data, apoi contorul se reseteaza). Zero modificari in `CentruDeLivrari`.
