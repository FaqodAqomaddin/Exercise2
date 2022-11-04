using System;
namespace Exercise2
{
    class Program
    {
        int[] faq = new int[20];
        int n;
        int i;

        public void input()
        {
            while (true)
            {
                Console.Write("Enter the number of elements in the array: ");
                string s = Console.ReadLine();
                n = Int32.Parse(s);
                if ((n > 0) && (n <= 20))
                    break;
                else
                    Console.WriteLine("\n Array should have minimum 1 and maximum 20 elements.\n");
            }
            Console.WriteLine("");
            Console.WriteLine("--------------------");
            Console.WriteLine("Enter array elements");
            Console.WriteLine("--------------------");
            for (i = 0; i < n; i++)
            {
                Console.Write("<" + (i + 1) + ">");
                string s1 = Console.ReadLine();
                faq[i] = Int32.Parse(s1);
            }
        }
        static void sort(int[] arr)
        {
            int n = arr.Length;

            
            for (int i = 0; i < n - 1; i++)
            {
                
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[min_idx])
                        min_idx = j;

                
                int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
            }
        }
        void merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            i = 0;
            j = 0;

            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }
        void sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                
                int m = l + (r - l) / 2;

                
                sort(arr, l, m);
                sort(arr, m + 1, r);

               
                merge(arr, l, m, r);
            }
        }
        static void Main(string[] args)
        {
            Program myList = new Program();
            int pilihanmenu;
            char ch;

            Console.WriteLine("Menu Option");
            Console.WriteLine("===============");
            Console.WriteLine("1.Linear Search");
            Console.WriteLine("2.Binary search");
            Console.WriteLine("3.Exit");
            Console.Write("Enter your choice (1,2,3) : ");
            pilihanmenu = Convert.ToInt32(Console.ReadLine());
            switch (pilihanmenu)
            {
                case 1:
                    Console.WriteLine("");
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Sort");
                    Console.WriteLine("-----------------");
                    myList.input();
                    myList.sort();
                    break;
                case 2:
                    Console.WriteLine("");
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Merge");
                    Console.WriteLine("-----------------");
                    myList.input();
                    myList.merge();
                    break;
                case 3:
                    Console.WriteLine("exit.");
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}