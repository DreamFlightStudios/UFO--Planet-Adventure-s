using Core.ResourceSystem;
using Zenject;

namespace Instaillers
{
    public class GlobalInstaller : MonoInstaller<GlobalInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<AssetProvider>().AsSingle();
        
            PlayerInput playerInput = new();
            playerInput.Enable();
            Container.Bind<PlayerInput>().FromInstance(playerInput).AsSingle();
        }
    }
}
