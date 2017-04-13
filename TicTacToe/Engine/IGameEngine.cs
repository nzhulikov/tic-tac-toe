using TicTacToe.Engine.Enums;
using TicTacToe.Engine.Models.Board;
using TicTacToe.Engine.Players;

namespace TicTacToe.Engine
{
    public delegate void MoveCompletedHandler(int row, int col, MarkType newMark);
    public delegate void GameOverHandler(GameState state, MarkType winner);

    /// <summary>
    /// Интерфейс игровой логики
    /// </summary>
    internal interface IGameEngine
    {
        /// <summary>
        /// Событие изменения игрового поля
        /// </summary>
        event MoveCompletedHandler BoardChanged;

        /// <summary>
        /// Событие окончания игры
        /// </summary>
        event GameOverHandler GameOver;

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
