WriteLine("day two part 2");
int depth = 0;
int horizontal = 0;
int aim = 0;
string subOperator;
int subOperand;
string[] splitLine;

// look through file, split line into operator & operand, change values based on case
foreach (string line in File.ReadLines(@"day2.txt"))
{
    splitLine = line.Split(' ');
    subOperator = splitLine[0];
    subOperand = int.Parse(splitLine[1]);
    switch (subOperator)
    {
        case "forward":
            horizontal += subOperand;
            depth += subOperand * aim;
            break;
        case "up":
            aim -= subOperand;
            break;
        case "down":
            aim += subOperand;
            break;
        default:
            Print("Invalid input");
            break;
    }
}
WriteLine("Horizontal: {0}", horizontal);
WriteLine("Depth: {0}", depth);
WriteLine("Multiplied: {0}", depth * horizontal);