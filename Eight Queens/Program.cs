using System;

namespace Eight_Queens
{
    class Program
    {
        static int _solutionCount = 1;
        static int _max = 8;
        static int[] _row = new int[_max];
        static string _resltRowFormat;

        static void Main(string[] args)
        {

            _resltRowFormat = string.Create(7, '.', (span, c) =>
            {
                for (int i = 0; i < span.Length; i++) span[i] = c;
            });

            Run(0);

            Console.Read();
        }

        private static void Run(int n)
        {
            if (n == _max) 
            {
                Print();
                return;
            }
            for (int i = 0; i < _max; i++)
            {
                _row[n] = i;
                if (IsAttack(n))
                {
                    Run(n + 1);
                }
            }
        }

        private static bool IsAttack(int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (_row[i] == _row[n] || Math.Abs(n - i) == Math.Abs(_row[n] - _row[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private static void Print()
        {
            Console.WriteLine($"// Solution { _solutionCount++}");
            for (int i = 0; i < _row.Length; i++)
            {
                System.Console.WriteLine(_resltRowFormat.Insert(_row[i], "q"));
            }
            System.Console.WriteLine();
        }
    }
}
