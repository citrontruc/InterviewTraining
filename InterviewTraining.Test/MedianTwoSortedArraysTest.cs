namespace InterviewTraining.Test;

public class MedianTwoSortedArraysTest
{
    [Fact]
    public void FindMedianSortedArrays_WithTwoSimpleArraysWithOddNumberOfValues_ReturnsMedian()
    {
        int[] nums1 = new int[] { 1, 3 };
        int[] nums2 = new int[] { 2 };
        double median = MedianSortedArrays.FindMedianSortedArrays(nums1, nums2);
        Assert.Equal(2, median);
    }

    [Fact]
    public void FindMedianSortedArrays_WithTwoSimpleArraysWithEvenNumberOfValues_ReturnsMedian()
    {
        int[] nums1 = new int[] { 1, 2 };
        int[] nums2 = new int[] { 3, 4 };
        double median = MedianSortedArrays.FindMedianSortedArrays(nums1, nums2);
        Assert.Equal(2.5, median);
    }

    [Fact]
    public void FindMedianSortedArrays_WithTwoSimpleArraysWithOddNumberOfValues2_ReturnsMedian()
    {
        int[] nums1 = new int[] { 1, 2 };
        int[] nums2 = new int[] { 3, 4, 5 };
        double median = MedianSortedArrays.FindMedianSortedArrays(nums1, nums2);
        Assert.Equal(3.0, median);
    }

    [Fact]
    public void FindMedianSortedArrays_WithEmptyArray_ReturnsMedian()
    {
        int[] nums1 = new int[] { };
        int[] nums2 = new int[] { 2, 4 };
        double median = MedianSortedArrays.FindMedianSortedArrays(nums1, nums2);
        Assert.Equal(3.0, median);
    }

    [Fact]
    public void FindMedianSortedArrays_WithEqualValues_ReturnsMedian()
    {
        int[] nums1 = new int[] { 2, 3, 4 };
        int[] nums2 = new int[] { 2, 3, 4 };
        double median = MedianSortedArrays.FindMedianSortedArrays(nums1, nums2);
        Assert.Equal(3.0, median);
    }
}
