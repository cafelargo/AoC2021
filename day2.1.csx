WriteLine("day two part 1");
int depth = 0;
int horizontal = 0;
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
            break;
        case "up":
            depth -= subOperand;
            break;
        case "down":
            depth += subOperand;
            break;
        default:
            Print("Invalid input");
            break;
    }
}
WriteLine("Horizontal: {0}", horizontal);
WriteLine("Depth: {0}", depth);
WriteLine("Multiplied: {0}", depth * horizontal);