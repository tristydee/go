using Common;
using Logic;
using UnityEngine;
using Zenject;

public class Main : MonoBehaviour
{

    private Game game;

    private async void Start()
    {

        game = new GenerateBoardCommand().Execute();
        new InitLogicCommand(game).Execute();

        await new RunGameCommandAsync(game).Execute();
        new EndGameCommand().Execute();
    }
}