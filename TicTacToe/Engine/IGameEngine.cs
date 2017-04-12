using TicTacToe.Engine.Models.Board;
using TicTacToe.Engine.Players;

namespace TicTacToe.Engine
{
    internal interface IGameEngine
    {
        IGameBoard NewGame(int boardLength);
        PlayResponse Play(PlayRequest request);
    }
}
