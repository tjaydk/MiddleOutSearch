using MiddleOutSearch.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleOutSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1000;
            int[] randomValues = new int[n];
            
            double mdsCount = 0;
            double bstBount = 0;

            double mdsTime = 0;
            double bstTime = 0;

            for (int j = 0; j < 5000; j++)
            {

                Stopwatch watchMDS = new Stopwatch();
                Stopwatch watchBST = new Stopwatch();


                MOS<int, int> mds = new MOS<int, int>();

                BST<int, int> bst = new BST<int, int>();

                int valueToFind = 0;

                Random ran = new Random();

                for (int i = 0; i < n; i++)
                {
                    int value = ran.Next(1000);

                    mds.insert(value, value);
                    bst.put(value, value);

                    if (i == n - 1) { valueToFind = value; }
                }


                //Console.WriteLine("Found the value " + valueToFind + "/" + mdsValue + " from MOS in " + watchMDS.ElapsedMilliseconds + "ms, and with " + mds.count + " steps.");
                
                long starttimeBST = DateTime.Now.Ticks;
                int bstValue = bst.get(valueToFind);
                long endtimeBST = DateTime.Now.Ticks;

                bstBount += bst.count;
                bstTime += endtimeBST - starttimeBST;

                long starttimeMOS = DateTime.Now.Ticks;
                int mdsValue = mds.find(valueToFind);
                long endtimeMOS = DateTime.Now.Ticks;

                mdsCount += mds.count;
                mdsTime += endtimeMOS - starttimeMOS;

                //Console.WriteLine("Found the value " + valueToFind + "/"+ bstValue + " from BST in " + watchBST.ElapsedMilliseconds + "ms, and with " + bst.count + " steps.");

            }

            Console.WriteLine("MOS found in avg: " + mdsTime/5000 + "ns and in avg " + mdsCount / 5000 + "steps");
            Console.WriteLine("BST found in avg: " + bstTime/5000 + "ns and in avg " + bstBount / 5000 + "steps");


            while (true) { }
        }
    }
}
