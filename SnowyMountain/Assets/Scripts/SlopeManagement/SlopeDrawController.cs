using System.Collections.Generic;
using UnityEngine;

namespace SnowyMountain.SlopeManagment
{
    public class SlopeDrawController : MonoBehaviour
    {
        [field: Header("Slope variants")]
        [field: SerializeField]
        private List<Slope> DefaultSlopeVariantCollection { get; set; } = new();

        [field: Header("Cliff slope variants")]
        [field: SerializeField]
        private Slope LeftCliffSlopeVariant { get; set; }
        [field: SerializeField]
        private Slope RightCliffSlopeVariant { get; set; }

        private Slope DrawSlope { get; set; }

        public SlopeType DrawSlopeVariant (SlopeType lastType)
        {
            switch (lastType)
            {
                case SlopeType.LEFT_START_CLIFF:
                    DrawSlope = LeftCliffSlopeVariant;
                    break;
                case SlopeType.RIGHT_START_CLIFF:
                    DrawSlope = RightCliffSlopeVariant;
                    break;
                default:
                    int randomIndex = Random.Range(0, DefaultSlopeVariantCollection.Count);
                    DrawSlope = DefaultSlopeVariantCollection[randomIndex];
                    break;
            }

            DrawSlope.gameObject.SetActive(true);
            return DrawSlope.Type;
        }

        protected virtual void OnDisable ()
        {
            DeactiveDrawSlope();
        }

        private void DeactiveDrawSlope ()
        {
            if (DrawSlope != null)
            {
                DrawSlope.gameObject.SetActive(false);
            }
        }
    }
}