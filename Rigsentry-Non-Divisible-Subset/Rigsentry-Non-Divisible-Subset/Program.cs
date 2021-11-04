using System;
using System.Collections.Generic;
using System.Linq;

namespace Rigsentry_Non_Divisible_Subset
{
    class Program
    {
        static void Main(string[] args)
        {
            //var array1 = new int[] { 1, 7, 2, 4 };
            //var k1 = 3;

            var array1 = new int[] { 19, 10, 12, 10, 24, 25, 22}; 
            var k1 = 4;

            var add = false;            
            var summ = 0;
            var tempMaxArray = 0;
            var maxArray = 0;

            List<List<int>> arrayList = new List<List<int>>();
            List<int> tempList = new List<int>();

            for (var i = 0; i < array1.Length; i++)
            {
                tempList.Add(array1[i]);
                for (var j = 0; j < array1.Length; j++)
                {
                    if(j != i)
                    {             
                        //check the number is compatible with the first number.
                        summ = array1[i] + array1[j];
                        if (summ % k1 != 0)
                        {
                            if (!tempList.Contains(array1[j]))
                            {
                                //checks that the number that is being added is compatible with the previous numbers in the list
                                foreach (var tempValue in tempList)
                                {
                                    summ = tempValue + array1[j];
                                    if (summ % k1 != 0) { add = true; }
                                    else 
                                    { 
                                        add = false;
                                        break;
                                    }
                                }
                                if (add == true)
                                {
                                    tempList.Add(array1[j]);
                                }                                
                            }
                        }
                    }
                }

                var isEqual = false;

                //check if there are duplicates array
                foreach (var list in arrayList)
                {
                    if(Enumerable.SequenceEqual(list.OrderBy(e => e), tempList.OrderBy(e => e)))
                    {
                        isEqual = true;
                        break;
                    }
                }

                //only adds not duplicate arrays and that has at least 2 numbers in it
                if (!isEqual && tempList.Count() > 1)
                {
                    arrayList.Add(tempList.ToList());

                    //prints the arrays
                    Console.WriteLine("---------Array for " + array1[i] + " ----------------");
                    foreach (var printValue in tempList)
                    {
                        Console.WriteLine(printValue);
                    }
                }

                tempList.Clear();
            }

            //finds the biggest array.
            foreach (var array in arrayList)
            {
                tempMaxArray = array.Count();
                if (maxArray < tempMaxArray)
                {
                    maxArray = tempMaxArray;
                }
            }

            Console.WriteLine();
            Console.WriteLine("The Maximun lenght solution array has " + maxArray + " elements");
        }
    }
}
