namespace UnityEngine.UI.Extensions
{
    public class TooltipView : MonoBehaviour
    {
        public bool IsActive
        {
            get
            {
                return gameObject.activeSelf;
            }
        }

        public Text TooltipText;
        //public Image TooltipImage;
        public Vector3 ToolTipOffset;

        void Awake()
        {
            instance = this;
            if (!TooltipText) TooltipText = GetComponentInChildren<Text>();
            HideTooltip();
        }

        public void ShowTooltip(string text, Vector3 pos, Sprite image)
        {
            if (TooltipText.text != text)
                TooltipText.text = text;

            transform.position = pos + ToolTipOffset;
            //TooltipImage.sprite = image;

            gameObject.SetActive(true);
        }

        public void HideTooltip()
        {
            gameObject.SetActive(false);
        }

        // Standard Singleton Access
        private static TooltipView instance;
        public static TooltipView Instance
        {
            get
            {
                if (instance == null)
                    instance = FindObjectOfType<TooltipView>();
                return instance;
            }
        }
    }
}
