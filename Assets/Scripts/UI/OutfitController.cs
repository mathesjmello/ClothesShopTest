using System;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace UI
{
    public class OutfitController : MonoBehaviour
    {
        public List<AnimatorController> outfits = new List<AnimatorController>();
        public AnimatorController selectedOutfit;
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
