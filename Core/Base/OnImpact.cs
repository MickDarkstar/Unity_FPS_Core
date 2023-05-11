using UnityEngine;

public class OnImpact : MonoBehaviour, IHasImpactEffect
{
    [SerializeField]
    private GameObject impactEffect;

    public GameObject GetImpactEffect()
    {
        if (!impactEffect)
            Debug.LogError($"No impactEffect set in: {gameObject.name}");

        return impactEffect;
    }
}
