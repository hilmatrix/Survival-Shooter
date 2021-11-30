using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
    public PlayerMovement playerMovement;
    public PlayerShooting playerShooting;

    Queue<Command> commands = new Queue<Command>();

    void FixedUpdate() {
        Command moveCommand = InputMovementHandling();
        if (moveCommand != null) {
            commands.Enqueue(moveCommand);
            moveCommand.Execute();
        }
    }

    void Update() {
        Command shootCommand = InputShootHandling();
        if (shootCommand != null) {
            shootCommand.Execute();
        }
    }

    Command InputMovementHandling() {
        /*
        if (Input.GetKey(KeyCode.D)) {
            return new MoveCommand(playerMovement, 1, 0);
        }
        else if (Input.GetKey(KeyCode.A)) {
            return new MoveCommand(playerMovement, -1, 0);
        }
        else if (Input.GetKey(KeyCode.W)) {
            return new MoveCommand(playerMovement, 0, 1);
        }
        else if (Input.GetKey(KeyCode.S)) {
            return new MoveCommand(playerMovement, 0, -1);
        }*/

        float h = (Input.GetKey(KeyCode.D) ? 1 : 0) + (Input.GetKey(KeyCode.A) ? -1 : 0);
        float v = (Input.GetKey(KeyCode.S) ? -1 : 0) + (Input.GetKey(KeyCode.W) ? 1 : 0);

        if ((h != 0) || (v != 0)) {
            return new MoveCommand(playerMovement, h, v);
        } else if (Input.GetKey(KeyCode.Z)) {
            return Undo();
        }
        else {
            return new MoveCommand(playerMovement, 0, 0); ;
        }
    }

    Command Undo() {
        if (commands.Count > 0) {
            Command undoCommand = commands.Dequeue();
            undoCommand.UnExecute();
        }
        return null;
    }

    Command InputShootHandling() {
        if (Input.GetButton("Fire1")) {
            return new ShootCommand(playerShooting);
        }
        else {
            return null;
        }
    }
}
