using System;
using System.Diagnostics;

class TimedSelectionSort {

  public static void selectionSort(int [] A) {
    
    int minPos, temp;

    for(int i = 0; i < A.Length - 1; i++) {
      minPos = i;

      for(int o = i + 1; o < A.Length; o++) {
        if(A[o] < A[minPos]) {
          minPos = o;
        }
      }

      if(minPos != i) {
        temp = A[i];
        A[i] = A[minPos];
        A[minPos] = temp;
      }
    }
  }

  public static void Main (string[] args) {

    Console.Clear();
    //Clears the console log, it's completely unessecary and just used for the sake of neatness
    
    int n = 0;
    //Establishes an int that will later be used for the array size

    double totalTime = 0;
    double averageTime = 0.0;
    //Creates 2 variables to measure total time and a double to get the average

    Random rd = new Random();
    //Establishes variable that will be used to fill the array with random numbers

    Console.Write("Enter a number to determine the array size: ");
    n = Convert.ToInt32(Console.ReadLine());
    //Prompts user for a number and sets n to the value that will be input

    for(int i = 0; i < 1000; i++) {

      int [] Array = new int [n];
      //Creates an array named Array

      Console.Write("\n\nUnsorted Array " + (i + 1) + ": ");

      for(int j = 0; j < n; j++) {
        Array[j] = rd.Next(0, 9999);

        if(j == n - 1) {
        Console.WriteLine(Array[j]);
        }
        else {
        Console.Write(Array[j] + ", ");
        }
      }

      Stopwatch Clock = new Stopwatch();
      Clock.Start();
      
      selectionSort(Array);
      
      Clock.Stop();

      Console.Write("Sorted Array " + (i + 1) + ": ");

      for(int k = 0; k < n; k++) {
        if(k == n - 1) {
        Console.WriteLine(Array[k]);
        }
        else {
        Console.Write(Array[k] + ", ");
        }
      }

      totalTime += Convert.ToDouble(Clock.Elapsed.Milliseconds);
      
    }

    averageTime = (totalTime / 1000);

    Console.WriteLine("\n\n\nThe total time is: " + totalTime + " milliseconds");
    Console.WriteLine("The average time was: " + averageTime + " milliseconds");
    
    
  }
}