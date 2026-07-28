# Exercitiul 6 — Doua contracte, acelasi nume

## Context

Pana acum fiecare interfata cerea metode cu nume diferite, asa ca o clasa le putea implementa pe toate fara conflict. Dar contractele vin din lumi diferite si nu se cunosc intre ele — ce se intampla cand DOUA interfete cer o metoda cu EXACT aceeasi semnatura, dar cu intelesuri diferite?

Un SmartTV stie sa redea si muzica, si filme. `IPlayerAudio` cere `Reda(string fisier)` — si `IPlayerVideo` cere tot `Reda(string fisier)`. Aceeasi semnatura, comportamente diferite. C# are un mecanism dedicat pentru asta: **implementarea explicita de interfata** — metoda nu mai e publica pe clasa, ci "apartine" contractului si e vizibila DOAR cand privesti obiectul prin interfata respectiva.

## Contractele

| Interfata | Membri |
|---|---|
| `IPlayerAudio` | `void Reda(string fisier)` |
| `IPlayerVideo` | `void Reda(string fisier)` |

- `IPlayerAudio.Reda` accepta doar fisiere `.mp3`, altfel `ArgumentException("Invalid audio file")`; afiseaza `[AUDIO] Redau <fisier>`.
- `IPlayerVideo.Reda` accepta doar fisiere `.mp4`, altfel `ArgumentException("Invalid video file")`; afiseaza `[VIDEO] Redau <fisier>`.
- Pentru verificarea extensiei: `fisier.EndsWith(".mp3")` — fara regex, fara LINQ.

## Clasele

| Clasa | Interfete | Detalii |
|---|---|---|
| `BoxaPortabila` | `IPlayerAudio` | are un nume; implementare normala (implicita) — niciun conflict, o singura interfata |
| `Videoproiector` | `IPlayerVideo` | are un nume; implementare normala |
| `SmartTv` | `IPlayerAudio`, `IPlayerVideo` | AICI e conflictul — vezi pasii de mai jos |

## Pasii (in ordinea asta — primul pas e o capcana intentionata)

1. Scrie `SmartTv` cu O SINGURA metoda publica `public void Reda(string fisier)`. Compileaza? Da — o singura metoda satisface AMBELE contracte. Gandeste-te de ce asta e o problema: ce validare faci inauntru, `.mp3` sau `.mp4`?
2. Rescrie cu implementari explicite: `void IPlayerAudio.Reda(string fisier)` si `void IPlayerVideo.Reda(string fisier)` — fara `public`, fiecare cu validarea si afisarea ei.
3. Convinge-te ca `smartTv.Reda("piesa.mp3")` NU mai compileaza si explica intr-un comentariu scurt in `Testare6` de ce: prin ce tip TREBUIE sa privesti obiectul ca sa vezi metoda?

## Mediateca

Clasa `Mediateca` cu metodele:

- `void RedaMuzica(IPlayerAudio[] playere, string fisier)` — reda fisierul pe fiecare player audio
- `void RedaFilm(IPlayerVideo[] playere, string fisier)` — reda fisierul pe fiecare player video

`Mediateca` nu cunoaste nicio clasa concreta.

## Cerinte

1. Defineste cele 2 interfete si cele 3 clase (cu pasii 1-3 de mai sus).
2. Implementeaza `Mediateca`.
3. Creeaza `Testare6` (chemata din `Program.cs`, ca la celelalte): un `SmartTv`, o `BoxaPortabila`, un `Videoproiector`; ACELASI obiect `SmartTv` apare si in array-ul de `IPlayerAudio`, si in cel de `IPlayerVideo`; reda o piesa `.mp3` pe toate playerele audio si un film `.mp4` pe toate playerele video — verifica in output ca SmartTv a raspuns diferit la fiecare.
4. Provoaca `ArgumentException` dand un `.mp4` la `RedaMuzica`, prinde-o si afiseaza mesajul.

## Constrangeri

- Doar array-uri brute si `for` — fara `List`, `Dictionary`, LINQ.
- Fara `is`, `as`, `GetType()`.
- Mesajele de eroare in engleza.

## Cum rulezi

```bash
dotnet run
```

## Bonus

- Adauga `IPlayerComplet : IPlayerAudio, IPlayerVideo` (fara membri noi). Scrie o metoda `void Testeaza(IPlayerComplet player)` si incearca inauntru `player.Reda("film.mp4")`. Ce zice compilatorul si de ce? Cum rezolvi FARA `is`/`as`? (hint: tot un cast catre un contract e — dar catre care?)
- Intrebare de gandit, legata de ex3: `Drona` implementeaza `ILivrator` implicit (metodele sunt publice pe clasa). Cand ai vrea ca o clasa sa-si ASCUNDA capabilitatea in spatele interfetei, asa cum face `SmartTv` acum? Gaseste un exemplu din .NET real (hint: cauta cum implementeaza `List<T>` interfata `IList` ne-generica).
