using System.Text;
Random random = new Random();
int num;

string[,] quiz = new string[10, 7] {
    { "Hansi meyve deyil?","a)",null,"b)",null,"c)",null },
    { "Dunyanin en uzun cayi hansidir?","a)",null,"b)",null,"c)",null },
    { "Gunes sistemindeki en boyuk planet hansi planetdir?", "a)", null, "b)", null, "c)",null },
    { "Hansi heyvan uca bilmez?", "a)", null, "b)", null, "c)", null },
    { "Hansi esas reng deyil?", "a)", null, "b)", null, "c)", null },
    { "Cenubi Amerika qitesinde hansi olke yerlesmir?", "a)", null, "b)", null, "c)", null },
    { "Hansi element deyil?", "a)", null, "b)", null, "c)", null },
    { "Hansi dunyanın en hundur dagidir?", "a)", null, "b)", null, "c)",null },
    { "Turkiyenin paytaxti hansidir?", "a)", null, "b)",null, "c)", null },
    { "Azerbaycanin paytaxti hansidir?", "a)", null, "b)",null, "c)", null }

};
string[,] quiz_variants = new string[10, 3] {
    { "alma","banan","pomidor" },
    { "Nil cayi","Amazon cayi","Yantszi cayi" },
    { "Mars","Yupiter", "Venera" },
    { "Qartal", "Yarasa", "Fil" },
    { "Qirmizi", "Sari", "Benovseyi" },
    { "Braziliya","Argentina", "Turkiye" },
    {  "Demir", "Mis","Almaz" },
    {  "Everest", "Tur", "Bazarduzu" },
    {  "Istanbul",  "Izmir", "Ankara" },
    {  "Baki","Quba", "Sumqayit" }
};
string[] correct_variant = new string[10] {
    "pomidor",
    "Nil cayi",
    "Yupiter",
    "Fil",
    "Benovseyi",
    "Turkiye",
    "Almaz",
    "Everest",
    "Ankara",
    "Baki"
};

#region Shuffle_rows
string[] str = new string[10];
for (int i = 0; i < 10; i++)
{
    str[i] = (i + 1).ToString();
}
string[] str_shuffle = new string[10];
int plus = 0;
do
{
    num = random.Next(0, 10);
    for (int j = 0; j < 10; j++)
    {
        if (num.ToString() == str_shuffle[j])
        {
            break;
        }
        if (j == 9)
        {
            str_shuffle[plus++] = num.ToString();
        }
    }
} while (str_shuffle[9] == null);

int[] int_shuffle = new int[10];
for (int i = 0; i < 10; i++)
{
    int_shuffle[i] = Int32.Parse(str_shuffle[i]);
}
#endregion

plus = 0;
int point = 0;
do
{
    #region Shuffle

    int j = int_shuffle[plus++];
    num = random.Next(3);

    string[] cannot_rand = new string[3];
    cannot_rand[0] = num.ToString(); ;

    quiz[j, 2] = quiz_variants[j, num];

    while (true)
    {
        num = random.Next(3);
        if (cannot_rand[0] != num.ToString())
        {
            break;
        }
    }
    cannot_rand[1] = num.ToString();
    quiz[j, 4] = quiz_variants[j, num];

    for (int i = 0; i < 3; i++)
    {
        if (i.ToString() != cannot_rand[0] && i.ToString() != cannot_rand[1])
        {
            quiz[j, 6] = quiz_variants[j, i];
            cannot_rand[2] = i.ToString();
        }
    }
    #endregion

    int select = 1;
    int choosed = 0;
    bool after = true;
    do
    {
        Console.WriteLine(quiz[j, 0]);
        switch (select)
        {
            case 1:
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(quiz[j, 1]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(quiz[j, 2]);
                choosed = 2;
                for (int i = 3; i < 7; i++)
                {
                    if (i == 3 || i == 5)
                    {
                        Console.Write(quiz[j, i]);
                    }
                    else
                    {
                        Console.WriteLine(quiz[j, i]);
                    }
                }
                break;

            case 2:
                for (int i = 1; i < 7; i++)
                {
                    if (i == 3)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(quiz[j, 3]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(quiz[j, 4]);
                        choosed = 4;
                        i++;
                    }
                    else if (i == 1 || i == 5)
                    {
                        Console.Write(quiz[j, i]);
                    }
                    else
                    {
                        Console.WriteLine(quiz[j, i]);
                    }
                }
                break;

            case 3:
                for (int i = 1; i < 7; i++)
                {
                    if (i == 5)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(quiz[j, 5]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(quiz[j, 6]);
                        choosed = 6;
                        i++;
                    }
                    else if (i == 1 || i == 3)
                    {
                        Console.Write(quiz[j, i]);
                    }
                    else
                    {
                        Console.WriteLine(quiz[j, i]);
                    }
                }
                break;

            default:
                break;
        }

        ConsoleKeyInfo info;
        while (true)
        {
            info = Console.ReadKey();
            if (info.Key == ConsoleKey.UpArrow || info.Key == ConsoleKey.DownArrow || info.Key == ConsoleKey.Enter)
            {
                break;
            }
        }


        if (info.Key == ConsoleKey.UpArrow)
        {
            Console.Clear();
            if (select == 1)
            {
                select = 3;
            }
            else
            {
                select--;
            }
        }
        else if (info.Key == ConsoleKey.DownArrow)
        {
            Console.Clear();
            if (select == 3)
            {
                select = 1;
            }
            else
            {
                select++;
            }
        }
        else if (info.Key == ConsoleKey.Enter)
        {
            if (choosed == 2) //CHOOSED A VARIANT
            {
                if (quiz[j, choosed] == correct_variant[j])// A TRUE
                {
                    Console.Clear();
                    Console.WriteLine(quiz[j, 0]);
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write(quiz[j, 1]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(quiz[j, 2]);

                    for (int i = 3; i < 7; i++)
                    {
                        if (i == 3 || i == 5)
                        {
                            Console.Write(quiz[j, i]);
                        }
                        else
                        {
                            Console.WriteLine(quiz[j, i]);
                        }
                    }
                    point += 10;
                    Thread.Sleep(1000);
                }
                else if (quiz[j, choosed + 2] == correct_variant[j])//A CHOOSED BUT B TRUE
                {
                    num = 0;
                    Console.Clear();
                    while (true)
                    {
                        Console.WriteLine(quiz[j, 0]);
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.Write(quiz[j, 1]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(quiz[j, 2]);

                        for (int i = 3; i < 7; i++)
                        {
                            if (i == choosed + 1)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                Console.Write(quiz[j, i]);
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (i == 5)
                            {
                                Console.Write(quiz[j, i]);
                            }
                            else
                            {
                                Console.WriteLine(quiz[j, i]);
                            }
                        }
                        Thread.Sleep(600);
                        Console.Clear();
                        Console.WriteLine(quiz[j, 0]);
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.Write(quiz[j, 1]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(quiz[j, 2]);

                        for (int i = 3; i < 7; i++)
                        {
                            if (i == 3 || i == 5)
                            {
                                Console.Write(quiz[j, i]);
                            }
                            else
                            {
                                Console.WriteLine(quiz[j, i]);
                            }
                        }
                        Thread.Sleep(600);
                        Console.Clear();
                        if (num == 3)
                        {
                            point -= 10;
                            break;
                        }
                        num++;
                    }
                }
                else if (quiz[j, choosed + 4] == correct_variant[j])//A CHOOSED BUT C TRUE
                {
                    num = 0;
                    Console.Clear();
                    while (true)
                    {
                        Console.WriteLine(quiz[j, 0]);
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.Write(quiz[j, 1]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(quiz[j, 2]);

                        for (int i = 3; i < 7; i++)
                        {
                            if (i == choosed + 3)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                Console.Write(quiz[j, i]);
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (i == 3 || i == 5)
                            {
                                Console.Write(quiz[j, i]);
                            }
                            else
                            {
                                Console.WriteLine(quiz[j, i]);
                            }
                        }
                        Thread.Sleep(600);
                        Console.Clear();
                        Console.WriteLine(quiz[j, 0]);
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.Write(quiz[j, 1]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(quiz[j, 2]);

                        for (int i = 3; i < 7; i++)
                        {
                            if (i == 3 || i == 5)
                            {
                                Console.Write(quiz[j, i]);
                            }
                            else
                            {
                                Console.WriteLine(quiz[j, i]);
                            }
                        }
                        Thread.Sleep(600);
                        Console.Clear();
                        if (num == 3)
                        {
                            point -= 10;
                            break;
                        }
                        num++;
                    }
                }
            }
            else if (choosed == 4) //CHOOSED B VARIANT
            {
                if (quiz[j, choosed] == correct_variant[j])// B TRUE
                {
                    Console.Clear();
                    Console.WriteLine(quiz[j, 0]);

                    for (int i = 1; i < 7; i++)
                    {
                        if (i == 1 || i == 5)
                        {
                            Console.Write(quiz[j, i]);
                        }
                        else if (i == 3)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write(quiz[j, i]);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.WriteLine(quiz[j, i]);
                        }
                    }
                    point += 10;
                    Thread.Sleep(1000);
                }
                else if (quiz[j, choosed - 2] == correct_variant[j])//B CHOOSED BUT A TRUE
                {
                    num = 0;
                    Console.Clear();
                    while (true)
                    {
                        Console.WriteLine(quiz[j, 0]);
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.Write(quiz[j, 1]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(quiz[j, 2]);

                        for (int i = 3; i < 7; i++)
                        {
                            if (i == 3)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.Write(quiz[j, i]);
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (i == 5)
                            {
                                Console.Write(quiz[j, i]);
                            }
                            else
                            {
                                Console.WriteLine(quiz[j, i]);
                            }
                        }
                        Thread.Sleep(600);
                        Console.Clear();
                        Console.WriteLine(quiz[j, 0]);

                        for (int i = 1; i < 7; i++)
                        {
                            if (i == 3)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.Write(quiz[j, i]);
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (i == 1 || i == 5)
                            {
                                Console.Write(quiz[j, i]);
                            }
                            else
                            {
                                Console.WriteLine(quiz[j, i]);
                            }
                        }
                        Thread.Sleep(600);
                        Console.Clear();
                        if (num == 3)
                        {
                            point -= 10;
                            break;
                        }
                        num++;
                    }
                }
                else if (quiz[j, choosed + 2] == correct_variant[j])//B CHOOSED BUT C TRUE
                {
                    num = 0;
                    Console.Clear();
                    while (true)
                    {
                        Console.WriteLine(quiz[j, 0]);

                        for (int i = 1; i < 7; i++)
                        {
                            if (i == 3)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.Write(quiz[j, i]);
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (i == 1)
                            {
                                Console.Write(quiz[j, i]);
                            }
                            else if (i == 5)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                Console.Write(quiz[j, i]);
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Console.WriteLine(quiz[j, i]);
                            }
                        }
                        Thread.Sleep(600);
                        Console.Clear();
                        Console.WriteLine(quiz[j, 0]);

                        for (int i = 1; i < 7; i++)
                        {
                            if (i == 3)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.Write(quiz[j, i]);
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (i == 1 || i == 5)
                            {
                                Console.Write(quiz[j, i]);
                            }
                            else
                            {
                                Console.WriteLine(quiz[j, i]);
                            }
                        }
                        Thread.Sleep(600);
                        Console.Clear();
                        if (num == 3)
                        {
                            point -= 10;
                            break;
                        }
                        num++;
                    }
                }
            }
            else if (choosed == 6) //CHOOSED C VARIANT
            {
                if (quiz[j, choosed] == correct_variant[j]) // C TRUE
                {
                    Console.Clear();
                    Console.WriteLine(quiz[j, 0]);
                    for (int i = 1; i < 7; i++)
                    {

                        if (i == 1 || i == 3)
                        {
                            Console.Write(quiz[j, i]);
                        }
                        else if (i == 5)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write(quiz[j, i]);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.WriteLine(quiz[j, i]);
                        }
                    }
                    point += 10;
                    Thread.Sleep(1000);
                }
                else if (quiz[j, choosed - 4] == correct_variant[j])// CHOOSED C BUT A TRUE
                {
                    num = 0;
                    Console.Clear();
                    while (true)
                    {
                        Console.WriteLine(quiz[j, 0]);
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.Write(quiz[j, 1]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(quiz[j, 2]);

                        for (int i = 3; i < 7; i++)
                        {
                            if (i == 3)
                            {
                                Console.Write(quiz[j, i]);
                            }
                            else if (i == 5)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.Write(quiz[j, i]);
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Console.WriteLine(quiz[j, i]);
                            }
                        }
                        Thread.Sleep(600);
                        Console.Clear();
                        Console.WriteLine(quiz[j, 0]);

                        for (int i = 1; i < 7; i++)
                        {
                            if (i == 1 || i == 3)
                            {
                                Console.Write(quiz[j, i]);
                            }
                            else if (i == 5)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.Write(quiz[j, i]);
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Console.WriteLine(quiz[j, i]);
                            }
                        }
                        Thread.Sleep(600);
                        Console.Clear();
                        if (num == 3)
                        {
                            point -= 10;
                            break;
                        }
                        num++;
                    }
                }
                else if (quiz[j, choosed - 2] == correct_variant[j])// CHOOSED C BUT B TRUE
                {
                    num = 0;
                    Console.Clear();
                    while (true)
                    {
                        Console.WriteLine(quiz[j, 0]);

                        for (int i = 1; i < 7; i++)
                        {
                            if (i == 1)
                            {
                                Console.Write(quiz[j, i]);
                            }
                            else if (i == 3)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                Console.Write(quiz[j, i]);
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (i == 5)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.Write(quiz[j, i]);
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Console.WriteLine(quiz[j, i]);
                            }
                        }
                        Thread.Sleep(600);
                        Console.Clear();
                        Console.WriteLine(quiz[j, 0]);

                        for (int i = 1; i < 7; i++)
                        {
                            if (i == 1 || i == 3)
                            {
                                Console.Write(quiz[j, i]);
                            }
                            else if (i == 5)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.Write(quiz[j, i]);
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Console.WriteLine(quiz[j, i]);
                            }
                        }
                        Thread.Sleep(600);
                        Console.Clear();
                        if (num == 3)
                        {
                            point -= 10;
                            break;
                        }
                        num++;
                    }
                }
            }
            after = false;
        }
        Console.Clear();
    } while (after);


} while (plus != 10);

Console.WriteLine($"Your point: {point}");























