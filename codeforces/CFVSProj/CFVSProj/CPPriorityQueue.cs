using System;
using System.Collections.Generic;
using System.Text;

public class CPPriorityQueue<T>
{
    private List<T> heap;
    private Comparison<T> comparison;

    public CPPriorityQueue(Comparison<T> comparison)
    {
        heap = new List<T>();
        this.comparison = comparison;
    }

    public int Count
    {
        get { return heap.Count; }
    }

    public bool Contains(T elem)
    {
        return heap.Contains(elem);
    }

    public void Enqueue(T elem)
    {
        heap.Add(elem);
        int idx = heap.Count - 1;
        int p = (idx - 1) / 2;
        while (p >= 0 && comparison.Invoke(heap[idx], heap[p]) == 1)
        {
            T aux = heap[idx];
            heap[idx] = heap[p];
            heap[p] = aux;
            idx = p;
            p = (idx - 1) / 2;
        }
    }

    public T Dequeue()
    {
        if (heap.Count == 0)
            throw new Exception("No elements in queue");
        T result = heap[0];
        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);
        int pidx = 0;
        int c1idx = 1;
        int c2idx = 2;
        int cidx = 0;
        while (cidx != int.MinValue)
        {
            cidx = int.MinValue;
            if (c1idx < heap.Count && c2idx < heap.Count)
            {
                cidx = (comparison.Invoke(heap[c1idx], heap[c2idx]) >= 0 ? c1idx : c2idx);
            } else
            if (c1idx < heap.Count)
            {
                cidx = c1idx;
            } else
            if (c2idx < heap.Count)
            {
                cidx = c2idx;
            }
            if (cidx != int.MinValue)
            {
                T aux = heap[pidx];
                heap[pidx] = heap[cidx];
                heap[cidx] = aux;
                pidx = cidx;
                c1idx = 2 * pidx + 1;
                c2idx = 2 * pidx + 2;
            }
        }
        return result;
    }

    public T Peek()
    {
        if (heap.Count == 0)
            throw new Exception("No elements in queue");
        return heap[0];
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CPPriorityQueue
    {
        [TestMethod]
        public void Test1()
        {
            CPPriorityQueue<int> pq = new CPPriorityQueue<int>((x, y) => x > y ? 1 : x == y ? 0 : -1);
            Assert.AreEqual(0, pq.Count);
            Assert.IsFalse(pq.Contains(3));
            pq.Enqueue(3);
            pq.Enqueue(2);
            pq.Enqueue(1);
            pq.Enqueue(7);
            pq.Enqueue(5);
            pq.Enqueue(4);
            Assert.AreEqual(7, pq.Peek());
            int max = pq.Dequeue();
            Assert.AreEqual(7, max);
            Assert.AreEqual(5, pq.Peek());
            Assert.AreEqual(5, pq.Count);
            Assert.AreEqual(5, pq.Dequeue());
            Assert.AreEqual(4, pq.Dequeue());
            Assert.AreEqual(3, pq.Dequeue());
            Assert.AreEqual(2, pq.Dequeue());
            Assert.AreEqual(1, pq.Dequeue());
            Assert.AreEqual(0, pq.Count);
        }

        [TestMethod]
        public void Test2()
        {
            CPPriorityQueue<int> pq = new CPPriorityQueue<int>((x, y) => x > y ? 1 : x == y ? 0 : -1);
            for (int i = 2; i < 100; i++)
            {
                pq.Enqueue(i - 2);
                pq.Enqueue(i);
                pq.Enqueue(i - 1);
                Assert.AreEqual(i, pq.Dequeue());
            }
        }
    }
}
#endif