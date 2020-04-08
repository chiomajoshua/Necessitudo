using Xamarin.Forms;

namespace Necessitudo.AttachedProperties
{
    public class LetterSpacingEffect : RoutingEffect
    {
        public LetterSpacingEffect() : base("Necessitudo.LetterSpacingEffect")
        {

        }

        public float LetterSpace
        {
            get;
            set;
        }
    }
}