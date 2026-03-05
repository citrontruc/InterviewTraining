public class MedianSortedArrays {
    public static double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int pointer1 = 0;
        int pointer2 = 0;
        int previousValue = 0;
        int currentValue = 0;
        int countValues = nums1.Length + nums2.Length;
        if (countValues == nums2.Length)
        {
            return (double)(nums2[(nums2.Length - 1) / 2] + nums2[nums2.Length / 2]) / 2;
        }

        if (countValues == nums1.Length)
        {
            return (double)(nums1[(nums1.Length - 1) / 2] + nums1[nums1.Length / 2]) / 2;
        }

        while (pointer1 + pointer2 <= countValues / 2)
        {
            if (pointer1 > nums1.Length - 1)
            {
                while (pointer1 + pointer2 <= countValues / 2){
                    previousValue = currentValue;
                    currentValue = nums2[pointer2];
                    pointer2++;
                }
                continue;
            }

            if (pointer2 > nums2.Length - 1)
            {
                while (pointer1 + pointer2 <= countValues / 2){
                    previousValue = currentValue;
                    currentValue = nums1[pointer1];
                    pointer1++;
                }
                continue;
            }

            if (nums1[pointer1] < nums2[pointer2])
            {
                previousValue = currentValue;
                currentValue = nums1[pointer1];
                pointer1++;
            }
            else
            {
                previousValue = currentValue;
                currentValue = nums2[pointer2];
                pointer2++;
            }
        }
        if (countValues % 2 == 1){
            return currentValue;
        }
        return (double)(currentValue + previousValue) / 2;
    }
}