﻿using Codebreaker.GameAPIs.Contracts;

namespace Codebreaker.GameAPIs.Models;

public abstract class Move(Guid gameId, Guid moveId, int moveNumber)
{
    public Guid GameId { get; private set; } = gameId;
    public Guid MoveId { get; private set; } = moveId;
    public int MoveNumber { get; init; } = moveNumber;

    public override string ToString() => $"{GameId}: {MoveNumber}";
}

public class Move<TField, TResult>(Guid gameId, Guid moveId, int moveNumber)
    : Move(gameId, moveId, moveNumber), IFormattable, IMove<TField, TResult>
    where TResult: struct
    where TField : IParsable<TField>
{
    public required ICollection<TField> GuessPegs { get; init; }
    public required TResult? KeyPegs { get; init; }

    public string ToString(string? format = default, IFormatProvider? formatProvider = default) =>
        $"{MoveNumber}, {string.Join(".", GuessPegs)}";

    public override string ToString() => ToString(null, null);
}