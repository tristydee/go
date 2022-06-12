using Configs;
using Zenject;

namespace Common
{
    public class ConfigInstaller : Installer<ConfigInstaller>
    {
        private const string PathPrefix = "Configs/";

        public override void InstallBindings()
        {
            Container.Bind<Settings>().FromScriptableObjectResource(PathPrefix + "Settings").AsSingle();
            Container.Bind<Assets>().FromScriptableObjectResource(PathPrefix + "Assets").AsSingle();
        }
    }
}