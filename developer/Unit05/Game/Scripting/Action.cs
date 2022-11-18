using Unit05.Game.Casting;

namespace Unit05.Game.Scripting 
{
    public interface Action
    {
        void Execute(Cast cast, Script script);
    }
}