using System.Diagnostics;
using System.Net.Http;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;

namespace Service
{
    public partial class Poll : ServiceBase
    {
        private Timer _timer;
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _url = "https://example.com/ex.txt";
        public Poll()
        {
            InitializeComponent();
            // Make sure service cant be stopped
            CanShutdown = false;
            CanStop = false;
            CanPauseAndContinue = false;
        }

        protected override void OnStart(string[] args)
        {
            // Start timer to keep checking
            _timer = new Timer(async _ => await CheckAndShutdown(), null, 0, 30000);
        }

        /* <Summary>
         * Checks _url for the value 1 every time timer ticks.
         */
        private async Task CheckAndShutdown()
        {
            try
            {
                string content = await _httpClient.GetStringAsync(_url);
                content = content.Trim();
                if (content == "1")
                {
                    // Shutdown command
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "shutdown",
                        Arguments = "/s /t 0",
                        CreateNoWindow = true,
                        UseShellExecute = false
                    });
                }
            }
            catch { }
        }
    }
}