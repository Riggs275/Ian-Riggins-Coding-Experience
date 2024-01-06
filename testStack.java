//Name: Ian Riggins
//Class: CS 3305/Section 04
//Term: Fall 2023
//Instructor: Umama Tasnim

import java.io.*;
import java.util.*;
import java.util.Scanner;

class Main {

  public static void topToBottom(Stack<Integer> s) {
    System.out.print("Stack content: ");

    Object[] a = s.toArray();
    
    for(int n = s.size() - 1; n >= 0; n--) {
      if(n > 0) {
        System.out.print(a[n] + ", ");
      }
      else {
        System.out.println(a[n]);
      }
    }
    

    System.out.print("Function Output: ");

    while(!s.empty()) {
      if(s.size() > 1) {
        System.out.print(s.peek() + ", ");
      }
      else {
        System.out.println(s.peek() + "\n");
      }
      s.pop();
    }
    
  }
  /*This method takes a stack of integers and 
  displays the values from top to bottom*/

  public static void bottomToTop(Stack<Double> s) {
    System.out.print("Stack content: ");

    Object[] a = s.toArray();

    for(int n = s.size() - 1; n >= 0; n--) {
      if(n > 0) {
        System.out.print(a[n] + ", ");
      }
      else {
        System.out.println(a[n]);
      }
    }

    System.out.print("Function Output: ");


    for(int i = 0; i < s.size(); i++) {
      if(i < s.size() - 1) {
        System.out.print(a[i] + ", ");
      }
      else {
        System.out.println(a[i] + "\n");
      }
    }
    
  }
    /*This method takes a stack of doubles
    and displays the values from bottom to top*/

  public static Stack<String> flipStack(Stack<String> s) {
    Stack<String> newStack = new Stack<String>();

    int temp = s.size();

    for(int z = 0; z < temp; z++) {
      newStack.push(s.peek());
      s.pop();
    }
    
    return newStack;
  }
  /*This method takes a stack of strings 
    and returns the reverse order of it*/

  public static boolean searchStack(Stack<Integer> s, int target) {

    int loops = s.size();
    for(int i = 0; i < loops; i++) {
      if(target == s.peek()) {
        return true;
      }
      else {
        s.pop();
      }
    }

    return false;
  }
    /*This method takes a stack of integers and a single integer the 
    method then searches the stack trying to find the single integer*/
  
  public static void main(String[] args) {

    Scanner Read = new Scanner(System.in);
    Scanner in = new Scanner(System.in);
    int option = 0, temp;
    double temp2;
    String input = "";
    //Some variables to convert input to stack
    
    do {
      System.out.println("-----Main Menu-----\n");

      System.out.print("1.) Test function topToBottom with integer stack\n2.) Test function");
      System.out.print(" bottomToTop with double stack\n3.) Test function flipStack with ");              System.out.println("string stack\n4.) Test function searchStack with integer stack");
      System.out.print("5.) Exit Program\n\nOption: ");
      option = Read.nextInt(); 

      System.out.println();
      /*I used multiple print statements here for soley for formatting purposes*/


      switch(option) {
          
        case 1:
          Stack<Integer> TTB = new Stack<Integer>();

          System.out.print("Enter integers to push onto the stack (space-separated): ");
          input = in.nextLine();

          String[] numbers = input.split(" ");
          /*Taking a space separtated input in then 
          turning it into an array with string.split*/

          for(int i = 0; i < numbers.length; i++) {
            temp = Integer.parseInt(numbers[i]);
            TTB.push(temp);
            //Pushing all integers into stack
          }

          topToBottom(TTB);
        break;

        case 2:
          Stack<Double> BTT = new Stack<Double>();

          System.out.print("Enter doubles to push onto the stack (space-separated): ");
          input = in.nextLine();

          String[] decimals = input.split(" ");

          for(int i = 0; i < decimals.length; i++) {
            temp2 = Double.parseDouble(decimals[i]);
            BTT.push(temp2);
          }
          //Same methodology for case 1 but this time with doubles

          bottomToTop(BTT);
        break;

        case 3:
          Stack<String> FS = new Stack<String>();

          System.out.print("Enter strings to push onto the stack (space-separated): ");
          input = in.nextLine();

          String[] words = input.split(" ");

          for(int i = 0; i < words.length; i++) {
            FS.push(words[i]);
          }
          //Same methodology for cases 1 & 2 but now with strings

          System.out.println("Stack content before calling flipStack: " + FS);
          System.out.println("Stack content after calling flipStack: " + flipStack(FS) + "\n");
          
        break;

        case 4:
          Stack<Integer> SS = new Stack<Integer>();

          System.out.print("Enter integers to push onto the stack (space-separated): ");
          input = in.nextLine();

          String[] nums = input.split(" ");

          for(int i = 0; i < nums.length; i++) {
            SS.push(Integer.parseInt(nums[i]));
          }
          //Using the same sequence as the previous cases

          System.out.print("Stack Content: ");
          
          for(int j = nums.length - 1; j >= 0; j--) {
            if(j > 0) {
              System.out.print(nums[j] + ", ");
            }
            else {
              System.out.println(nums[j]);
            }
          }
          //Displaying the stack values

          

          System.out.print("Enter target value to search for: ");
          int target = Read.nextInt(); 

          System.out.println("Function output: " + searchStack(SS, target) + "\n");
          
        break;

        case 5:
          System.out.println("Closing program...");
        break;

        default:
          System.out.println("Not a valid option. Please pick an option 1 - 5.\n\n");
        break;
      }

    } while(option != 5);
    
  }
} 
