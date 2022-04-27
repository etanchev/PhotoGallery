using Microsoft.AspNetCore.Components;


namespace PhotoGallery.Components
{
    public class CustomButtonBase  : ComponentBase
    {
        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public string FontSize { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter] 
        public EventCallback ButtonClick { get; set; }
    }


}

