using Zenject;

public class GlobalInstaller : MonoInstaller<GlobalInstaller>
{
    public override void InstallBindings()
    {
        PlayerInput playerInput = new PlayerInput();
        playerInput.Enable();
        Container.Bind<PlayerInput>().FromInstance(playerInput).AsSingle();
    }
}
