using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleOutSearch.Services
{
    public class BST<K, V> where K : IComparable<K>
    {
        private Node<K, V> root;

        public int count = 0;

        public class Node<K, V> where K : IComparable<K>
        {
            public K key;
            public V value;
            public Node<K, V> left;
            public Node<K, V> right;

            public Node(K key, V value)
            {
                this.key = key;
                this.value = value;
            }
        }

        public void put(K key, V val)
        {
            root = put(root, key, val);
        }

        private Node<K, V> put(Node<K, V> x, K key, V val)
        {
            if (x == null) return new Node<K, V>(key, val);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) x.left = put(x.left, key, val);
            else if (cmp > 0) x.right = put(x.right, key, val);
            else x.value = val;
            return x;
        }

        public V get(K key)
        {
            Node<K, V> x = root;
            while (x != null)
            {
                count++;
                int cmp = key.CompareTo(x.key);
                if (cmp < 0) x = x.left;
                else if (cmp > 0) x = x.right;
                else return x.value;
            }
            return default(V);
        }

        public void delete(K key)
        {
            root = delete(root, key);
        }

        private Node<K, V> delete(Node<K, V> x, K key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) x.left = delete(x.left, key);
            else if (cmp > 0) x.right = delete(x.right, key);
            else
            {
                if (x.right == null) return x.left;
                if (x.left == null) return x.right;

                Node<K, V> t = x;
                x = min(t.right.key);
                x.right = deleteMin(t.right);
                x.left = t.left;
            }
            return x;
        }

        private Node<K, V> min(K key)
        {
            Node<K, V> x = root;
            int cmp = 100;
            while (cmp != 0)
            {
                cmp = key.CompareTo(x.key);
                if (cmp < 0) x = x.left;
                if (cmp > 0) x = x.right;
            }

            while (x.left != null)
            {
                x = x.left;
            }
            return x;
        }


        public void deleteMin()
        {
            root = deleteMin(root);

        }

        private Node<K, V> deleteMin(Node<K, V> x)
        {
            if (x.left == null) return x.right;
            x.left = deleteMin(x.left);
            return x;
        }

        public Queue<K> keys()
        {
            Queue<K> q = new Queue<K>();
            inorder(root, q);
            return q;
        }

        private void inorder(Node<K, V> x, Queue<K> q)
        {
            if (x == null) return;
            inorder(x.left, q);
            q.Enqueue(x.key);
            inorder(x.right, q);
        }
    }
}
