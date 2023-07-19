using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions
{
    public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
    {
        [TextAreaAttribute]
        public string text;

        public bool useMousePosition = false;

        public Vector3 offset;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (useMousePosition)
            {
                StartHover(new Vector3(eventData.position.x, eventData.position.y, 0f));
            }
            else
            {
                StartHover(transform.position + offset);
            }
        }

        public void OnSelect(BaseEventData eventData)
        {
            StartHover(transform.position + offset);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            StopHover();
        }

        public void OnDeselect(BaseEventData eventData)
        {
            StopHover();
        }

        void StartHover(Vector3 position)
        {
            var image = GetComponent<Image>().sprite;
            TooltipView.Instance.ShowTooltip(text, position, image);
        }

        void StopHover()
        {
            TooltipView.Instance.HideTooltip();
        }
    }
}