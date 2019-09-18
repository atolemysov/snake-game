using PixelEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Snack
{
    public class ExampleSnake : ISnake
    {
        private const int _width = 50;
        private const int _wallDistanceThreshold = 5;
        private Point _myHeadPosition;
        private Point _foodPosition;

        public string Name => "Example Snake";

        public SnakeDirection GetNextDirection(SnakeDirection currentDirection)
        {
            if(currentDirection == SnakeDirection.Up 
                && _myHeadPosition.Y < _wallDistanceThreshold)
            {
                if (_foodPosition.X < _myHeadPosition.X)
                    return SnakeDirection.Left;
                else
                    return SnakeDirection.Right;
            }

            if(currentDirection == SnakeDirection.Right
                && _myHeadPosition.X > _width - _wallDistanceThreshold)
            {
                if (_foodPosition.Y < _myHeadPosition.Y)
                    return SnakeDirection.Up;
                else
                    return SnakeDirection.Down;
            }

            if(currentDirection == SnakeDirection.Down
                && _myHeadPosition.Y > _width - _wallDistanceThreshold)
            {
                if (_foodPosition.X > _myHeadPosition.X)
                    return SnakeDirection.Right;
                else
                    return SnakeDirection.Left;
            }

            if (currentDirection == SnakeDirection.Left
                && _myHeadPosition.X <  _wallDistanceThreshold)
            {
                if (_foodPosition.Y > _myHeadPosition.Y)
                    return SnakeDirection.Down;
                else
                    return SnakeDirection.Up;
            }

            if (currentDirection == SnakeDirection.Up)
            {
                if (_foodPosition.X < _myHeadPosition.X)
                    return SnakeDirection.Left;
                else
                    return SnakeDirection.Right;
            }
            if (currentDirection == SnakeDirection.Right)
            {
                if (_foodPosition.Y < _myHeadPosition.Y)
                    return SnakeDirection.Up;
                else
                    return SnakeDirection.Down;
            }
            if (currentDirection == SnakeDirection.Down)
            {
                if (_foodPosition.X > _myHeadPosition.X)
                    return SnakeDirection.Right;
                else
                    return SnakeDirection.Left;
            }
            if (currentDirection == SnakeDirection.Left)
            {
                if (_foodPosition.Y > _myHeadPosition.Y)
                    return SnakeDirection.Down;
                else
                    return SnakeDirection.Up;
            }

            return currentDirection;
        }

        public void UpdateMap(string map)
        {
            _myHeadPosition = getMyHeadPosition(map);
            _foodPosition = getFoodPosition(map);
        }

        private Point getMyHeadPosition(string map)
        {
            var headIndex = map.IndexOf('*');
            return new Point(headIndex % _width, headIndex / _width);
        }

        private Point getFoodPosition(string map)
        {
            var headIndex = map.IndexOf('7');
            return new Point(headIndex % _width, headIndex / _width);
        }
    }
}
