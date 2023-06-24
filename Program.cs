// This is a simple practice program created to simulate using an Automated Teller Machine or ATM

Console.WriteLine("Welcome to MoneyGiver Bank.");
Console.WriteLine("How can we help you today?");
Console.WriteLine("-------------OPTIONS-----------");

string[] mainmenu = { "Withdraw Cash", "Deposit Cash", "Check Balance","Cancel"};


for (int ctr = 0; ctr < mainmenu.Length; ctr++)
{
    Console.Write((ctr+1) + " ");
    Console.WriteLine(mainmenu[ctr]);
}

int userOption = -1;

while (userOption == -1)
{
    if (int.TryParse(Console.ReadLine(), out userOption))
    {
        userOption = userOption - 1;
        bool isPinValid;
        switch (userOption)
        {
            case 0:
                Console.WriteLine("You chose {0}", mainmenu[userOption]);
                Console.WriteLine("----WITHDRAW CASH----");
                
                PinCheck(out isPinValid);
                if (isPinValid == true)
                {
                    NameCheck();
                }
                else { 
                    PinCheck(out isPinValid); 
                }
                break;

            case 1:
                Console.WriteLine("You chose {0}", mainmenu[userOption]);
                Console.WriteLine("----DEPOSIT CASH----");
                PinCheck(out isPinValid);
                if (isPinValid == true)
                {
                    deposit_amount();
                }
                break;
            case 2:
                Console.WriteLine("You chose {0}", mainmenu[userOption]);
                PinCheck(out isPinValid);
                if (isPinValid == true)
                {
                    Console.WriteLine("Your account currently has 3,000 dollars.");
                }

                break;
            case 3:
                Console.WriteLine("You chose {0}", mainmenu[userOption]);
                int closing = 3;
                while (closing > 0)
                {
                    Console.WriteLine("The program will close in {0}.", closing);
                    closing--;
                }
                break;
            default:
                Console.WriteLine("Please provide a valid input.");
                break;
        };
    }
    else
    {
        Console.WriteLine("Please provide a valid number.");
        userOption = -1;
    }
}

static void PinCheck(out bool pin_validity) {
    Console.WriteLine("What is your PIN?");
    Console.WriteLine("Note: The PIN is 1234");

    string userPin = Console.ReadLine();

    if (userPin == "1234")
    {
        Console.WriteLine("Authenticating PIN");
        Console.WriteLine("PIN authenticated");
        bool isPinValid = true;
        pin_validity = isPinValid;
    }
    else
    {
        Console.WriteLine("Authenticating PIN");
        Console.WriteLine("PIN is incorrect.");
        bool isPinValid = false;
        pin_validity = isPinValid;
    }
}

static void NameCheck()
{
    Console.WriteLine("How much do you want to withdraw?");
    int amount;
    if (int.TryParse(Console.ReadLine(),out amount))
    {
        checkBank(amount);
        Console.WriteLine($"You are withdrawing {amount} dollars?");
        Console.WriteLine("Please input either Yes or No.");
        string withdraw_option = Console.ReadLine();
        withdraw_option = withdraw_option.ToUpper();

        if (withdraw_option == "YES"){
            Console.WriteLine("Confirming decision.");
            Console.WriteLine("Please wait as we process your transaction.");
            Console.WriteLine("Transaction complete.");
            Console.WriteLine("Thank you for your business!");
        }
        else if (withdraw_option == "NO")
        {
            Console.WriteLine("You have cancelled your transaction.");
            Console.WriteLine("Thank you for your business!");
        }
        else
        {
            Console.WriteLine("Please provide a valid answer.");
            NameCheck();
        }
    }
    else
    {
        Console.WriteLine("You have provided an invalid amount.");
        NameCheck();
    }
}

static void deposit_amount()
{
    Console.WriteLine("How much do you want to deposit?");
    int amount;
    if (int.TryParse(Console.ReadLine(), out amount))
    {
        Console.WriteLine($"You want to deposit {amount} dollars?");
        Console.WriteLine("Please input either Yes or No.");
        string withdraw_option = Console.ReadLine();
        withdraw_option = withdraw_option.ToUpper();

        if (withdraw_option == "YES")
        {
            Console.WriteLine("Confirming decision.");
            deposited();
        }
        else if (withdraw_option == "NO")
        {
            Console.WriteLine("You have cancelled your transaction.");
            Console.WriteLine("Thank you for your business!");
        }
        else
        {
            Console.WriteLine("Please provide a valid answer.");
            deposit_amount();
        }
    }
    else
    {
        Console.WriteLine("You have provided an invalid amount.");
        deposit_amount();
    }
}

static void checkBank(int withdrawal_amount)
{
    if (withdrawal_amount > 3000)
    {
        Console.WriteLine("Checking your account.");
        Console.WriteLine("Apologies but you have insufficience funds in your account.");
        NameCheck();
    }
    else
    {
        Console.WriteLine("Checking your account.");
    }
}

static void deposited()
{
    Console.WriteLine("Please insert your money into the cash slot.");
    Console.WriteLine("Have you deposited your money into the cash slot?");
    string deposit_option = Console.ReadLine();
    deposit_option = deposit_option.ToUpper();
    if (deposit_option == "YES")
    {
        Console.WriteLine("Confirming amount. Please wait.");
        Console.WriteLine("Transaction completed.");
        Console.WriteLine("Thank you for your business!");
    }
    else
    {
        deposited();
    }
}