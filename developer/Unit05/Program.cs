using Unit05.Game.Casting;
using Unit05.Game.Directing;
using Unit05.Game.Scripting;
using Unit05.Game.Services;

namespace Unit05
    class Program
    {
        static void Main(string[] args)
        {
            Cast cast = new Cast();
            cast.AddActor("cycletwo", new CycleTwo());
            cast.AddActor("cycleone", new CycleOne());
            cast.AddActor("onescore", new OneScore());
            cast.AddActor("twoscore", new TwoScore());
            
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            Script script = new Script();
            script.AddAction("input", new ControlCycleOneAction(keyboardService));
            script.AddAction("input", new ControlCycleTwoAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}