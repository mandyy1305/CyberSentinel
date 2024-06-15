using UnityEngine;

public class Server : DefenceUnit
{
    private void OnDestroy()
    {
        ResourceManager.Instance.DecreaseServersRemaining();
    }
}
