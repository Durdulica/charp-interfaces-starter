# Code Review — stefan-charp-interfaces-starter (runda 3)

**Data:** 2026-07-28 · **Commit:** ad7766c „code rewiew fixes" · **Build:** trece, 0 warning-uri · **Rulare:** toate cele 5 exerciții + demo-ul cu figuri, output corect

## Rezolvate în runda 3 ✅

| Nr. | Constatare | Verificat |
|---|---|---|
| B2 | `NotificatorCuIstoric` e acum Decorator adevărat: un singur `interior`, deleagă, istoric real | codul e corect — dar vezi M8 mai jos |
| M1 | `Bec.SeteazaIntensitate`: validarea înaintea mutării de stare | ✅ |
| M2 | `EstePornit { get; }` în interfață + `private set` în Bec/Boxa/Priza | ✅ |
| M3 | `Ramburseaza` cu `<= 0` în CardBancar și Numerar | ✅ |
| M5 | comutarea pe autonomie se vede: `test2.1` e preluat de ARCTX-250 | ✅ în output |
| M6 | `Afisare()` pe Elev/Produs/Cuvant, folosită în Testare5 | ✅ (comentariul de la cerința 4 încă lipsește — vezi M9) |
| M7 | `Program.cs` rulează demo-ul + toate exercițiile | ✅ |
| C2, C4 | `public` scos din `ILivrator`, format `Priza.Stare()` | ✅ |

Warning-urile de compilare au dispărut complet. Progres real față de runda 2.

---

## 🔴 Critice

### B1 (rămas, formă nouă) — Robot: contorul nu se mai resetează NICIODATĂ
`ex3/Models/Robot.cs:23` + `ex3/Models/Robot.cs:32-36`

Fix-ul e pe jumătate: `PoateLivra` refuză acum corect la `livrare == 3` — dar reset-ul contorului a rămas în `Livreaza`, în ramura `if (livrare == 3)`. Urmărește fluxul: `CentruDeLivrari` cheamă `Livreaza` DOAR după ce `PoateLivra` a zis `true` — iar la `livrare == 3`, `PoateLivra` zice mereu `false`. Deci ramura cu reset-ul din `Livreaza` a devenit **cod mort**: nimeni nu mai ajunge la ea prin centru, contorul rămâne 3 pentru totdeauna, iar robotul e „la reîncărcat" pe viață.

Cerința spunea: „`PoateLivra` returnează `false` O DATĂ, apoi contorul se resetează". Reset-ul trebuie mutat în `PoateLivra` — refuzul ESTE momentul resetării (vezi soluția completă în `SOLUTII.pdf`, B1):

```csharp
public bool PoateLivra(double greutateKg)
{
    if (livrare == 3)
    {
        livrare = 0;
        return false;
    }

    return greutateKg <= Capacitate;
}
```

…iar ramura `if (livrare == 3) { ... throw }` din `Livreaza` se șterge.

**Lecția din spatele bug-ului:** un fix care schimbă condiția fără să mute și efectul (reset-ul) lasă cele două jumătăți ale mecanismului în funcții diferite — iar una din ele devine de neatins. După orice fix, întreabă-te: „mai poate ajunge cineva la codul vechi?" Dacă nu, șterge-l — codul mort de azi e bug-ul ascuns de mâine.

**Și demo-ul tace în continuare:** robotul primește exact 3 colete (`test4`–`test6`), deci nici refuzul, nici (lipsa) revenirii nu apar în output. Adaugă `test7` și `test8` cu 25 kg: cu codul actual vei vedea „No courier available" de DOUĂ ori (bug-ul devine vizibil); cu fix-ul corect, o dată refuz, apoi robotul livrează din nou.

---

## 🟡 Importante

### M4 (rămas din runda 2) — ex2: rambursarea reușită pe numerar tot nu există
`ex2/Testare2.cs:22`

Neschimbat: sertarul termină cu 3.51, primul `Ramburseaza(20)` aruncă, deci scenariul „o rambursare pe card ȘI una pe numerar" tot nu e demonstrat, iar al doilea apel din `try` nu se execută niciodată. Fix-ul e în `SOLUTII.pdf` (M4): pornește numerarul de la 300, scoate rambursarea reușită din `try` și prinde `InvalidOperationException`, nu `Exception`.

### M8 (nou) — NotificatorCuIstoric: corectat, dar nefolosit — bonus nedemonstrat
`ex4/Models/NotificatorCuIstoric.cs` · `ex4/Testare4.cs`

Clasa e acum un Decorator corect, dar `Testare4` n-o instanțiază nicăieri: `AfiseazaIstoric` nu e chemat, deci bonusul există doar ca text sursă. Cod care nu rulează = cod nedovedit — exact capcana de la B1. Împachetează emailul:

```csharp
NotificatorCuIstoric emailCuIstoric = new(new EmailNotificator());

INotificator[] canale =
[
    emailCuIstoric,
    new SmsNotificator(),
    new ImprimantaBonuri(11, 2022)
];
```

…și după cele două expedieri cheamă `emailCuIstoric.AfiseazaIstoric()`. Detaliu de verificat în output: emailul invalid din CMD-1002 NU trebuie să apară în istoric (delegarea aruncă înainte de înregistrare).

### M9 (rămas din M6) — ex5: răspunsul-comentariu de la cerința 4 lipsește
`Program.cs:60-62`

Cerința 4 din ex5 cere explicit un comentariu la finalul lui `Program.cs`: de ce criteriul de sortare stă în `Elev`, nu în `Sortator`. Textul e schițat în `SOLUTII.pdf` (M6) — scrie-l cu cuvintele tale; e partea în care demonstrezi că ai înțeles open/closed, nu doar că ai aplicat-o.

---

## 🟢 Cleanups

- **C7 (rămas)** — toată logica `Testare1`–`Testare5` stă în constructori, iar `Program.cs:52-60` face `new` doar pentru efecte secundare (variabilele `testare1`…`testare5` nu sunt folosite nicăieri). O metodă `Ruleaza()` pe fiecare clasă face intenția vizibilă: `new Testare1().Ruleaza();`.
- **C9 (nou)** — redenumirea `Testare` → `Testare1`…`Testare5` rezolvă ambiguitatea din `using`-uri, dar duplică informația pe care namespace-ul o are deja (`Interfaces.ex1.Testare`). Alternativa fără redenumire: păstrai numele `Testare` peste tot și chemai calificat — `new Interfaces.ex1.Testare();` — fără niciun `using` pe ex1–ex5. Numele numerotate merg, dar când vezi un sufix numeric într-un nume de clasă, întreabă-te dacă nu cumva contextul (namespace, folder) spunea deja același lucru.
- **C1, C3, C5, C6, C8 (rămase din runda 2)** — neatinse: ternarul redundant din `Curier.cs:18`, metoda moartă `SeteazaIntensitateMinima` din `Boxa`, `ArgumentException("destinatari")` cu mesaj criptic, `metoda.Nume` nefolosit în `CasaDeMarcat`, destinatarul ținut ca stare în notificatoare. Toate au fix-urile în `SOLUTII.pdf`.

---

## Q&A — runda 3

**Q1.** În `Robot`-ul tău actual, după a 3-a livrare: cine mai poate seta vreodată `livrare` înapoi la 0 și pe ce drum de apel? Desenează lanțul `DistribuieColet → PoateLivra → Livreaza` și arată linia de la care nu se mai poate ajunge la reset.

**Q2.** De ce contează ca rambursarea *reușită* pe numerar să stea ÎNAINTE de blocul `try`, nu înăuntrul lui? Ce ai afla (sau n-ai afla) din output dacă ar sta înăuntru și ar arunca?

**Q3.** `NotificatorCuIstoric` deleagă întâi și abia apoi înregistrează mesajul. Dacă ai inversa ordinea, ce ar apărea în istoric după expedierea CMD-1002 (cea cu emailul invalid) — și de ce ar fi asta o minciună?

---

*Regula proiectului: codul elevului nu se modifică — fix-urile complete sunt în `SOLUTII.pdf`, alături.*
