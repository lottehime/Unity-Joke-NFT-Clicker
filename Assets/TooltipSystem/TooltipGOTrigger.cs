using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions
{
    public class TooltipGOTrigger : MonoBehaviour
    {
        [TextAreaAttribute]
        public string text;

        public Sprite tooltipIcon;

        public bool useMousePosition = false;

        public Vector3 offset;

        public void OnMouseOver()
        {
            if (useMousePosition)
            {
                StartHover(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            }
            else
            {
                StartHover(Input.mousePosition + offset);
            }
        }


        public void OnMouseExit()
        {
            StopHover();
        }

        //public void OnSelect(BaseEventData eventData)
        //{
        //    StartHover(transform.position);
        //}
        //
        //public void OnDeselect(BaseEventData eventData)
        //{
        //    StopHover();
        //}

        void StartHover(Vector3 position)
        {
            var image = tooltipIcon;
            TooltipView.Instance.ShowTooltip(text, position, image);
        }

        void StopHover()
        {
            TooltipView.Instance.HideTooltip();
        }
    }
}