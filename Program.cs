    using static System.Console; 
    namespace logIn
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                const int maxUsers = 5;
                string[] userNames = new string[maxUsers];
                string[] passwords = new string[maxUsers];
                int userCount = 0;

                while (true)
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                    WriteLine("Welcome to this program.");
                    WriteLine("[1] - Sign in.");
                    WriteLine("[2] - Log in.");
                    WriteLine("[3] - Exit.");

                    if ( Int32.TryParse(ReadLine(), out int input))
                    {
                        string userName = "";
                        string password = "";


                        if (input == 1)
                        {
                            if (userCount < maxUsers)
                            {
                                WriteLine("Enter a username you would like to use:");
                                userName = ReadLine()!;
                                if (IsUserNameTaken(userName, userNames, userCount))
                                {
                                    ForegroundColor = ConsoleColor.Red;
                                    WriteLine("Username is already taken. Please choose another.");
                                    ResetColor();
                                    Thread.Sleep(2000);
                                    continue;
                                }
                                WriteLine("Enter a password:");
                                password = ReadLine()!;
                                userNames[userCount] = userName;
                                passwords[userCount] = password;
                                userCount++;
                                ForegroundColor = ConsoleColor.Green;
                                WriteLine("Account successfully created.");
                            }
                            else 
                            {
                                ForegroundColor = ConsoleColor.Red;
                                WriteLine("Maximul amount of users.");
                                ResetColor();
                                Thread.Sleep(1000);
                            }
                        }
                        else if (input == 2)
                            {
                                WriteLine("Enter your username:");
                                string loginUserName = ReadLine()!;
                                WriteLine("Enter your password:");
                                string loginPassword = ReadLine()!;

                                if (TryLogin(loginUserName, loginPassword, userNames, passwords, userCount))
                                {
                                    ForegroundColor = ConsoleColor.Green;
                                    WriteLine("Login successful!");
                                    Thread.Sleep(1000);
                                    ResetColor();
                                }
                                else
                                {
                                    ForegroundColor = ConsoleColor.Red;
                                    WriteLine("Login failed. Incorrect username or password.");
                                    ResetColor();
                                    Thread.Sleep(2000);
                                }
                            }
                        else if (input == 3)
                        {
                            ForegroundColor = ConsoleColor.Green;
                            WriteLine("Shutting down...");
                            ResetColor();
                            Thread.Sleep(1000);
                            return;
                        }
                        else
                        {
                            ForegroundColor = ConsoleColor.Red;
                            WriteLine("Wrong input.");
                            ResetColor();
                            Thread.Sleep(2000);
                        }
                    }
                else
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Wrong input.");
                    ResetColor();
                    Thread.Sleep(2000);
                }

            }
                static bool IsUserNameTaken(string userName, string[] existingUserNames, int count)
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (existingUserNames[i] == userName)
                        {
                            return true; 
                        }
                    }
                    return false; 
                }

                static bool TryLogin(string userName, string password, string[] userNames, string[] passwords, int count)
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (userNames[i] == userName && passwords[i] == password)
                        {
                            return true; 
                        }
                    }
                    return false; 
                }

            }

        }
    }
