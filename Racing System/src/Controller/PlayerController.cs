namespace Racing_System.Controller;

public class PlayerController : BasePlayerController
{
    public override void RegisterTypes() => Player.Register<Player>();
}
