using Zenject;

namespace Common
{
    public class GameInstaller  : MonoInstaller
    {
        public override void InstallBindings()
        {
            LogicInstaller.Install(Container);
            ConfigInstaller.Install(Container);
        }
    }
}