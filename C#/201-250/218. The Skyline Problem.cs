public class Solution {
    
    // Helper to avoid allocating an object for lookups
    private static NumberCount placeHolderNumberCount = new NumberCount(0,0);
    
    public IList<IList<int>> GetSkyline(int[][] buildings) {
        // We want to know all the heights in the skyline, removing overlapping intersections.
        // Idea: A building has two points of interest start and end. 
        // The start can be seen an event that wants to hold that height until the building ends
        // A building starting after another will either do nothing to the height if the buiding is lower
        // or the same height or increase the height if the buiding is taller.
        // At any point, the current height is the maximum height of all buildings that started 
        // and have not ended yet
        // A building end is another event that finishes the corresponding start "event". 
        // If, as one buiding ends, there are still others that have not ended, their maximum
        // height is going to be the current height.
        //
        //
        // Basic idea: split start and end into the events mentioned above, sort them by x
        //   Starts add to a max heap based on y 
        //   Ends remove the corresponding y from the max heap
        // On removal or addition if the max y changes in the max heap register the change in height
        //   by adding it to the output at the x position of start/end
        //
        // Or, in the 4 loop steps:
        // read events in sequence
        //    1) if a start comes up add it to the max y heap
        //       1.1) if the max y in the heap changed when the start was added add that change to the output as x,heap's max y 
        //    2) if an end comes up remove the corresponding y from the heap
        //      2.2) if the max y in the heap changed when the start was removed
        //      Detail: Let's say we add a bunch of buildings at the same y=8 in x1=1,2 and 3 all with length 10
        //      When the first building finishes at x2=11, it doesn't really matter what y we remove from the priority queue
        //
        // Two road blocks destroyed:
        //   Road Block 1: Priority queue removal is O(n)
        //      We sort in O(n log n). 
        //      Then we go for each point (O(n) 2*n for start and end points, but O(n)).
        //              If the point is a start we add to the Priority Queue O(log n)
        //              If the point is an end we remove from the Priority Queue in... O(n)!!! *
        //              We allways check max which is O(1)
        //      * Problem: priority queue removal is O(n). We are removing by y value and a priority
        // queue is not a binary search tree. Our beautiful idea turned out not to be any better
        // than a O(n^2) approach.
        //
        //     Solution: Use a binary search tree as a priority queue. It has addition/removal by 
        // value in O(log n). Max check is O(log n). Not as good as priority queue's O(1) but
        // will still give us a beautiful O(n log n) for the whole thing
        //     
        //      Note: There is a way of removing by a pointer in O(log n) in a priority queue and with 
        // some work we could keep a pointer in the end to where the start was added.
        //      For the typical Priority queue, that pointer would be the index in the array
        //      where the element was inserted.
        //      Unfortunately the removal/addition of one item may invalidate an index based pointer.
        //      since the bubling up and down of the priority queue changes indexes arrund.
        //
        //  Road block 2: We have to carefully consider starts at the same x, ends at the same x,
        // and start at the same x of an end. 
        // Solution: Read the long comment on top of buildingPointComparison

        List<IList<int>> returnValue = new List<IList<int>>();

        // BuildingPoint is the event. The isStart boolean will tell which kind
        List<BuildingPoint> points = new List<BuildingPoint>();
        for (int i = 0; i < buildings.GetLength(0); i++)
        {
            int x1 = buildings[i][0];
            int x2 = buildings[i][1];
            int y = buildings[i][2]; // in production code we should throw for y == 0
            points.Add(new BuildingPoint(x1, y, true));
            
            // You might think y = 0 is the right thing to add here, but we will use the
            // y in the end event to find a corresponding start event with that y and 
            // remove it from the priority queue
            points.Add(new BuildingPoint(x2, y, false));
        }
        points.Sort(Solution.buildingPointComparison);

        // SortedSet and SortedDictionary are tree based.
        // We can have multiple y's so we need a count to manage that 
        // Right now, you can't simply use a SortedDictionary<int, int> (of y to its count)
        // because SortedDictionary can't extract max/min in O(log n) even though it is based
        // on SortedSet, which can extract max/min in O(log n).
        // To use a SortedSet and keep a count as well, we use the NumberCount class and
        // NumberCountComparer
        SortedSet<NumberCount> setAsPriorityQueue = new SortedSet<NumberCount>(new NumberCountComparer());

        // This makes it so we allways have an oldYMax in the loop. The count of 1
        // could be anything. We will never remove this because 0 is not in the input as a height
        setAsPriorityQueue.Add(new NumberCount(0, 1));

        // Finally do what I wrote above
        foreach (BuildingPoint point in points)
        {
            int oldYMax = setAsPriorityQueue.Max.number;
            if (point.isStart)
            {
                Solution.AddInSetAsPriorityQueue(setAsPriorityQueue, point.y);
            }
            else // the poit is an end
            {
                Solution.RemoveFromSetAsPriorityQueue(setAsPriorityQueue, point.y);
            }

            int newYMax = setAsPriorityQueue.Max.number;
            if (newYMax != oldYMax)
            {
                IList<int> temp=new List<int>();
                temp.Add(point.x);
                temp.Add(newYMax);
                returnValue.Add(new List<int>(temp));
            }
        }

        return returnValue;
    }
    
    
    /// <summary>
    /// Helper to add a new NumberCount or increment its count
    /// </summary>
    private static void AddInSetAsPriorityQueue(SortedSet<NumberCount> setAsPriorityQueue, int number)
    {
        // I wish I could use SortedDictionary. SortedSet's main scenario is Contains
        // Extracting the object we added is not the main scenario. Thankfully GetViewBetween does that
        Solution.placeHolderNumberCount.number = number;
        SortedSet<NumberCount> existing = setAsPriorityQueue.GetViewBetween(Solution.placeHolderNumberCount, Solution.placeHolderNumberCount);

        if (existing.Count == 1)
        {
            existing.Max.count++;
        }
        else
        {
            setAsPriorityQueue.Add(new NumberCount(number, 1));
        }
    }
    
    /// <summary>
    /// Helper to decrement a NumberCount or remove it when it reaches 0
    /// </summary>
    private static void RemoveFromSetAsPriorityQueue(SortedSet<NumberCount> setAsPriorityQueue, int number)
    {
        Solution.placeHolderNumberCount.number = number;
        SortedSet<NumberCount> existing = setAsPriorityQueue.GetViewBetween(Solution.placeHolderNumberCount, Solution.placeHolderNumberCount);
        
        // assert existing.Count == 1
        NumberCount numberCount = existing.Max;
        if (numberCount.count == 1)
        {
            setAsPriorityQueue.Remove(numberCount);
        }
        else
        {
            numberCount.count--;
        }
    }
    
    //      Sorting of points
    //  	The 3 corner cases are
    //  	1) Two starts at same x:
    //  
    //  	     __________
    //          |          |
    //          |______    |
    //          |      |   |
    //          |      |   |
    //          |      |   |
    //  
    //          Small building is at x=3,y=3. Tall building is at x=3,y=5. We need to have start of the tall building first, so it gets added to the output and the small building is not added to the output as it gets into the SortedSet. 
    //          If the start of the small goes first, its point is added to the output, which is wrong.
    //  
    //  	2) Two ends at the same x:
    //         	 __________
    //          |          |
    //          |    ______|
    //          |   |      |   
    //          |   |      |
    //          |   |      |
    //  
    //          small building ends at x=7,y=3. Tall building ends at x=7,y=5. The end for the small building has to go first so that it removes the start not adding to the output since max y does not change. The end of the tall building is then processed changing max y to 0 which gets added to the output.
    //  	If the tall building is first it gets removed and the max y changes to 3 causing x=7,y=3 to be incorrectly added to the output. 
    //  
    //          
    //  	3) A start and an end at the same x:
    //  
    //         	 __________
    //          |          |
    //          |          |______
    //          |          |      |
    //          |          |      |
    //          |          |      |
    //  
    //  	Tall building ends at x=7,y=5. Small building starts at x=7,y=3. The start goes first so that the end does not cause the max to go from 5 to 0 ading x=5,y=0 to the output.
    //  
    //  When considering 2 start/end points  start=start, end=end and start=end are all the corner cases we need to cover. The rest are entries the algorithm was thought out to adress:
    //       	 __________                  _________
    //          |          |                |         |
    //          |      ____|______          |         |     ___
    //          |     |    |      |   and   |         |    |   |
    //          |     |    |      |         |         |    |   |
    //          |     |    |      |         |         |    |   |
    //          |     |    |      |         |         |    |   |
    private static Comparison<BuildingPoint> buildingPointComparison = (BuildingPoint first, BuildingPoint second) =>
    {
        if (first.x != second.x)
        {
            return first.x - second.x;
        }

        // from here forward first.x == second.x

        if (first.isStart && second.isStart)
        {
            // Biggest y first means descending (second - first)
            return second.y - first.y;
        }

        if (!first.isStart && !second.isStart)
        {
            // Smallest y first is the usual ascending (first - second)
            return first.y - second.y;
        }

        // from here forward one is a start and the other is an end
        // either second.isStart (first.isEnd will be true) ...
        if (second.isStart)
        {
            return 1; // A positive value causes a swap (think first = 2, second = 1)
            // and the regular ascending first-second
        }

        // ...or first.isStart && second.isEnd
        return -1; // causes first and second to remain as they are
    };
    
    class BuildingPoint
    {
        public int x;
        public int y;
        public bool isStart;
        public BuildingPoint(int x, int y, bool isStart)
        {
            this.x = x;
            this.y = y;
            this.isStart = isStart;
        }
    }

    class NumberCount
    {
        public int number;
        public int count;
        public NumberCount(int number, int count)
        {
            this.number = number;
            this.count = count;
        }
    }

    class NumberCountComparer : IComparer<NumberCount>
    {
        public int Compare(NumberCount first, NumberCount second)
        {
            return first.number - second.number;
        }
    }
}