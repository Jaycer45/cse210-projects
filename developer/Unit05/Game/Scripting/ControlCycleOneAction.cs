using Unit05.Game.Casting;
using Unit05.Game.Services;

namespace Unit05.Game.Scripting
{
    public class ControlCycleOneAction : Action
    {
        private KeyboardService keyboardService;
        private Point direction = new Point(Constants.CELL_SIZE, 0);

        public ControlCycleOneAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script)
        {
            if (keyboardService.IsKeyDown("a"))
            {
                direction = new Point(-Constants.CELL_SIZE, 0);
            }

            if (keyboardService.IsKeyDown("d"))
            {
                direction = new Point(Constants.CELL_SIZE, 0);
            }

            if (keyboardService.IsKeyDown("w"))
            {
                direction = new Point(0, -Constants.CELL_SIZE);
            }

            if (keyboardService.IsKeyDown("s"))
            {
                direction = new Point(0, Constants.CELL_SIZE);
            }

            CycleOne cycleone = (CycleOne)cast.GetFirstActor("cycleone");
            cycleone.TurnHead(direction);

        }
    }
}