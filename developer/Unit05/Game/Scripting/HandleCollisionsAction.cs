using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;

namespace Unit05.Game.Scripting
{
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;
        private bool CycleOneLoose = false;
        private bool CycleTwoLoose = false;
        private int counter = 0;
        public HandleCollisionsAction()
        {
        }

        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleGrowth(cast);
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        private void HandleGrowth(Cast cast)
        {
            CycleOne cycleone = (CycleOne)cast.GetFirstActor("cycleone");
            CycleTwo cycletwo = (CycleTwo)cast.GetFirstActor("cycletwo");
            OneScore onescore = (OneScore)cast.GetFirstActor("onescore");
            TwoScore twoscore = (TwoScore)cast.GetFirstActor("twoscore");
            counter = counter +1;
            if (counter % 15 == 0){
                cycleone.GrowTail(1);
                cycletwo.GrowTail(1);
                onescore.AddPointsOne(1);
                twoscore.AddPointsTwo(1);
            }

        }

        private void HandleSegmentCollisions(Cast cast)
        {
            CycleOne cycleone = (CycleOne)cast.GetFirstActor("cycleone");
            Actor head1 = cycleone.GetHead();
            List<Actor> body1 = cycleone.GetBody();
            CycleTwo cycletwo = (CycleTwo)cast.GetFirstActor("cycletwo");
            Actor head2 = cycletwo.GetHead();
            List<Actor> body2 = cycletwo.GetBody();

            foreach (Actor segment1 in body1)
            {
                foreach (Actor segment2 in body2)
                    if (segment1.GetPosition().Equals(head2.GetPosition()))
                    {
                        isGameOver = true;
                        CycleTwoLoose = true;
                    }
                    else if(segment2.GetPosition().Equals(head1.GetPosition()))
                    {
                        isGameOver = true; 
                        CycleOneLoose = true;  
                    }

                    else if(segment2.GetPosition().Equals(head2.GetPosition()))
                    {
                        isGameOver = true;
                        CycleTwoLoose = true;
                    }

                if (segment1.GetPosition().Equals(head1.GetPosition()))
                {
                    isGameOver = true;
                    CycleOneLoose = true;
                }

            }

        }

        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                CycleOne cycleone = (CycleOne)cast.GetFirstActor("cycleone");
                List<Actor> segments1 = cycleone.GetSegments();
                CycleTwo cycletwo = (CycleTwo)cast.GetFirstActor("cycletwo");
                List<Actor> segments2 = cycletwo.GetSegments();

                if(CycleOneLoose == true)
                {
                    foreach (Actor segment in segments1)
                    {

                        int x = Constants.MAX_X / 2;
                        int y = Constants.MAX_Y / 2;
                        Point position = new Point(x, y);

                        Actor message = new Actor();
                        message.SetText("Player Two Wins!");
                        message.SetPosition(position);
                        cast.AddActor("messages", message);

                        segment.SetColor(Constants.WHITE);
                        message.SetColor(Constants.BLUE);
                    }
                }
                if (CycleTwoLoose == true)
                {
                    foreach (Actor segment in segments2)
                    {

                        int x = Constants.MAX_X / 2;
                        int y = Constants.MAX_Y / 2;
                        Point position = new Point(x, y);

                        Actor message = new Actor();
                        message.SetText("Player One Wins!");
                        message.SetPosition(position);
                        cast.AddActor("messages", message);

                        segment.SetColor(Constants.WHITE);
                        message.SetColor(Constants.RED);
                    }
                }
            
            }
        }
    }
}