namespace BinarniVyhledavaciStromy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<Student> tree = new BinarySearchTree<Student>();

            using (StreamReader streamReader = new StreamReader("../../../../studenti_shuffled.csv"))
            {
                string? line = streamReader.ReadLine();
                while (line != null)
                {
                    string[] studentData = line.Split(',');
                    Student student = new Student(
                        Convert.ToInt32(studentData[0]),
                        studentData[1],
                        studentData[2],
                        Convert.ToInt16(studentData[3]),
                        studentData[4]);
                    tree.Insert(student.Id, student);
                    line = streamReader.ReadLine();
                }
            }

            //student s ID 20
            Node<Student>? node20 = tree.Find(20);
            Console.WriteLine(node20 != null ? node20.Value : "Nenalezen");     //tohle mi poradila AI, aby se to zjednodušilo

            //student s nejnižším ID
            Node<Student>? minNode = tree.FindMin();
            Console.WriteLine(minNode != null ? minNode.Value : "Strom je prázdný");

            //student s ID > 100
            Student newStudent = new Student(101, "Ppp", "Mmm", 18, "9.A");
            tree.Insert(newStudent.Id, newStudent);
            Node<Student>? found101 = tree.Find(101);
            Console.WriteLine(found101 != null ? found101.Value : "Nenalezen");

            //minus studenty se sudým ID
            List<int> allIds = tree.GetIds();
            foreach (int id in allIds)
            {
                if (id % 2 == 0)
                    tree.Delete(id);
            }

            Console.WriteLine();

            //výpis
            tree.ShowTree();
        }
    }

    class BinarySearchTree<T>
    {
        public Node<T>? Root;

        public void Insert(int newKey, T newValue)
        {
            void _insert(Node<T> node, int newKey, T newValue)
            {
                //vlevo
                if (newKey < node.Key)
                {
                    if (node.LeftSon == null)
                        node.LeftSon = new Node<T>(newKey, newValue);
                    else
                        _insert(node.LeftSon, newKey, newValue);
                }
                //vpravo
                else if (newKey > node.Key)
                {
                    if (node.RightSon == null)
                        node.RightSon = new Node<T>(newKey, newValue);
                    else
                        _insert(node.RightSon, newKey, newValue);
                }
                else
                {
                    throw new Exception("Klíč musí být unikátní!");    //jestli jsou stejné ID
                }
            }

            if (Root == null)
                Root = new Node<T>(newKey, newValue);
            else
                _insert(Root, newKey, newValue);
        }

        public Node<T>? Find(int wantedKey)
        {
            Node<T>? _find(Node<T>? node, int wantedKey)
            {
                if (node == null)       //nenašel
                    return null;
                if (wantedKey == node.Key)     //našel
                    return node;
                if (wantedKey < node.Key)
                    return _find(node.LeftSon, wantedKey);
                return _find(node.RightSon, wantedKey);
            }

            return _find(Root, wantedKey);
        }

        public Node<T>? FindMin(Node<T>? node = null)
        {
            if (node == null)
            {
                if (Root == null) return null;
                node = Root;
            }

            while (node.LeftSon != null)         //pořad doleva
                node = node.LeftSon;

            return node;
        }

        public void Delete(int deleteKey)
        {
            Node<T>? _delete(Node<T>? node, int deleteKey)
            {
                if (node == null)
                    return null;

                if (deleteKey < node.Key)
                {
                    node.LeftSon = _delete(node.LeftSon, deleteKey);
                }
                else if (deleteKey > node.Key)
                {
                    node.RightSon = _delete(node.RightSon, deleteKey);
                }
                else
                {
                    if (node.LeftSon == null && node.RightSon == null)     //jestli nemá potomky
                        return null;

                    if (node.LeftSon == null) return node.RightSon;      //jestli má 1 potomka
                    if (node.RightSon == null) return node.LeftSon;

                    Node<T> minRight = FindMin(node.RightSon)!;        //jestli má 2 potomky, hledá nejmin z pravého podstromu
                    node.Key = minRight.Key;
                    node.Value = minRight.Value;
                    node.RightSon = _delete(node.RightSon, minRight.Key);
                }

                return node;
            }

            Root = _delete(Root, deleteKey);
        }

        public void ShowTree()
        {
            void _print(Node<T> node)
            {
                if (node.LeftSon != null)
                    _print(node.LeftSon);

                Console.WriteLine($"{node.Key}: {node.Value}");    //výpis studenta

                if (node.RightSon != null)
                    _print(node.RightSon);
            }

            if (Root == null)
                Console.WriteLine("Prázdný strom");
            else
                _print(Root);
        }

        public List<int> GetIds()
        {
            List<int> ids = new List<int>();

            void _getIds(Node<T>? node)       //rekurzivně prochází stromem
            {
                if (node == null) return;
                _getIds(node.LeftSon);
                ids.Add(node.Key);
                _getIds(node.RightSon);
            }

            _getIds(Root);
            return ids;
        }
    }

    class Node<T>
    {
        public Node(int key, T value)
        {
            Key = key;
            Value = value;
        }

        public int Key;
        public T Value;
        public Node<T>? LeftSon;
        public Node<T>? RightSon;
    }

    class Student
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }
        public string ClassName { get; }

        public Student(int id, string firstName, string lastName, int age, string className)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            ClassName = className;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} (ID: {2}) ze třídy {3}", FirstName, LastName, Id, ClassName);
        }
    }
}
