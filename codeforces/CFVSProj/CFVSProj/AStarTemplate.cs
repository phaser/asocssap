using System;
using System.Collections.Generic;
using System.Text;

public interface Node
{
    int GetG();
    void SetG(int g);
    int GetH();
    void SetH(int h);
    void SetParent(Node p);
    Node GetParent();
}
public interface PQueue<T>
{
    void Enqueue(T elem);
    T Dequeue();
    bool Empty();
}

public interface AStar
{
    void Init();
    PQueue<Node> GetOpenList();
    PQueue<Node> GetClosedList();
    IList<Node> GetSuccessors(Node node);
    int Heuristic(Node s, Node goal);
    int Distance(Node n1, Node n2);
    bool IsSamePositionNodeWithLowerFInOpenList(Node node);
    bool IsSamePositionNodeWithLowerFInClosedList(Node node);
}

public class AStarTemplate
{
    public static void DoAStar(AStar astar_instance, Node goal)
    {
        astar_instance.Init();
        var open_list = astar_instance.GetOpenList();
        var closed_list = astar_instance.GetClosedList();
        bool end = false;
        while (!end && !open_list.Empty())
        {
            var currentNode = open_list.Dequeue();
            var successors = astar_instance.GetSuccessors(currentNode);
            foreach (var s in successors)
            {
                if (s.Equals(goal))
                {
                    goal.SetParent(currentNode);
                    end = true;
                    break;
                }
                s.SetG(currentNode.GetG() + astar_instance.Distance(s, currentNode));
                s.SetH(astar_instance.Heuristic(s, goal));
                if (astar_instance.IsSamePositionNodeWithLowerFInOpenList(s))
                    continue;

                if (!astar_instance.IsSamePositionNodeWithLowerFInClosedList(s))
                {
                    open_list.Enqueue(s);
                    s.SetParent(currentNode);
                }
            }
            closed_list.Enqueue(currentNode);
        }

        var n = goal;
        while (n != null)
        {
            Console.WriteLine("x: {0} y: {1}", ((MapAStar.MapNode)n).x, ((MapAStar.MapNode)n).y);
            n = n.GetParent();
        }
    }
}

public class MapAStar : AStar
{
    public class MapNode : Node
    {
        public int x, y; // position on map
        private int g, h;
        private MapNode parent;

        public int GetG()
        {
            return g;
        }

        public int GetH()
        {
            return h;
        }

        public void SetG(int g)
        {
            this.g = g;
        }

        public void SetH(int h)
        {
            this.h = h;
        }

        public override bool Equals(object nn)
        {
            var n = nn as MapNode;
            if (n == null)
                return false;
            return x == n.x && y == n.y;
        }

        public void SetParent(Node p)
        {
            this.parent = (MapNode)p;
        }

        public Node GetParent()
        {
            return this.parent;
        }
    }

    public class MyPriorityQueue : PQueue<Node>
    {
        private List<Node> poorMansPriorityQueue;

        public MyPriorityQueue()
        {
            poorMansPriorityQueue = new List<Node>();
        }

        public Node Dequeue()
        {
            if (poorMansPriorityQueue.Count <= 0)
                return default(Node);
            var result = poorMansPriorityQueue[0];
            poorMansPriorityQueue.RemoveAt(0);
            return result;
        }

        public bool Empty()
        {
            return poorMansPriorityQueue.Count <= 0;
        }

        public void Enqueue(Node elem)
        {
            poorMansPriorityQueue.Add(elem);
            poorMansPriorityQueue.Sort((x, y) => {
                var f1 = x.GetG() + x.GetH();
                var f2 = y.GetG() + y.GetH();
                return (f1 < f2 ? -1 : f1 == f2 ? 0 : 1);
            });
        }

        public List<Node> GetList()
        {
            return poorMansPriorityQueue;
        }
    }

    private MyPriorityQueue openList;
    private MyPriorityQueue closedList;
    private bool[,] map;
    private Node start;

    public PQueue<Node> GetClosedList()
    {
        return closedList;
    }

    public PQueue<Node> GetOpenList()
    {
        return openList;
    }

    public IList<Node> GetSuccessors(Node node)
    {
        List<Node> slist = new List<Node>();
        var x = ((MapNode)node).x;
        var y = ((MapNode)node).y;
        if (x - 1 >= 0 && y - 1 >= 0 && map[x - 1, y - 1])
            slist.Add(new MapNode() { x = x - 1, y = y - 1 });
        if (x - 1 >= 0 && map[x - 1, y])
            slist.Add(new MapNode() { x = x - 1, y = y});
        if (y - 1 >= 0 && map[x, y - 1])
            slist.Add(new MapNode() { x = x, y = y - 1 });
        if (x - 1 >= 0 && y + 1 < 5 && map[x - 1, y + 1])
            slist.Add(new MapNode() { x = x - 1, y = y + 1 });
        if (y + 1 < 5 && map[x, y + 1])
            slist.Add(new MapNode() { x = x, y = y + 1 });
        if (x + 1 < 8 && y - 1 >= 0 && map[x + 1, y - 1])
            slist.Add(new MapNode() { x = x + 1, y = y - 1 });
        if (x + 1 < 8 && y + 1 < 5 && map[x + 1, y + 1])
            slist.Add(new MapNode() { x = x + 1, y = y + 1 });
        if (x + 1 < 8 && map[x + 1, y])
            slist.Add(new MapNode() { x = x + 1, y = y });

        return slist;
    }

    public int Heuristic(Node s, Node goal)
    {
        var ms = (MapNode)s;
        var mgoal = (MapNode)goal;
        return Math.Abs(ms.x - mgoal.x) + Math.Abs(ms.y - mgoal.y);
    }

    public void Init()
    {
        openList = new MyPriorityQueue();
        closedList = new MyPriorityQueue();
        openList.Enqueue(start);
    }

    public bool IsSamePositionNodeWithLowerFInClosedList(Node node)
    {
        var list = closedList.GetList();
        var idx = list.FindIndex(0, list.Count, (n) => ((MapNode)n).x == ((MapNode)node).x && ((MapNode)n).y == ((MapNode)node).y);
        if (idx != -1)
        {
            var n1f = node.GetG() + node.GetH();
            var n2f = list[idx].GetG() + list[idx].GetH();
            if (n2f < n1f)
                return true;
        }
        return false;
    }

    public bool IsSamePositionNodeWithLowerFInOpenList(Node node)
    {
        var list = openList.GetList();
        var idx = list.FindIndex(0, list.Count, (n) => ((MapNode)n).x == ((MapNode)node).x && ((MapNode)n).y == ((MapNode)node).y);
        if (idx != -1)
        {
            var n1f = node.GetG() + node.GetH();
            var n2f = list[idx].GetG() + list[idx].GetH();
            if (n2f < n1f)
                return true;
        }
        return false;
    }

    public int Distance(Node n1, Node n2)
    {
        return n1.GetG() + n2.GetG() + 1;
    }

    public MapAStar(bool[,] map, Node start)
    {
        this.map = map;
        this.start = start;
    }
}

namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_AStarTemplate
    {
        [TestMethod]
        public void Test1()
        {
            bool[,] map = new bool[8, 5] {
                {true, true, true, true, true },
                {true, true, true, false, true },
                {false, false, true, false, true },
                {true, true, true, false, true },
                {true, false, true, false, true },
                {true, false, true, true, true },
                {true, false, true, false, true },
                {true, true, true, true, true }
            };

            var mastar = new MapAStar(map, new MapAStar.MapNode() { x = 7, y = 0 });
            AStarTemplate.DoAStar(mastar, new MapAStar.MapNode() { x = 0, y = 0 });
        }
    }
}
