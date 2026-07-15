# Exercitiul 5 — Sortatorul universal

## Context

Pana acum ai folosit interfete ca sa pui obiecte diferite in acelasi array. Acum le folosesti pentru altceva: **sa scrii un algoritm O SINGURA DATA si sa mearga pentru orice tip viitor**.

Vrei sa sortezi: elevi dupa medie, produse dupa pret, cuvinte alfabetic. Trei sortari, un singur algoritm. Algoritmul nu stie ce compara — stie doar ca elementele SE POT compara intre ele.

Exact asa functioneaza `Array.Sort` din .NET real: cere `IComparable`, nu il intereseaza ce sortezi. Aici iti construiesti versiunea ta.

## Contractul

| Interfata | Membri |
|---|---|
| `IComparabil` | `int ComparaCu(IComparabil altul)` |

Conventia (aceeasi ca in .NET):
- returneaza **negativ** daca obiectul curent vine INAINTEA lui `altul`
- returneaza **0** daca sunt egale
- returneaza **pozitiv** daca vine DUPA

In implementare vei primi `altul` ca `IComparabil` si va trebui sa-l convertesti la tipul concret cu cast explicit, de exemplu `(Elev)altul` — daca cineva amesteca tipuri in acelasi array, e corect sa crape.

## Sortatorul

Clasa `Sortator` cu o singura metoda:

- `void Sorteaza(IComparabil[] elemente)` — bubble sort (doua `for`-uri, compari vecinii cu `ComparaCu`, faci swap cand rezultatul e pozitiv)

Metoda se scrie O DATA si nu se mai atinge. Nu contine niciun nume de clasa concreta.

## Tipurile de sortat

| Clasa | Criteriu |
|---|---|
| `Elev` (nume, medie) | descrescator dupa medie — primul din array e cel cu media cea mai mare |
| `Produs` (denumire, pret) | crescator dupa pret |
| `Cuvant` (text) | alfabetic — foloseste `string.Compare(a, b)`, care returneaza deja negativ/0/pozitiv |

Fiecare clasa are si o metoda `Afisare()`.

## Cerinte

1. Defineste `IComparabil` si `Sortator`.
2. Implementeaza cele 3 clase.
3. In `Program.cs`: cate un array cu minim 5 elemente din fiecare tip, in ordine amestecata; sorteaza-le pe toate CU ACELASI obiect `Sortator` si afiseaza-le inainte si dupa.
4. Raspunde in comentariu la finalul lui `Program.cs`: de ce criteriul de sortare sta in `Elev`, si nu in `Sortator`? Ce ar pati `Sortator` daca ar trebui sa cunoasca toate criteriile?

## Constrangeri

- Doar array-uri brute si `for` — fara `List`, `Dictionary`, LINQ, `Array.Sort`.
- Fara `is`, `as`, `GetType()` — castul explicit din `ComparaCu` e singura conversie permisa.
- Mesajele de eroare in engleza.

## Cum rulezi

```bash
cd ex5
dotnet new console
dotnet run
```

## Bonus

- Adauga sortare pentru `Elev` si dupa nume: o clasa noua `ElevDupaNume`? Nu — gandeste-te la o solutie mai buna: un `bool` sau un criteriu setat in constructor. Care varianta respecta mai bine ideea de contract?
- Masoara cu un contor cate comparatii face bubble sort pe un array de 10 elemente deja sortat. Merita optimizat?
