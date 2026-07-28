# Code Review — stefan-charp-interfaces-starter (runda 2)

**Data:** 2026-07-28 · **Stare build:** trece, 3 warning-uri (toate în `NotificatorCuIstoric.cs`) · **Context:** review după commit-ul „code fixes" (4bc3167); reviewul anterior e în `CODE_REVIEW.pdf`.

Ce e bine și merită spus: ex1–ex4 au contractele împărțite corect, `Telecomanda`/`CasaDeMarcat`/`CentruDeLivrari`/`MagazinOnline` nu cunosc nicio clasă concretă (exact ideea lecției), iar la ex5 soluția generică `Sortator<T> where T : IComparabil<T>` e un upgrade real față de cerință — prinde amestecul de tipuri la compilare, nu la rulare. Bravo pentru ea, dar vezi M6: un upgrade nedocumentat tot deviație de la cerință se numește.

---

## 🔴 Critice

### B1 — Robot: `Livreaza` aruncă excepție deși `PoateLivra` a promis `true`
`ex3/Models/Robot.cs:32-36`

Cerința (bonus ex3): „la a 4-a livrare `PoateLivra` returnează `false` o dată, apoi contorul se resetează". Tu ai pus verificarea de reîncărcare în `Livreaza`, care aruncă `InvalidOperationException("This courier is recharging")`.

**Mecanismul:** perechea `PoateLivra`/`Livreaza` e un contract în doi timpi: cel care apelează (aici `CentruDeLivrari.DistribuieColet`) întreabă întâi, și abia apoi livrează. Dacă `PoateLivra` zice `true` dar `Livreaza` aruncă, contractul e mințit — `DistribuieColet` nu are `try/catch` (și nici n-ar trebui să aibă) și aplicația crapă. Mai rău: robotul trebuia doar *sărit* (să preia următorul livrator), nu să dărâme tot centrul.

**De ce n-ai văzut bug-ul:** în `ex3/Testare.cs` robotul primește exact 3 colete — a 4-a cerere nu vine niciodată. Adaugă `centru.DistribuieColet("test7", 25)` și programul crapă. Un test care nu atinge ramura nu dovedește că ramura e corectă.

### B2 — NotificatorCuIstoric: mesajele se pierd în tăcere
`ex4/Models/NotificatorCuIstoric.cs:22-25`

`Trimite` are corpul gol: cine folosește acest notificator crede că a trimis mesajul, dar mesajul dispare — fără eroare, fără urmă. Ăsta e cel mai periculos tip de bug: nu crapă nimic, doar lipsesc date.

Restul clasei confirmă că Decoratorul a fost înțeles greșit:
- primește `INotificator[]` — cerința spune „PRIMEȘTE în constructor **alt** `INotificator`" (unul singur, pe care îl îmbracă);
- nu deleagă nimic și nu reține niciun mesaj — `istoric` (linia 5) e câmp mort (warning CS0169);
- `Canal` (linia 7) nu e asignat niciodată → rămâne `null` (warning CS8618);
- `AfiseazaIstoric` (linia 18) face `Console.WriteLine(Notificari[i])` pe un obiect → afișează numele tipului (`Interfaces.ex4.Models.EmailNotificator`), nu mesaje.

**Mecanismul Decorator:** decoratorul semnează ACELAȘI contract ca obiectul îmbrăcat, deleagă apelul mai departe și adaugă comportamentul lui (aici: memorarea mesajului) înainte sau după delegare. Din exterior e de nedistins de un notificator obișnuit — de-asta intră în `MagazinOnline` fără nicio modificare acolo.

---

## 🟡 Importante

### M1 — Bec: starea se schimbă ÎNAINTE de validare
`ex1/Models/Bec.cs:35-36`

```csharp
public void SeteazaIntensitate(int procent)
{
    EstePornit = true;      // mutare...
    Intensitate = procent;  // ...apoi validare (poate arunca)
}
```

`bec.SeteazaIntensitate(150)` aruncă excepția corectă, dar becul rămâne **pornit**, cu intensitatea veche. O operație care eșuează nu are voie să lase urme — regula e: *validezi tot, abia apoi muți starea*. Inversează liniile (setează întâi `Intensitate`, care validează; dacă trece, abia atunci `EstePornit = true`).

### M2 — IPornibil: `EstePornit` are setter public
`ex1/Models/IPornibil.cs:5`

Cerința cere `bool EstePornit { get; }`. Cu `{ get; set; }` în interfață, orice cod poate face `bec.EstePornit = true` ocolind `Porneste()`. Interfața e fața publică — setter-ul e detaliu intern al implementării: în interfață doar `get`, iar în clasă `public bool EstePornit { get; private set; }`.

### M3 — Ramburseaza acceptă suma 0
`ex2/Models/CardBancar.cs:32`, `ex2/Models/Numerar.cs:34`

`if (pret < 0)` lasă `Ramburseaza(0)` să treacă, deși mesajul spune „Amount must be positive" și `Plateste` folosește corect `<= 0`. Aceeași regulă de business → aceeași condiție peste tot.

### M4 — ex2: rambursarea reușită pe numerar nu se întâmplă niciodată
`ex2/Testare.cs:22`

Fă calculul sertarului: start 170 → plătește 120.50 → 49.51 → 80 eșuează → plătește 45.99 → **3.51**. Primul `numerar.Ramburseaza(20)` găsește 3.51 în sertar și aruncă imediat — deci cerința „fă o rambursare pe card ȘI una pe numerar" nu e demonstrată; al doilea apel (245.99) nu se mai execută deloc. Pornește sertarul cu mai mulți bani sau rambursează o sumă ≤ 3.51 înainte de cea care provoacă excepția.

### M5 — ex3: scenariul cerut la punctul 4 nu e demonstrat
`ex3/Testare.cs:27-32`

Cerința: „distribuie destule colete mici încât unei drone să i se termine autonomia și să preia următorul livrator". Drona1 (14 km) face 2 livrări → 4 km rămași → următorul colet mic ar trebui preluat de drona2. Dar după `test2` nu mai trimiți niciun colet ≤ 3 kg, deci comutarea pe autonomie nu se vede în output (la `test3`+ dronele pică pe greutate, nu pe autonomie). Adaugă 1-2 colete mici după `test2`.

### M6 — ex5: cerințe lipsă pe lângă upgrade-ul generic
`ex5/Models/` + `ex5/Testare.cs`

- Cele 3 clase nu au metoda `Afisare()` cerută — afișarea e duplicată în `Testare.cs` în 6 for-uri identice.
- Răspunsul-comentariu de la cerința 4 (de ce criteriul stă în `Elev`, nu în `Sortator`) lipsește din `Program.cs`.
- Cu `Sortator<T>` generic nu mai poți sorta toate cele 3 array-uri „CU ACELAȘI obiect `Sortator`" (ai 3 instanțe). Deviația e justificabilă — dar la predare o *spui*, nu o lași descoperită de corector.

### M7 — Program.cs: rulează doar ex4, demo-ul e comentat
`Program.cs:9-47`

`dotnet run` execută doar `Interfaces.ex4.Testare`; demo-ul cu figuri (Pasul 1-4 din cerința principală) e într-un bloc comentat. Codul comentat nu compilează odată cu proiectul — poate putrezi fără să observi. Decomentează demo-ul și cheamă toate cele 5 `Testare`-uri pe rând (cu un `Console.WriteLine` separator), ca o singură rulare să arate tot.

---

## 🟢 Cleanups

- **C1** — `ex3/Models/Oameni/Curier.cs:18`: `return greutateKg <= Capacitate ? true : false;` → condiția E deja bool: `return greutateKg <= Capacitate;`. Același pattern cu if/return în `Robot.cs:21-29` și `Drona.cs`.
- **C2** — `ex3/Models/ILivrator.cs:5`: `public` pe un singur membru de interfață, celelalte fără — membrii de interfață sunt publici implicit; șterge modificatorul.
- **C3** — `ex1/Models/Boxa.cs:40-43`: `SeteazaIntensitateMinima()` nu e chemată de nimeni (dead code — `ModNoapte` folosește deja `Minim`). Tot aici: `Porneste`/`Opreste` scriu direct în câmpul `volum`, dar `SeteazaIntensitate` trece prin proprietatea `Volum` — alege o singură cale (proprietatea). Și inconsecvență cu `Bec`: acolo `Intensitate` e publică, aici `Volum` privată.
- **C4** — `ex1/Models/Priza.cs:19`: `Stare()` întoarce doar `"True"` — pune-l în același format cu celelalte rapoarte („este pornita: True").
- **C5** — `ex4/Models/MagazinOnline.cs:15-18`: `throw new ArgumentException("destinatari")` — mesajul e doar numele parametrului. Folosește `ArgumentNullException.ThrowIfNull(destinatari)`, simetric cu linia 9.
- **C6** — `ex2/Models/CasaDeMarcat.cs`: `metoda.Nume` nu e citit nicăieri — outputul nu spune cu ce metodă s-a plătit, iar proprietatea cerută de interfață rămâne moartă. Include `metoda.Nume` în mesaje. Tot aici: `Console.Write("\n")` → `Console.WriteLine()`.
- **C7** — toate `Testare.cs`: toată logica stă în constructor, iar `Program.cs` face `new Testare()` doar pentru efectele secundare. Constructorul construiește obiecte; rularea e o acțiune — mut-o într-o metodă `Ruleaza()`.
- **C8** — `ex4/Models/EmailNotificator.cs:6-21`, `SmsNotificator.cs`: notificatorul ține destinatarul ca stare (câmp + proprietate cu validare în setter) doar ca să valideze un parametru. Notificatorul n-are nevoie de stare — o metodă privată `ValideazaDestinatar(string)` chemată din `Trimite` spune mai direct ce se întâmplă.

---

## Before / After (criticele)

### B1 — Robot: reîncărcarea mutată în `PoateLivra`

| Before (`Robot.cs`) | After |
|---|---|
| ```csharp
public bool PoateLivra(double greutateKg)
{
    if (greutateKg <= Capacitate)
    {
        return true;
    }
    return false;
}

public void Livreaza(string adresa, double greutateKg) {
    if (livrare == 3)
    {
        livrare = 0;
        throw new InvalidOperationException("This courier is recharging");
    }
    ...
}
``` | ```csharp
public bool PoateLivra(double greutateKg)
{
    if (livrare == 3)
    {
        livrare = 0;   // a refuzat o data, apoi e reincarcat
        return false;
    }
    return greutateKg <= Capacitate;
}

public void Livreaza(string adresa, double greutateKg)
{
    if (!PoateLivra(greutateKg))
    {
        throw new InvalidOperationException("This courier cannot deliver the package");
    }
    livrare++;
    Console.WriteLine(...);
}
``` |

Observație de discutat: și varianta „after" are o subtilitate — `Livreaza` cheamă `PoateLivra`, care consumă refuzul. E acceptabil aici, dar vezi întrebarea Q1.

### B2 — NotificatorCuIstoric: Decorator adevărat

| Before | After |
|---|---|
| ```csharp
public class NotificatorCuIstoric : INotificator
{
    private string istoric;
    INotificator[] Notificari { get; }
    public string Canal { get; }

    public NotificatorCuIstoric(INotificator[] notificari)
    {
        Notificari = notificari;
    }

    public void AfiseazaIstoric()
    {
        for (int i = 0; i < Notificari.Length; i++)
        {
            Console.WriteLine(Notificari[i]);
        }
    }

    public void Trimite(string destinatar, string mesaj)
    {
    }
}
``` | ```csharp
public class NotificatorCuIstoric : INotificator
{
    private readonly INotificator interior;
    private readonly string[] istoric = new string[10];
    private int numarMesaje;

    public string Canal => interior.Canal;

    public NotificatorCuIstoric(INotificator interior)
    {
        this.interior = interior;
    }

    public void Trimite(string destinatar, string mesaj)
    {
        interior.Trimite(destinatar, mesaj);
        istoric[numarMesaje % istoric.Length] = mesaj;
        numarMesaje++;
    }

    public void AfiseazaIstoric()
    {
        for (int i = 0; i < istoric.Length; i++)
        {
            if (istoric[i] != null)
            {
                Console.WriteLine(istoric[i]);
            }
        }
    }
}
``` |

Punctul-cheie: `Trimite` întâi **deleagă**, apoi înregistrează — dacă `interior.Trimite` aruncă (email invalid), mesajul eșuat NU intră în istoric. Și fiindcă semnează `INotificator`, îl pui în `MagazinOnline` în locul oricărui canal, cu zero modificări acolo: `new NotificatorCuIstoric(new EmailNotificator())`.

---

## Q&A — verifică-ți înțelegerea

**Q1.** `CentruDeLivrari` face `PoateLivra(...)` apoi `Livreaza(...)`. De ce e grav ca `Livreaza` să arunce excepție după ce `PoateLivra` a răspuns `true`? Și subtilitatea din varianta corectată: dacă `Livreaza` cheamă intern `PoateLivra` (care consumă refuzul de reîncărcare), ce se poate întâmpla când centrul cheamă `PoateLivra` de două ori la rând pentru același robot?

**Q2.** După `bec.SeteazaIntensitate(150)` (care aruncă excepție), în ce stare e becul în codul tău actual? De ce regula „validezi tot, apoi muți starea" contează mai ales în metode chemate din bucle care prind excepții și merg mai departe (ca `MagazinOnline.AnuntaExpediere`)?

**Q3.** `Sortator<T> where T : IComparabil<T>` versus `Sortator` ne-generic cu `(Elev)altul` în `ComparaCu`: în fiecare variantă, *când* și *cum* afli că cineva a amestecat un `Produs` într-un array de `Elev` — la compilare sau la rulare? De ce e aproape întotdeauna mai bine „la compilare"?

---

*Regula proiectului: codul elevului nu se modifică — toate fragmentele „after" sunt doar în acest document.*
