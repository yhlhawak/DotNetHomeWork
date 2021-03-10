using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactorization
{
    /*
     * 埃氏筛法实现
     */
    class Sieve
    {
        int n;
        bool[] vis;
        public List<int> prime;

        public Sieve(int n)
        {
            this.n = n;
            this.vis = new bool[n+1];
            sieve();
            getPrime();
        }
        
        void sieve()
        {
            for(int i = 2; i * i < n; i++)
            {
                if (!vis[i])
                {
                    for (int j = i * i; j <= n; j += i) 
                    {
                        if (j > n) break;
                        vis[j] = true;
                        
                    }
                }
            }
        }

        void getPrime()
        {
            List<int> primeobj = new List<int>();
            for(int i = 2; i <= n; i++)
            {
                if (!vis[i])
                    primeobj.Add(i);
            }
            this.prime = primeobj;
        }

        public void showPrime()
        {
            foreach (int a in prime)
            {
                Console.Write(a.ToString()+" ");
            }
        }
    }
}
