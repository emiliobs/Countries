namespace Countries.Infrastructure
{
    using Countries.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InstanceLocator
    {

        #region Properties

        public MainViewModel Main { get; set; }

        #endregion

        #region Constructors

        public InstanceLocator()
        {
            Main = new MainViewModel();
        }

        #endregion



    }
}
