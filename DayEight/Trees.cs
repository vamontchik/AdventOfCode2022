namespace DayEight;

public sealed class Trees
{
    private readonly uint _rows;
    private readonly uint _columns;
    private readonly uint[,] _trees;

    public Trees(List<string> linesOfGridFile)
    {
        _rows = Convert.ToUInt32(linesOfGridFile.Count);
        _columns = Convert.ToUInt32(linesOfGridFile[0].Length);
        _trees = new uint[_rows, _columns];

        PopulateFromFile(linesOfGridFile);
    }

    private void PopulateFromFile(List<string> lines)
    {
        var row = 0;
        var col = 0;
        foreach (var line in lines)
        {
            foreach (var numberAsChar in line)
            {
                var number = Convert.ToUInt32(char.GetNumericValue(numberAsChar));
                _trees[row, col] = number;
                ++col;
            }

            col = 0;
            ++row;
        }
    }

    public uint CalculateAmountOfVisibleTrees()
    {
        var amount = 0U;

        for (var row = 0U; row < _rows; ++row)
        {
            for (var col = 0U; col < _columns; ++col)
            {
                var isTreeVisibleFromTop = VisibleFromTop(row, col);
                var isTreeVisibleFromLeft = VisibleFromLeft(row, col);
                var isTreeVisibleFromRight = VisibleFromRight(row, col);
                var isTreeVisibleFromBottom = VisibleFromBottom(row, col);

                amount += isTreeVisibleFromTop || isTreeVisibleFromLeft || isTreeVisibleFromRight ||
                          isTreeVisibleFromBottom
                    ? 1
                    : 0U;
            }
        }

        return amount;
    }

    private bool VisibleFromTop(uint row, uint col)
    {
        var currentValue = _trees[row, col];
        var possiblyNegativeRow = Convert.ToInt32(row);

        possiblyNegativeRow--;

        while (possiblyNegativeRow >= 0)
        {
            if (currentValue <= _trees[possiblyNegativeRow, col])
                return false;

            possiblyNegativeRow--;
        }

        return true;
    }

    private bool VisibleFromLeft(uint row, uint col)
    {
        var currentValue = _trees[row, col];
        var possiblyNegativeCol = Convert.ToInt32(col);

        possiblyNegativeCol--;

        while (possiblyNegativeCol >= 0)
        {
            if (currentValue <= _trees[row, possiblyNegativeCol])
                return false;

            possiblyNegativeCol--;
        }

        return true;
    }

    private bool VisibleFromRight(uint row, uint col)
    {
        var currentValue = _trees[row, col];

        col++;

        while (col < _columns)
        {
            if (currentValue <= _trees[row, col])
                return false;

            col++;
        }

        return true;
    }

    private bool VisibleFromBottom(uint row, uint col)
    {
        var currentValue = _trees[row, col];

        row++;

        while (row < _rows)
        {
            if (currentValue <= _trees[row, col])
                return false;

            row++;
        }

        return true;
    }

    public uint CalculateMaximumScenicScore()
    {
        var max = 0U;

        for (var row = 0U; row < _rows; ++row)
        {
            for (var col = 0U; col < _columns; ++col)
            {
                var scenicScoreLookingUp = ScenicScoreLookingUp(row, col);
                var scenicScoreLookingLeft = ScenicScoreLookingLeft(row, col);
                var scenicScoreLookingRight = ScenicScoreLookingRight(row, col);
                var scenicScoreLookingDown = ScenicScoreLookingDown(row, col);

                var currentScore = scenicScoreLookingUp *
                                   scenicScoreLookingLeft *
                                   scenicScoreLookingRight *
                                   scenicScoreLookingDown;

                if (max < currentScore)
                    max = currentScore;
            }
        }

        return max;
    }

    private uint ScenicScoreLookingUp(uint row, uint col)
    {
        var currentTreeHeight = _trees[row, col];
        var rowIteration = Convert.ToInt32(row);
        var distance = 0U;

        rowIteration--;

        while (rowIteration >= 0)
        {
            distance++;

            if (currentTreeHeight <= _trees[rowIteration, col])
                break;

            rowIteration--;
        }

        return distance;
    }

    private uint ScenicScoreLookingLeft(uint row, uint col)
    {
        var currentTreeHeight = _trees[row, col];
        var colIteration = Convert.ToInt32(col);
        var distance = 0U;

        colIteration--;

        while (colIteration >= 0)
        {
            distance++;

            if (currentTreeHeight <= _trees[row, colIteration])
                break;

            colIteration--;
        }

        return distance;
    }

    private uint ScenicScoreLookingRight(uint row, uint col)
    {
        var currentTreeHeight = _trees[row, col];
        var distance = 0U;

        col++;

        while (col < _columns)
        {
            distance++;

            if (currentTreeHeight <= _trees[row, col])
                break;

            col++;
        }

        return distance;
    }

    private uint ScenicScoreLookingDown(uint row, uint col)
    {
        var currentTreeHeight = _trees[row, col];
        var distance = 0U;

        row++;

        while (row < _rows)
        {
            distance++;

            if (currentTreeHeight <= _trees[row, col])
                break;

            row++;
        }

        return distance;
    }
}