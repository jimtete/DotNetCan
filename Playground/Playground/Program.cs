int min;
int[] arr = new[] { -2, -9, 2, -3, 1, 0 };

min = GetMinimumElement(arr, 6);

Console.WriteLine(min);


static int GetMinimumElement(int[] arr, int length)
{
    if (length == 1)
    {
        return arr[0];
    }

    if (arr[length - 1] < GetMinimumElement(arr, length - 1))
    {
        return arr[length - 1];
    }
    return GetMinimumElement(arr, length - 1);
}