WriteLine("Day 3 part 2");
List<string> values = File.ReadAllLines(@"day3.txt").ToList();
enum RatingType {O2, CO2}; //set of named int constants

//count number of 1s at given index
int OneCount(List<string> values, int index)
{
    return values.Count(v => v[index] == '1');
}

//remove values from list based on majority count of 1s
void ReduceList(List<string> values, int index, RatingType type)
{
    int countedOnes = OneCount(values, index);
    char charToRemove;
    if (type == RatingType.O2)
    {
        charToRemove = (countedOnes >= (values.Count + 1) / 2) ? '0' : '1'; //conditional ternary operator
    }
    else
    {
        charToRemove = (countedOnes >= (values.Count + 1) / 2) ? '1' : '0';
    }
    values.RemoveAll(v => v[index] == charToRemove);
    return;
}

//get the CO2 or O2 value based on rating type passed in
int GetSupportVal(List<string> values, RatingType type)
{
    int index = 0;
    while (index < 12 && values.Count > 1)
    {
        ReduceList(values, index++, type);
    }
    return Convert.ToInt32(values[0], 2); //turns string at index 0 to an integer calculated from base2
}

int O2Val = GetSupportVal(new List<string>(values), RatingType.O2);
WriteLine($"O2: {O2Val}: "); //clones contents to a new list
int CO2Val = GetSupportVal(new List<string>(values), RatingType.CO2);
WriteLine($"CO2: {CO2Val}: ");

WriteLine($"Life Support rating {O2Val * CO2Val}: ");