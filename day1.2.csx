WriteLine("Part 2");

//method to add numbers together in the arrays
int AddNumbers(int[] arr)
{
    return arr[0]+arr[1]+arr[2];
}
int index = 0;

int arrIndex = 0;
int count = 0;
int currentVal = 0;
int[] last3 = new int[3];
int[] current3 = new int[3];

//iterate through file, adding to arrays and compare sums
foreach (string line in File.ReadLines(@"day1.txt"))
{
    currentVal = int.Parse(line);
    //adding to arrays in circular queue style
    arrIndex = index % 3;
    last3[arrIndex] = current3[Math.Abs(index - 1) % 3];
    current3[arrIndex] = currentVal;
    if (index > 2)
    {
        if (AddNumbers(last3) < AddNumbers(current3))
        {
            count++;
        }
        WriteLine(AddNumbers(last3));WriteLine(AddNumbers(current3));
    }
    index++;
}
WriteLine(count);