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
            public int value { get; set; }
            public Node leftChild { get; set; }
            public Node rightChild { get; set; }

            public Node()
            {
                this.value = 0;
                this.leftChild = null;
                this.rightChild = null;
            }
        }

        private void UpdateTree(Node currentNode, int lBorder, int rBorder, int position, int value)
        {
            if (lBorder == rBorder)
            {
                currentNode.value = value;
                return;
            }

            int middlePosition = (lBorder + rBorder) / 2;

            if (position <= middlePosition)
            {
                if (currentNode.leftChild == null)
                {
                    currentNode.leftChild = new Node();
                }
                
                UpdateTree(currentNode.leftChild, lBorder, middlePosition, position, value);
                currentNode.value = currentNode.leftChild.value;

                if (currentNode.rightChild != null)
                {
                    currentNode.value += currentNode.rightChild.value;
                }
            }
            else
            {
                if (currentNode.rightChild == null)
                {
                    currentNode.rightChild = new Node();
                }
                
                UpdateTree(currentNode.rightChild, middlePosition + 1, rBorder, position, value);
                currentNode.value = currentNode.rightChild.value;

                if (currentNode.leftChild != null)
                {
                    currentNode.value += currentNode.leftChild.value;
                }
            }
        }
        
        public void Update(int position, int value)
        {
            UpdateTree(root, 1, maxSize, position, value);
        }

        private int GetSegmentSum(Node currentNode, int lBorder, int rBorder,
                                  int requestedLBorder, int requestedRBorder)
        {
            if (requestedLBorder <= lBorder && rBorder <= requestedRBorder)
            {
                return currentNode.value;
            }

            if (requestedRBorder < lBorder || rBorder < requestedLBorder)
            {
                return 0;
            }

            int middlePosition = (lBorder + rBorder) / 2;

            int lSum = 0;
            int rSum = 0;

            if (currentNode.leftChild != null)
            {
                lSum = GetSegmentSum(currentNode.leftChild, lBorder, middlePosition, 
                                     requestedLBorder, requestedRBorder);
            }
            
            if (currentNode.leftChild != null)
            {
                rSum = GetSegmentSum(currentNode.rightChild, middlePosition + 1, rBorder, 
                    requestedLBorder, requestedRBorder);
            }

            return lSum + rSum;
        }

        public int GetSum(int lBorder, int rBorder)
        {
            return GetSegmentSum(root, 1, maxSize, lBorder, rBorder);
        }
    }
}