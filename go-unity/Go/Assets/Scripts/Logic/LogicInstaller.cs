using Logic.AI;
using Logic.Rules;
using Logic.Scoring;
using Zenject;

namespace Common
{
    public class LogicInstaller : Installer<LogicInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<MoveSelector>().To<RandomMoveSelector>().AsSingle();
            Container.Bind<ScoringCommand>().To<AreaScoringCommand>().AsSingle();
            Container.Bind<PlacementRuleCommand>().To<CellIsEmptyPlacementRuleCommand>().AsSingle();
            Container.Bind<PlacementRuleCommand>().To<KoPlacementRuleCommand>().AsSingle();
            Container.Bind<PlacementRuleCommand>().To<EnoughLibertiesPlacementRuleCommand>().AsSingle();
        }
    }
}