using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game configurations
    string[] level1passwords = {"hungergames","artemisfowl","percyjackson","harrypotter","secretseven"};
    string[] level2passwords = { "suits", "andhadhun", "murdermystery", "riverdale", "lovedeathrobot" };
    string[] level3passwords = { "osamabinladen", "dawoodibrahim", "donaldtrump", "mukeshambani", "allahuakbar"};
    string[] level4passwords = { "fdhf74ytfchfgc2", "jkmi6ru65e3csg", "hgd45w2456fjgvjvj", "87tbuhgcbest4sy", "65vehfdvutfvytrstresv76576" };


    //Game States
    const string menuhint = "You may type menu to return to main menu.";
    int level = 0;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        showMainMenu();
    }

    void showMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Enter 1 for MPSTME Library");
        Terminal.WriteLine("Enter 2 for Netflix");
        Terminal.WriteLine("Enter 3 for ISIS Terrorist System");
        Terminal.WriteLine("Enter 4 for Aakshu's MacBook Pro");
        Terminal.WriteLine("Enter your selection:");
    }
    // Update is called once per frame
    void Update()
    {
        //print(Random.Range(0, 5));
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            showMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);

        }
        else if (currentScreen == Screen.Password)
        {
            checkPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2" || input == "3" || input == "4");
        if (isValidLevel)
        {
            level = int.Parse(input);
            askForPassword();
        }
        else if (input == "007") //easter egg
        {
            Terminal.WriteLine("Welcome Mr. Bond, Please select your level");
        }
        else
        {
            Terminal.WriteLine("Please enter a valid level");
            Terminal.WriteLine(menuhint);
        }
    }

    void askForPassword()
    {
        Terminal.ClearScreen();
        setRandomPassword();
        Terminal.WriteLine("Enter Password, hint: " + password.Anagram());
        currentScreen = Screen.Password;
        Terminal.WriteLine(menuhint);
    }

    void setRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1passwords[Random.Range(0, level1passwords.Length)];
                break;
            case 2:
                password = level2passwords[Random.Range(0, level2passwords.Length)];
                break;
            case 3:
                password = level3passwords[Random.Range(0, level3passwords.Length)];
                break;
            case 4:
                password = level4passwords[Random.Range(0, level4passwords.Length)];
                break;
            default:
                Terminal.WriteLine("Something went wrong..");
                break;
        }
    }

    void checkPassword(string input)
    {
        if(input == password)
        {
            displayWinScreen();
        }
        else
        {
            askForPassword();
        }
    }

    void displayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        showLevelReward();
        Terminal.WriteLine(menuhint);
    }

    void showLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("You've won a signed copy of the harrypotter series by JK Rowling!");
                break;
            case 2:
                Terminal.WriteLine("You've won a lifetime Netflix subscription!!");
                break;
            case 3:
                Terminal.WriteLine("You've won a 1000 million dollars!!");
                break;
            case 4:
                Terminal.WriteLine("You are now the owner of the earth, You work & report directly to Aakshu");
                break;
            default:
                Terminal.WriteLine("Something went wrong...");
                break;
        }
    }
}
