# Code Review — stefan-charp-interfaces-starter (runda 4)

**Data:** 2026-07-29 · **Commit:** 59062d7 „ex6" · **Build:** trece, 0 warning-uri · **Rulare:** `dotnet run` afișează DOAR ex6 (vezi B2)

## Rezolvate în runda 4 ✅

| Nr. | Constatare | Verificat |
|---|---|---|
| B1 (Robot) | reset mutat în `PoateLivra`, ramura moartă ștearsă din `Livreaza`; `test7`/`test8` adăugate în `Testare3` | codul e corect — dar nu mai rulează, vezi B2 |
| M8 | `NotificatorCuIstoric` e instanțiat în `Testare4:15`, `AfiseazaIstoric()` chemat la `:28` | codul e corect — dar nu mai rulează, vezi B2 |

Fix-urile pe cod sunt exact cele cerute. Problema e că le-ai făcut și apoi ai închis robinetul care le arată (B2).

---

## 🔴 Critice

### B1 (ex6) — SmartTv: cele două contracte produc EXACT același output, deci demonstrația nu se vede
`ex6/Models/SmartTv.cs:12` și `ex6/Models/SmartTv.cs:22`

Tot rostul lui ex6 e în cerința 3: „verifică în output că SmartTv a răspuns **diferit** la fiecare". Ambele implementări explicite scriu însă aceeași linie — `"SmartTv reda " + fisier`. La rulare iese:

```
SmartTv reda Nirvana.mp3      ← IPlayerAudio.Reda
SmartTv reda Star_Wars.mp4    ← IPlayerVideo.Reda
```

Singura diferență e numele fișierului, adică argumentul — nu comportamentul. Un cititor nu poate deosebi că au rulat DOUĂ metode diferite; arată exact ca o singură metodă apelată cu două argumente. Adică fix iluzia de la pasul 1 din cerință (o metodă publică unică), pe care implementarea explicită trebuia s-o spargă vizibil.

Cerința fixase și formatul tocmai ca să facă diferența vizibilă: `IPlayerAudio.Reda` → `[AUDIO] Redau <fisier>`, `IPlayerVideo.Reda` → `[VIDEO] Redau <fisier>`. Aceeași abatere de format e și în `BoxaPortabila.cs:19` și `VideoProiector.cs:19` („… reda …" în loc de „[AUDIO]/[VIDEO] Redau …") — acolo e doar cosmetic; la SmartTv e critic, fiindcă ascunde exact ce trebuia demonstrat.

**Lecția:** implementarea explicită separă *căile de cod*, dar dacă cele două căi tipăresc același text, separarea rămâne invizibilă la rulare. Eticheta din output e singura dovadă că mecanismul funcționează — fă-o să spună care contract a răspuns.

### B2 (regresie) — `Program.cs` rulează doar `Testare6`; tot restul e comentat
`Program.cs:12-62` (bloc comentat) + `Program.cs:64`

`Main` face acum un singur lucru: `new Testare6()`. Demo-ul cu figuri și `Testare1`…`Testare5` sunt toate în blocul `/* … */`. Consecința directă: fix-urile pe care le-ai făcut în runda asta — `Robot` (B1) și `NotificatorCuIstoric` (M8) — **nu mai apar la `dotnet run`**. Le-ai reparat corect în cod și apoi le-ai scos din execuție. „Cod care nu rulează = cod nedovedit" (aceeași capcană din runda 3) s-a întors, dar acum peste TOT proiectul, nu doar peste un exercițiu.

Cerința ex6, pct. 3 spune „chemată din `Program.cs`, **ca la celelalte**" — adică alături de ele, nu în locul lor. Scoate blocul din comentariu înainte de predare; dacă vrei să testezi doar ex6 în timp ce lucrezi, comentează local, dar nu comita starea asta ca finală.

---

## 🟡 Importante

### M1 (ex6, bonus) — `IPlayerComplet`: metoda `Testeaza` e pusă ÎN interfață, contrazice cerința și rămâne nefolosită
`ex6/Models/IPlayerComplet.cs:5`

Bonusul cerea `IPlayerComplet : IPlayerAudio, IPlayerVideo` **fără membri noi**, iar `Testeaza(IPlayerComplet)` să fie o metodă separată (într-o clasă de test), în care `player.Reda("film.mp4")` NU compilează din cauza ambiguității `IPlayerAudio.Reda` vs `IPlayerVideo.Reda` — și se rezolvă cu un cast către un contract, nu cu `is`/`as`.

Tu ai băgat `Testeaza` ca membru al interfeței. Asta schimbă complet sensul: acum ORICE `IPlayerComplet` ar trebui să știe să se „testeze" pe sine — n-are logică. Și cum nicio clasă nu implementează `IPlayerComplet` și nimic nu cheamă `Testeaza`, tot bonusul există doar ca text sursă, exact tiparul de la B2. Fie duci bonusul până la capăt corect (interfață goală + metodă separată care demonstrează ambiguitatea și cast-ul), fie îl scoți — jumătatea asta doar induce în eroare.

### M2 (ex6) — comentariul din `Testare6` explică GREȘIT mecanismul
`ex6/Testare6.cs:11`

Comentariul zice: „metoda nu este vizibila deoarece tipul ei nu este public. Indiferent de tipul tvului din testare metoda nu este vizibila". Nu e adevărat: metoda ESTE vizibilă — dar **doar** prin tipul de interfață. `((IPlayerAudio)tv).Reda(...)` compilează și rulează; `tv.Reda(...)` nu, fiindcă pe tipul concret `SmartTv` nu există niciun `Reda` public. Pasul 3 din cerință întreba exact: „prin ce tip TREBUIE să privești obiectul ca să vezi metoda?" — răspunsul e `IPlayerAudio` / `IPlayerVideo`, nu „niciodată". Ăsta e comentariul prin care arăți că ai înțeles implementarea explicită; rescrie-l ca să spună *prin ce contract* devine vizibilă metoda.

### M4 (rămas din runda 2) — ex2: rambursarea reușită pe numerar tot nu există
`ex2/Testare2.cs:22`

Neatins în pull-ul ăsta. Fix-ul e în `SOLUTII.pdf` (M4): pornește numerarul de la 300, scoate rambursarea reușită din `try`, prinde `InvalidOperationException`.

### M9 (rămas) — ex5: comentariul de la cerința 4 lipsește (și acum e și mai ascuns)
`Program.cs` (blocul comentat)

Comentariul cerut la ex5 — de ce criteriul de sortare stă în `Elev`, nu în `Sortator` — încă nu e scris, iar acum e în interiorul blocului comentat integral. Când reactivezi `Main` (B2), adaugă-l.

---

## 🟢 Cleanups

- **C1 (ex6)** — `Testare6.cs:36` prinde `catch (Exception ex)`; provoci o `ArgumentException`, deci prinde exact tipul ăla: `catch (ArgumentException ex)`. Un `catch (Exception)` prinde și un `NullReferenceException` venit din altă parte și l-ar raporta ca „fișier invalid".
- **C2 (ex6)** — clasa se numește `VideoProiector`, cerința o scrie `Videoproiector`. Trivial, dar ai grijă la consecvența numelor între cerință și cod.
- **C3 (ex6)** — validarea extensiei + `throw` e copiată identic în `BoxaPortabila`, `VideoProiector` și de două ori în `SmartTv`. E firesc la 4 implementări mici și nu forța o abstracție aici; doar reține tiparul „aceeași regulă în N locuri" pentru când devin 10.
- **C4–C8 (rămase din rundele 2-3)** — neatinse: `Ruleaza()` în loc de `new` pentru efecte secundare (C7), ternarul redundant din `Curier.cs:18`, `SeteazaIntensitateMinima` moartă din `Boxa`, mesajul criptic `ArgumentException("destinatari")`, destinatarul ținut ca stare. Toate au fix-uri în `SOLUTII.pdf`.

---

## Q&A — runda 4

**Q1.** Rulează acum `dotnet run`. Câte linii vezi de la SmartTv și prin ce le deosebești una de alta? Dacă ți-aș ascunde numele fișierelor din output, ai mai putea spune care apel a trecut prin `IPlayerAudio` și care prin `IPlayerVideo`? Ce ai schimba ca să poți?

**Q2.** În `Testare6`, scrie mental linia `tv.Reda("piesa.mp3")` (cu `tv` de tip `SmartTv`). Compilează? Dar `((IPlayerAudio)tv).Reda("piesa.mp3")`? Explică diferența în termeni de „ce metode publice are tipul `SmartTv`".

**Q3.** Ai reparat `Robot` și `NotificatorCuIstoric`, dar la rulare nu se văd. Cine decide ce se execută — codul din clasă sau `Main`? Ce spune asta despre relația dintre „am scris fix-ul" și „fix-ul e dovedit"?

---

*Regula proiectului: codul elevului nu se modifică — fix-urile complete sunt în `SOLUTII.pdf`, alături.*
