using Godot;
using System;

public class John : KinematicBody
{ 
    // Physics
    double moveSpeed = 5.0;
    double jumpForce = 5.0;
    double gravity  = 12.0;
    // Camera
    double minLookAngle = -90.0;
    double maxLookAngle = 90.0;
    double lookSensitivity = 10.0;
    // Vectors
    Vector3 velocity = new Vector3();
    Vector2 mouseDelta = new Vector2();
 
    Camera camera;

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
    }


}
