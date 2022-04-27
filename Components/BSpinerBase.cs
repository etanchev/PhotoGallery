using Microsoft.AspNetCore.Components;


namespace PhotoGallery.Components
{
    public class BSpinerBase : ComponentBase
    {

        [Parameter]
        public bool IsVisible { get; set; } 

        public  void Show()
        {
            IsVisible = true;
            StateHasChanged();
        }
        public  void Hide()
        {
            IsVisible = false;
            StateHasChanged();
        }
    }
}
