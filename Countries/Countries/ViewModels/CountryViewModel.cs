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
        private ObservableCollection<Currency> currencies;
        private ObservableCollection<Language> languages;
        #endregion

        #region Properties

        public ObservableCollection<Language> Languages
        {
            get => languages;
            set
            {
                if (languages != value)
                {
                    languages = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Currency> Currencies
        {
            get => currencies;
            set
            {
                if (currencies != value)
                {
                    currencies = value;
                    OnPropertyChanged();
                }
            }
        }

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
            Currencies = new ObservableCollection<Currency>(Country.Currencies);
            Languages = new ObservableCollection<Language>(Country.Languages);
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
