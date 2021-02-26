namespace SegmentTree
{
    public class SegmentTree
    {
        private Node root = new Node();
        private int maxSize;

        public SegmentTree(int maxSize)
        {
            this.maxSize = maxSize;
        }

        public int MaxSize
        {
            get { return maxSize; }
        }
        
        private class Node
        {
            public int Value { get; set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }

            public Node()
            {
                this.Value = 0;
                this.LeftChild = null;
                this.RightChild = null;
            }
        }

        private void UpdateTree(Node currentNode, int leftBorder, int rightBorder, int position, int value)
        {
            if (leftBorder == rightBorder)
            {
                currentNode.Value = value;
                return;
            }

            int middlePosition = (leftBorder + rightBorder) / 2;

            if (position <= middlePosition)
            {
                if (currentNode.LeftChild == null)
                {
                    currentNode.LeftChild = new Node();
                }
                
                UpdateTree(currentNode.LeftChild, leftBorder, middlePosition, position, value);
                currentNode.Value = currentNode.LeftChild.Value;

                if (currentNode.RightChild != null)
                {
                    currentNode.Value += currentNode.RightChild.Value;
                }
            }
            else
            {
                if (currentNode.RightChild == null)
                {
                    currentNode.RightChild = new Node();
                }
                
                UpdateTree(currentNode.RightChild, middlePosition + 1, rightBorder, position, value);
                currentNode.Value = currentNode.RightChild.Value;

                if (currentNode.LeftChild != null)
                {
                    currentNode.Value += currentNode.LeftChild.Value;
                }
            }
        }
        
        public void Update(int position, int value)
        {
            UpdateTree(root, 1, maxSize, position, value);
        }

        private int GetSegmentSum(Node currentNode, int leftBorder, int rightBorder,
                                  int requestedLBorder, int requestedRBorder)
        {
            if (requestedLBorder <= leftBorder && rightBorder <= requestedRBorder)
            {
                return currentNode.Value;
            }

            if (requestedRBorder < leftBorder || rightBorder < requestedLBorder)
            {
                return 0;
            }

            int middlePosition = (leftBorder + rightBorder) / 2;

            int lSum = 0;
            int rSum = 0;

            if (currentNode.LeftChild != null)
            {
                lSum = GetSegmentSum(currentNode.LeftChild, leftBorder, middlePosition, 
                                     requestedLBorder, requestedRBorder);
            }
            
            if (currentNode.LeftChild != null)
            {
                rSum = GetSegmentSum(currentNode.RightChild, middlePosition + 1, rightBorder, 
                    requestedLBorder, requestedRBorder);
            }

            return lSum + rSum;
        }

        public int GetSum(int leftBorder, int rightBorder)
        {
            return GetSegmentSum(root, 1, maxSize, leftBorder, rightBorder);
        }
    }
}