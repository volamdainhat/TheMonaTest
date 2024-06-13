public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Nhập các phần tử của mảng, cách nhau bởi dấu cách:");
        string input = Console.ReadLine();
        int[] nums = Array.ConvertAll(input.Split(' '), int.Parse);

        Console.WriteLine("Nhập indexDiff:");
        int indexDiff = int.Parse(Console.ReadLine());

        Console.WriteLine("Nhập valueDiff:");
        int valueDiff = int.Parse(Console.ReadLine());

        bool result = ContainsNearbyAlmostDuplicate(nums, indexDiff, valueDiff);

        Console.WriteLine(result.ToString());
    }

    public static bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDifference, int valueDifference)
    {
        if (indexDifference <= 0 || valueDifference < 0)
        {
            return false;
        }

        SortedSet<long> set = new SortedSet<long>();

        for (int i = 0; i < nums.Length; i++)
        {
            // Tìm vị trí để chèn giá trị hiện tại (sử dụng long để tránh tràn số nguyên)
            if (set.GetViewBetween((long)nums[i] - valueDifference, (long)nums[i] + valueDifference).Count > 0)
            {
                return true;
            }

            // Thêm giá trị hiện tại vào set
            set.Add((long)nums[i]);

            // Loại bỏ phần tử cũ nhất trong cửa sổ nếu cần
            if (i >= indexDifference)
            {
                set.Remove((long)nums[i - indexDifference]);
            }
        }

        return false;
    }
}