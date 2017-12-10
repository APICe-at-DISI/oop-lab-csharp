# Programmazione a oggetti - Lab C#

L'ordine degli esercizi sarebbe il seguente:

1. Properties
2. Indexer
3. OperatorsOverloading
4. ExtensionMethods
5. DelegatesAndEvents
6. Iterators

Svolgere gli esercizi in ordine diverso non è un problema.

Nota generale per tutti gli esercizi: lo statement `throw new NotImplementedException();` è un segnaposto che va sempre **sostituito** con del codice prodotto da voi.

## Esercizio 1 - Proprietà

Il progetto `Properties` consiste in un semplice programma a riga di comando che permette di generare un mazzo di carte (deck) a partire dai nomi dei semi (p.e. fiori, quadri, picche e cuori) e dai nomi delle carte (p.e. asso, ..., fante, regina, re).

La classe `Program` rappresenta il punto d'ingresso dell'applicazione e, come esempio, genera un mazzo di carte italiane.
La classe `DeckFactory` permette di costruire un certo numero di istanze della classe `Card` (che andranno a comporre il mazzo) a partire dai nomi dei semi e delle carte.
Queste classi sono state scritte da un programmatore Java, non abituato a scrivere codice C#.

Scopo dell'esercizio è "convertire" il codice dallo stile Java allo stile C#, ad esempio usando le proprietà e gli altri costrutti tipici del secondo linguaggio.

Notare anche che nel codice vengono impiegate le stringhe formato (alcuni esempi qui: https://msdn.microsoft.com/it-it/library/system.string.format(v=vs.110).aspx) e l'interpolazione di stringhe (alcuni esempi: https://docs.microsoft.com/it-it/dotnet/csharp/language-reference/keywords/interpolated-strings).
La comprensione di questi aspetti del linguaggio è auspicabile.


## Esercizio 2 - Indicizzatori & generici

Il progetto `Indexers` consiste in una semplice libreria che fornisce l'astrazione di mappa bidimensionale (cioè mappa con due chiavi). 
Il progetto fornisce l'interfaccia `IMap2D<TKey1, TKey2, TValue>`, che mostra i metodi forniti da una mappa bi-dimensionale, e la classe `Program` che rappresenta il punto d'ingresso del programma di test.
Le implementazioni dell'interfaccia `IMap2D` permettono di memorizzare valori di tipo `TValue` in quella che può essere pensata come una matrice sparsa, in cui le righe sono indicizzare con valori di tipo `TKey1` e le colonne con valori di tipo `TKey2`.
Dato un oggetto `IMap<TKey1, TKey2, TValue> map` e due chiavi `k1` di tipo `TKey1` e `k2` di tipo `TKey2`, si accede al valore corrispondente con la sintassi `map[k1, k2]`.

Scopo dell'esercizio è implementare la classe `Map2D<TKey1, TKey2, TValue>`.
Il test contenuto nella classe `Program` tenta di chiarire il comportamento atteso per una classe che implementi `IMap2D`.
Esso lancia eccezioni nel caso di errata implementazione della classe `Map2D`.


## Esercizio 3 - Overloading degli operatori

Il progetto `OperatorsOverloading` consiste in una semplice libreria che fornisce l'astrazione di lista concatenata e immutabile.
Il progetto fornisce la classe astratta List<TValue> (e la sua implementazione), che permette di manipolare [liste concatenate](https://it.wikipedia.org/wiki/Lista_concatenata), e la classe statica `List` che contiene dei metodi di utilità per creare una `List<TValue>` a partire dai suoi elementi di tipo `TValue` o per concatenare due liste dello stesso tipo.
Ad esempio, la lista `[1, 2, 3]` può essere creata con le seguenti sintassi:

    List<int> lst = List.Of(1, List.Of(2, List.Of(3)))

	List<int> lst1 = List.Of(1, List.Of(2, List.Of(3, List.Nil<int>())))

	List<int> lst2 = List.From(1, 2, 3)

Il metodo `List.Append` permette invece di concatenare due liste:

    List.Append(List.From(1, 2, 3), List.Of(4, List.Of(5))) // = [1, 2, 3, 4, 5]

Scopo dell'esercizio è implementare l'overload degli operatori di confronto, cast, addizione e sottrazione con le sequenti semantiche:

- `==` e `!=` confrontano i valori delle liste, elemento per elemento
- gli operatori `>`, `<`, `>=`, `<=`, confrontano **le lunghezze** delle due liste
- l'operatore `+` concatena due liste (in maniera analoga al metodo `List.Append`)
- l'operatore `-` rimuove tutti gli elementi della seconda lista di destra da quella di sinistra

Inoltre, dev'essere possibile effettuare le seguenti conversioni:

- da array di `TValue` a `List<TValue>`, in maniera implicita

- da valore di tipo `TValue` a `List<TValue>` (contenente un solo elemento!), in maniera implicita

- da `List<TValue>` ad array di `TValue`, in maniera **esplicita**

Il test contenuto nella classe `Program` tenta di chiarire il comportamento della classe `List<TValue>`, nel caso in cui l'overload degli operatori sia stato implementato correttamente.

È sempre buona cosa riusare i metodi già forniti o la logica con cui sono stati implementati.


## Esercizio 4 - Metodi estensione

Il progetto `ExtensionMethods` consiste in una semplice libreria che fornisce l'interfaccia `IComplex` per lavorare con i numeri complessi.
L'interfaccia è volutamente minimale e delega l'implementazione delle [varie operazioni](https://en.wikipedia.org/wiki/Complex_number#Elementary_operations) ai metodi estensione contenuti nella classe `ComplexExtensions`.

Gli scopi dell'esercizio sono:

- Implementare l'interfaccia `IComplex` nella/nelle maniere che si ritengono migliori

- Implementare le operazioni sui numeri complessi, le cui firme sono presenti nella classe statica nella classe `ComplexExtensions`

Il test contenuto nella classe `Program` tenta di chiarire il comportamento atteso per i metodi estensione suddetti.

## Esercizio 5 - Delegati ed eventi

Il progetto `DelegatesAndEvent` consiste in una semplice libreria che fornisce l'astrazione di "lista osservabile".
L'intefaccia `IObservableList` estende `IList` (interfaccia standard di .Net) con la capacità della lista di generare eventi ogni volta che subisce una modifica.

L'esercizio fornisce già i delegati `ListChangeCallback` e `ListElementChangeCallback`.
Il primo codifica la firma dei metodi che possono essere registrati per intercettare l'aggiunta/rimozione di elementi dalla lista.
Il secondo codifica la firma dei metodi che possono essere registrati per intercettare la sostituzione di un elemento della lista.

Scopo dell'esercizio è implementare la classe `ObservableList` in maniera tale da generare gli eventi in maniera corretta.

Il test contenuto nella classe `Program` tenta di chiarire il comportamento atteso per le implementazioni dell'interfaccia `IObservableList`.
Esso mostra inoltre come è possibile registrare ascoltatori di eventi per una specifica lista.

## Esercizio 6 - Iterators

Il progetto `Iterators` è finalizzato alla comprensione delle analogie e delle differenze tra gli Stream di Java 8 e gli enumerabili di .Net.
Per ciò, viene fornita la classe `Java8StreamOperations` contenente le firme di alcuni metodi estensione aventi gli stessi nomi dei metodi dell'interfaccia `Stream` di Java 8 (p.e. `map`, `filter`, `reduce`, etc).

Scopo dell'esercizio è implementare i suddetti metodi --- auspicabilmente sfruttando il costrutto degli [iteratori di C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/iterators) -- affinchè i metodi della classe `Java8StreamOperations` si comportino come gli omonimi definiti in Java, a cui siamo abituati.
Per varificare la correttezza delle proprie implementazioni, l'esercizio prevede infine che la pipeline di elaborazione presente nella classe `Program` venga riscritta sfruttando i metodi estensione precedentemente implementati.

