using System;
using System.Collections.Generic;
using System.Linq;
using Logic.AI;
using Logic.Rules;
using Logic.Scoring;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "Settings", menuName = "ScriptableObjects/Configs/Settings")]
    public class Settings : ScriptableObject
    {
        public Vector2Int BoardSize;
        public float DelayBetweenMoves;
        
        public Type MoveSelector;
        public Type ScoringCommand;
        public List<PlacementRuleCommand> RuleCommands;
        
        //todo: should be a dropdown of the different possible types...
        [SerializeField] private string MoveSelectorType;
        [SerializeField] private string ScoringCommandType;
        [SerializeField] private List<string> RuleCommandTypes;

        private void Awake()
        {
            MoveSelector = Type.GetType(MoveSelectorType);
            ScoringCommand = Type.GetType(ScoringCommandType);
            //todo: want this to be rule commands and not types...
            // RuleCommands = RuleCommandTypes.Select(Type.GetType).ToList();
        }
    }
}