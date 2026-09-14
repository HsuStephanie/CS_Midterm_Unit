using UnityEngine;

namespace MidtermTuringTest
{
    public abstract class Command
    {
       //execute method
        public abstract void Execute();

        //check if command has been followed
        public abstract bool isComplete {get;}
        

    }
}
