WriteLine("Part 1");
int count = 0;
int last = 0;
int current = 0;
//iterate through file, parse str to int and compare with last value
foreach (string line in File.ReadLines(@"day1.txt"))
{
    current = int.Parse(line);
    if (last != 0 && current > last)
    {
        count++;
    }
    last = int.Parse(line);
}
WriteLine(count);