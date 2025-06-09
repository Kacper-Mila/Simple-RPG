namespace Simple_RPG.Interfaces;

/// <summary>
/// Represents an action that can be executed in the game.
/// <summary>
public interface IAction<out T>
{
    /// <summary>
    /// Executes the action.
    /// </summary>
    T Execute();

    /// <summary>
    /// Returns a description of the action.
    /// </summary>
    String Description();
}