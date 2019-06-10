using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            RSA_Class rs = new RSA_Class(11, 13, 23, 47);
            //Console.WriteLine(rs.GCDRecursive(540, 7));
            rs.encrypt();
            rs.decrypt();
        }
    }
}
