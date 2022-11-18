using System.Collections.Generic;
using Unit05.Game.Casting;
using Unit05.Game.Scripting;
using Unit05.Game.Services;


namespace Unit05.Game.Directing
{
    public class Director
    {
        private VideoService videoService = null;

        public Director(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void StartGame(Cast cast, Script script)
        {
            videoService.OpenWindow();
            while (videoService.IsWindowOpen())
            {
                ExecuteActions("input", cast, script);
                ExecuteActions("update", cast, script);
                ExecuteActions("output", cast, script);
            }
            videoService.CloseWindow();
        }

        private void ExecuteActions(string group, Cast cast, Script script)
        {
            List<Action> actions = script.GetActions(group);
            foreach(Action action in actions)
            {
                action.Execute(cast, script);
            }
        }
    }
}