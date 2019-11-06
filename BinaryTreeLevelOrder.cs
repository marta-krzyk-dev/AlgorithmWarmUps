//https://leetcode.com/problems/binary-tree-level-order-traversal/submissions/
public class Solution {
    public IList<IList<int>> LevelOrder(TreeNode root) {
        
        Queue queue = new Queue();
        List<IList<int>> values = new   List<IList<int>>();
        if (root is null)
            return values;
        
        Queue newQueue = new Queue();
        queue.Enqueue(root);
        
        while(queue.Count > 0)
        {
            List<int> temp = new List<int>();
            //get the recent nodes in the queue and add its values
            while(queue.Count > 0)
            {
                TreeNode nexty = (TreeNode)queue.Dequeue();
                temp.Add(nexty.val);
                if (nexty.left  != null) newQueue.Enqueue(nexty.left);
                if (nexty.right != null) newQueue.Enqueue(nexty.right);
            }
                        
            values.Add(temp); //Add all the values of the current level
            
            queue =  newQueue;
            newQueue = new Queue();
        }
        return values;
    }
}
