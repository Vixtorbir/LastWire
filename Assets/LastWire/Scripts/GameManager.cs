using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState { Menu, Playing, Won, Lost }

    public float startTime = 180f;
    public int maxStrikes = 3;
    public int modulesToSolve = 3;

    public UnityEvent onGameStart;
    public UnityEvent onStrike;
    public UnityEvent onModuleSolved;
    public UnityEvent onWin;
    public UnityEvent onLose;

    public GameState State { get; private set; } = GameState.Menu;
    public float TimeLeft { get; private set; }
    public int Strikes { get; private set; }
    public int SolvedModules { get; private set; }

    void Start()
    {
        TimeLeft = startTime;
    }

    void Update()
    {
        if (State != GameState.Playing) return;

        TimeLeft -= Time.deltaTime;
        if (TimeLeft <= 0f)
        {
            TimeLeft = 0f;
            Lose();
        }
    }

    public void StartGame()
    {
        if (State != GameState.Menu) return;
        State = GameState.Playing;
        onGameStart.Invoke();
    }

    public void AddStrike()
    {
        if (State != GameState.Playing) return;
        Strikes++;
        onStrike.Invoke();
        if (Strikes >= maxStrikes) Lose();
    }

    public void ModuleSolved()
    {
        if (State != GameState.Playing) return;
        SolvedModules++;
        onModuleSolved.Invoke();
        if (SolvedModules >= modulesToSolve)
        {
            State = GameState.Won;
            onWin.Invoke();
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Lose()
    {
        State = GameState.Lost;
        onLose.Invoke();
    }
}
