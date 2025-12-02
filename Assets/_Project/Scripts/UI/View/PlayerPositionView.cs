using MVVM;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.UI.View
{
    public class PlayerPositionView : MonoBehaviour
    {
        [Data("Position")]
        public TMP_Text PositionText;
    }
}