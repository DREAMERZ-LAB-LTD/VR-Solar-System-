using UnityEngine;

[CreateAssetMenu(fileName = "New Solar System", menuName = "SolarSystem/SolarSystemData")]
public class SolarSystemData : ScriptableObject
{
    [System.Serializable]
    public class PlanetInfo
    {
        public Solar solar;
        [TextArea(3, 10)]
        public string description;
        public GameObject PlaneObj;
        public float Speed;
        public AudioClip _audioClip;
    }

    public PlanetInfo[] planets;

    
}
