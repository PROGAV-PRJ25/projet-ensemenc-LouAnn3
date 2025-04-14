using System;

class Program
{
    static char[,] grille;
    static string[,] etatPlante;

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Combien de grilles 3x3 veux-tu afficher (carré NxN) ? ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Entrée invalide.");
            return;
        }

        int total = n * 3; // Taille totale de la grille en cases
        grille = new char[total + 1, total + 1];
        etatPlante = new string[total + 1, total + 1];

        // Initialiser la grille
        for (int i = 0; i <= total; i++)
        {
            for (int j = 0; j <= total; j++)
            {
                if (i % 3 == 0)
                    grille[i, j] = '|';
                else
                    grille[i, j] = ' ';
            }
        }

        // Initialiser les plantes
        for (int i = 1; i <= total; i++)
        {
            for (int j = 1; j <= total; j++)
            {
                if (i % 3 != 0 && j % 3 != 0)
                    etatPlante[i, j] = " ";  // Vide au départ
            }
        }

        // Affichage initial
        AfficherGrille();

        bool continuer = true;
        while (continuer)
        {
            Console.WriteLine("\nQue veux-tu faire ?");
            Console.WriteLine("1 - Planter (p)");
            Console.WriteLine("2 - Arroser (a)");
            Console.WriteLine("3 - Récolter (r)");
            Console.WriteLine("4 - Quitter (q)");
            Console.Write("Choisis une action : ");
            char action = Char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();

            switch (action)
            {
                case 'p':
                    ChoisirCase("planter");
                    break;
                case 'a':
                    ChoisirCase("arroser");
                    break;
                case 'r':
                    ChoisirCase("récolter");
                    break;
                case 'q':
                    continuer = false;
                    break;
                default:
                    Console.WriteLine("Action non valide.");
                    break;
            }

            AfficherGrille();
        }
    }

    static void AfficherGrille()
    {
        int total = grille.GetLength(0) - 1;
        for (int row = 0; row <= total; row++)
        {
            for (int col = 0; col <= total; col++)
            {
                if (row % 3 == 0)
                {
                    if (col % 3 == 0)
                        Console.Write(" ");
                    else
                        Console.Write(" ");
                }
                else
                {
                    if (col % 3 == 0)
                        Console.Write("|");
                    else
                    {
                        string contenu = etatPlante[row, col];

                        if (contenu == ".")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" . ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write($" {contenu} ");
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }

    static void ChoisirCase(string action)
    {
        Console.Write("Choisis une ligne (1 à N) : ");
        int ligne = int.Parse(Console.ReadLine());
        Console.Write("Choisis une colonne (1 à N) : ");
        int colonne = int.Parse(Console.ReadLine());

        if (ligne < 1 || colonne < 1 || ligne >= grille.GetLength(0) || colonne >= grille.GetLength(1))
        {
            Console.WriteLine("Case invalide.");
            return;
        }

        switch (action)
        {
            case "planter":
                if (etatPlante[ligne, colonne] == " ")
                {
                    etatPlante[ligne, colonne] = ".";  // Plante plantée
                    Console.WriteLine("Tu as planté une plante !");
                }
                else
                {
                    Console.WriteLine("Il y a déjà une plante ici.");
                }
                break;

            case "arroser":
                if (etatPlante[ligne, colonne] == ".")
                {
                    etatPlante[ligne, colonne] = "🌿";  // Plante arrosée
                    Console.WriteLine("Tu as arrosé la plante !");
                }
                else
                {
                    Console.WriteLine("Il n'y a pas de plante à arroser ici.");
                }
                break;

            case "récolter":
                if (etatPlante[ligne, colonne] == "🌿")
                {
                    etatPlante[ligne, colonne] = "🌳";  // Récolte
                    Console.WriteLine("Tu as récolté la plante !");
                }
                else
                {
                    Console.WriteLine("Il n'y a pas de plante à récolter ici.");
                }
                break;

            default:
                Console.WriteLine("Action non reconnue.");
                break;
        }
    }
}
