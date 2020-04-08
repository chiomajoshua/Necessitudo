using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Necessitudo.AttachedProperties
{
    public class ControlProperties
    {
        public static readonly BindableProperty LetterSpaceProperty =
            BindableProperty.CreateAttached("LetterSpace", typeof(float), typeof(ControlProperties), (float)0, propertyChanged: HandleLetterSpaceChanged);

        public static float GetLetterSpace(BindableObject view)
        {
            return (float)view.GetValue(LetterSpaceProperty);
        }
        public static void SetLetterSpace(BindableObject view, float value)
        {
            view.SetValue(LetterSpaceProperty, value);
        }


        public static void HandleLetterSpaceChanged(BindableObject control, object oldValue, object newValue)
        {
            var view = control as Label;
            if (view.Effects?.Any(a => a is LetterSpacingEffect) == true)
            {
                view.Effects.Remove(view.Effects.Where(a => a is LetterSpacingEffect).FirstOrDefault());
            }


            view.Effects.Add(new LetterSpacingEffect { LetterSpace = (float)newValue });
        }




        public static readonly BindableProperty CompletedCommandProperty =
            BindableProperty.CreateAttached("CompletedCommand", typeof(ICommand), typeof(ControlProperties), null, propertyChanged: HandleCompletedCommandChanged);

        public static ICommand GetCompletedCommand(BindableObject view)
        {
            return (ICommand)view.GetValue(CompletedCommandProperty);
        }
        public static void SetCompletedCommand(BindableObject view, ICommand value)
        {
            view.SetValue(CompletedCommandProperty, value);
        }


        public static void HandleCompletedCommandChanged(BindableObject control, object oldValue, object newCommand)
        {
            Entry view = control as Entry;
            ICommand com = newCommand as ICommand;
            view.Completed += (sender, e) => com.Execute(view.Text);
            view.Unfocused += (sender, e) => com.Execute(view.Text);
        }


        public static readonly BindableProperty PickerSelectedItemProperty =
            BindableProperty.CreateAttached("PickerSelectedItem", typeof(object), typeof(ControlProperties), null, propertyChanged: HandlePickerSelectedItemChanged);


        public static object GetPickerSelectedItem(BindableObject view)
        {
            return view.GetValue(CompletedCommandProperty);
        }
        public static void SetPickerSelectedItem(BindableObject view, object value)
        {
            view.SetValue(CompletedCommandProperty, value);
        }

        public static void HandlePickerSelectedItemChanged(BindableObject control, object oldValue, object newValue)
        {
            Picker view = control as Picker;

            if (oldValue != null) return;
            view.PropertyChanged += async (sender, e) =>
            {

                if (e.PropertyName == "ItemsSource")
                {
                    int i = 0;
                    foreach (var item in view.ItemsSource)
                    {
                        if (await CompareAsync(item, newValue))
                        {
                            view.SelectedIndex = i;
                            break;
                        }
                        i++;
                    }
                }
            };
        }


        private async static Task<bool> CompareAsync(object obj1, object obj2)
        {
            return await Task.Run(() =>
            {
                if (obj1 == null || obj2 == null) return false;
                return RemoveBadChars(Newtonsoft.Json.JsonConvert.SerializeObject(obj1).ToLower()) == RemoveBadChars(Newtonsoft.Json.JsonConvert.SerializeObject(obj2).ToLower());
            });
        }




        public static string RemoveBadChars(string word)
        {
            Regex badChars = new Regex("[^A-Za-z']");
            return badChars.Replace(word, "");
        }


    }
}
