using System.Collections.Generic;

public enum MovementState {
    LEFT_WALK,
    UP_WALK,
    RIGHT_WALK,
    DOWN_WALK,
    STAND
}

public static class MovementStateExtensions {
    private static readonly Dictionary<MovementState, string> MovementStateStrings = new Dictionary<MovementState, string>
    {
        { MovementState.LEFT_WALK, "left_walk" },
        { MovementState.UP_WALK, "up_walk" },
        { MovementState.RIGHT_WALK, "right_walk" },
        { MovementState.DOWN_WALK, "down_walk" },
        { MovementState.STAND, "stand" }
    };

    public static string ToFriendlyString(this MovementState state)
    {
        return MovementStateStrings[state];
    }
}