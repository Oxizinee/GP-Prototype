using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace IMPossible.UI.Dragging
{
    /// Allows a UI element to be dragged and dropped from and to a container.
    /// 
    /// Create a subclass for the type you want to be draggable. Then place on
    /// the UI element you want to make draggable.
    /// 
    /// During dragging, the item is reparented to the parent canvas.
    /// 
    /// After the item is dropped it will be automatically return to the
    /// original UI parent. It is the job of components implementing `IDragContainer`,
    /// `IDragDestination and `IDragSource` to update the interface after a drag
    /// has occurred.
    
    public class DragItem<T> : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
        where T : class
    {
        // PRIVATE STATE
        Vector3 startPosition;
        Transform originalParent;
        IDragSource<T> source;

        // CACHED REFERENCES
        Canvas parentCanvas;

        // LIFECYCLE METHODS

        private void Start()
        {
            parentCanvas = FindFirstObjectByType<Canvas>();
            source = GetComponentInParent<IDragSource<T>>();
        }
        // PRIVATE
        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            startPosition = transform.position;
            originalParent = transform.parent;
            // Else won't get the drop event.
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            transform.SetParent(parentCanvas.transform, true);
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            transform.position = startPosition;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            transform.SetParent(originalParent, true);
            transform.SetSiblingIndex(0);

            IDragDestination<T> container;
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                container = parentCanvas.GetComponent<IDragDestination<T>>();
            }
            else
            {
                container = GetContainer(eventData);
            }

            if (container != null)
            {
                DropItemIntoContainer(container);
            }

            
        }

        private IDragDestination<T> GetContainer(PointerEventData eventData)
        {
            if (eventData.pointerEnter)
            {
                var container = eventData.pointerEnter.GetComponentInParent<IDragDestination<T>>();

                return container;
            }
            return null;
        }

        private void DropItemIntoContainer(IDragDestination<T> destination)
        {
            //check if you droped the item on itself if so return
            if (object.ReferenceEquals(destination, source)) return;

            var destinationContainer = destination as IDragContainer<T>;
            var sourceContainer = source as IDragContainer<T>;

            // Swap won't be possible
            if (destinationContainer == null || sourceContainer == null || 
                destinationContainer.GetItem() == null || 
                object.ReferenceEquals(destinationContainer.GetItem(), sourceContainer.GetItem()))
            {
                AttemptSimpleTransfer(destination);
                return;
            }

            AttemptSwap(destinationContainer, sourceContainer);
        }


        private void AttemptSwap(IDragContainer<T> destination, IDragContainer<T> source)
        {
            // Provisionally remove item from both sides. 
            var removedSourceItem = source.GetItem();
            var removedDestinationItem = destination.GetItem();

            source.RemoveItem();
            destination.RemoveItem();

            // Do swaps
           
                source.AddItem(removedDestinationItem);
                destination.AddItem(removedSourceItem);
        }

        private bool AttemptSimpleTransfer(IDragDestination<T> destination)
        {
            var draggingItem = source.GetItem();

            var acceptable = destination.MaxAcceptable(draggingItem);
            var toTransfer = Mathf.Min(acceptable, 1);

            if (toTransfer > 0)
            {
                source.RemoveItem();
                destination.AddItem(draggingItem);

                return false;
            }

            return true;
        }

    }

}
