# Exercitiul 2 — Metode de plata

## Context

Un magazin accepta mai multe metode de plata. Casa de marcat proceseaza platile fara sa stie daca in spate e un card, numerar sau un voucher — vede doar **contractul**.

O parte din metode suporta si **rambursare** (returnarea banilor), altele nu. Asta e a doua interfata: o capabilitate pe care doar unele clase o semneaza.

## Contractele

| Interfata | Membri |
|---|---|
| `IMetodaPlata` | `string Nume { get; }`, `bool Plateste(double suma)` |
| `IRambursabil` | `void Ramburseaza(double suma)` |

`Plateste` returneaza `true` daca plata a reusit, `false` daca nu (fonduri insuficiente). Nu arunca exceptie pentru fonduri insuficiente — doar pentru sume invalide.

## Metodele de plata

| Clasa | Interfete | Comportament |
|---|---|---|
| `CardBancar` | `IMetodaPlata`, `IRambursabil` | are sold; la plata se retine suma + comision 1%; rambursarea adauga suma inapoi (fara comision) |
| `Numerar` | `IMetodaPlata`, `IRambursabil` | are suma disponibila in sertar; rambursarea scoate bani din sertar — daca sertarul nu are destui bani, arunca `InvalidOperationException("Not enough cash in the drawer")` |
| `VoucherCadou` | `IMetodaPlata` | are o valoare fixa; se consuma treptat; NU e rambursabil — si asta trebuie sa se vada in cod, nu intr-un comentariu |

Validari comune (mesaje in engleza): suma negativa sau zero -> `ArgumentException("Amount must be positive")`.

## Casa de marcat

Clasa `CasaDeMarcat` cu metoda:

- `void ProceseazaCos(double[] preturi, IMetodaPlata metoda)` — incearca sa plateasca fiecare pret din cos cu metoda primita; afiseaza pentru fiecare produs daca plata a reusit sau nu, si la final totalul platit cu succes.

`CasaDeMarcat` NU are voie sa cunoasca clasele concrete — doar `IMetodaPlata`.

## Cerinte

1. Defineste cele 2 interfete si cele 3 metode de plata.
2. Implementeaza `CasaDeMarcat`.
3. In `Program.cs`:
   - proceseaza acelasi cos (`[120.50, 80, 45.99]`) cu toate cele 3 metode, cu solduri alese asa incat una din plati sa esueze;
   - fa o rambursare pe card si una pe numerar;
   - incearca sa provoci `InvalidOperationException` la rambursarea din numerar si prinde-o cu `try/catch`, afisand mesajul.

## Constrangeri

- Doar array-uri brute si `for` — fara `List`, `Dictionary`, LINQ.
- Fara `is`, `as`, `GetType()` in `CasaDeMarcat`.
- Atentie la lectia din recapitulare: in `catch (Exception ex)`, `ex` nu e NICIODATA null.

## Cum rulezi

```bash
cd ex2
dotnet new console
dotnet run
```

## Bonus

- Adauga `PortofelDigital` (`IMetodaPlata`, `IRambursabil`) cu bonus de loialitate: la fiecare plata reusita primeste inapoi 1% din suma. Cate linii ai schimbat in `CasaDeMarcat`?
