/* 
 * Student: Chau Trinh
 * Class: ITSE 1430
 * Lab 1: Pizza Creator
 * Date: 14 Sep 2018
 */

using System;

namespace PizzaCreator
{
    class Program
    {
        static void Main( string[] args )
        {
            bool notQuit;
            do
            {
                notQuit = DisplayMenu();
            }
            while (notQuit);

        }

        private static bool DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("\n\tMAIN MENU\n");
                Console.WriteLine("\t1.New Order");
                Console.WriteLine("\t2.Mofidy Order");
                Console.WriteLine("\t3.Display Order");
                Console.WriteLine("\t4.Quit\n");

                Console.Write("Please choose 1, 2, 3 or 4 for your option below: ");
                string menu = Console.ReadLine();

                switch (menu[0])
                {
                    case '1':
                    NewOrder();
                    return true;

                    case '2':
                    ModifyOrder();
                    return true;

                    case '3':
                    DisplayOrder();
                    return true;

                    case '4':
                    return false;

                    default:
                    Console.WriteLine("You did not choose any available option.");
                    Console.WriteLine("Please enter 1, 2, 3, or 4 from the menu.");
                    break;
                }
            }
        }

        private static void DisplayOrder()
        {
            Console.WriteLine("\n\tYour Order");
            Console.WriteLine($"YOUR CART: {totalPrice:C}");

            if (String.IsNullOrEmpty(size))
            {
                Console.WriteLine("You have not created your order, yet");
                Console.WriteLine("Please choose 1 to create a new order!");
            } else
            {

                Console.WriteLine($"{size.PadRight(20)} {sizePrice:C}");

                if (deliveryPrice == 0.00)
                    Console.WriteLine($"{delivery}");
                else
                    Console.WriteLine($"{delivery.PadRight(20)} {deliveryPrice:C}");

                if (meatPrice != 0.00)
                {
                    Console.WriteLine("Meats");
                    if (!String.IsNullOrEmpty(bacon))
                    {
                        Console.WriteLine($"   {bacon.PadRight(17)} {priceBacon:C}");
                    }
                    if (!String.IsNullOrEmpty(ham))
                    {
                        Console.WriteLine($"   {ham.PadRight(17)} {priceHam:C}");
                    }
                    if (!String.IsNullOrEmpty(pepperoni))
                    {
                        Console.WriteLine($"   {pepperoni.PadRight(17)} {pricePepperoni:C}");
                    }
                    if (!String.IsNullOrEmpty(sausage))
                    {
                        Console.WriteLine($"   {sausage.PadRight(17)} {priceSausage:C}");
                    }
                }

                if (vegetablesPrice != 0.00)
                {
                    Console.WriteLine("Vegetables");
                    if (!String.IsNullOrEmpty(blackOlives))
                    {
                        Console.WriteLine($"   {blackOlives.PadRight(17)} {priceOlives:C}");
                    }
                    if (!String.IsNullOrEmpty(mushrooms))
                    {
                        Console.WriteLine($"   {mushrooms.PadRight(17)} {priceMushrooms:C}");
                    }
                    if (!String.IsNullOrEmpty(onions))
                    {
                        Console.WriteLine($"   {onions.PadRight(17)} {priceOnions:C}");
                    }
                    if (!String.IsNullOrEmpty(peppers))
                    {
                        Console.WriteLine($"   {peppers.PadRight(17)} {pricePeppers:C}");
                    }
                }
                if (cheesePrice == 0.00)
                {
                    Console.WriteLine($"{cheese}");
                } else
                {
                    Console.WriteLine($"{cheese.PadRight(20)} {cheesePrice:C}");
                }

                Console.WriteLine("Sauce");
                if (sauce == "Traditional")
                    Console.WriteLine($"   {sauce}");
                else
                    Console.WriteLine($"   {sauce.PadRight(17)} {saucePrice:C}");

                Console.WriteLine("----------------------------");
                Console.WriteLine($"Total                {totalPrice:C}");

            }
        }

        private static void ModifyOrder()
        {
            if (String.IsNullOrEmpty(size))
            {
                Console.WriteLine("You have not created your order, yet");
                Console.WriteLine("Please choose 1 to create a new order!");
            } else
            {
                DisplayOrder();
                //Modify Size
                if (ConfirmSize("Do you want to modify the size?"))
                {
                    Console.WriteLine("\nSize");
                    Console.WriteLine("S. Small\t$5.00");
                    Console.WriteLine("M. Medium\t$6.25");
                    Console.WriteLine("L. Large\t$8.75");

                    do
                    {
                        Console.Write("New Size: ");
                        string newSize = Console.ReadLine();
                        size = newSize;
                        switch (size[0])
                        {
                            case 's':
                            case 'S':
                            size = "Small Pizza";
                            sizePrice = 5.00;
                            break;

                            case 'm':
                            case 'M':
                            sizePrice = 6.25;
                            size = "Medium Pizza";
                            break;

                            case 'l':
                            case 'L':
                            sizePrice = 8.75;
                            size = "Large Pizza";
                            break;

                            default:
                            Console.WriteLine("Please choose the valid size");
                            break;
                        }
                    }
                    while (sizePrice != 5.00 && sizePrice != 6.25 && sizePrice != 8.75);
                }

                //Modify Meat
                if (ConfirmMeat("Do you want to modify the meat?"))
                {
                    Console.WriteLine("\nMeats");
                    Console.WriteLine("Each option is $0.75 extra");

                    do
                    {
                        Console.WriteLine("Press any key if you want each option, Enter if you do not want.");
                        Console.Write("Bacon: ");
                        bacon = Console.ReadLine();
                        Console.Write("Ham: ");
                        ham = Console.ReadLine();
                        Console.Write("Pepperoni: ");
                        pepperoni = Console.ReadLine();
                        Console.Write("Sausage: ");
                        sausage = Console.ReadLine();
                    }
                    while (ReselectMeat() == true);

                    if (String.IsNullOrEmpty(bacon))
                        priceBacon = 0.00;
                    else
                    {
                        priceBacon = 0.75;
                        bacon = "Bacon";
                    }

                    if (String.IsNullOrEmpty(ham))
                        priceHam = 0.00;
                    else
                    {
                        priceHam = 0.75;
                        ham = "Ham";
                    }

                    if (String.IsNullOrEmpty(pepperoni))
                        pricePepperoni = 0.00;
                    else
                    {
                        pricePepperoni = 0.75;
                        pepperoni = "Pepperoni";
                    }

                    if (String.IsNullOrEmpty(sausage))
                        priceSausage = 0.00;
                    else
                    {
                        priceSausage = 0.75;
                        sausage = "Sausage";
                    }

                    meatPrice = priceBacon + priceHam + pricePepperoni + priceSausage;
                }

                //Modify Vegetables
                if (ConfirmVegetables("Do you want to modify the vegetables?"))
                {
                    Console.WriteLine("\nVegetables");
                    Console.WriteLine("Each option is $0.50 extra");

                    do
                    {
                        Console.WriteLine("Press any key if you want each option, Enter if you do not want.");
                        Console.Write("Black Olives: ");
                        blackOlives = Console.ReadLine();
                        Console.Write("Mushrooms: ");
                        mushrooms = Console.ReadLine();
                        Console.Write("Onions: ");
                        onions = Console.ReadLine();
                        Console.Write("Peppers: ");
                        peppers = Console.ReadLine();
                    }
                    while (ReselectVegetables() == true);

                    if (String.IsNullOrEmpty(blackOlives))
                        priceOlives = 0.00;
                    else
                    {
                        priceOlives = 0.50;
                        blackOlives = "Black Olives";
                    }

                    if (String.IsNullOrEmpty(mushrooms))
                        priceMushrooms = 0.00;
                    else
                    {
                        priceMushrooms = 0.50;
                        mushrooms = "Mushrooms";
                    }

                    if (String.IsNullOrEmpty(peppers))
                        pricePeppers = 0.00;
                    else
                    {
                        pricePeppers = 0.50;
                        peppers = "Peppers";
                    }

                    if (String.IsNullOrEmpty(onions))
                        priceOnions = 0.00;
                    else
                    {
                        priceOnions = 0.50;
                        onions = "Onions";
                    }

                    vegetablesPrice = priceOlives + priceMushrooms + priceOnions + pricePeppers;
                }

                //Modify Sauce
                if (ConfirmSauce("Do you want to modify the sauce?"))
                {
                    Console.WriteLine("\nSauce");
                    Console.WriteLine("T. Traditional\t$0.00");
                    Console.WriteLine("G. Garlic\t$1.00");
                    Console.WriteLine("0. Oregano\t$1.00");

                    do
                    {
                        Console.Write("New Sauce: ");
                        string newSauce = Console.ReadLine();
                        sauce = newSauce;
                        switch (sauce[0])
                        {
                            case 'T':
                            case 't':
                            sauce = "Traditional";
                            saucePrice = 0.00;
                            break;

                            case 'g':
                            case 'G':
                            sauce = "Garlic";
                            saucePrice = 1.00;
                            break;

                            case 'o':
                            case 'O':
                            sauce = "Oregano";
                            saucePrice = 1.00;
                            break;

                            default:
                            Console.WriteLine("Please choose the valid sauce");
                            break;
                        }
                    }
                    while (sauce != "Traditional" && sauce != "Garlic" && sauce != "Oregano");
                }

                //Modify Cheese 
                if (ConfirmCheese("Do you want to modify the cheese?"))
                {
                    Console.WriteLine("\nChesse");
                    Console.WriteLine("R. Regular\t$0.00");
                    Console.WriteLine("E. Extra\t$1.25");

                    do
                    {
                        Console.Write("New Cheese: ");
                        string newCheese = Console.ReadLine();
                        cheese = newCheese;
                        switch (cheese[0])
                        {
                            case 'R':
                            case 'r':
                            cheese = "Regular Cheese";
                            cheesePrice = 0.00;
                            break;

                            case 'e':
                            case 'E':
                            cheese = "Extra Cheese";
                            cheesePrice = 1.25;
                            break;

                            default:
                            Console.WriteLine("Please choose the valid cheese");
                            break;
                        }
                    }
                    while (cheese != "Regular Cheese" && cheese != "Extra Cheese");
                }

                //Modify Delivery
                if (ConfirmDelivery("Do you want to modify the delivery?"))
                {
                    Console.WriteLine("\nDelivery Method");
                    Console.WriteLine("T. Take Out\t$0.00");
                    Console.WriteLine("D. Delivery\t$2.50");

                    do
                    {
                        Console.Write("New Delivery Method: ");
                        string newDelivery = Console.ReadLine();
                        delivery = newDelivery;
                        switch (delivery[0])
                        {
                            case 'T':
                            case 't':
                            deliveryPrice = 0.00;
                            delivery = "Take Out";
                            break;

                            case 'D':
                            case 'd':
                            deliveryPrice = 2.50;
                            delivery = "Delivery";
                            break;

                            default:
                            Console.WriteLine("Please choose the valid delivery method");
                            break;
                        }
                    }
                    while (delivery != "Take Out" && delivery != "Delivery");
                }

                totalPrice = sizePrice + meatPrice + vegetablesPrice + saucePrice + cheesePrice + deliveryPrice;
            }
        }

        private static bool ConfirmDelivery( string message )
        {
            Console.WriteLine($"{message} (Y/N)");
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 'Y':
                    case 'y':
                    return true;

                    case 'N':
                    case 'n':
                    return false;
                }
            }
            while (true);
        }

        private static bool ConfirmCheese( string message )
        {
            Console.WriteLine($"{message} (Y/N)");
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 'Y':
                    case 'y':
                    return true;

                    case 'N':
                    case 'n':
                    return false;
                }
            }
            while (true);
        }

        private static bool ConfirmSauce( string message )
        {
            Console.WriteLine($"{message} (Y/N)");
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 'Y':
                    case 'y':
                    return true;

                    case 'N':
                    case 'n':
                    return false;
                }
            }
            while (true);
        }

        private static bool ConfirmVegetables( string message )
        {
            Console.WriteLine($"{message} (Y/N)");
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 'Y':
                    case 'y':
                    return true;

                    case 'N':
                    case 'n':
                    return false;
                }
            }
            while (true);
        }

        private static bool ConfirmMeat( string message )
        {
            Console.WriteLine($"{message} (Y/N)");
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 'Y':
                    case 'y':
                    return true;

                    case 'N':
                    case 'n':
                    return false;
                }
            }
            while (true);
        }

        private static bool ConfirmSize( string message )
        {
            Console.WriteLine($"{message} (Y/N)");
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 'Y':
                    case 'y':
                    return true;

                    case 'N':
                    case 'n':
                    return false;
                }
            }
            while (true);
        }

        private static void NewOrder()
        {
            Console.WriteLine("\n\tNew Order\n");
            Console.WriteLine($"YOUR CART: {totalPrice:C}");

            //Choose the size
            Console.WriteLine("\nSize");
            Console.WriteLine("S. Small\t$5.00");
            Console.WriteLine("M. Medium\t$6.25");
            Console.WriteLine("L. Large\t$8.75");

            do
            {
                Console.Write("Size: ");
                size = Console.ReadLine();
                switch (size[0])
                {
                    case 's':
                    case 'S':
                    size = "Small Pizza";
                    sizePrice = 5.00;
                    break;

                    case 'm':
                    case 'M':
                    sizePrice = 6.25;
                    size = "Medium Pizza";
                    break;

                    case 'l':
                    case 'L':
                    sizePrice = 8.75;
                    size = "Large Pizza";
                    break;

                    default:
                    Console.WriteLine("Please choose the valid size");
                    break;
                }
            }
            while (sizePrice != 5.00 && sizePrice != 6.25 && sizePrice != 8.75);

            // Choose the meat
            Console.WriteLine("\nMeats");
            Console.WriteLine("Each option is $0.75 extra");

            do
            {
                Console.WriteLine("Press any key if you want each option, Enter if you do not want.");
                Console.Write("Bacon: ");
                bacon = Console.ReadLine();
                Console.Write("Ham: ");
                ham = Console.ReadLine();
                Console.Write("Pepperoni: ");
                pepperoni = Console.ReadLine();
                Console.Write("Sausage: ");
                sausage = Console.ReadLine();
            }
            while (ReselectMeat() == true);

            if (String.IsNullOrEmpty(bacon))
                priceBacon = 0.00;
            else
            {
                priceBacon = 0.75;
                bacon = "Bacon";
            }

            if (String.IsNullOrEmpty(ham))
                priceHam = 0.00;
            else
            {
                priceHam = 0.75;
                ham = "Ham";
            }

            if (String.IsNullOrEmpty(pepperoni))
                pricePepperoni = 0.00;
            else
            {
                pricePepperoni = 0.75;
                pepperoni = "Pepperoni";
            }

            if (String.IsNullOrEmpty(sausage))
                priceSausage = 0.00;
            else
            {
                priceSausage = 0.75;
                sausage = "Sausage";
            }

            meatPrice = priceBacon + priceHam + pricePepperoni + priceSausage;

            //Choose the vegetable
            Console.WriteLine("\nVegetables");
            Console.WriteLine("Each option is $0.50 extra");

            do
            {
                Console.WriteLine("Press any key if you want each option, Enter if you do not want.");
                Console.Write("Black Olives: ");
                blackOlives = Console.ReadLine();
                Console.Write("Mushrooms: ");
                mushrooms = Console.ReadLine();
                Console.Write("Onions: ");
                onions = Console.ReadLine();
                Console.Write("Peppers: ");
                peppers = Console.ReadLine();
            }
            while (ReselectVegetables() == true);

            if (String.IsNullOrEmpty(blackOlives))
                priceOlives = 0.00;
            else
            {
                priceOlives = 0.50;
                blackOlives = "Black Olives";
            }

            if (String.IsNullOrEmpty(mushrooms))
                priceMushrooms = 0.00;
            else
            {
                priceMushrooms = 0.50;
                mushrooms = "Mushrooms";
            }

            if (String.IsNullOrEmpty(peppers))
                pricePeppers = 0.00;
            else
            {
                pricePeppers = 0.50;
                peppers = "Peppers";
            }

            if (String.IsNullOrEmpty(onions))
                priceOnions = 0.00;
            else
            {
                priceOnions = 0.50;
                onions = "Onions";
            }

            vegetablesPrice = priceOlives + priceMushrooms + priceOnions + pricePeppers;

            //Choose the sauce
            Console.WriteLine("\nSauce");
            Console.WriteLine("T. Traditional\t$0.00");
            Console.WriteLine("G. Garlic\t$1.00");
            Console.WriteLine("0. Oregano\t$1.00");

            do
            {
                Console.Write("Sauce: ");
                sauce = Console.ReadLine();
                switch (sauce[0])
                {
                    case 'T':
                    case 't':
                    sauce = "Traditional";
                    saucePrice = 0.00;
                    break;

                    case 'g':
                    case 'G':
                    sauce = "Garlic";
                    saucePrice = 1.00;
                    break;

                    case 'o':
                    case 'O':
                    sauce = "Oregano";
                    saucePrice = 1.00;
                    break;

                    default:
                    Console.WriteLine("Please choose the valid sauce");
                    break;
                }
            }
            while (sauce != "Traditional" && sauce != "Garlic" && sauce != "Oregano");

            //Choose cheese
            Console.WriteLine("\nChesse");
            Console.WriteLine("R. Regular\t$0.00");
            Console.WriteLine("E. Extra\t$1.25");

            do
            {
                Console.Write("Cheese: ");
                cheese = Console.ReadLine();
                switch (cheese[0])
                {
                    case 'R':
                    case 'r':
                    cheese = "Regular Cheese";
                    cheesePrice = 0.00;
                    break;

                    case 'e':
                    case 'E':
                    cheese = "Extra Cheese";
                    cheesePrice = 1.25;
                    break;

                    default:
                    Console.WriteLine("Please choose the valid cheese");
                    break;
                }
            }
            while (cheese != "Regular Cheese" && cheese != "Extra Cheese");

            //Choose delivery method 
            Console.WriteLine("\nDelivery Method");
            Console.WriteLine("T. Take Out\t$0.00");
            Console.WriteLine("D. Delivery\t$2.50");

            do
            {
                Console.Write("Delivery Method: ");
                delivery = Console.ReadLine();
                switch (delivery[0])
                {
                    case 'T':
                    case 't':
                    deliveryPrice = 0.00;
                    delivery = "Take Out";
                    break;

                    case 'D':
                    case 'd':
                    deliveryPrice = 2.50;
                    delivery = "Delivery";
                    break;

                    default:
                    Console.WriteLine("Please choose the valid delivery method");
                    break;
                }
            }
            while (delivery != "Take Out" && delivery != "Delivery");

            totalPrice = sizePrice + meatPrice + vegetablesPrice + saucePrice + cheesePrice + deliveryPrice;

        }

        private static bool ReselectVegetables()
        {
            do
            {
                Console.WriteLine("Do you want to Reselect the vegetables option? Y/N");
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 'y':
                    case 'Y':
                    return true;

                    case 'n':
                    case 'N':
                    return false;
                }
            }
            while (true);
        }

        private static bool ReselectMeat()
        {
            do
            {
                Console.WriteLine("Do you want to Reselect the meat option? Y/N");
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 'y':
                    case 'Y':
                    return true;

                    case 'n':
                    case 'N':
                    return false;
                }
            }
            while (true);
        }

        static string size;
        static double sizePrice;
        static string sauce;
        static double saucePrice;
        static string cheese;
        static double cheesePrice;
        static string delivery;
        static double deliveryPrice;
        static double meatPrice;
        static string bacon, ham, pepperoni, sausage;
        static double priceBacon, priceHam, pricePepperoni, priceSausage;
        static string blackOlives, mushrooms, onions, peppers;
        static double vegetablesPrice;
        static double priceOlives, priceMushrooms, priceOnions, pricePeppers;
        static double totalPrice;

    }
}

