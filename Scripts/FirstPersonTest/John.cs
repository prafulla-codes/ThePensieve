using Godot;
using System;

public class John : KinematicBody
{ 
    // Physics
    float moveSpeed = 5.0f;
    float jumpForce = 5.0f;
    float gravity  = 12.0f;
    // Camera
    float minLookAngle = -90.0f;
    float maxLookAngle = 90.0f;
    float lookSensitivity = 10.0f;
    // Vectors
    Vector3 velocity = new Vector3();
    Vector2 mouseDelta = new Vector2();
 
    Camera camera;

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
        // Reset the x and z velocity
        velocity.x=0;
        velocity.z=0;

        Vector2 input  = new Vector2();
        // Movement Inputs
        if(Input.IsActionPressed("move_forward")) input.y-=1;
        if(Input.IsActionPressed("move_backward")) input.y+=1;
           if(Input.IsActionPressed("move_left")) input.x-=1;
        if(Input.IsActionPressed("move_right")) input.x+=1;
        
        // Noramalize the vector
        input = input.Normalized();

        // get the forward and right directions
        var forward = GlobalTransform.basis.z;
        var right = GlobalTransform.basis.x;

        var relativeDirection = (forward * input.y) + (right * input.x);

        // Set the velocity
        velocity.x = relativeDirection.x * moveSpeed;
        velocity.z = relativeDirection.z * moveSpeed;

        // Apply Gravity
        velocity.y -= gravity * delta;

        // Apply
        MoveAndSlide(velocity,Vector3.Up);

        // Jump 
        if(Input.IsActionPressed("jump") && IsOnFloor())
        {
            velocity.y = jumpForce;
        }

    }


}
