using Zenject;
using RunnerGame.Player;
using RunnerGame.UI;
using RunnerGame.Signals;
using RunnerGame.Platform;

namespace RunnerGame.Zenject
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
        
            Container.DeclareSignal<PlayerHitSignal>();
            Container.DeclareSignal<HealthChangedSignal>();
        
            Container.Bind<PlayerHealth>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PlayerShake>().FromComponentInHierarchy().AsSingle();
            Container.Bind<HealthUI>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PlayerCollision>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PlatformColorChanger>().FromComponentInHierarchy().AsSingle();

        }
    }
}

