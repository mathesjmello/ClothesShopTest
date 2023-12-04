
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class OutfitController : MonoBehaviour
    {
        public List<RuntimeAnimatorController> outfits = new List<RuntimeAnimatorController>();
        public RuntimeAnimatorController selectedOutfit;
        public Animator outfitAnimator;


        private void Awake()
        {
            selectedOutfit = outfits[0];
            outfitAnimator.runtimeAnimatorController = selectedOutfit;
        }

        public void ChangeOutfit(int i)
        {
            selectedOutfit = outfits[i];
            outfitAnimator.runtimeAnimatorController = selectedOutfit;
        }
    }
}
