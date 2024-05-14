using UnityEngine;

[CreateAssetMenu(fileName = "New Planet", menuName = "SolarSystem/Planet")]
public class Planet : ScriptableObject
{
    public Solar solar;
    [TextArea(3, 10)]
    public string description;
    public Sprite image;
}
