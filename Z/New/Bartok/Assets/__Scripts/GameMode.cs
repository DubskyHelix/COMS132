using UnityEngine;
using UnityEngine.UI;

public class GameMode : PersistentGameObjectSingleton<GameMode>
{
    public enum Mode
    {
        classic,
        matchRank,
        facesWild,
        rankPlusMinus
    };

    private Mode state = Mode.classic;

    public Mode State
    {
        get
        {
            return state;
        }

        private set
        {
            state = value;
            Debug.Log("GameMode: state set to " + state);
        }
    }

    public void UpdateStateFromUI()
    {
        State = (Mode)FindObjectOfType<Dropdown>().value;
    }
}
