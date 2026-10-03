using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MidtermTuringTest
{
    public class CommandInteractor : Interactor
    {
        //First in, First out. Will complete commands as given
       Queue<Command> commands = new Queue<Command>();

        [SerializeField] NavMeshAgent navMeshAgent;
        [SerializeField] GameObject pointerPrefab;
        [SerializeField] Camera cam;

        private Command currentCommand;


      
        public override void Interact()
        {
            if (PlayerInput.instance.commandPressed)
            {
                Debug.Log("Command pressed");
                
                //Raycast from center of screen
                Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
                //if raycast hits something
                if (Physics.Raycast(ray, out var hitInfo))
                {
                    //if raycast hits the ground
                    if (hitInfo.transform.CompareTag("Ground"))
                    {
                        GameObject pointer = Instantiate(pointerPrefab);
                        pointer.transform.position = hitInfo.point;

                        commands.Enqueue(new MoveCommand(navMeshAgent, hitInfo.point));
                    }
                }

            }
            ProcessCommand();
        }


        //Responsible for processing commands in the queue one at at time
        void ProcessCommand()
        {
            //don't do anything until finish the current command
            if (currentCommand != null && !currentCommand.isComplete)
                return;
            // if there are no commands in the queue, don't do anything
            if (commands.Count == 0)
                return;
            
            //get rid of command that was just processed.
            currentCommand= commands.Dequeue();
            //Execute the command that was juse dequeued.
            currentCommand.Execute();
        }


    }

    
}
