using System;

namespace SegmentTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter array size: ");

            int arraySize = DataReader.ReadInt();
            SegmentTree segmentTree = new SegmentTree(arraySize);
            
            Console.Write("Enter array: ");
            int[] array = DataReader.ReadIntArray(arraySize);
            
            //initializing segment tree
            for (int i = 0; i < arraySize; ++i)
            {
                segmentTree.Update(i + 1, array[i]);
            }

            while (true)
            {
                Console.Write("Enter operation type (0 - exit, 1 - update, 2 - get sum): ");

                OperationType operationType = (OperationType) DataReader.ReadInt();

                switch (operationType)
                {
                    case OperationType.Update:
                        HandleUpdateOperation(segmentTree);
                        break;
                    
                    case OperationType.GetSum:
                        HandleGetSumOperation(segmentTree);
                        break;
                    
                    case OperationType.Exit:
                        Console.WriteLine("Shutting down");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Unknown operation");
                        break;
                }
            }
        }

        private static void HandleUpdateOperation(SegmentTree segmentTree)
        {
            Console.Write("Enter position and new value: ");
            int[] updateArgs = DataReader.ReadIntArray(2);
            int position = updateArgs[0];
            int value = updateArgs[1];

            if (position <= 0 || position > segmentTree.MaxSize)
            {
                Console.WriteLine("Invalid position value: " + position);
                return;
            }
            
            segmentTree.Update(position, value);
            Console.WriteLine("Updated");
        }
        
        private static void HandleGetSumOperation(SegmentTree segmentTree)
        {
            Console.Write("Enter left and right borders of segment: ");
            int[] sumArgs = DataReader.ReadIntArray(2);
            int lBorder = sumArgs[0];
            int rBorder = sumArgs[1];
            
            if (lBorder <= 0 || lBorder > segmentTree.MaxSize ||
                rBorder <= 0 || rBorder > segmentTree.MaxSize ||
                lBorder >= rBorder)
            {
                Console.WriteLine("Invalid border values: {0} {1}", lBorder, rBorder);
                return;
            }

            int sum = segmentTree.GetSum(lBorder, rBorder);
            Console.WriteLine("Sum on segment: " + sum);
        }
    }
}