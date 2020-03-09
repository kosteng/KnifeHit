using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController 
{
    private readonly UIController _UIController;
    private readonly TargetCicleController _targetCicleController;

    public GameplayController (UIController UIController, TargetCicleController targetCicleController)
    {
        _UIController = UIController;
        _targetCicleController = targetCicleController;
    }

    public void Start ()
    {

    }

    public void Update (float deltaTime)
    {

    }
}
