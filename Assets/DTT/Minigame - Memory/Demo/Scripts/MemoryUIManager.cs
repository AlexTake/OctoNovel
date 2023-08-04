using DTT.MinigameMemory;
using DTT.MinigameMemory.Demo;
using UnityEngine;
using Naninovel;

//using CustomVariableSetter;


/// <summary>
/// Manages the UI for the memory game.
/// </summary>
public class MemoryUIManager : MonoBehaviour
{
    /// <summary>
    /// Used to get the state of the game.
    /// </summary>
    [SerializeField] private MemoryGameManager _gameManager;


    //public CustomVariableSetter _setter;
    /// <summary>
    /// <see cref="FinishedMenu"/> used to display the game results.
    /// </summary>
    [SerializeField] private FinishedMenu _finishedMenu;

    /// <summary>
    /// Subscrive to game events.
    /// </summary>
    private void OnEnable()
    {
        _gameManager.Started += SetFinisedMenuInactive;
        _gameManager.Finish += SetFinisedMenuActive;

        _finishedMenu._homeButton.onClick.AddListener(Home);
    }

    /// <summary>
    /// Unsubscrive from game events.
    /// </summary>
    private void OnDisable()
    {
        _gameManager.Started -= SetFinisedMenuInactive;
        _gameManager.Finish -= SetFinisedMenuActive;
    }

    public void SetResult(MemoryGameResults results)
    {
        ICustomVariableManager variableManager = Engine.GetService<ICustomVariableManager>();

        variableManager.SetVariableValue("MiniGameResult", results.timeTaken.Seconds > 15 ? "0" : "1");
        var a = variableManager.GetVariableValue("MiniGameResult");
        Debug.Log(a);
    }

    /// <summary>
    /// Sets the active state of the <see cref="FinishedMenu"/> gameobject to active.
    /// </summary>
    /// <param name="results">Results to be shown on the _finishedMenu.</param>
    private void SetFinisedMenuActive(MemoryGameResults results)
    {
        SetResult(results);
        _finishedMenu.SetResultText(results);

        _finishedMenu.gameObject.SetActive(true);
    }

    /// <summary>
    /// Sets the active state of the <see cref="FinishedMenu"/> gameobject to inactive.
    /// </summary>
    private void SetFinisedMenuInactive() => _finishedMenu.gameObject.SetActive(false);

    /// <summary>
    /// Show home menu.
    /// </summary>
    private void Home()
    {
        Hide();
        _gameManager.Stop();
    }

    /// <summary>
    /// Restart the game.
    /// </summary>
    private void Restart()
    {
        Hide();
        _gameManager.Restart();
    }

    /// <summary>
    /// Hide menu UI.
    /// </summary>
    private void Hide()
    {
        SetFinisedMenuInactive();
    }
}