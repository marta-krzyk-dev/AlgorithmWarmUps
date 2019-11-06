/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    
    // ITERATION
    public IList<int> PreorderTraversal(TreeNode root)
    {
        List<int> values = new List<int>();

        Stack stack = new Stack();
        TreeNode next = root;
      
        while(next != null)
        {
            values.Add(next.val); 
            
            if (next.right != null)
              stack.Push(next.right);
          
            if (next.left != null)
              stack.Push(next.left);
           
            if (stack.Count == 0)
                 break;
                 
            next = (TreeNode) stack.Pop();
        }
        
        return values;
    }
    
    // RECURSIVE
    public IList<int> PreorderTraversal(TreeNode root)
    {   
        List<int> values = new List<int>();
        
        return Preorder(values, root);
    }
    
    private List<int> Preorder( List<int> values, TreeNode root)
    {
        if (root is null)
            return values;
        
        values.Add(root.val);
        Preorder(values, root.left);
        Preorder(values, root.right);
        
        return values;
    }
}
