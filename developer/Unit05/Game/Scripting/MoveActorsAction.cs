using System.Collections.Generic;
using Unit05.Game.Casting;

namespace Unit05.Game.Scripting
{

    public class MoveActorsAction : Action
    {
        public MoveActorsAction(){

        }

        public void Execute(Cast cast, Script script){
            List<Actor> actors = cast.GetAllActors();
            foreach(Actor actor in actors){
                actor.MoveNext();
            }
        }
    }
}