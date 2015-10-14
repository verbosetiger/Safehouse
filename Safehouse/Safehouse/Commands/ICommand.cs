using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Safehouse
{
    /*
     * ICommand is the base interface for commands which perform an action on an actor
     * */
    public interface ICommand
    {
        /*
         * Execute allows the command to perform a derived action on the actor
         * */
        public void Execute(Actor actor);

        /*
         * The derrived command will return a command that will return a version of the 
         * command that undoes anything the command did 
         * */
        public ICommand Undo(Actor actor);
    }
}
