public class TargetCicleController 
{
    private readonly TargetCicleView _targetCicleView;
    private readonly Pool<TargetCicleView> _targetCiclePool;
    private TargetCicleFactory _cicleFactory;
    private float _speedRotation = 100f;

    public TargetCicleController (TargetCicleFactory _cicleFactory)
    {
        _targetCiclePool = new Pool<TargetCicleView>(_cicleFactory);
        _targetCicleView = _targetCiclePool.GetObject();     
    }
    public void Start()
    {

    }

    public void Update()
    {
        _targetCicleView.Rotate(_speedRotation);
    }
}
