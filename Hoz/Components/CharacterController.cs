using Godot;
using System.Linq;
using TheHoz.Hoz.Kernel.Contracts;
using TheHoz.Hoz.Kernel.Kernel;
using TheHoz.Hoz.Tools.Physical.Contracts;

public class CharacterController : KinematicBody2D, IKinematicBody2D
{
    public Vector2 GroundNormal { get => _groundNormal; set => _groundNormal = value; }
    public Vector2 Gravity { get => _gravity; set => _gravity = value; }
    public Vector2 Velocity { get => _velocity; set => _velocity = value; }
    private IKernel _kernel;
    private ITick _tik;
    [Export]
    public Vector2 _gravity;
    [Export]
    public Vector2 _velocity;
    [Export]
    public Vector2 _groundNormal;

    public void Initialize(IKernel locator)
    {
        _kernel = locator;
    }

    public bool IsOnGround()
    {
        return IsOnFloor();
    }

    public bool IsOnLeftWall()
    {
        var index = GetSlideCount();
        if (index == 0) return false;
        var normal = GetSlideCollision(index - 1).Normal;
        return normal == Vector2.Right;
    }

    public bool IsOnRightWall()
    {
        var index = GetSlideCount();
        if (index == 0) return false;
        var normal = GetSlideCollision(index - 1).Normal;
        return normal == Vector2.Left;
    }

    public void Register(IKernel locator)
    {
        locator.Register(nameof(IKinematicBody2D), this);
    }

    public void Tick()
    {
        Velocity = MoveAndSlide(Velocity, GroundNormal);
    }

    public override void _Ready()
    {
        var kernel = new Kernel();
        _tik = kernel;
        var components = (GetChildren()).OfType<IComponent>().ToArray();
        foreach (var component in components) component.Register(kernel);
        Register(kernel);
        kernel.Initialize();
    }

    public override void _PhysicsProcess(float delta)
    {
        _tik.Tick();
    }

    public float GetDeltaTime()
    {
        return GetProcessDeltaTime();
    }
}
