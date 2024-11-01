namespace _2048
{
    internal class Board
    {
        private readonly int[,] _array;
        private readonly Random _random;
        private int _score;

        public const int SIZE = 4;

        public int[,] Array => _array;
        public int Score => _score;

        public Board()
        {
            _array = new int[SIZE, SIZE];
            _random = new();
            _score = 0;
        }

        public bool IsGameOver()
        {
            for (int y = 0; y < SIZE; y++)
            {
                for (int x = 0; x < SIZE; x++)
                {
                    if (_array[y, x] == 0)
                    {
                        return false;
                    }
                    if (y > 0 && _array[y, x] == _array[y - 1, x] ||
                        y < SIZE - 1 && _array[y, x] == _array[y + 1, x] ||
                        x > 0 && _array[y, x] == _array[y, x - 1] ||
                        x < SIZE - 1 && _array[y, x] == _array[y, x + 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool SetNew()
        {
            List<(int, int)> empty = [];
            int value = _random.Next(1, 101) <= 90 ? 2 : 4;

            for (int y = 0; y < SIZE; y++)
                for (int x = 0; x < SIZE; x++)
                    if (_array[y, x] == 0)
                        empty.Add((y, x));

            if (empty.Count > 0)
            {
                var (i, j) = empty[_random.Next(empty.Count)];
                _array[i, j] = value;
                _score += value;
                return true;
            }
            return false;
        }

        private void Move(int dir)
        {
            switch (dir)
            {
                case 0: // up
                    for (int x = 0; x < SIZE; x++)
                    {
                        for (int y = 1; y < SIZE; y++)
                        {
                            if (_array[y, x] != 0)
                            {
                                int current = y;
                                while (current > 0 && (_array[current - 1, x] == 0 || _array[current - 1, x] == _array[current, x]))
                                {
                                    if (_array[current - 1, x] == _array[current, x])
                                    {
                                        _array[current - 1, x] *= 2;
                                        _score += _array[current - 1, x];
                                        _array[current, x] = 0;
                                        break;
                                    }
                                    else
                                    {
                                        _array[current - 1, x] = _array[current, x];
                                        _array[current, x] = 0;
                                    }
                                    current--;
                                }
                            }
                        }
                    }
                    break;

                case 1: // down
                    for (int x = 0; x < SIZE; x++)
                    {
                        for (int y = SIZE - 2; y >= 0; y--)
                        {
                            if (_array[y, x] != 0)
                            {
                                int current = y;
                                while (current < SIZE - 1 && (_array[current + 1, x] == 0 || _array[current + 1, x] == _array[current, x]))
                                {
                                    if (_array[current + 1, x] == _array[current, x])
                                    {
                                        _array[current + 1, x] *= 2;
                                        _score += _array[current + 1, x];
                                        _array[current, x] = 0;
                                        break;
                                    }
                                    else
                                    {
                                        _array[current + 1, x] = _array[current, x];
                                        _array[current, x] = 0;
                                    }
                                    current++;
                                }
                            }
                        }
                    }
                    break;

                case 2: // left
                    for (int y = 0; y < SIZE; y++)
                    {
                        for (int x = 1; x < SIZE; x++)
                        {
                            if (_array[y, x] != 0)
                            {
                                int current = x;
                                while (current > 0 && (_array[y, current - 1] == 0 || _array[y, current - 1] == _array[y, current]))
                                {
                                    if (_array[y, current - 1] == _array[y, current])
                                    {
                                        _array[y, current - 1] *= 2;
                                        _score += _array[y, current - 1];
                                        _array[y, current] = 0;
                                        break;
                                    }
                                    else
                                    {
                                        _array[y, current - 1] = _array[y, current];
                                        _array[y, current] = 0;
                                    }
                                    current--;
                                }
                            }
                        }
                    }
                    break;

                case 3: // right
                    for (int y = 0; y < SIZE; y++)
                    {
                        for (int x = SIZE - 2; x >= 0; x--)
                        {
                            if (_array[y, x] != 0)
                            {
                                int current = x;
                                while (current < SIZE - 1 && (_array[y, current + 1] == 0 || _array[y, current + 1] == _array[y, current]))
                                {
                                    if (_array[y, current + 1] == _array[y, current])
                                    {
                                        _array[y, current + 1] *= 2;
                                        _score += _array[y, current + 1];
                                        _array[y, current] = 0;
                                        break;
                                    }
                                    else
                                    {
                                        _array[y, current + 1] = _array[y, current];
                                        _array[y, current] = 0;
                                    }
                                    current++;
                                }
                            }
                        }
                    }
                    break;
            }
        }

        public void Up() => Move(0);
        public void Down() => Move(1);
        public void Left() => Move(2);
        public void Right() => Move(3);

        public void Clear()
        {
            for (int y = 0; y < SIZE; y++)
            {
                for (int x = 0; x < SIZE; x++)
                {
                    _array[y, x] = 0;
                }
            }
            _score = 0;
        }
    }
}
