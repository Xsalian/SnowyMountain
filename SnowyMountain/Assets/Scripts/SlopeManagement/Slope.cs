using UnityEngine;

namespace SnowyMountain.SlopeManagment
{
    public class Slope : MonoBehaviour
    {
        [field: SerializeField]
        public SlopeType Type { get; private set; }
    }
}