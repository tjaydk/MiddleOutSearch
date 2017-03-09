using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleOutSearch.Services
{
    public class Node<k, v>
    {
        public readonly k key; // set the key to readonly to avoid it being changed
        public v value;
        public Node<k, v> left, right;

        public Node(k key, v value)
        {
            this.key = key;
            this.value = value;
            left = null;
            right = null;
        }
    }
}
