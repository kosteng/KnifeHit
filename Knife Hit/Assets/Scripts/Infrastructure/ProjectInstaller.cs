using UnityEngine;

public class ProjectInstaller : MonoBehaviour
{
    [SerializeField] private MonoBehaviourContainer _monoBehaviourContainer;

    private ProjectInfrastructure _infrastructure;

    private void Awake()
    {
        _infrastructure = new ProjectInfrastructure(_monoBehaviourContainer);
    }

    private void Start()
    {
        _infrastructure.Start();
    }
    private void Update()
    {
        _infrastructure.Update(Time.deltaTime);
    }
}
