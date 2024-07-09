namespace MyMauiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // 새로운 페이지 라우팅 추가
            Routing.RegisterRoute(nameof(DigitsPage), typeof(DigitsPage));
            Routing.RegisterRoute(nameof(OmokGamePage), typeof(OmokGamePage));
        }
    }
}
