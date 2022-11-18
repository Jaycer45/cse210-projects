using System;
using System.Collections.Generic;
using System.Linq;

namespace Unit05.Game.Casting
{
    public class CycleTwo : Actor
    {
        private List<Actor> segments = new List<Actor>();

        public CycleTwo()
        {
            PrepareBody();
        }

        public List<Actor> GetBody()
        {
            return new List<Actor>(segments.Skip(1).ToArray());
        }

        public Actor GetHead()
        {
            return segments[0];
        }

        public List<Actor> GetSegments()
        {
            return segments;
        }

        public void GrowTail(int numberOfSegments)
        {
            for (int i = 0; i < numberOfSegments; i++)
            {
                Actor tail = segments.Last<Actor>();
                Point velocity = tail.GetVelocity();
                Point offset = velocity.Reverse();
                Point position = tail.GetPosition().Add(offset);

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText("#");
                segment.SetColor(Constants.BLUE);
                segments.Add(segment);
            }
        }

        public override void MoveNext()
        {
            foreach (Actor segment in segments)
            {
                segment.MoveNext();
            }

            for (int i = segments.Count - 1; i > 0; i--)
            {
                Actor trailing = segments[i];
                Actor previous = segments[i - 1];
                Point velocity = previous.GetVelocity();
                trailing.SetVelocity(velocity);
            }
        }

        public void TurnHead(Point direction)
        {
            segments[0].SetVelocity(direction);
        }

        private void PrepareBody()
        {
            int x = Constants.MAX_X  / (4);
            int y = Constants.MAX_Y  / (4);

            for (int i = 0; i < Constants.SNAKE_LENGTH; i++)
            {
                Point position = new Point(x - i * Constants.CELL_SIZE, y);
                Point velocity = new Point(1 * Constants.CELL_SIZE, 0);
                string text = i == 0 ? "8" : "#";
                Color color = i == 0 ? Constants.HEADBLUE : Constants.BLUE;

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText(text);
                segment.SetColor(color);
                segments.Add(segment);
            }
        }
    }
}