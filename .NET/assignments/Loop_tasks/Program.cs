namespace Loop_tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("the squares:");
            Console.WriteLine();
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i*i);
            }

            Console.WriteLine();
            Console.WriteLine("the cubes: ");

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(Math.Pow(i, 3));
            }




            //task_2
            //int count = 0;
            for (int i = 1; i<1000; i++)
            {
                int sum = 0;
                for (int j = 1; j<i; j++)
                {
                    if (i%j==0)
                    {
                        sum+=j;
                    }
                }
                if (sum==i) Console.WriteLine(i);
            }

            //task3
            Console.WriteLine("Enter the numer of rows");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n%2==0) Console.WriteLine("Number should be even");
            for (int i = n; i>0; i=i-2)
            {
                for (int k = 0; k<(n-i)/2; k++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j<i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int i = 3; i<=n; i=i+2)
            {
                for (int k = 0; k<(n-i)/2; k++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j<i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }


            //task4

            for (int i = 0; i<=n; i++)
            {
                for (int k = 0; k<(n-i); k++)
                {
                    Console.Write(" ");
                }
                int j;
                for (j = 1; j<=i; j++)
                {
                    Console.Write(j);
                }
                for (int k = j-2; k>=1; k--)
                {
                    Console.Write(k);
                }
                Console.WriteLine();
            }


            //task5
            int flag = 0;
            for (int i = 0; i<n; i++)
            {
                if (i%2==0) flag=0;
                else flag=1;
                for (int j = 0; j<=i; j++)
                {
                    flag=1-flag;
                    Console.Write(flag);
                }
                Console.WriteLine();
            }

            //task6
            Console.WriteLine("enter the number between 100 and 999");
            for (int num = 100; num<=999; num++)
            {
                int sum = 0;
                int temp = num;
                while (temp > 0)
                {
                    int digit = temp % 10;
                    sum+=digit*digit*digit;
                    temp/= 10;
                }
                if (sum==num)
                {
                    Console.WriteLine(num);
                }
            }

            //task7
            Console.Write("Enter the number of terms: ");
            int x= Convert.ToInt32(Console.ReadLine()); 
            int[] fib = new int[x];
            fib[0] = 0;
            if (x > 1)
                fib[1] = 1;

            for (int i = 2; i < n; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
            }
            Console.WriteLine("Fibonacci series in reverse order:");
            for (int i = n - 1; i >= 0; i--)
            {
                Console.Write(fib[i] + " ");
            }

            //task8
            Console.WriteLine("zigzag pattern of height 4");
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    if (i + j == 5 || i + j == 11 || j - i == 9 || j - i == 3)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }

            //task 9
            int tempo=n;
            int count = 0;
            while (tempo > 0)
            {
                count++;
                tempo/=10;
            }
            Console.WriteLine($"the total digits are:{count}");

            //task 10
            //n = 5;
            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j);
                }
                for (int j = i - 1; j >= 1; j--)
                {
                    Console.Write(j);
                }

                Console.WriteLine();
            }
            for (int i = n - 1; i >= 1; i--)
            {
               
                for (int j = n; j > i; j--)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j);
                }
                for (int j = i - 1; j >= 1; j--)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }
        }
    }
}
