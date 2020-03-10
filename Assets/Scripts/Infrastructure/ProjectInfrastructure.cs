public class ProjectInfrastructure
{
    private readonly MonoBehaviourContainer _monoBehaviourContainer;
    private readonly UIController _UIController;
    private readonly TargetCicleController _targetCicleController;
    private readonly KnifeController _knifeController;
    private readonly CoinBonusController _coinBonusController;
    private readonly GameplayController _gameplayController;

    
    public ProjectInfrastructure(MonoBehaviourContainer monoBehaviourContainer)
    {
        _monoBehaviourContainer = monoBehaviourContainer;
        _UIController = new UIController(monoBehaviourContainer.UIView);
        _targetCicleController = new TargetCicleController(monoBehaviourContainer.TargetCicleFactory);
        _knifeController = new KnifeController(monoBehaviourContainer.KnifeFactory);
        _coinBonusController = new CoinBonusController(monoBehaviourContainer.CoinBonusFactory);
        _gameplayController = new GameplayController(_UIController, _targetCicleController);
    }

    public void Start()
    {
        _UIController.Start();
        _targetCicleController.Start();
        _knifeController.Start();
        _gameplayController.Start();
    }

    public void Update(float deltaTime)
    {
        _targetCicleController.Update();
        _knifeController.Update();
        _gameplayController.Update(deltaTime);
    }
}
