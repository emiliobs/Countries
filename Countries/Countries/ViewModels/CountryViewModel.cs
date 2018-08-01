namespace Countries.ViewModels
{
    using Models;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class CountryViewModel : BaseViewModel
    {
        #region Atributes
        private ObservableCollection<Border> borders;
        #endregion

        #region Properties

        public ObservableCollection<Border> Borders
        {
            get => borders;
            set
            {
                if (borders != value)
                {
                    borders = value;
                    OnPropertyChanged();
                }
            }
        }
        public Countries Country { get; set; }
        #endregion

        #region Contructors
        public CountryViewModel(Countries country)
        {
            Country = country;
            LoadBorders();
        }

        #endregion

        #region Methods

        private void LoadBorders()
        {
            Borders = new ObservableCollection<Border>();

            foreach (var border in Country.Borders)
            {
                var country = MainViewModel.GetInstance().countriesList
                                           .Where(l => l.Alpha3Code.Equals(border)).FirstOrDefault();

                if (country != null)
                {

                    Borders.Add(new Border
                    {
                       Code = country.Alpha3Code,
                       Name = country.Name,

                    });

                }
            }

        }

        #endregion
    }
}
