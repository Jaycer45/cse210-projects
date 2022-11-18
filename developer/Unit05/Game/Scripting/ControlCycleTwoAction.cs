using Unit05.Game.Casting;
using Unit05.Game.Services;

namespace Unit05.Game.Scripting
{
    public class ControlCycleTwoAction : Action
    {
        private KeyboardService keyboardService;
        private Point direction = new Point(Constants.CELL_SIZE, 0);

        public ControlCycleTwoAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script)
        {
            if (keyboardService.IsKeyDown("j"))
            {
                direction = new Point(-Constants.CELL_SIZE, 0);
            }

            if (keyboardService.IsKeyDown("l"))
            {
                direction = new Point(Constants.CELL_SIZE, 0);
            }

            if (keyboardService.IsKeyDown("i"))
            {
                direction = new Point(0, -Constants.CELL_SIZE);
            }

            if (keyboardService.IsKeyDown("k"))
            {
                direction = new Point(0, Constants.CELL_SIZE);
            }

            CycleTwo cycletwo = (CycleTwo)cast.GetFirstActor("cycletwo");
            cycletwo.TurnHead(direction);

        }
    }
}