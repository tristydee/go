using Common;
using Logic;
using UnityEngine;
using Zenject;

public class Main : MonoBehaviour
{
    [Inject] private DiContainer container;
    
    private async void Start()
    {
        var game = new GenerateBoardCommand().Inject(container).Execute();
        new InitLogicCommand(game).Inject(container).Execute();
        await new RunGameCommandAsync(game).Inject(container).Execute();
        new EndGameCommand().Inject(container).Execute();
    }
}