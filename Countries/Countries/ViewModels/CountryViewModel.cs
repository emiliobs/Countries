namespace Countries.ViewModels
{
    using Models;
    public class CountryViewModel
    {
        #region Properties
        public Countries Country { get; set; }
        #endregion

        #region Contructors
        public CountryViewModel(Countries country)
        {
            Country = country;
        } 
        #endregion
    }
}
