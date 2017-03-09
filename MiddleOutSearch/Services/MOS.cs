using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleOutSearch.Services
{
    /// <summary>
    /// The middleout search works like the binary search tree but has two roots, an even and an uneven root.
    /// If the key's value is even it is put into the even root with the same bigger or smalle principal and vice versa
    /// 
    /// by doing this we can best case scenario half the search time from an original binary search tree
    /// 
    /// ###########################!! ISSUES #############################
    /// 
    /// The right key is found through the traversal but the value is not returned right, it seems it continues
    /// the recursive method and then returns the default value even as the right key is found.
    /// </summary>
    /// <typeparam name="k"></typeparam>
    /// <typeparam name="v"></typeparam>
    public class MOS<k, v> where k : IComparable<k>
    {
        private Node<k, v> rootEven, rootUneven;
        public int count = 0;

        public MOS() { }

        public MOS(Node<k,v> firstRootNode)
        {
            this.rootEven   = (firstRootNode.key.GetHashCode() % 2 == 0) ? firstRootNode : null;
            this.rootUneven = (firstRootNode.key.GetHashCode() % 2 == 1) ? firstRootNode : null;
        }

        public void insert(k key, v value)
        {
            Node<k, v> node = new Node<k, v>(key, value);
            if (node.key.GetHashCode() % 2 == 0) {
                if (rootEven == null) { rootEven = node; }
                else { insertNode(node, rootEven); }
            } else {
                if (rootUneven == null) { rootUneven = node; }
                else { insertNode(node, rootUneven); }
            }
        }

        private void insertNode(Node<k,v> node, Node<k,v> root)
        {
            int comparatorValue = node.key.CompareTo(root.key);

            if (comparatorValue < 0)  {
                if (root.left == null) { root.left = node; }
                else { insertNode(node, root.left); }
            }
            else if (comparatorValue > 0) {
                if (root.right == null) { root.right = node; }
                else { insertNode(node, root.right); }
            }
            else { root.value = node.value; }
        }

        public v find(k key)
        {
            if (key.GetHashCode() % 2 == 0) { return get(rootEven, key); }
            else                            { return get(rootUneven, key); }
        }

        private v searchAndFind(Node<k,v> root, k key)
        {
            if      (key.CompareTo(root.key) == 0)  { return root.value; }
            else if (key.CompareTo(root.key) < 0)   { searchAndFind(root.left, key); }
            else if (key.CompareTo(root.key) > 0)   { searchAndFind(root.right, key); }
            return default(v);
        }

        public v get(Node<k,v> root, k key)
        {
            Node<k, v> x = root;
            while (x != null)
            {
                count++;
                int cmp = key.CompareTo(x.key);
                if (cmp < 0) x = x.left;
                else if (cmp > 0) x = x.right;
                else return x.value;
            }
            return default(v);
        }

    }
}
