using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Get_Shorty
{
    
    class Program
    {
        public static Dictionary<string, Rooms> Dungeon = new Dictionary<string, Rooms>();

        public static Dictionary<int, LinkedList<Rooms>> AdjencyList = new Dictionary<int, LinkedList<Rooms>>();

        static void Main(string[] args)
        {

            List<decimal> output = new List<decimal>();
            bool loop = true;
            while (loop)
            {
                string line = Console.ReadLine();
                string[] flineArray = line.Split(new[] { '\t', ' ' });
                int n;
                int m;
                Int32.TryParse(flineArray[0].ToString(), out n);
                Int32.TryParse(flineArray[1].ToString(), out m);
            List<decimal> final = new List<decimal>();
            string input = "";

            while ((input = Console.ReadLine()) != null && input != "")
            {               
                string[] sp = input.Split(' ');

                if(sp.Length == 2)
                {  
                    
                int intersections = Int32.Parse(sp[0]);
                int corridore = Int32.Parse(sp[1]);


                if (sp.Length == 2)
                {
                    for (int i = 0; i < corridore; i++)
                    {
                        Rooms r = new Rooms();
                  
                        string inp = Console.ReadLine();
                  
                        r.Name = inp;

                        string[] inpspl = inp.Split(' ');
                    

                         int x= Int32.Parse(inpspl[0]);
                         int y= Int32.Parse(inpspl[1]);

                        if (x == 0 && y == 0||inpspl.Length == 2)
                            break;

                        r.Intersection = x;
                        r.Corridoors = y;

                        r.Weight = double.Parse(inpspl[2]);

                        if(Dungeon.ContainsKey(r.Name) == false)
                            Dungeon.Add(r.Name, r);

                        if(AdjencyList.ContainsKey(x) == false)
                            AdjencyList.Add(x, new LinkedList<Rooms>());

                        Rooms c2 = new Rooms();
                        c2.Name = y + "" + x;
                        c2.X = y;
                        c2.Y = x;
                        c2.Weight = f;
                        c2.Next = x;
                        if (Dungeon.ContainsKey(c2.Name) == false)
                            Dungeon.Add(c2.Name, c2);

                        if (AdjencyList.ContainsKey(y) == false)
                            AdjencyList.Add(y, new LinkedList<Rooms>());

                        AdjencyList[x].AddLast(c1);
                        AdjencyList[y].AddLast(c2);



                    }

                    decimal num = Dijkstra(Dungeon.First().Value.Name, n - 1);
                    output.Add(num);
                    // clear intersects Dict
                    Dungeon.Clear();
                    AdjencyList.Clear();
                }
            }

            foreach(decimal answer in final)
            {

                Console.WriteLine(string.Format("0:f4", answer));
            }

            Console.Read();
        }

        public static decimal Dijkstra(string start, int end)
        {

            Dictionary<int, double> distant = new Dictionary<int,double>();

            foreach (KeyValuePair<int , LinkedList<Rooms>> entry in AdjencyList)
            {
                distant.Add(entry.Key, 0.0);
            }

            PriorityQueue<double, int> pq = new PriorityQueue<double, int>();

            int begin = distant.ElementAt(0).Key;

            distant[begin] = 1.0;

            pq.Enqueue(1.0, 0);

            while (!pq.IsEmpty)
            {
                KeyValuePair<double, int> u = pq.Dequeue();

                foreach (var edge in AdjencyList[u.Value])
                {
                    if(distant[edge.Next] < distant[u.Value] * edge.Weight)
                    {
                        distant[edge.Next] = distant[u.Value] * edge.Weight;
                        pq.Enqueue(distant[edge.Next], edge.Next);
                    }

                }

            }
            decimal d = Convert.ToDecimal(distant[end]);


                return d;
            
            
        }

    }
    public class Rooms
    {
        public string Name { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public double Weight { get; set; }

        public double Dist { get; set; }

        public int Next { get; set; }

        internal void SetDist(double w)
        {
           Dist = w;
        }
    }

    /*
     * This code implements priority queue which uses min-heap as underlying storage
     * https://www.codeproject.com/Articles/126751/Priority-queue-in-Csharp-with-help-of-heap-data-st.aspx
     * Copyright (C) 2010 Alexey Kurakin
     * www.avk.name
     * alexey[ at ]kurakin.me
     */

    public class PriorityQueue<TPriority, TValue> : ICollection<KeyValuePair<TPriority, TValue>>
    {
        private List<KeyValuePair<TPriority, TValue>> _baseHeap;
        private IComparer<TPriority> _comparer;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of priority queue with default initial capacity and default priority comparer
        /// </summary>
        public PriorityQueue()
            : this(Comparer<TPriority>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of priority queue with specified initial capacity and default priority comparer
        /// </summary>
        /// <param name="capacity">initial capacity</param>
        public PriorityQueue(int capacity)
            : this(capacity, Comparer<TPriority>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of priority queue with specified initial capacity and specified priority comparer
        /// </summary>
        /// <param name="capacity">initial capacity</param>
        /// <param name="comparer">priority comparer</param>
        public PriorityQueue(int capacity, IComparer<TPriority> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException();

            _baseHeap = new List<KeyValuePair<TPriority, TValue>>(capacity);
            _comparer = comparer;
        }

        /// <summary>
        /// Initializes a new instance of priority queue with default initial capacity and specified priority comparer
        /// </summary>
        /// <param name="comparer">priority comparer</param>
        public PriorityQueue(IComparer<TPriority> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException();

            _baseHeap = new List<KeyValuePair<TPriority, TValue>>();
            _comparer = comparer;
        }

        /// <summary>
        /// Initializes a new instance of priority queue with specified data and default priority comparer
        /// </summary>
        /// <param name="data">data to be inserted into priority queue</param>
        public PriorityQueue(IEnumerable<KeyValuePair<TPriority, TValue>> data)
            : this(data, Comparer<TPriority>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of priority queue with specified data and specified priority comparer
        /// </summary>
        /// <param name="data">data to be inserted into priority queue</param>
        /// <param name="comparer">priority comparer</param>
        public PriorityQueue(IEnumerable<KeyValuePair<TPriority, TValue>> data, IComparer<TPriority> comparer)
        {
            if (data == null || comparer == null)
                throw new ArgumentNullException();

            _comparer = comparer;
            _baseHeap = new List<KeyValuePair<TPriority, TValue>>(data);
            // heapify data
            for (int pos = _baseHeap.Count / 2 - 1; pos >= 0; pos--)
                HeapifyFromBeginningToEnd(pos);
        }

        #endregion

        #region Merging

        /// <summary>
        /// Merges two priority queues
        /// </summary>
        /// <param name="pq1">first priority queue</param>
        /// <param name="pq2">second priority queue</param>
        /// <returns>resultant priority queue</returns>
        /// <remarks>
        /// source priority queues must have equal comparers,
        /// otherwise <see cref="InvalidOperationException"/> will be thrown
        /// </remarks>
        public static PriorityQueue<TPriority, TValue> MergeQueues(PriorityQueue<TPriority, TValue> pq1, PriorityQueue<TPriority, TValue> pq2)
        {
            if (pq1 == null || pq2 == null)
                throw new ArgumentNullException();
            if (pq1._comparer != pq2._comparer)
                throw new InvalidOperationException("Priority queues to be merged must have equal comparers");
            return MergeQueues(pq1, pq2, pq1._comparer);
        }

        /// <summary>
        /// Merges two priority queues and sets specified comparer for resultant priority queue
        /// </summary>
        /// <param name="pq1">first priority queue</param>
        /// <param name="pq2">second priority queue</param>
        /// <param name="comparer">comparer for resultant priority queue</param>
        /// <returns>resultant priority queue</returns>
        public static PriorityQueue<TPriority, TValue> MergeQueues(PriorityQueue<TPriority, TValue> pq1, PriorityQueue<TPriority, TValue> pq2, IComparer<TPriority> comparer)
        {
            if (pq1 == null || pq2 == null || comparer == null)
                throw new ArgumentNullException();
            // merge data
            PriorityQueue<TPriority, TValue> result = new PriorityQueue<TPriority, TValue>(pq1.Count + pq2.Count, pq1._comparer);
            result._baseHeap.AddRange(pq1._baseHeap);
            result._baseHeap.AddRange(pq2._baseHeap);
            // heapify data
            for (int pos = result._baseHeap.Count / 2 - 1; pos >= 0; pos--)
                result.HeapifyFromBeginningToEnd(pos);

            return result;
        }

        #endregion

        #region Priority queue operations

        /// <summary>
        /// Enqueues element into priority queue
        /// </summary>
        /// <param name="priority">element priority</param>
        /// <param name="value">element value</param>
        public void Enqueue(TPriority priority, TValue value)
        {
           // Insert(priority, value);
            KeyValuePair<TPriority, TValue> val = new KeyValuePair<TPriority, TValue>(priority, value);
            _baseHeap.Add(val);

            // heapify after insert, from end to beginning
            HeapifyFromEndToBeginning(_baseHeap.Count - 1);
        }

        /// <summary>
        /// Dequeues element with minimum priority and return its priority and value as <see cref="KeyValuePair{TPriority,TValue}"/> 
        /// </summary>
        /// <returns>priority and value of the dequeued element</returns>
        /// <remarks>
        /// Method throws <see cref="InvalidOperationException"/> if priority queue is empty
        /// </remarks>
        public KeyValuePair<TPriority, TValue> Dequeue()
        {
            if (!IsEmpty)
            {
                KeyValuePair<TPriority, TValue> result = _baseHeap[0];
                DeleteRoot();
                return result;
            }
            else
                throw new InvalidOperationException("Priority queue is empty");
        }

        /// <summary>
        /// Dequeues element with minimum priority and return its value
        /// </summary>
        /// <returns>value of the dequeued element</returns>
        /// <remarks>
        /// Method throws <see cref="InvalidOperationException"/> if priority queue is empty
        /// </remarks>
        public TValue DequeueValue()
        {
            return Dequeue().Value;
        }

        /// <summary>
        /// Returns priority and value of the element with minimun priority, without removing it from the queue
        /// </summary>
        /// <returns>priority and value of the element with minimum priority</returns>
        /// <remarks>
        /// Method throws <see cref="InvalidOperationException"/> if priority queue is empty
        /// </remarks>
        public KeyValuePair<TPriority, TValue> Peek()
        {
            if (!IsEmpty)
                return _baseHeap[0];
            else
                throw new InvalidOperationException("Priority queue is empty");
        }

        /// <summary>
        /// Returns value of the element with minimun priority, without removing it from the queue
        /// </summary>
        /// <returns>value of the element with minimum priority</returns>
        /// <remarks>
        /// Method throws <see cref="InvalidOperationException"/> if priority queue is empty
        /// </remarks>
        public TValue PeekValue()
        {
            return Peek().Value;
        }

        /// <summary>
        /// Gets whether priority queue is empty
        /// </summary>
        public bool IsEmpty
        {
            get { return _baseHeap.Count == 0; }
        }

        #endregion

        #region Heap operations

        private void ExchangeElements(int pos1, int pos2)
        {
            KeyValuePair<TPriority, TValue> val = _baseHeap[pos1];
            _baseHeap[pos1] = _baseHeap[pos2];
            _baseHeap[pos2] = val;
        }

        private void Insert(TPriority priority, TValue value)
        {
            KeyValuePair<TPriority, TValue> val = new KeyValuePair<TPriority, TValue>(priority, value);
            _baseHeap.Add(val);

            // heap[i] have children heap[2*i + 1] and heap[2*i + 2] and parent heap[(i-1)/ 2];

            // heapify after insert, from end to beginning
            HeapifyFromEndToBeginning(_baseHeap.Count - 1);
        }


        private int HeapifyFromEndToBeginning(int pos)
        {
            if (pos >= _baseHeap.Count) return -1;

            while (pos > 0)
            {
                int parentPos = (pos - 1) / 2;
                if (_comparer.Compare(_baseHeap[parentPos].Key, _baseHeap[pos].Key) > 0)
                {
                    ExchangeElements(parentPos, pos);
                    pos = parentPos;
                }
                else break;
            }
            return pos;
        }


        private void DeleteRoot()
        {
            if (_baseHeap.Count <= 1)
            {
                _baseHeap.Clear();
                return;
            }

            _baseHeap[0] = _baseHeap[_baseHeap.Count - 1];
            _baseHeap.RemoveAt(_baseHeap.Count - 1);

            // heapify
            HeapifyFromBeginningToEnd(0);
        }

        private void HeapifyFromBeginningToEnd(int pos)
        {
            if (pos >= _baseHeap.Count) return;

            // heap[i] have children heap[2*i + 1] and heap[2*i + 2] and parent heap[(i-1)/ 2];

            while (true)
            {
                // on each iteration exchange element with its smallest child
                int smallest = pos;
                int left = 2 * pos + 1;
                int right = 2 * pos + 2;
                if (left < _baseHeap.Count && _comparer.Compare(_baseHeap[smallest].Key, _baseHeap[left].Key) > 0)
                    smallest = left;
                if (right < _baseHeap.Count && _comparer.Compare(_baseHeap[smallest].Key, _baseHeap[right].Key) > 0)
                    smallest = right;

                if (smallest != pos)
                {
                    ExchangeElements(smallest, pos);
                    pos = smallest;
                }
                else break;
            }
        }

        #endregion

        #region ICollection<KeyValuePair<TPriority, TValue>> implementation

        /// <summary>
        /// Enqueus element into priority queue
        /// </summary>
        /// <param name="item">element to add</param>
        public void Add(KeyValuePair<TPriority, TValue> item)
        {
            Enqueue(item.Key, item.Value);
        }

        /// <summary>
        /// Clears the collection
        /// </summary>
        public void Clear()
        {
            _baseHeap.Clear();
        }

        /// <summary>
        /// Determines whether the priority queue contains a specific element
        /// </summary>
        /// <param name="item">The object to locate in the priority queue</param>
        /// <returns><c>true</c> if item is found in the priority queue; otherwise, <c>false.</c> </returns>
        public bool Contains(KeyValuePair<TPriority, TValue> item)
        {
            return _baseHeap.Contains(item);
        }

        /// <summary>
        /// Gets number of elements in the priority queue
        /// </summary>
        public int Count
        {
            get { return _baseHeap.Count; }
        }

        /// <summary>
        /// Copies the elements of the priority queue to an Array, starting at a particular Array index. 
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from the priority queue. The Array must have zero-based indexing. </param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <remarks>
        /// It is not guaranteed that items will be copied in the sorted order.
        /// </remarks>
        public void CopyTo(KeyValuePair<TPriority, TValue>[] array, int arrayIndex)
        {
            _baseHeap.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets a value indicating whether the collection is read-only. 
        /// </summary>
        /// <remarks>
        /// For priority queue this property returns <c>false</c>.
        /// </remarks>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the priority queue. 
        /// </summary>
        /// <param name="item">The object to remove from the ICollection <(Of <(T >)>). </param>
        /// <returns><c>true</c> if item was successfully removed from the priority queue.
        /// This method returns false if item is not found in the collection. </returns>
        public bool Remove(KeyValuePair<TPriority, TValue> item)
        {
            // find element in the collection and remove it
            int elementIdx = _baseHeap.IndexOf(item);
            if (elementIdx < 0) return false;

            //remove element
            _baseHeap[elementIdx] = _baseHeap[_baseHeap.Count - 1];
            _baseHeap.RemoveAt(_baseHeap.Count - 1);

            // heapify
            int newPos = HeapifyFromEndToBeginning(elementIdx);
            if (newPos == elementIdx)
                HeapifyFromBeginningToEnd(elementIdx);

            return true;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>Enumerator</returns>
        /// <remarks>
        /// Returned enumerator does not iterate elements in sorted order.</remarks>
        public IEnumerator<KeyValuePair<TPriority, TValue>> GetEnumerator()
        {
            return _baseHeap.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>Enumerator</returns>
        /// <remarks>
        /// Returned enumerator does not iterate elements in sorted order.</remarks>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }



}
