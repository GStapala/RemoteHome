namespace RemoteHomePrism.Pages.WashMachine
{
    /// <summary>
    ///     Wash machine page
    /// </summary>
    public partial class WashMachine
    {
        public WashMachine()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            nControl.ShowAnimation = true;
            nControlImage.ShowAnimation = true;
            optionsGrid.ShowAnimation = true;
        }
    }
}