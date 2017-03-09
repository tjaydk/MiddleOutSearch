# MiddleOutSearch
####By Dennis Rønnebæk

An optimization of the Binary Search Tree.

Instead of one root in the BST the MOS has two roots - an even root and an uneven root. Every object with an uneven hashcode value is put
into the uneven root and vice versa. The search for an item then starts of by evaluating item being searched for, its hashcode value.
Thereby being able to in best case cut the values being traversed by half.

Test with a tree of aprox. size 800 with random numbers between 0 and 999 it takes the binary search tree aprox 12 steps in avg. over
1000 test and the MOS does it in 10 steps. So a small implementation for an search speed increase of aproximately 18 %.

Still need to find a proper way of calculating the ellapsed time in C#
