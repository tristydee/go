using System;
using System.Collections.Generic;
using Logic;
using Logic.AI;
using Logic.Rules;
using Logic.Scoring;
using UnityEngine;

namespace Configs
{
    public class Config : MonoBehaviour
    {
        public Settings Settings;
        public Assets Assets;

        public ScoringCommand ScoringCommand;
        public MoveSelector MoveSelector;
        public List<PlacementRuleCommand> PlacementRules;

        public void CreateInstances(Game game)
        {
            MoveSelector = (MoveSelector)Activator.CreateInstance(typeof(RandomMoveSelector));
            ScoringCommand = (ScoringCommand)Activator.CreateInstance(typeof(AreaScoringCommand), game);
            PlacementRules = new List<PlacementRuleCommand>()
            {
                new CellIsEmptyPlacementRuleCommand(),
                new KoPlacementRuleCommand(),
                new EnoughLibertiesPlacementRuleCommand(),
            };
        }
    }
}