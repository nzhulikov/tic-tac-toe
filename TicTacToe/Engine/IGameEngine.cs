using TicTacToe.Engine.Models.Board;
using TicTacToe.Engine.Players;

namespace TicTacToe.Engine
{
    internal interface IGameEngine
    {
        IGameBoard NewGame();
        PlayResponse Play(PlayRequest request);
    }
}
