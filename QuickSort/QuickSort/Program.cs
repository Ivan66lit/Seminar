namespace QuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string vstup = Console.ReadLine();
            List<int> numbers = vstup.Split(' ').Select(int.Parse).ToList();

            Console.WriteLine(numbers);
            numbers = QS(numbers);
            
            for (int i = 0; i < numbers.Count; i++)
                Console.Write(numbers[i] + " ");
        }
        public static List<int> QS(List<int> numbers)
        {
            if (numbers.Count <= 1)
            {
                List<int> ready = numbers;
                return numbers;
            }
            else
            {
                int pivot = numbers[numbers.Count / 2];

                List<int> L = new List<int>();
                List<int> P = new List<int>();
                List<int> S = new List<int>();

                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] == pivot)
                        S.Add(numbers[i]);
                    else if (numbers[i] > pivot)
                        P.Add(numbers[i]);
                    else if (numbers[i] < pivot)
                        L.Add(numbers[i]);
                }

                List<int> result = new List<int>();

                result.AddRange(QS(L));
                result.AddRange(S);
                result.AddRange(QS(P));

                return result;
            }
        }
    }
}
