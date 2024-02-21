/*
Class: CSE 1322L
Section: W#1
Term: Spring 2022
Instructor: Joe Tierno
Name: Ian Riggins 
Lab#: Assignment 9
*/

using System;
using System.Collections.Generic;

class BankManager {
  public static void Main (string[] args) {

    int choice = 0, accountIndex;
    double money;
    string name, userID, password;
    bool found;
    List<BankAccount> Accounts = new List<BankAccount>();
    
    Console.Clear();


    do {

      name = "";
      userID = "";
      password = "";
      found = false;
      accountIndex = -1;
      money = 0;


      Console.WriteLine("1.) Create an Account\n2.) Delete an Account\n3.) Make an Account Deposit\n4.) Make an Account Withdrawl\n5.) Check an Account Balance\n6.) Exit\n");

      Console.Write("Choice: ");
      try {
        choice = Convert.ToInt16(Console.ReadLine());
      }
      catch {
        Console.WriteLine("Please enter a number between 1 & 6. No decimals please");
      }

      Console.WriteLine();
      
      switch(choice) {
          
        case 1:
          Console.Write("Enter Customer's Name: ");
          name = Console.ReadLine();

          Console.Write("Enter User ID: ");
          userID = Console.ReadLine();

          try {
            Console.Write("Enter User's Password: ");
            password = Console.ReadLine();

            if((!password.Contains("*")) && (password.Length < 8)) {
              throw new InvalidPasswordFormat("Password is too short and doesn't contain a *");
            }
            else if(password.Length < 8) {
              throw new InvalidPasswordFormat("Password length is too short");
            }
            else if (!password.Contains("*")) {
             throw new InvalidPasswordFormat("Password doesn't contain a *");
            }
            Console.WriteLine();
            Accounts.Add(new CheckingAccount(name, userID, password));
          }
          catch (InvalidPasswordFormat No) {
            Console.WriteLine("\nError: Must Enter a Valid Password\nInvalidPasswordFormat: " + No.Message);
          }
        break;

        case 2:
          Console.Write("Enter User ID: ");
          userID = Console.ReadLine();
          
          Console.Write("Enter User's Password: ");
          password = Console.ReadLine();

          try {
            for(int i = 0; i < Accounts.Count; i++) {
              if((userID.Equals(Accounts[i].getUserID())) && (password.Equals(Accounts[i].getPassword()))) {
                Accounts.RemoveAt(i);
                found = true;
                Console.WriteLine("Customer Loan Deleted");
              }
            }

            if(found == false) {
              throw new CustomerAccountNotFound("This account does not exist");
            }
          }
          catch(CustomerAccountNotFound dataNotFound) {
            Console.WriteLine("\nError: Data not found\nCustomerNotFound: " + dataNotFound.Message);
          }
        break;

        case 3:
          Console.Write("Enter User ID: ");
          userID = Console.ReadLine();
          
          Console.Write("Enter User's Password: ");
          password = Console.ReadLine();

          try {
            for(int i = 0; i < Accounts.Count; i++) {
              if((userID.Equals(Accounts[i].getUserID())) && (password.Equals(Accounts[i].getPassword()))) {
                found = true;
                accountIndex = i;
              }
            }

            if(found == false) {
              throw new CustomerAccountNotFound("This account does not exist");
            }
          }
          catch(CustomerAccountNotFound dataNotFound) {
            Console.WriteLine("\nError: Data not found\nCustomerNotFound: " + dataNotFound.Message);
          }

          if(found == true) {
            Console.Write("Enter an amount to deposit: $");
            try {
              money = Convert.ToDouble(Console.ReadLine());
              if(money < 0) {
                throw new NegativeDollarAmount("You cannot make a negative deposit!");
              }
              else {
                Accounts[accountIndex].addBalance(money);
                Console.WriteLine("Deposit successful.");
              }
            }
            catch(NegativeDollarAmount wrongSign) {
              Console.WriteLine("\nError: Invalid Input\nNegativeDollarAmount: " + wrongSign.Message);
            }
            catch {
              Console.WriteLine("Enter an actual amount of money...");
            }
          }
        break;

        case 4:
          Console.Write("Enter User ID: ");
          userID = Console.ReadLine();
          
          Console.Write("Enter User's Password: ");
          password = Console.ReadLine();

          try {
            for(int i = 0; i < Accounts.Count; i++) {
              if((userID.Equals(Accounts[i].getUserID())) && (password.Equals(Accounts[i].getPassword()))) {
                found = true;
                accountIndex = i;
              }
            }

            if(found == false) {
              throw new CustomerAccountNotFound("This account does not exist");
            }
          }
          catch(CustomerAccountNotFound dataNotFound) {
            Console.WriteLine("\nError: Data not found\nCustomerNotFound: " + dataNotFound.Message);
          }

          if(found == true) {
            Console.Write("Enter an amount to Withdraw: $");
            try {
              money = Convert.ToDouble(Console.ReadLine());
              if(money < 0) {
                throw new NegativeDollarAmount("You cannot make a negative Withdrawl!");
              }
              else if(money > Accounts[accountIndex].getBalance()) {
                throw new InsufficientFunds("You do not have enough funds to withdrawl that amount!");
              }
              else {
                Accounts[accountIndex].addBalance((-1 * money));
                Console.WriteLine("Withdrawl successful.");
              }
            }
            catch(InsufficientFunds Broke) {
              Console.WriteLine("\nError: Invalid Input\nInsufficientFunds: " + Broke.Message);
            }
            catch(NegativeDollarAmount wrongSign) {
              Console.WriteLine("\nError: Invalid Input\nNegativeDollarAmount: " + wrongSign.Message);
            }
            catch {
              Console.WriteLine("Enter an actual amount of money...");
            }
          }
        break;

        case 5:
          Console.Write("Enter User ID: ");
          userID = Console.ReadLine();
          
          Console.Write("Enter User's Password: ");
          password = Console.ReadLine();

          try {
            for(int i = 0; i < Accounts.Count; i++) {
              if((userID.Equals(Accounts[i].getUserID())) && (password.Equals(Accounts[i].getPassword()))) {
                found = true;
                accountIndex = i;
              }
            }

            if(found == false) {
              throw new CustomerAccountNotFound("This account does not exist");
            }
          }
          catch(CustomerAccountNotFound dataNotFound) {
            Console.WriteLine("\nError: Data not found\nCustomerNotFound: " + dataNotFound.Message);
          }

          if(found == true) {
            Console.WriteLine("\nCustomer Name: " + Accounts[accountIndex].getName() + "\nAccount Number: " + Accounts[accountIndex].getAccNum() + "\nAccount Balance: $" + (Accounts[accountIndex].getBalance()).ToString("#,##0.00") + "\nAccount Type: Checking\nAccount Daily Withdrawl: $300.00");
          }
        break;

        case 6:
          Console.WriteLine("Terminating Program...");
        break;

        default:
          Console.WriteLine("Please enter a number between 1 & 6");
        break;
      }

      Console.WriteLine();
      
    }while (choice != 6);


    
  }
}