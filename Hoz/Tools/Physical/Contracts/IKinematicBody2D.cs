using Godot;
using TheHoz.Hoz.Kernel.Contracts;

namespace TheHoz.Hoz.Tools.Physical.Contracts
{
    public interface IKinematicBody2D : IComponent
    {
        Vector2 GroundNormal { get; set; }
        Vector2 Gravity { get; set; }
        Vector2 Velocity { get; set; }
        bool IsOnGround();
        bool IsOnWall();
        bool IsOnLeftWall();
        bool IsOnRightWall();
        float GetDeltaTime();
    }
}
