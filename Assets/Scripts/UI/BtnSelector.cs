using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BtnSelector : MonoBehaviour
    {
        public Button btn;

        public void ActBtn()
        {
            btn.Select();
        }
    }
}