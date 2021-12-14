WriteLine("Day 3 part 1");

int[] biNums = {0,0,0,0,0,0,0,0,0,0,0,0};
double gamma;
double epsilon;

//count the number of 1s in each index
foreach (string word in File.ReadLines(@"day3.txt"))
{
    for (int x = 0; x < 12; x++)
    {
        biNums[x] += int.Parse(word[x].ToString());
    }
}

//calculate number from binary string
for (int x = 0; x < 12; x++)
{
    if (biNums[x] > 500)
    {
        gamma += Math.Pow(2,11-x);
    }
}

epsilon = 4095 - gamma;

WriteLine("Gamma: {0}", gamma);
WriteLine("Epsilon: {0}", epsilon);
WriteLine("Power: {0}", epsilon * gamma);