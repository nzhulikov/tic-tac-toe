using TicTacToe.Engine.VictoryValidators;

namespace TicTacToe.Engine.Players
{
    /// <summary>
    /// Интерфейс игрока
    /// </summary>
    internal interface IPlayer
    {
        /// <summary>
        /// Отметка игрока
        /// </summary>
        Enums.MarkType Mark { get; set; }

        /// <summary>
        /// Сыграть на поле
        /// </summary>
        /// <param name="request">Запрос хода</param>
        /// <returns>Ответный ход</returns>
        PlayResponse Play(PlayRequest request, IVictoryValidator victoryValidator);

        /// <summary>
        /// Проверить, сможет ли игрок сделать ход
        /// </summary>
        /// <param name="request">Запрос хода</param>
        /// <returns>Возвращает true, если игрок сможет сделать ход</returns>
        bool CanPlay(PlayRequest request);
    }
}
