using Core.ResourceSystem;
using Zenject;

namespace Instaillers
{
    public class GlobalInstaller : MonoInstaller<GlobalInstaller>
    {
        public override async void InstallBindings()
        {
            AssetProvider assetProvider = new();
            await assetProvider.Init();
            Container.Bind<AssetProvider>().FromInstance(assetProvider).AsSingle();
        
            PlayerInput playerInput = new();
            playerInput.Enable();
            Container.Bind<PlayerInput>().FromInstance(playerInput).AsSingle();
        }
    }
}
