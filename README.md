# Pracownicy

    Aplikacja "Pracownicy" jest systemem zarządzania pracownikami w firmie.Pozwala na logowanie, wyświetlanie, dodawanie i usuwanie pracowników, zarządzanie notatkami oraz zmianę hasła.

## Funkcje

### Logowanie

    Po uruchomieniu aplikacji, użytkownik zostaje poproszony o podanie loginu i hasła. Następnie aplikacja sprawdza wprowadzone dane w bazie danych. Jeśli dane są poprawne, użytkownik zostaje zalogowany i przechodzi do menu głównego. W przeciwnym przypadku, użytkownik otrzymuje informację o błędnych danych logowania i może ponownie wprowadzić dane.
    ![image](https://github.com/lemur112/Pracownicy/assets/105245169/a304a25f-e8aa-44ed-9475-53a803baeb4a)
    ### Menu główne

    Po zalogowaniu, użytkownik zostaje przeniesiony do menu głównego, które jest dostosowane do roli użytkownika. W zależności od roli, użytkownik ma dostęp do różnych funkcji.

    ![image](https://github.com/lemur112/Pracownicy/assets/105245169/b62feff9-dce7-489b-94b5-fcf45a09d40c)
    #### Administrator i IT

    - Dodawanie pracownika wraz z wygenerowanym hasłem i możliwosscia dodania wieku
    ![image](https://github.com/lemur112/Pracownicy/assets/105245169/93d4df21-18b3-4ce8-a268-d639887b25fd)
    - Usuwanie pracownika
    ![image](https://github.com/lemur112/Pracownicy/assets/105245169/a81a17b8-ca05-4a47-a689-427667ffc16e)
    - Szukanie pracownika na podstawie imienia i nazwiska

    - Wyświetlanie listy pracowników
    - Wyświetlanie stanowisk
    - Wyświetlanie notatek o pracownikach
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