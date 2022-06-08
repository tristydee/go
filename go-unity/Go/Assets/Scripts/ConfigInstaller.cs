using Configs;
using Zenject;

namespace Common
{
    public class ConfigInstaller : Installer<ConfigInstaller>
    {
        private const string PathPrefix = "Assets/Configs/";

        public override void InstallBindings()
        {
            Container.Bind<Settings>().FromScriptableObjectResource(PathPrefix + "Settings");
            Container.Bind<Assets>().FromScriptableObjectResource(PathPrefix + "Assets");
        }
    }
}