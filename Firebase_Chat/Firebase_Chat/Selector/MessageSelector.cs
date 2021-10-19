using Firebase_Chat.Models;
using Firebase_Chat.ViewModel;
using Xamarin.Forms;

namespace Firebase_Chat.Selector
{
    public class MessageSelector : DataTemplateSelector
    {
        public DataTemplate SimpleTextSelector { get; set; }
        public DataTemplate InboundTextSelector { get; set; }

        ChatVM Chat;

        public MessageSelector()
        {
            Chat = DependencyService.Get<ChatVM>();
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (((MessageBase)item).Author == Chat.Author)
            {
                return SimpleTextSelector;
            }
            else
            {
                return InboundTextSelector;
            }
        }
    }
}
