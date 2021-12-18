WriteLine("Day 4 part 1");

private class BingoCard
{
    private readonly int[,] card = new int[5,5];
    private bool hasWon = false;
    //get 2d tuple (xindex,yindex) of value chosen in an array. indices is an outparam which is written to on return
    private bool TryGetIndexOf(int value, out (int,int) indices)
    {
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                if (card[x,y] == value)
                {
                    indices = (x,y);
                    return true;
                }
            }
        }
        indices = (-1,-1);
        return false;
    }
    //remove value from pickedNums
    private void RemoveVal(int chosen)
    {
        if (TryGetIndexOf(chosen, out (int,int) cardIndex))
        {
            (int x, int y) = cardIndex;
            card[x,y] = -1;
        }
    }
    private bool HasWon()
    {
        int xCount = 0;
        int yCount = 0;
        //iterate through x axis counting -1s
        for (int y = 0; y < 5; y++)
        {
            xCount = 0;
            for (int x = 0; x < 5; x++)
            {
                if (card[x,y] == -1)
                {
                    xCount++;
                }
            }
            if (xCount == 5)
            {
                return true;
            }
        }
        //iterate through y axis, counting -1s
        for (int x = 0; x < 5; x++)
        {
            yCount = 0;
            for (int y = 0; y < 5; y++)
            {
                if (card[x,y] == -1)
                {
                    yCount++;
                }
            }
            if (yCount == 5)
            {
                return true;
            }
        }
        return false;
    }
    //counts the numbers in a won card excluding -1
    private int CountVals()
    {
        int count = 0;
        for (int y = 0 ; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                if (card[x,y] != -1)
                {
                    count += card [x,y];
                }
            }
        }
        return count;
    }
    //takes a turn in bingo
    public bool Turn(int chosen, out int sum)
    {
        RemoveVal(chosen);
        if (HasWon())
        {
            sum = CountVals();
            return true;
        }
        sum = -1;
        return false;
    }
    //constructs a bingocard
    public BingoCard(IEnumerable<string> unProccessed)
    {
        string[] lines = unProccessed.ToArray();
        char[] delimArr = {' '};
        int[] numLine;
        for (int y = 0; y < 5; y++)
        {
            numLine = lines[y].Split(delimArr, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int x = 0; x < 5; x++)
            {
                card[x,y] = numLine[x];
            }
        }
    }
}

string[] day4File = File.ReadAllLines(@"day4.txt");

//select takes in first line and returns new collection, each value parsed as an int
int[] pickedNums = day4File[0].Split(',').Select(int.Parse).ToArray();

BingoCard[] cardArr = day4File.Skip(1)
    .Where(line => !string.IsNullOrWhiteSpace(line)) // take lines which are not whitespace
    .Select((item, index) => new { item, index }) //attach index of element
    .GroupBy(yes => yes.index / 5) //groups into chunks of 5
    .Select(no => no.Select(maybe => maybe.item)) //IEnumerable of 5 strings
    .Select(chunk => new BingoCard(chunk)) //create BingoCard from IE of 5
    .ToArray(); //array of BingoCards

bool hasWon = false;
foreach (int num in pickedNums)
{
    foreach (BingoCard thisCard in cardArr)
    {
        if (thisCard.Turn(num, out int sum))
        {
            WriteLine($"Winning card has score of: {sum * num}");
            hasWon = true;
            break;
        }
    }
    if (hasWon)
    {
        break;
    }
}