public class LC25
{
    public static ListNode reverseKNodes(ListNode list, int k)
    {
        // trivial cases
        if (list == null)
        {
            return null;
        }
        if (list.next == null || k == 0) // In these cases (list is just a single node or k = 0), don't do anything to the list.
        {
            return list;
        }

        ListNode answer = list;

        Stack<ListNode> stack = new Stack<ListNode>();
        ListNode currNode = list;
        ListNode nextStart = null;
        ListNode prevEnd = null;
        bool head = true; // denotes if we need to take special care of the head node

        while (true)
        {
            // Push k nodes from list onto the stack.
            for (int i = 0; i < k && currNode != null; i++)
            {
                stack.Push(currNode);
                currNode = currNode.next;
            }

            // If we do not k nodes on the stack, then we cannot reverse k nodes, so we terminate.
            if (stack.Count != k)
            {
                break;
            }

            nextStart = currNode; // keeps track of the start of the next k nodes
            //Console.WriteLine("nextStart = {0}", nextStart.val);

            currNode = stack.Pop();
            // Set the head of the list if the group of k nodes we are working on includes the head.
            if (head)
            {
                answer = currNode;
                head = false; // A list only has one head, so after taking care of the head once, we never need to deal with it again.
            }
            else
            {
                prevEnd.next = currNode;
            }
            // Pop nodes from stack, while adding them to the reversed group of k nodes.
            while (stack.Count > 0)
            {
                currNode.next = stack.Pop();
                currNode = currNode.next;
            }
            // Now every node from the stack has been popped and added to its place in the reversed k nodes.
            currNode.next = nextStart;
            prevEnd = currNode;
            currNode = nextStart; // Now we are ready to reverse the next k nodes. 
        }

        return answer;
    }

    public static ListNode createList(int[] arr)
    {
        ListNode result = new ListNode();
        ListNode curr = result;

        foreach (int x in arr)
        {
            curr.next = new ListNode(x);
            curr = curr.next;
        }

        return result.next;
    }

    public static void printList(ListNode node)
    {
        ListNode curr = node;
        while (curr != null)
        {
            if (curr.next != null)
            {
                Console.Write("{0} -> ", curr.val);
            }
            else // if curr is the last node of the list
            {
                Console.Write("{0}", curr.val);
            }
            curr = curr.next;
        }
        Console.WriteLine();
    }

    public static void test1()
    {
        Console.WriteLine("\n-----Starting test 1-----");

        Console.WriteLine("k = 4");
        // 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8 -> 9 -> 10
        ListNode list1 = LC25.createList([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        ListNode answer1 = LC25.reverseKNodes(list1, 4);
        LC25.printList(answer1);

        Console.WriteLine("-----Finished test 1-----\n");
    }

    public static void test2()
    {
        Console.WriteLine("\n-----Starting test 2-----");

        Console.WriteLine("k = 5");
        // 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8 -> 9 -> 10
        ListNode list2 = LC25.createList([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        ListNode answer2 = LC25.reverseKNodes(list2, 5);
        LC25.printList(answer2);

        Console.WriteLine("-----Finished test 2-----\n");
    }

    public static void test3()
    {
        Console.WriteLine("\n-----Starting test 3-----");

        Console.WriteLine("k = 9");
        // 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8 -> 9 -> 10
        ListNode list3 = LC25.createList([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        ListNode answer3 = LC25.reverseKNodes(list3, 9);
        LC25.printList(answer3);

        Console.WriteLine("-----Finished test 3-----\n");
    }

    public static void test4()
    {
        Console.WriteLine("\n-----Starting test 4-----");

        Console.WriteLine("k = 10");
        // 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8 -> 9 -> 10
        ListNode list4 = LC25.createList([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        ListNode answer4 = LC25.reverseKNodes(list4, 10);
        LC25.printList(answer4);

        Console.WriteLine("-----Finished test 4-----\n");
    }

    public static void test5()
    {
        Console.WriteLine("\n-----Starting test 5-----");

        Console.WriteLine("k = 7");
        // 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8 -> 9 -> 10
        ListNode list4 = LC25.createList([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        ListNode answer4 = LC25.reverseKNodes(list4, 7);
        LC25.printList(answer4);

        Console.WriteLine("-----Finished test 5-----\n");
    }

    public static void test6()
    {
        Console.WriteLine("\n-----Starting test 6-----");

        Console.WriteLine("k = 2");
        // 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8 -> 9 -> 10
        ListNode list4 = LC25.createList([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        ListNode answer4 = LC25.reverseKNodes(list4, 2);
        LC25.printList(answer4);

        Console.WriteLine("-----Finished test 6-----\n");
    }

    public static void test7()
    {
        Console.WriteLine("\n-----Starting test 7-----");

        Console.WriteLine("k = 1");
        // 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8 -> 9 -> 10
        ListNode list4 = LC25.createList([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        ListNode answer4 = LC25.reverseKNodes(list4, 1);
        LC25.printList(answer4);

        Console.WriteLine("-----Finished test 7-----\n");
    }

    public static void test8()
    {
        Console.WriteLine("\n-----Starting test 8-----");

        Console.WriteLine("k = 11");
        // 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8 -> 9 -> 10
        ListNode list4 = LC25.createList([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        ListNode answer4 = LC25.reverseKNodes(list4, 11);
        LC25.printList(answer4);

        Console.WriteLine("-----Finished test 8-----\n");
    }

    static void Main(string[] args)
    {
        Console.WriteLine("----------STARTING TESTS----------");

        LC25.test1();
        LC25.test2();
        LC25.test3();
        LC25.test4();
        LC25.test5();
        LC25.test6();
        LC25.test7();
        LC25.test8();

        Console.WriteLine("----------FINISHED TESTS----------");
    }
}