# Exercitiul 4 — Canale de notificare

## Context

Un magazin online anunta clientii cand comanda a fost expediata. Azi trimite email si SMS. Luna viitoare vine cererea: "vrem si notificari push". Peste un an: "vrem si bon printat la casa".

Designul corect: magazinul depinde de UN contract, iar fiecare canal nou e doar o clasa noua — **zero modificari** in codul magazinului. Asta e principiul open/closed, si interfetele sunt unealta lui principala.

## Contractul

| Interfata | Membri |
|---|---|
| `INotificator` | `string Canal { get; }`, `void Trimite(string destinatar, string mesaj)` |

## Canalele

| Clasa | Detalii |
|---|---|
| `EmailNotificator` | destinatarul trebuie sa contina `@`, altfel `ArgumentException("Invalid email address")`; afiseaza `[EMAIL catre x@y.com] mesaj` |
| `SmsNotificator` | destinatarul trebuie sa aiba exact 10 cifre si sa inceapa cu `07`, altfel `ArgumentException("Invalid phone number")`; afiseaza `[SMS catre 07...] mesaj` |
| `ImprimantaBonuri` | mosteneste clasa `Echipament` (numar de inventar, an achizitie) SI implementeaza `INotificator` — ierarhie straina, ca in demo; ignora destinatarul si afiseaza mesajul incadrat in linii de `-` |

Pentru validarea SMS: fara regex — un `for` peste caractere si `char.IsDigit`.

## Magazinul

Clasa `MagazinOnline`:

- primeste in constructor `INotificator[]` (canalele active) 
- metoda `void AnuntaExpediere(string client, string[] destinatari, string numarComanda)` — `destinatari[i]` corespunde canalului `i`; trimite pe fiecare canal mesajul `"Comanda <numarComanda> a fost expediata"`; daca un canal arunca exceptie (destinatar invalid), prinde-o, afiseaza `"Channel <canal> failed: <mesaj>"` si continua cu restul canalelor — o notificare esuata nu trebuie sa le blocheze pe celelalte.

## Cerinte

1. Defineste contractul si cele 3 canale (plus clasa `Echipament`).
2. Implementeaza `MagazinOnline`.
3. In `Program.cs`: un magazin cu toate cele 3 canale; anunta o expediere cu toti destinatarii valizi, apoi una in care emailul e invalid — restul canalelor trebuie sa functioneze.

## Constrangeri

- Doar array-uri brute si `for` — fara `List`, `Dictionary`, LINQ.
- Fara `is`, `as`, `GetType()` in `MagazinOnline`.
- Mesajele de eroare in engleza.

## Cum rulezi

```bash
cd ex4
dotnet new console
dotnet run
```

## Bonus

- Adauga `NotificatorCuIstoric` — un `INotificator` care PRIMESTE in constructor alt `INotificator`, ii deleaga trimiterea si tine intr-un array ultimele mesaje trimise, cu metoda `AfiseazaIstoric()`. (Asta e pattern-ul Decorator — un contract care imbraca alt contract.)
