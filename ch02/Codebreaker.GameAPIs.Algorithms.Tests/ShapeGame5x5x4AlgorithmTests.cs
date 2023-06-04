using System.Collections;

using Codebreaker.GameAPIs.Extensions;
using Codebreaker.GameAPIs.Models;

using static Codebreaker.GameAPIs.Models.Colors;
using static Codebreaker.GameAPIs.Models.Shapes;

namespace Codebreaker.GameAPIs.Algorithms.Tests;

// TODO: add more unit tests
public class ShapeGame5x5x4AlgorithmTests
{
    [Fact]
    public void SetMoveWithThreeBlue()
    {
        ShapeAndColorResult expectedKeyPegs = new(0, 3, 0);
        ShapeAndColorResult? resultKeyPegs = TestSkeleton(
            new ShapeAndColorField[] { (Shapes.Rectangle, Green), (Circle, Yellow), (Shapes.Rectangle, Green), (Star, Blue) },
            new ShapeAndColorField[] { (Circle, Yellow), (Shapes.Rectangle, Green), (Star, Blue), (Square, Purple)  }
        );

        Assert.Equal(expectedKeyPegs, resultKeyPegs);
    }

    //[InlineData(1, 2, Red, Yellow, Red, Blue)]
    //[InlineData(2, 0, White, White, Blue, Red)]
    //[Theory]
    //public void SetMoveUsingVariousData(int expectedBlack, int expectedWhite, params string[] guessValues)
    //{
    //    string[] code = new[] { Red, Green, Blue, Red };
    //    ColorResult expectedKeyPegs = new (expectedBlack, expectedWhite);
    //    ColorResult resultKeyPegs = TestSkeleton(code, guessValues);
    //    Assert.Equal(expectedKeyPegs, resultKeyPegs);
    //}

    //[Theory]
    //[ClassData(typeof(TestData6x4))]
    //public void SetMoveUsingVariousDataUsingDataClass(string[] code, string[] guess, ColorResult expectedKeyPegs)
    //{
    //    ColorResult actualKeyPegs = TestSkeleton(code, guess);
    //    Assert.Equal(expectedKeyPegs, actualKeyPegs);
    //}

    //[Fact]
    //public void ShouldThrowOnInvalidGuessCount()
    //{
    //    Assert.Throws<ArgumentException>(() =>
    //    {
    //        TestSkeleton(
    //            new[] { "Black", "Black", "Black", "Black" },
    //            new[] { "Black" }
    //        );
    //    });
    //}

    //[Fact]
    //public void ShouldThrowOnInvalidGuessValues()
    //{
    //    Assert.Throws<ArgumentException>(() =>
    //    {
    //        TestSkeleton(
    //            new[] { "Black", "Black", "Black", "Black" },
    //            new[] { "Black", "Der", "Blue", "Yellow" }      // "Der" is the wrong value
    //        );
    //    });
    //}

    private static ShapeAndColorResult TestSkeleton(ShapeAndColorField[] codes, ShapeAndColorField[] guesses)
    {
        MockShapeGame game = new()
        {
            GameType = GameTypes.Game5x5x4,
            Holes = 4,
            MaxMoves = 14,
            Won = false,
            Fields = new List<ShapeAndColorField>() { (Shapes.Rectangle, Red), (Circle, Blue), (Star, Yellow), (Triangle, Green), (Square, Purple) },
            Codes = new List<ShapeAndColorField>(codes)
        };

        MockShapeMove move = new()
        {
            MoveNumber = 1,
            GuessPegs = new List<ShapeAndColorField>(guesses)
        };

        var guessPegs = new List<ShapeAndColorField>(guesses);

        game.ApplyMove(guessPegs, 1);

        return game.Moves.First().KeyPegs ?? throw new InvalidOperationException();
    }
}

public class TestData5x5x4 : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new string[] { Green, Blue,  Green, Yellow }, // code
            new string[] { Green, Green, Black, White },  // inputdata
            new ColorResult(1, 1) // expected
        };
        yield return new object[]
        {
            new string[] { Red,   Blue,  Black, White },
            new string[] { Black, Black, Red,   Yellow },
            new ColorResult(0, 2)
        };
        yield return new object[]
        {
            new string[] { Yellow, Black, Yellow, Green },
            new string[] { Black,  Black, Black,  Black },
            new ColorResult(1, 0)
        };
        yield return new object[]
        {
            new string[] { Yellow, Yellow, White, Red },
            new string[] { Green,  Yellow, White, Red },
            new ColorResult(3, 0)
        };
        yield return new object[]
        {
            new string[] { White, Black, Yellow, Black },
            new string[] { Black, Blue,  Black,  White },
            new ColorResult(0, 3)
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}