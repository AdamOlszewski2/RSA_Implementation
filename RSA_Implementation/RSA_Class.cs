using System;
using System.Collections.Generic;
using System.IO;
namespace RSA_Implementation
{
    class RSA_Class
    {

        private long _p;
        private long _q;
        private long _n;
        private long _phi;
        private long _e;
        private long _k;
        private long _d;

        string file = "C:\\CIPHER.txt";
        List<long> c = new List<long>();
        List<long> m = new List<long>();
        String bytesToBeEncrypted;
        public RSA_Class(long p, long q, long e, long d)
        {
            _p = p;
            _q = q;
            _n = p * q;
            _phi = (p - 1) * (q - 1);
                if (GCDRecursive(e, _phi) != 1)
                {
                    throw new Exception();
                }
            _e = e;
            _d = d;
        }

        public long GCDRecursive(long a, long b)
        {
            if (a == 0)
                return b;
            if (b == 0)
                return a;

            if (a > b)
                return GCDRecursive(a % b, b);
            else
                return GCDRecursive(a, b % a);
        }

        long cdn(long c, long d, long n)    
        {
            long value = 1;
            while (d > 0)
            {
                value *= c;
                value %= n;
                d--;
            }
            return value;
        }

        public void encrypt()
        {
            bytesToBeEncrypted = (File.ReadAllText(file));
            Console.Write("Original message: ");
            for (int i = 0; i < bytesToBeEncrypted.Length; i++)
            {
                Console.Write((int)bytesToBeEncrypted[i] + " ");
            }
            Console.WriteLine("\n");
            Console.Write("Encrypted message: ");
            for (int i = 0; i < bytesToBeEncrypted.Length;i++)
            {
                c.Add(cdn(bytesToBeEncrypted[i], _e, _n));
                Console.Write(c[i] + " ");
            }
        }
        public void decrypt()
        {
            Console.WriteLine("\n");
            Console.Write("Decrypted message: ");
            for (int i = 0; i < c.Count; i++)
            {
                m.Add(cdn(c[i], _d, _n));
                Console.Write(m[i].ToString() + " ");
            }
        }
    }
}
