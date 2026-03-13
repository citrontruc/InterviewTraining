public class ListNode
{
    public int val;
    public ListNode? next;

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public static class SortListOfLinkedList
{
    public static ListNode? MergeKLists(ListNode[] lists)
    {
        if (lists.Length == 0)
        {
            return null;
        }

        if (lists.Length == 1)
        {
            return lists[0];
        }

        int[] listVals = new int[lists.Length];
        Array.Fill(listVals, int.MaxValue);
        for (int i = 0; i < listVals.Length; i++)
        {
            if (lists[i] != null)
            {
                listVals[i] = lists[i].val;
            }
        }

        int minVal = listVals.Min();
        if (minVal == int.MaxValue)
            return null;
        int indexMin = listVals.IndexOf(minVal);
        lists[indexMin] = lists[indexMin].next;
        listVals[indexMin] = lists[indexMin] == null ? int.MaxValue : lists[indexMin].val;
        ListNode beginning = new(minVal);
        ListNode current = beginning;

        while (true)
        {
            minVal = listVals.Min();
            if (minVal == int.MaxValue)
                return beginning;
            indexMin = listVals.IndexOf(minVal);
            lists[indexMin] = lists[indexMin].next;
            listVals[indexMin] = lists[indexMin] == null ? int.MaxValue : lists[indexMin].val;
            current.next = new(minVal);
            current = current.next;
        }
    }
}
