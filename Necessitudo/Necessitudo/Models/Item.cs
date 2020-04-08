using System;
using Xamarin.Forms;

namespace Necessitudo.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }

    public class SliderItem
    {
        public string Title
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }


        public string ImagePath
        {
            get;
            set;
        }
    }



    public class Step
    {
        public Image Icon { get; set; }
        public Label Title { get; set; }
        public BoxView[] Lines { get; set; }
        public StepType Type { get; set; }
    }


    public enum StepType
    {
        Personal, Social, Pictures, Interests
    }
}