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
using System.Diagnostics;
using System.Threading;

namespace Prime_Numbers_Generation
{
	class Program
	{
		public static void Main(string[] args)
		{
			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();
			var d = new PrimeNumber(300000);
			stopWatch.Stop();
			TimeSpan time  = stopWatch.Elapsed;
			Console.WriteLine("Затрачено времени {0:00}.{1:000} секунд \nМассив состоит из {2} элементов", time.Seconds, time.Milliseconds, d.primeNumber.Count);
			int countOfTests = int.Parse(Console.ReadLine());
			string [] inputString = Console.ReadLine().Split(' ');
			
			for(int i = 0; i < countOfTests ; i++)
			{
				int result = d.ShowNum(int.Parse(inputString[i])-1);
				Console.Write("{0} ", result);
			}
			
			Console.ReadLine();
		}
	}
	
	class PrimeNumber
	{
		public List <int> primeNumber;
        List<int> primeNumberSecond;
        int n, k;
        Thread thread;
		
		public PrimeNumber(int k)
		{
			this.n = 2;
			this.k = k;
			primeNumber = new List <int>();
            primeNumberSecond = new List<int>();

            thread = new Thread(fillSecondHalf);
            thread.Start();

			for(int i = n; i <this.k/2; i++)
				primeNumber.Add(i);
            formQueueThread(primeNumber);

            primeNumber.AddRange(primeNumberSecond);
            Console.WriteLine("Формирование первичного списка завершено. Массив содержит {0} значений", primeNumber.Count);
            Console.ReadLine();
            formQueue();
		}

        private void fillSecondHalf()
        {
            for (int i = this.k/2; i <= this.k; i++)
                primeNumberSecond.Add(i);
            formQueueThread(primeNumberSecond);
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

        void formQueueThread(List<int> prime)
        {
            for (int i = 0; i < prime.Count; i++)
            {
                if (prime[i] % n == 0 && prime[i] !=2)
                {
                        primeNumber.RemoveAt(i);
                        i--;
                    Thread.Sleep(0);
                }
                
            }
            
        }

        public int ShowNum(int index)
		{
			return primeNumber[index];
		}
	}
}