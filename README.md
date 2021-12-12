# Programmazione a oggetti - Lab C-Sharp

L'ordine degli esercizi sarebbe il seguente:

1. Collections
2. Exceptions
3. OperatorsOverloading
4. ExtensionMethods
5. DelegatesAndEvents

Svolgere gli esercizi in ordine diverso non è un problema.

Nota generale per tutti gli esercizi: lo statement `throw new NotImplementedException();` è un segnaposto che va sempre **sostituito** con del codice prodotto da voi.

## Esercizio 1 - Collezioni

Il progetto `Collections` consiste in una semplice libreria che offre la possibilità di modellare un utente di un generico social network.

Scopo dell'esercizio è approfondire le Collections e il loro utilizzo, in particolare:

1. Osservare e capire l'interfaccia `IUser` e `ISocialNetworkUser`
2. Completare l'implementazione di `User` e `SocialNetworkUser`

Il test contenuto in `TestSocialNetworkUser.cs` tenta di chiarire il comportamento atteso per le entità soprariportate.
L'esercizio si può considerare concluso quando il test termina con successo.


## Esercizio 2 - Eccezioni

Il progetto `Exceptions` contiene l'intefaccia `IFixedSizeQueue` che rappresenta una collezione mutevole di tipo FIFO dalla capacità prefissata.
Un tentativo di inserire un elemento in una coda piena, deve produrre una `FullQueueException`.
Invece, un tentativo di prelevare un elemento da una cosa vuota, deve produrre una `EmptyQueueException`.


Scopo dell'esercizio è completare l'implementazione della classe `FixedSizeQueue`, assicurandosi di lanciare correttamente o due tipi di eccezione forniti: `EmptyQueueException` e `FullQueueException`.

Il test contenuto in `TestFixedSizeQueue.cs` verifica e chiarisce il comportamento atteso per le entità soprariportate.
L'esercizio si può considerare concluso quando tutti i test terminano con successo.


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

Il test contenuto in `ComplexExtensionsTests.cs` tenta di chiarire il comportamento atteso per i metodi estensione suddetti.
L'esercizio si può considerare concluso quando tutti i test terminano con successo.

## Esercizio 5 - Delegati ed eventi

Il progetto `DelegatesAndEvent` consiste in una semplice libreria che fornisce l'astrazione di "lista osservabile".
L'intefaccia `IObservableList` estende `System.Collections.Generic.IList` con la capacità della lista di generare eventi ogni volta che subisce una modifica.

L'esercizio fornisce già i delegati `ListChangeCallback` e `ListElementChangeCallback`.
Il primo codifica la firma dei metodi che possono essere registrati per intercettare l'aggiunta/rimozione di elementi dalla lista.
Il secondo codifica la firma dei metodi che possono essere registrati per intercettare la sostituzione di un elemento della lista.

Scopo dell'esercizio è implementare la classe `ObservableList` in maniera tale da generare gli eventi in maniera corretta.

Il test contenuto nella classe `Program` tenta di chiarire il comportamento atteso per le implementazioni dell'interfaccia `IObservableList`.
Esso mostra inoltre come è possibile registrare ascoltatori di eventi per una specifica lista.

