using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Firebase_Chat.Helpers
{
    static class SafeObservableColletion
    {
        public static void SafeClear<T>(this ObservableCollection<T> observableCollection)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                observableCollection.Clear();
            });
        }

        public static void TSafeClear<T>(this ICollection<T> Collection)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Collection.Clear();
            });
        }
    }
}
