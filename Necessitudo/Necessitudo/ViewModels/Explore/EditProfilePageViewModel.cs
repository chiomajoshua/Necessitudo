using Necessitudo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Necessitudo.ViewModels.Explore
{
    public class EditProfilePageViewModel : BaseViewModel
    {
        public EditProfilePageViewModel()
        {
            ListAges = PickerService.GetAges().OrderBy(c => c.Value).ToList();
        }
        #region AgePickerItem

        public List<Age> ListAges
        {
            get;
            set;
        }

        private Age _selectedAge;
        public Age SelectedAge
        {
            get
            {
                return _selectedAge;
            }
            set
            {
                SetProperty(ref _selectedAge, value);
                AgeText = _selectedAge.Value;
            }
        }
        private string _ageText;
        public string AgeText
        {
            get
            {
                return _ageText;
            }
            set
            {
                SetProperty(ref _ageText, value);
            }
        }
        #endregion
    }
}
