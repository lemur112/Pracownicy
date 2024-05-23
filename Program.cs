using MySql.Data.MySqlClient;
using Mysqlx.Session;
using System.ComponentModel.Design;
namespace Pracownicy
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=workgroup;";
            MySqlConnection conn = new MySqlConnection(connStr);

            Console.WriteLine("Zaloguj się do systemu: \n");

            Console.Write("Podaj login:");
            string login = Console.ReadLine();
            Console.Write("Podaj hasło:");
            string password = Console.ReadLine();

            conn.Open();
            string query = "SELECT * FROM workers WHERE login = @login AND password = @password";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@password", password);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Console.WriteLine("Zalogowano pomyślnie!");
                Console.Read();
                Console.Clear();
                string role = reader["id_role"].ToString();
                int id = Convert.ToInt16(reader["id_worker"]);
                conn.Close();
                reader.Close();
                ShowMenu(role, login, conn, id);
            }
            else
            {
                Console.WriteLine("Błędne dane logowania!");
                Console.Clear();
                conn.Close();
                reader.Close();
                Main(null);
            }
        }

        /************************************** 
         * nazwa funkcji:        ShowMenu
         * parametry wejściowe: role (string z id roli), login (string z loginem), conn (połączenie z bazą danych), id (int z id pracownika)
         * wartość zwracana:     Funkcja wyświetla menu główne i dostosowywuje je w zależności od posiadanych uprawnień
         * autor:                Bartosz Klimczak 3D
         * *************************************/
        public static void ShowMenu(string role,string login, MySqlConnection conn, int id)
        {
            switch (role)
            {
                case "1":
                    //ADMINISTRATOR
                    Console.WriteLine($"Witaj {login}!");
                    Console.WriteLine("Wybierz opcję: ");
                    Console.WriteLine("1. Dodaj pracownika");
                    Console.WriteLine("2. Usuń pracownika");
                    Console.WriteLine("3. Szukaj pracownika");
                    Console.WriteLine("4. Wyświetl listę pracowników");
                    Console.WriteLine("5. Wyświetl stanowiska");
                    Console.WriteLine("6. Wyświetl notatki o pracownikach");
                    Console.WriteLine("7. Zmien Hasło dla pracownika");
                    Console.WriteLine("8. Wyloguj");
                    Console.Read();
                    switch (Console.ReadLine())
                    {
                        case "1":
                            AddWorker(conn);
                            break;
                        case "2":
                            DeleteWorker(conn);
                            break;
                        case "3":
                            SearchWorker(conn);
                            break;
                        case "4":
                            ShowWorkers(conn);
                            break;
                        case "5":
                            ShowPositions(conn);
                            break;
                        case "6":
                            ShowNotes(conn);
                            break;
                        case "7":
                            ChangePassword(conn);
                            break;
                        case "8":
                            Logout(conn);
                            break;
                    }
                    break;

                case "2":
                    //REKRUTER
                    Console.WriteLine($"Witaj {login}!");
                    Console.WriteLine("Wybierz opcję: ");
                    Console.WriteLine("1. Wyświetl notatki");
                    Console.WriteLine("2. Dodaj notatkę");
                    Console.WriteLine("3. Dodaj Pracownika");
                    Console.WriteLine("4. Wyloguj");
                    string option2 = Console.ReadLine();
                    switch (option2)
                    {
                        case "1":
                            ShowNotes(conn);
                            break;
                        case "2":
                            AddNote(conn, id);
                            break;
                        case "3":
                            AddWorker(conn);
                            break;
                        case "4":
                            Logout(conn);
                            break;
                        default:
                            Console.WriteLine("Nieprawidłowa opcja!");
                            break;
                    }
                    break;
                case "3":
                    Console.WriteLine($"Witaj {login}!");
                    Console.WriteLine("Wybierz opcję: ");
                    Console.WriteLine("1. Dodaj pracownika");
                    Console.WriteLine("2. Usuń pracownika");
                    Console.WriteLine("3. Szukaj pracownika");
                    Console.WriteLine("4. Wyświetl listę pracowników");
                    Console.WriteLine("5. Wyświetl stanowiska");
                    Console.WriteLine("6. Wyświetl notatki o pracownikach");
                    Console.WriteLine("7. Zmien Hasło dla pracownika");
                    Console.WriteLine("8. Wyloguj");
                    string option3 = Console.ReadLine();

                    switch (option3)
                    {
                        case "1":
                            AddWorker(conn);
                            break;
                        case "2":
                            DeleteWorker(conn);
                            break;
                        case "3":
                            SearchWorker(conn);
                            break;
                        case "4":
                            ShowWorkers(conn);
                            break;
                        case "5":
                            ShowPositions(conn);
                            break;
                        case "6":
                            ShowNotes(conn);
                            break;
                        case "7":
                            ChangePassword(conn);
                            break;
                        case "8":
                            Logout(conn);
                            break;
                    }
                    break;
                case "4":
                    //HR
                    Console.WriteLine($"Witaj {login}!");
                    Console.WriteLine("Wybierz opcję: ");
                    Console.WriteLine("1. Wyświetl notatki");
                    Console.WriteLine("2. Dodaj notatkę");
                    Console.WriteLine("3. Wyświetl listę pracowników");
                    Console.WriteLine("4. Wyświetl stanowiska");
                    Console.WriteLine("5. Usun Pracownika");
                    Console.WriteLine("6. Dodaj pracownika");
                    Console.WriteLine("7. Wyloguj");
                    string option4 = Console.ReadLine();
                    switch (option4)
                    {
                        case "1":
                            ShowNotes(conn);
                            break;
                        case "2":
                            AddNote(conn, id);
                            break;
                        case "3":
                            ShowWorkers(conn);
                            break;
                        case "4":
                            ShowPositions(conn);
                            break;
                        case "5":
                            DeleteWorker(conn);
                            break;
                        case "6":
                            AddWorker(conn);
                            break;
                        case "7":
                            Logout(conn);
                            break;
                    }
                    break;
            }
        }

        /************************************** 
         * nazwa funkcji:        AddNote
         * parametry wejściowe: conn (połączenie z bazą danych), id (int z id pracownika)
         * wartość zwracana:     Dzięki funkcji można dodać notatkę do bazy danych
         * autor:                Bartosz Klimczak 3D
         * *************************************/
        private static void AddNote(MySqlConnection conn, int id)
        { 
            string query = "SELECT * FROM note";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            Console.Clear();
            Console.WriteLine("Podaj treść notatki: ");
            string content = Console.ReadLine();
            Console.Clear();
            query = "INSERT INTO note (id_worker, content) VALUES (@id_worker, @content)";
            cmd.Parameters.AddWithValue("@id_worker", id);
            cmd.Parameters.AddWithValue("@content", content);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Notatka dodana pomyślnie!");
            conn.Close();
            Console.WriteLine("Nacisnij dowolny przycisk aby wrocic do menu");
            Console.Read();
            Main(null);
        }


        /************************************** 
         * nazwa funkcji:        Logout
         * parametry wejściowe: conn (połączenie z bazą danych)
         * wartość zwracana:     Funkcja zamknie połączenie z bazą danych i wyjdzie z programu
         * autor:                Bartosz Klimczak 3D
         * *************************************/
        private static void Logout(MySqlConnection conn)
        {
            conn.Close();
            Console.Clear();
            Environment.Exit(0);
        }

        private static void ChangePassword(MySqlConnection conn)
        {
            // TODO: Implement ChangePassword method

        }

        private static void ShowNotes(MySqlConnection conn)
        {
            // TODO: Implement ShowNotes method
        }


        /************************************** 
        * nazwa funkcji:        ShowPositions
        * parametry wejściowe: conn (połączenie z bazą danych)
        * wartość zwracana:    Funkcja wyswietla pracowników wraz z ich stanowiskiem
        * autor:                Bartosz Klimczak 3D
        * *************************************/
        private static void ShowPositions(MySqlConnection conn)
        {
            Console.Clear();
            string query = "SELECT workers.name,workers.surname,role.role_name FROM role INNER JOIN workers ON workers.id_role = role.id_role";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader["name"]} {reader["surname"]} - {reader["role_name"]}");
            }
        }


        /************************************** 
         * nazwa funkcji:        ShowWorkers
         * parametry wejściowe: conn (połączenie z bazą danych)
         * wartość zwracana:     Funkcja wyświetla wszytskich pracowników z bazy danych
         * autor:                Bartosz Klimczak 3D
         * *************************************/
        private static void ShowWorkers(MySqlConnection conn)
        {
            Console.Clear();
            string query = "SELECT workers.id_worker,workers.name,workers.surname,workers.id_role,role.role_name FROM workers INNER JOIN role ON workers.id_role = role.id_role";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.Write(
                    $"{reader["id_worker"]}. {reader["name"]} {reader["surname"]} / {reader["role_name"]} \n");
            }
            conn.Close();

            Console.WriteLine("Nacisnij dowolny przycisk aby wrocic do menu");
            Console.Read();
            Main(null);

        }


        /************************************** 
        * nazwa funkcji:        SearchWorker
        * parametry wejściowe: conn (połączenie z bazą danych)
        * wartość zwracana:   Funkcja wyświetla informacje o pracowniku
        * autor:                Bartosz Klimczak 3D
        * *************************************/
        private static void SearchWorker(MySqlConnection conn)
        {
            Console.Clear();
            Console.WriteLine("Podaj imię i nazwisko:");
            string fullname = Console.ReadLine();
            string name = fullname.Split(" ")[0];
            string surname = fullname.Split(" ")[1];
            string query = $"SELECT workers.id_worker,workers.name,workers.surname,workers.login,workers.id_role,workers.hire_date, workers.age, role.role_name FROM workers INNER JOIN role ON workers.id_role = role.id_role WHERE workers.name = @name AND workers.surname = @surname";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@surname", surname);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["id_worker"]}");
                Console.WriteLine($"{reader["name"]} {reader["surname"]} ({reader["age"]} lat)");
                Console.WriteLine("Login: " + reader["login"]);
                Console.WriteLine($"Zatrudniony {reader["hire_date"]} na stanowisku {reader["role_name"]}");
            }

            Console.WriteLine("Nacisnij dowolny przycisk aby wrocic do menu");
            Console.Read();
            Main(null);
        }
        private static void DeleteWorker(MySqlConnection conn)
        {
            Console.Clear();
            string query = "SELECT workers.id_worker,workers.name,workers.surname,workers.id_role,role.role_name FROM workers INNER JOIN role ON workers.id_role = role.id_role";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.Write(
                    $"{reader["id_worker"]}. {reader["name"]} {reader["surname"]} / {reader["role_name"]} \n");
            }

            Console.WriteLine("Podaj ID pracownika do usunięcia: ");
            int id = Convert.ToInt16(Console.ReadLine());
            query = $"DELETE FROM workers WHERE id_worker = {id}";
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Pracownik usunięty pomyślnie!");

            Console.WriteLine("Nacisnij dowolny przycisk aby wrocic do menu");
            Console.Read();
            Main(null);
        }


        /************************************** 
         * nazwa funkcji:        AddWorker
         * parametry wejściowe: conn (połączenie z bazą danych)
         * wartość zwracana:    Funkcja dodaje pracownika do tabeli i generuje hasło
         * autor:                Bartosz Klimczak 3D
         * *************************************/
        private static void AddWorker(MySqlConnection conn)
        {
            Console.Clear();
            Console.Write("Podaj imie: ");
            string name = Console.ReadLine();
            Console.Write("Podaj nazwisko: ");
            string surname = Console.ReadLine();
            Console.Write("Podaj login: ");
            string login = Console.ReadLine();
            string password = Guid.NewGuid().ToString("d").Substring(1, 8);
            Console.Write($"Wygenerowane hasło dla pracownika: {password}");
            Console.WriteLine("\nPodaj stanowisko: \n1.Administrator\n2.Rekruter\n3.Programista\n4.H4");
            string position = Console.ReadLine();
            Console.WriteLine("Podaj wiek pracownika: ");
            int age = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Podaj date zatrudnienia (np. 2024-05-23): ");
            DateTime hire_date = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", null);
            string query = $"INSERT INTO workers (name, surname, login, password, id_role, age, hire_date) VALUES ('{name}', '{surname}', '{login}', '{password}', '{position}', {age}, '{hire_date.ToString("yyyy-MM-dd")}')";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Pracownik:\n " + name + " " + surname + " \n na został dodany pomyślnie!");
            Console.WriteLine("Naciśnij dowolny przycisk aby wrócic do menu...");
            Console.Read();
            conn.Close();
            Main(null);
        }
    }
}