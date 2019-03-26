# ReportGenerator

Project made as an recruitment task for core services bootcamp.

## :warning:Komipilacja:warning:

**Ze względu na użyte zależności przed kompilacją należy przwrócić pakiety (nuget restore) dla obu projektów zarówno ReportGenerator.cproj jak i ReportGenerator.UnitTests.csproj.**

Pomimo automatycznego budowania pakietów w trakcie budowy solucji czasami nie wszytkie zależności są pobierane do projektu.

##  Wstęp

Poniższy dokument jest podstawową dokumentacją całego projektu. Całe zadanie zostało zrealizowane zgodnie z wymaganiami zawartymi w przesłanym dokumencie. Projekt został zrealizowany w konwencji TDD, dzięki czemu każda z kluczowych funkcjonalności została przetestowana. Poniżej znajduje się instrukcja obsługi aplikacji wraz z krótkimi opisami danych implementacji.

## Instrukcja obsługi 

Aplikacja posiada interfejs graficzny, który pozwalana na interakcję z użytkownikiem. Całość została zrealizowana w taki sposób aby maksymalnie uprościć użytkownikowi pracę z aplikacją. Zgodnie z założeniami projektu aplikacja udostępnia poniższą funkcjonalność przy pomocy odpowiednich komponentów.

**Wartość zamówienia**

Zgodnie z założeniami zamówienia budowane są na podstawie request_id, gdzie wartość danego zamówienia równa jest sumie ilości produktów z każdego pod zamówienia pomnożonego przez ilość danego produktu w pod zamówieniu.

Formuła opisująca wartość zamówienia:

Order_Value = SUM(Quantity_of_sub_request_with_same_id * Price_of_sub_order_with_same_id)

**Interfejs graficzny**

Poniżej zamieszczono listę pól wraz z ich krótkim opisem.

**Load orders**

Pozwala na wczytywanie dowolnej ilości plików typu .xml .json oraz .csv do bazy danych znajdującej się w programie. Wystarczy wybrać interesujące pliki (możliwa selekcja wielu plików) po otwarciu okna dialogowego.

**Available reports to generate**

Zawiera listę reportów do wygenerowania.

**Client ID**

Pole wykorzystywane podczas generowania raportów dla zadanego klienta.

**Lower/Upper price in range**

Pole wykorzystywane w trakcie generowania raportu o zamówieniach mieszczących się w zadanym przedziale cenowym.

**Clear orders stored in database**

Pozwala na wyczyszczenie wszystkich zamówień znajdujących się w bazie danych.

**Clear error/report logs**

Czyści okna wyświetlające informacje o operacjach oraz niektóre wyniki raportów.

**Logs**

Zgodnie z założeniami podczas wczytywania każdego pliku następuje walidacja danych w nim zawartych. Jeśli plik zawiera jakieś błędne informacje lub brak wymaganych pól podczas wczytywania, panel Logs wyświetli błędy które wystąpiły wraz z ich opisem.

**Reports**

Generuje wyniki raportów, które nie zwracają danych w postaci wierszowej.

**Request list**

W zależności od raportu zawiera informacje go dotyczące. Każdą z kolumn można sortować poprzez naciśnięcie na nagłówek tabeli zawierający jej nazwę.

## Dynamiczne sortowanie 

Zgodnie z założeniami projektu aplikacja udostępnia dynamiczne sortowanie zwracanych reportów. Jeśli raport prezentuje się w formie wierszowej w tabeli, istnieje możliwość posortowania danych ze względu na daną kolumnę. Do implementacji tego rozwiązania użyto [bindingListView](http://blw.sourceforge.net/), które pozwala na konwersję dowolnego kontenera do postaci implementującej sortowanie malejące oraz rosnące.

W celu posortowania wystarczy nacisnąć na nagłówek zawierający nazwę tabeli i dane zostaną posortowane rosnąco. Ponowne naciśnięcie skutkuje posortowaniem malejącym.

## Użyte wzorce projektowe

### Mvc

W aplikacji zaimplementowano, moją własną uproszczoną interpretację wzorca model-view-controller. Głównym celem zastosowanego wzorca jest separacja danych odpowiedzialnych za logikę biznesową od części odpowiedzialnej za poprawne wyświetlanie danych oraz części zawierającą interakcję z użytkownikiem końcowym. Dzięki takiemu podejściu w strukturze plików panuje jasny podział na dane moduły w związku z czym każdy z nich jest niezależny od innych. Każdy z komponentów jest luźno połączony z pozostałymi dzięki czemu z łatwością podmienić można interfejs graficzny lub rozbudować model o nowe funkcjonalności nie naruszając struktury całego projektu.

Bazowy schemat obiegu instrukcji w aplikacji:

Interakcja użytkownika -> kontroler odbiera zadanie -> pobranie danych z modelu -> przesłanie danych do widoku, gdzie zostają wyświetlone

Implementacja:

 - Controller - [`Controller.cs`](/ReportGenerator/Controllers/MainMenuController.cs)
 - ViewModel - [`OrderViewModel.cs`](/ReportGenerator/ViewModel/OrderViewModel.cs)
 - View -  [`MainView.cs`](/ReportGenerator/Views/MainView.cs)

### Factory pattern

Kolejnym wzorcem projektowym jest wzorzec fabryki, która definiuje standardowy sposób tworzenia obiektów w sposób niezależny od ich rodzaju. Aplikacja obsługuje trzy rodzaje plików wejściowych w związku z czym wymagane są trzy różne instancje obiektów realizujących przetwarzanie danych wejściowych. Każda z klas zawiera analogiczne metody lecz niektóre z nich wymagają różnej implementacji w związku z czym metody te zostały odseparowane do interfejsu, natomiast wspólne metody dziedziczone są z klasy bazowej. Fabryka pozwala na poprawne tworzenie danych obiektów ze względu na przekazywany parametr. Rozwiązanie to odseparowuje tworzenie obiektu od jego implementacji, dzięki czemu kod zyskuje na przejrzystości oraz jest mniej podatny na błędy.

Implementacja fabryki:  [`ParserFactory.cs`](/ReportGenerator/Utilities/Parsers/ParserFactory.cs)

## Test driven deployment 

Cały projekt zrealizowany został w konwencji TDD, dzięki czemu każda z kluczowych funkcjonalności programu posiada test, który sprawdza jej poprawność. Testy są kluczowym obiektem programu, ponieważ pozwalają na szybką walidację czy dana funkcjonalność poprawnie realizuje swoje zadanie. Przy pomocy podstawowej biblioteki dostarczanej przez Microsoft zaimplementowano testy zarówno do części biznesowej dotyczącej generowania raportów jak i wszystkich możliwych przypadków odczytu danych w trzech formatach przy pomocy parserów. Testy znajdują się w dołączonym projekcie w solucji.

Testy - [Test directory ](/ReportGenerator.UnitTests)

## Baza danych

Zgodnie z założeniami każde poprawnie wczytane zamówienie dodawane jest do bazy danych in memory. Do implementacji tego rozwiązania użyłem  [Nmemory](https://nmemory.net/), który oferuje dynamiczne tworzenia bazy danych na podstawie obiektów zawartych w projekcie. Rozwiązanie to jest bardzo wydaje oraz oferuje dużą swobodę podczas kreowana zapytań z użyciem LINQ.

Implementacja bazy - [`OrderDatabase.cs`](/ReportGenerator/Models/OrdersDatabase.cs)

Zapytania z użyciem LINQ - [`OrderViewModel.cs`](/ReportGenerator/ViewModel/OrderViewModel.cs)

## Walidacja plików JSON

Do obsługi plików JSON  została użyna biblioteka [JSON.NET](https://www.newtonsoft.com/json), pozwalająca na efektywną pracę z danymi w tym formacie. Dodatkowo na każde zamówienie nałożona została restrykcja dotycząca niektórych z typów danych. Do sprawdzenia poprawności plików JSON, zastosowano [JSON-SCHEMA](https://json-schema.org/), który w aplikacji został obsłużony przez [JSON.NET Schema](https://www.newtonsoft.com/jsonschema). Rozwiązane to pozwoliło na 100 % walidację czytanych danych przy pomocy jednego schematu. Wpłynęło to znacząco na przejrzystość kodu oraz czas jego walidacji. 

Plik JSON Schema przy pomocy, którego sprawdzane są dane został stworzony pod przykładowy plik zawarty w dokumencie z zadaniem. W pliku tym wszystkie wartości reprezentowane były jako stringi w związku z czym json schema sprawdza poprawność typu jako obiektu string. W repozytorium zamieszczono również schemat, który moim zdaniem jest bardziej adekwatny do walidacji zamówień, lecz nie pasuje on do formatu danych z pliku. Wystarczyłoby zmienić typ danych w pliku .json na numeryczny i walidacja z nowym schematem przebiegła by pomyślnie.

Zastosowany schemat JSON - [`json-OrderSchema.json`](/ReportGenerator/Properties/json-OrderSchema.json)

Proponowana zmiana implementacji schematu json -[`My-version-json-schema.json`](/ReportGenerator/Properties/My-version-json-schema.json)

## Walidacja plików XML

Analogicznie do walidacji plików JSON, posłużono się schematem, który pozwala na sprawdzenie pełnej poprawności wczytywanych danych. Plik w formacie .xsd wykorzystany został, w trakcie parsowania kolejnych zamówień i odrzucaniu tych, które nie przeszły walidacji.

Zastosowany schemat .XSD - [`xml_Schema.xsd`](/ReportGenerator/Properties/xml_Schema.xsd)


## Walidacja plików CSV

Do wczytywania plików CSV posłużono się biblioteką [CsvHelper](https://joshclose.github.io/CsvHelper/), która znacznie przyśpieszyła proces wczytywania danych oraz pozwoliła na wstępną walidację poprawności czytanego pliku oraz automatyczne mapowanie danych do tworzonego obiektu zamówienia w aplikacji. Do walidacji danych na które nałożono ograniczenia dotyczące liczby znaków oraz ich zawartości posłużono się wyrażeniami regularnymi.

## Dokumentacja

Ze względu na wielkość zadania oraz czas na jego wykonanie, nie została wygenerowana dokumentacja przy u życiu narzędzia [Sandcastle Help File Builder](https://github.com/EWSoftware/SHFB). Przykładową dokumentację wygenerowaną przy użyciu tego narzędzia znaleźć można w jednym z moich projektów [BettingParlor](https://github.com/LeszekBlazewski/BettingParlor) ( wystarczy ściągnąć repozytorium, a następnie wejść w folder Documentation i otworzyć plik index.html)

## Dependencies

### [Nmemory](https://nmemory.net/)

### [BindingListView](http://blw.sourceforge.net/)

### [JSON.NET](https://www.newtonsoft.com/json)

### [CSVHelper](https://joshclose.github.io/CsvHelper/)
