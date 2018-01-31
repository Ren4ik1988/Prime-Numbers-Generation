/*
 * Created by SharpDevelop.
 * User: User
 * Date: 31.01.2018
 * Time: 17:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Prime_Numbers_Generation
{
	class Program
	{
		public static void Main(string[] args)
		{
			var d = new PrimeNumber(300000);
			int countOfTests = int.Parse(Console.ReadLine());
			string [] inputString = Console.ReadLine().Split(' ');
			
			for(int i = 0; i < countOfTests ; i++)
			{
				int result = d.ShowNum(int.Parse(inputString[i])-1);
				Console.Write("{0} ", result);
			}
		}
	}
	
	class PrimeNumber
	{
		List <int> primeNumber;
		int n, k;
		
		public PrimeNumber(int k)
		{
			this.n = 2;
			this.k = k;
			primeNumber = new List <int>();
			
			for(int i = n; i <=this.k; i++)
				primeNumber.Add(i);
			
			formQueue();
		}
		
		void formQueue()
		{
			for (int j = 0; j < primeNumber.Count; j++)
			{
				n = primeNumber[j];
				int nextPrimary = n*n;
				if(nextPrimary>k)
					break;
			    int i = primeNumber.IndexOf(nextPrimary);
			    for(; i < primeNumber.Count; i++)
			    {
				    if(primeNumber[i]%n == 0)
				    {
				   	    primeNumber.RemoveAt(i);
					    i--;
				    }
			    }
			   
			}
			
		}
		
		public int ShowNum(int index)
		{
			return primeNumber[index];
		}
	}
}