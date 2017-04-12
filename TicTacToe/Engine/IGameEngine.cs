using TicTacToe.Engine.Models.Board;
using TicTacToe.Engine.Players;

namespace TicTacToe.Engine
{
    /// <summary>
    /// Интерфейс игровой логики
    /// </summary>
    internal interface IGameEngine
    {
        /// <summary>
        /// Создать новую игру
        /// </summary>
        /// <returns>Новое игровое поле</returns>
        IGameBoard NewGame();

        /// <summary>
        /// Сыграть ход
        /// </summary>
        /// <param name="request">Запрос хода</param>
        /// <returns>Ответ на запрос</returns>
        PlayResponse Play(PlayRequest request);
    }
}
