using TicTacToe.Engine.Enums;
using TicTacToe.Engine.Models.Board;
using TicTacToe.Engine.Players;

namespace TicTacToe.Engine
{
    /// <summary>
    /// Делегат обработки события совершенного хода
    /// </summary>
    /// <param name="row">Строка с новой отметкой</param>
    /// <param name="col">Столбец с новой отметкой</param>
    /// <param name="newMark">Новая отметка</param>
    public delegate void MoveCompletedHandler(int row, int col, MarkType newMark);

    /// <summary>
    /// Делегат обработки события завершенной игры
    /// </summary>
    /// <param name="state">Исход игры</param>
    /// <param name="winner">Победитель. Принимает значение MarkType.None, если победителя нет.</param>
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
