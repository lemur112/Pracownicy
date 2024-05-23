# Pracownicy
Aplikacja "Pracownicy" jest systemem zarządzania pracownikami w firmie.Pozwala na logowanie, wyświetlanie, dodawanie i usuwanie pracowników, zarządzanie notatkami oraz zmianę hasła.

### Logowanie

Po uruchomieniu aplikacji, użytkownik zostaje poproszony o podanie loginu i hasła. Następnie aplikacja sprawdza wprowadzone dane w bazie danych. Jeśli dane są poprawne, użytkownik zostaje zalogowany i przechodzi do menu głównego. W przeciwnym przypadku, użytkownik otrzymuje informację o błędnych danych logowania i może ponownie wprowadzić dane.

![image](https://github.com/lemur112/Pracownicy/assets/105245169/c99acd6f-81fa-4885-a8c0-e8b74abd80cf)

    
### Menu główne

    Po zalogowaniu, użytkownik zostaje przeniesiony do menu głównego, które jest dostosowane do roli użytkownika. W zależności od roli, użytkownik ma dostęp do różnych funkcji.
![image](https://github.com/lemur112/Pracownicy/assets/105245169/2fc796da-1618-436c-ac44-a0aaf24e1dd9)

#### Administrator i IT

- Dodawanie pracownika wraz z wygenerowanym hasłem i wymaganych danych
    ![image](https://github.com/lemur112/Pracownicy/assets/105245169/9a0d90cf-ffac-4cb5-9ffc-1af2b4e84b43)

    - Usuwanie pracownika
    ![image](https://github.com/lemur112/Pracownicy/assets/105245169/3d4b884b-e0e6-4545-9f9d-484b83d5c3cf)

    - Szukanie pracownika na podstawie imienia i nazwiska
    ![image](https://github.com/lemur112/Pracownicy/assets/105245169/9f79f35a-6a32-4196-a89c-866a7d95e6c3)

    - Wyświetlanie listy pracowników
    ![image](https://github.com/lemur112/Pracownicy/assets/105245169/5f643058-6ade-4791-b288-b6edacbc3d2e)

    - Wyświetlanie stanowisk
    ![image](https://github.com/lemur112/Pracownicy/assets/105245169/ca8ffa2e-c6ab-4e12-86fc-dcacb2028564)

    - Wyświetlanie notatek o pracownikach
    ![image](https://github.com/lemur112/Pracownicy/assets/105245169/8098d018-bd97-49b5-b170-ce79bc85e4a6)

    - Zmiana hasła dla pracownika
    - Wylogowanie

#### Rekruter

    - Wyświetlanie notatek
    - Dodawanie notatki
    - Dodawanie pracownika
    - Wylogowanie


#### HR

    - Wyświetlanie notatek
    - Dodawanie notatki
    - Wyświetlanie listy pracowników
    - Wyświetlanie stanowisk
    - Usuwanie pracownika
    - Dodawanie pracownika
    - Wylogowanie

### Dodawanie notatki

    Funkcja umożliwia dodanie notatki do bazy danych. Użytkownik podaje treść notatki, a następnie notatka zostaje zapisana w bazie danych.

### Wyświetlanie notatek

    Funkcja wyświetla wszystkie notatki z bazy danych wraz z informacjami o pracowniku, który dodał notatkę.

### Zmiana hasła

    Funkcja umożliwia zmianę hasła dla wybranego pracownika.Użytkownik wybiera pracownika, wprowadza nowe hasło, a następnie hasło zostaje zmienione w bazie danych.

## Technologie

    Aplikacja "Pracownicy" została napisana w języku C# na lokalnej bazie danych przy użyciu frameworka .NET. Do komunikacji z bazą danych wykorzystano bibliotekę MySql.Data.MySqlClient.

    ## Uruchomienie

    Aby uruchomić aplikację, należy skompilować kod źródłowy i uruchomić plik wykonywalny.
