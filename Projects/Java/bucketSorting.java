//Name: Ian Riggins
//Class: CS 3305/Section 04
//Term: Fall 2023
//Instructor: Umama Tasnim
//Assignment: 4

import java.io.*;
import java.util.*;
import java.util.Scanner;
import java.lang.Math;



class bucketSorting {

  public static int[] RadixSort(int[] unsorted) {

    int large = unsorted[0];
    int count = 1;
    int temp = 9;
    boolean passCountFound = false;
    Stack<Integer> [] buckets = new Stack[10];
    /*Creating an array of stacks for sorting process.
    Setting largest element to first value in the array (for now)
    count, temp, & passCountFound are used to determine number of passes needed*/


    for(int a = 1; a < unsorted.length; a++) {
      if(unsorted[a] > large) {
        large = unsorted[a];
      }
    }
    /*Traversing through the array searching for the largest value*/


    while(passCountFound == false) {
      count++;

      if(temp >= large) {
        passCountFound = true;
      }
      else {
        temp += (9 * Math.pow(10, count));
      }
    }
    /*In order to get number of passes needed, use the largest
    value in the array. Then determine how many digits the
    largest value has. To do this, check if largest value in the
    array is less than the largest value for digit count (9, 99, etc.)*/

    for(int l = 0; l < 10; l++) {
      buckets[l] = new Stack<Integer>();
    }
    //Initializing stack for each bucket.


    for(int i = 1; i <= count; i ++) {
      for(int j = unsorted.length - 1; j > -1; j--) {
        temp = unsorted[j];
        temp /= (int)(Math.pow(10, (i - 1)));
        temp %= 10;
        buckets[temp].push(unsorted[j]);
      }
      /*The i for-loop is used for the number of passes. The j for-loop
      is used to traverse through the array from back to front and put
      each value into buckets based on pass count & the respective digit.*/

      int n = 0;

      for(int k = 0; k < 10; k++) {
        while(buckets[k].isEmpty() == false) {
          unsorted[n] = buckets[k].pop();
          n++;
        }
      }
      /*The k for-loop is used to traverse through the
      buckets and put the values back into the array.*/
    }

    return unsorted;
    //After the sort is complete the array will be returned
  }
  //Radix Sort method to sort the array per assignment instructions

  
  public static void main(String[] args) {

    boolean cont = true;
    int size = 0;
    String list = "";
    /*These variables will be used so
    that the array can be any size*/

    Scanner Value = new Scanner(System.in);


    System.out.println("Enter integers into the array and enter a non-integer to stop.");

    do {
      try {
        System.out.print("Value " + (size + 1) + ": ");
        list += Value.nextInt();
        list += (", ");
        size++;
      }
      catch(InputMismatchException exc) {
        System.out.println("No more integers can be added to the array.\n\n");
        cont = false;
      }
    } while (cont == true);
    /*The do-while loop allows the user to enter however many
    integers they choose for the array. This allows the array
    to be any size. Loop ends when non-integer is entered*/

    String[] nums = list.split(", ");
    int[] arr = new int[size];
    cont = true;
    //Arrays are initialized

    for(int x = 0; x < size; x++) {
      arr[x] = Integer.parseInt(nums[x]);
    }
    //Int array is set

    
    System.out.print("Unsorted Array: [");
    
    for(int y = 0; y < size; y++) {
      if(y != size - 1) {
        System.out.print(arr[y] + ", ");
      }
      else if(cont == true) {
        System.out.print(arr[y] + "]\n");
        arr = RadixSort(arr);
        System.out.print("Sorted Array: [");
        cont = false;
        y = -1;
      }
      else {
        System.out.print(arr[y] + "]\n");
      }
    }
    //Printing the unsorted & sorted arrays
    
  }
}
