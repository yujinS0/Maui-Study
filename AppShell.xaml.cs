namespace MyMauiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DigitsPage), typeof(DigitsPage)); // 새로운 페이지 라우팅 추가
        }
    }
}
