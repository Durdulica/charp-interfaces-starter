# Exercitiu teoretic — De ce `interface`?

## Context

Aceeasi problema pe care ai rezolvat-o deja la recapitulare (vezi `figuri.jpeg`): un modul care **afiseaza** si **manipuleaza** desene geometrice formate din elemente (Punct, Linie, Cerc, Dreptunghi, Eticheta).

Atunci ai rezolvat-o cu o **clasa abstracta** (`Figura`). Acum o rezolvam din nou, cu **interfete** — si comparam cele doua design-uri.

## Diferenta de intrebare

| | Clasa abstracta | Interfata |
|---|---|---|
| Raspunde la | „ce **esti**?" (is-a) | „ce **stii sa faci**?" (can-do) |
| Cate poti avea | mostenesti UNA singura | implementezi ORICATE |
| Contine cod | da (metode implementate, campuri) | nu, doar contractul |
| Cine intra in ierarhie | doar clase care se nasc din `Figura` | orice clasa care semneaza contractul |

## Contractele

```csharp
public interface IAfisabil
{
    void Afisare();
}

public interface ITranslatabil
{
    void Translatare(int dx, int dy);
}

public interface IElement : IAfisabil, ITranslatabil
{
    IElement Duplicare();
}
```

- `IAfisabil` si `ITranslatabil` sunt capabilitati separate — o clasa poate avea doar una din ele.
- `IElement` le combina si adauga `Duplicare` — o interfata poate mosteni alte interfete.
- `Desen` lucreaza cu `IElement[]` — nu-l intereseaza CE sunt elementele, doar CA respecta contractul.

## Momentul-cheie al demo-ului: `ImaginePng`

In firma vine o cerinta noua: desenele trebuie sa contina si **imagini PNG**. Dar `ImaginePng` face deja parte din alta ierarhie — mosteneste `Resursa` (fisier pe disc, cu nume si dimensiune).

**Cu clasa abstracta esti blocat:** `ImaginePng` nu poate mosteni si `Resursa` si `Figura` — C# nu permite mostenire multipla de clase.

**Cu interfata nu e nicio problema:**

```csharp
public class ImaginePng : Resursa, IElement
```

Mosteneste `Resursa` (ce ESTE) si implementeaza `IElement` (ce STIE SA FACA). Intra in orice `Desen`, alaturi de figuri, fara ca `Desen` sa fie modificat cu vreo linie.

## Ce demonstreaza fiecare pas din `Program.cs`

1. **Polimorfism prin contract** — `Desen` afiseaza elemente diferite printr-un singur tip: `IElement`.
2. **Un apel, tot desenul se muta** — `Translatare` se propaga in fiecare element, fara if-uri pe tip.
3. **Duplicare = deep copy** — copia are propriile puncte; mutarea originalului nu o afecteaza.
4. **Beneficiul decisiv** — `ImaginePng`, dintr-o ierarhie complet straina, intra in desen pentru ca semneaza contractul.

## Intrebari de discutie

- De ce `Desen` implementeaza si el `IElement`? Ce castigi cand un desen poate contine alte desene?
- Cand ai alege totusi clasa abstracta in loc de interfata? (hint: cod comun intre subclase)
- Ce s-ar strica daca `Duplicare` ar returna aceleasi obiecte `Punct` in loc de copii?

## Cum rulezi

```bash
dotnet run
```
