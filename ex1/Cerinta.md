# Exercitiul 1 — Casa inteligenta

## Context

O aplicatie controleaza dispozitivele dintr-o casa inteligenta. Dispozitivele sunt foarte diferite intre ele, dar au **capabilitati** comune: unele pot fi pornite/oprite, unele pot fi reglate in intensitate, toate pot raporta starea lor.

Telecomanda nu trebuie sa stie CE dispozitiv controleaza — doar CE STIE SA FACA acel dispozitiv.

## Contractele

Defineste 3 interfete:

| Interfata | Membri |
|---|---|
| `IPornibil` | `void Porneste()`, `void Opreste()`, `bool EstePornit { get; }` |
| `IReglabil` | `void SeteazaIntensitate(int procent)` |
| `IRaportor` | `string Stare()` |

Observatie: o interfata poate cere si **proprietati**, nu doar metode.

## Dispozitivele

| Dispozitiv | Capabilitati | Detalii |
|---|---|---|
| `Bec` | `IPornibil`, `IReglabil`, `IRaportor` | intensitate 0-100; daca becul e oprit, `SeteazaIntensitate` il porneste automat |
| `Priza` | `IPornibil`, `IRaportor` | doar pornit/oprit |
| `Termostat` | `IReglabil`, `IRaportor` | NU e pornibil (merge mereu); intensitatea = temperatura dorita, 5-30 grade |
| `SenzorTemperatura` | `IRaportor` | doar raporteaza temperatura masurata (o primesti in constructor) |

Reguli de validare (mesaje in engleza):
- `Bec.SeteazaIntensitate` in afara 0-100 -> `ArgumentException("Intensity must be between 0 and 100")`
- `Termostat.SeteazaIntensitate` in afara 5-30 -> `ArgumentException("Temperature must be between 5 and 30")`

## Telecomanda

O clasa `Telecomanda` cu metodele:

- `void StingeTot(IPornibil[] dispozitive)` — opreste tot ce e pornit
- `void ModNoapte(IReglabil[] dispozitive)` — seteaza toate la intensitate minima rezonabila (becuri 10, termostat 18 — gandeste-te cum rezolvi asta FARA sa verifici tipul concret; hint: valoarea minima poate fi o proprietate ceruta de interfata)
- `void RaportGeneral(IRaportor[] dispozitive)` — afiseaza starea tuturor

## Cerinte

1. Defineste cele 3 interfete si cele 4 dispozitive.
2. Implementeaza `Telecomanda`.
3. In `Program.cs`: creeaza cate un dispozitiv din fiecare tip, porneste-le pe cele pornibile, seteaza intensitati, afiseaza `RaportGeneral`, apoi `ModNoapte` si `StingeTot`, si din nou `RaportGeneral`.

## Constrangeri

- Doar array-uri brute si `for` — fara `List`, `Dictionary`, LINQ.
- Fara `is`, `as`, `GetType()` — daca simti nevoia lor, contractul tau e prost impartit.
- Acelasi obiect `Bec` trebuie sa apara si in array-ul de `IPornibil`, si in cel de `IReglabil`, si in cel de `IRaportor`.

## Cum rulezi

```bash
cd ex1
dotnet new console
dotnet run
```

## Bonus

- Adauga `Boxa` (`IPornibil`, `IReglabil`, `IRaportor` — intensitate = volum 0-100) FARA sa modifici `Telecomanda`. Cate linii ai schimbat in codul existent?
