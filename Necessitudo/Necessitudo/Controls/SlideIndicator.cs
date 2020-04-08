using Xamarin.Forms;

namespace Necessitudo.Controls
{
    public class SlideIndicator : StackLayout
    {
        public SlideIndicator()
        {
            Orientation = StackOrientation.Horizontal;
            Spacing = 5;
        }

        private void InitChildren()
        {
            this.Children.Clear();
            for (int i = 0; i < Items; i++)
            {
                if (i == Active)
                {
                    Children.Add(new BoxView { WidthRequest = 10, HeightRequest = 5, Color = ActiveColor, HorizontalOptions = LayoutOptions.Center });
                }
                else
                {
                    Children.Add(new BoxView { WidthRequest = 10, HeightRequest = 5, Color = DefaultColor, HorizontalOptions = LayoutOptions.Center });
                }
            }
        }

        private void MakeActive()
        {
            if (Active >= Children.Count) return;
            int cur = 0;
            foreach (BoxView child in Children)
            {
                if (cur == Active) child.Color = ActiveColor;
                else child.Color = DefaultColor;
                cur++;
            }
        }

        public static readonly BindableProperty ActiveColorProperty = BindableProperty.Create(
            "ActiveColor", typeof(Color), typeof(SlideIndicator), Color.Red, propertyChanged: OnActiveColorChanged);

        static void OnActiveColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var obj = bindable as SlideIndicator;
            obj.InitChildren();
        }

        public Color ActiveColor
        {
            get { return (Color)GetValue(ActiveColorProperty); }
            set { SetValue(ActiveColorProperty, value); }
        }


        public static readonly BindableProperty DefaultColorProperty = BindableProperty.Create(
            "DefaultColor", typeof(Color), typeof(SlideIndicator), Color.White, propertyChanged: OnDefaultColorChanged);

        static void OnDefaultColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var obj = bindable as SlideIndicator;
            obj.InitChildren();
        }

        public Color DefaultColor
        {
            get { return (Color)GetValue(DefaultColorProperty); }
            set { SetValue(DefaultColorProperty, value); }
        }

        public static readonly BindableProperty ActiveProperty = BindableProperty.Create(
            "Active", typeof(int), typeof(SlideIndicator), 0, propertyChanged: OnActiveChanged);

        static void OnActiveChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var obj = bindable as SlideIndicator;
            obj.MakeActive();
        }

        public int Active
        {
            get { return (int)GetValue(ActiveProperty); }
            set { SetValue(ActiveProperty, value); }
        }

        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(
            "Items", typeof(int), typeof(SlideIndicator), 0, propertyChanged: OnItemsChanged);

        static void OnItemsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var obj = bindable as SlideIndicator;
            obj.InitChildren();
        }

        public int Items
        {
            get { return (int)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

    }
}