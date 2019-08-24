using System.Collections.Generic;
using System.Linq;

namespace Guestlogix.Services
{
    public class Itenary<T>
    {
        public T Value;

        public Itenary(T val)
        {
            Value = val;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class Travel<T>
    {
        private readonly Dictionary<Itenary<T>, List<Itenary<T>>> _adj;

        public Travel()
        {
            _adj = new Dictionary<Itenary<T>, List<Itenary<T>>>();
        }

        public void AddRoute(Itenary<T> origin, Itenary<T> dest)
        {
            if (!_adj.ContainsKey(origin))
                _adj[origin] = new List<Itenary<T>>();
            if (!_adj.ContainsKey(dest))
                _adj[dest] = new List<Itenary<T>>();
            _adj[origin].Add(dest);
        }

        public Stack<Itenary<T>> ShortestPath(Itenary<T> source, Itenary<T> dest)
        {
            var path = new Dictionary<Itenary<T>, Itenary<T>>();
            var distance = new Dictionary<Itenary<T>, int>();
            foreach (var route in _adj.Keys)
            {
                distance[route] = -1;
            }
            distance[source] = 0;
            var q = new Queue<Itenary<T>>();
            q.Enqueue(source);
            while (q.Count > 0)
            {
                var route = q.Dequeue();
                if (_adj.ContainsKey(route))
                {
                    foreach (var adj in _adj[route].Where(n => distance[n] == -1))
                    {
                        distance[adj] = distance[route] + 1;
                        path[adj] = route;
                        q.Enqueue(adj);
                    }
                }

            }
            var res = new Stack<Itenary<T>>();
            var cur = dest;
            while (cur != source)
            {
                res.Push(cur);
                if (!path.ContainsKey(cur))
                {
                    res.Clear();
                    return res;
                }
                cur = path[cur];
            }
            res.Push(source);
            return res;
        }
    }
}