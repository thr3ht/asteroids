using MVVM;
using UnityEngine;

namespace _Project.Scripts.UI.View
{
    public class PlayerHealthView : MonoBehaviour
    {
        [Data("Health")]
        public GameObject[] HealthObject;
    }
}