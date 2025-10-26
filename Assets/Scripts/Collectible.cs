using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Collectible Settings")]
    public AudioClip collectSound;      // sound to play when collected
    public Color collectibleColor;      // color of this object

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = collectibleColor;
    }
}
