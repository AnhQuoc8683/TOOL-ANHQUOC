using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Keys = System.Windows.Forms.Keys;


namespace TOOL_CHANGE_USER_AGENT_ANH_QUOCV1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        IWebDriver driver;
        string ExtensionPart = "C:\\Users\\ANH QUOC PRO\\Desktop\\Selenium\\TOOL CHANGE USER AGENT ANH QUOCV1\\TOOL CHANGE USER AGENT ANH QUOCV1\\TOOL CHANGE USER AGENT ANH QUOCV1\\bin\\Debug\\Extension";
        private void BtnOpenChrome_Click(object sender, EventArgs e)
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            //driver = new ChromeDriver(service);
            ////try
            ////{
            ////    driver.Close();
            ////    driver.Quit();
            ////}
            ////catch (Exception ex)
            ////{
            ////    MessageBox.Show(ex.Message);
            ////}
            //driver.Navigate().GoToUrl("https://mbasic.facebook.com/");
            string IP = TxtIP.Text;
            string UserName = TxtUsedname.Text;
            string Password = Txtpasswork.Text;
            ChromeOptions options = new ChromeOptions();
            options.AddArguments(new string[] { "--disable-notifications", "--window-size="+400+","+600,"--no-sandbox","disable-gpu","--disable-dev-shm-usage"});
            options.AddExcludedArgument("enable-automation");
            options.AddArgument("--blink-settings=imagesEnabled=false");
            if (!string.IsNullOrEmpty(IP))
            {
                if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
                {
                    options.AddExtension(ExtensionPart + "\\Auto Proxy Auth.crx");
                }
                options.AddArgument(string.Format("--proxy-server={0}", IP));
                
            }
            ChromeDriver driver = new ChromeDriver(service, options);
            Thread.Sleep(3000);
            //driver.Close();

            if (!string.IsNullOrEmpty(IP))
            {
                if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
                {
                    ////driver.Navigate().Refresh();
                    //driver.Navigate().GoToUrl("chrome-extension://ggmdpepbjljkkkdaklfihhngmmgmpggp/options.html");
                    //IWebElement User = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[1]/div[1]/input"));
                    //User.SendKeys(UserName);
                    //IWebElement Pass = driver.FindElement(By.Id("password"));
                    //Pass.SendKeys(Password);
                    //IWebElement retry = driver.FindElement(By.Id("retry"));
                    //retry.Clear();
                    //retry.SendKeys("2"); 
                    //IWebElement save = driver.FindElement(By.Id("save"));
                    //save.Click();
                    //#region ADD PROXY
                    driver.Navigate().GoToUrl("chrome-extension://ggmdpepbjljkkkdaklfihhngmmgmpggp/options.html");
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    driver.Close();
                    driver.SwitchTo().Window(driver.WindowHandles.First());
                    driver.FindElement(By.Id("login")).SendKeys(UserName);
                    driver.FindElement(By.Id("password")).SendKeys(Password);
                    driver.FindElement(By.Id("retry")).Clear();
                    driver.FindElement(By.Id("retry")).SendKeys("2");
                    driver.FindElement(By.Id("save")).Click();
                    //#endregion
                }
            }
            //IReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            //string firstTab = windowHandles.First();

            //string lastTab = windowHandles.Last();
            //driver.CurrentWindowHandle.EndsWith(firstTab);
            //driver.SwitchTo().Window(firstTab);
           
            driver.Navigate().GoToUrl("https://mbasic.facebook.com");
            string taikhoan = Txttaikhoan.Text;
            string[] Chuoitaikhoan = taikhoan.Split("|");
            IWebElement Tkfb = driver.FindElement(By.Name("email"));
            Tkfb.SendKeys(Chuoitaikhoan[0]);
            IWebElement Mkfb = driver.FindElement(By.Name("pass"));
            Mkfb.SendKeys(Chuoitaikhoan[1]);
            try 
            {
                IWebElement Login = driver.FindElement(By.Name("login"));
                Login.Click();
            }catch (Exception ex)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
            }

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            //driver = new ChromeDriver(chromeOptions);
            ChromeDriver driveran = new ChromeDriver(service, chromeOptions);
            driveran.Navigate().GoToUrl("https://2fa.live/");
            IWebElement token = driveran.FindElement(By.Id("listToken"));
            token.SendKeys(Chuoitaikhoan[2]);
            IWebElement submit = driveran.FindElement(By.Id("submit"));
            submit.Click();
            IWebElement Code2fa = driveran.FindElement(By.Id("copy_btn"));
            //string ma2fa = Code2fa.GetAttribute("placeholder");
            //Txt2fa.Text = ma2fa;
            Code2fa.Click() ;
            Thread.Sleep(3000);
            Txt2fa.Paste();
            driveran.Close();
            driveran.Quit();
            try
            {
                IWebElement Nhap2fa = driver.FindElement(By.Id("approvals_code"));
                Nhap2fa.Click();
            }
            catch
            {
                Thread.Sleep(3000);
                driver.Navigate().Refresh();
                driver.Navigate().GoToUrl("https://mbasic.facebook.com");
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {


        }

        private void TabConfiguration_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void BtnLoginmail_Click(object sender, EventArgs e)
        {
            try
            {
                string Mails = "Hotmail";
                ChromeDriverService HideCmd = ChromeDriverService.CreateDefaultService();
                HideCmd.HideCommandPromptWindow = true;
                ChromeOptions Options = new ChromeOptions();
                Options.AddArgument("--window-size=" + 400 + "," + 600);
                string taikhoan = Txttaikhoan.Text;
                string[] Chuoitaikhoan = taikhoan.Split("|");
                string Mail = Chuoitaikhoan[3];
                string Passmail = Chuoitaikhoan[4];
                string[] ChuoiTKMail = Mail.Split("@");
                if (Chuoitaikhoan.Count() > 3)
                {


                    if (ChuoiTKMail[1].Length < 9)
                    {
                        MessageBox.Show("Mail của bạn không đúng định dạng Hotmail hoặc Gmail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(ChuoiTKMail[1].Trim().Length == 9)
                    {
                        ChromeDriver Openchrome = new ChromeDriver(HideCmd, Options);
                        Openchrome.Navigate().GoToUrl("https://accounts.google.com/v3/signin/identifier?dsh=S956487633%3A1664956326643983&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&rip=1&sacu=1&service=mail&flowName=GlifWebSignIn&flowEntry=ServiceLogin&ifkv=AQDHYWpoOKdag5s-WgmQefagnCHnKx_FzDEOSW-mCOi6Rs9DbrE8yXF8hrNhnTX7134k-39rx2CaqQ");
                        IWebElement Idmail = Openchrome.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div/c-wiz/div/div[2]/div/div[1]/div/form/span/section/div/div/div[1]/div/div[1]/div/div[1]/input"));
                        Idmail.SendKeys(Mail);
                        Thread.Sleep(2000);
                        Idmail.SendKeys(OpenQA.Selenium.Keys.Enter);
                    }
                    else
                    {
                        ChromeDriver Openchrome = new ChromeDriver(HideCmd, Options);
                        Openchrome.Navigate().GoToUrl("https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=13&ct=1664961454&rver=7.0.6737.0&wp=MBI_SSL&wreply=https%3a%2f%2foutlook.live.com%2fowa%2f%3fnlp%3d1%26RpsCsrfState%3d55237ceb-5959-48fa-ad4a-4ab7a26c9fe5&id=292841&aadredir=1&CBCXT=out&lw=1&fl=dob%2cflname%2cwld&cobrandid=90015");
                        IWebElement Idmail = Openchrome.FindElement(By.XPath("/html/body/div/form[1]/div/div/div[2]/div[1]/div/div/div/div/div[1]/div[3]/div/div/div/div[2]/div[2]/div/input[1]"));
                        Idmail.SendKeys(Mail);
                        Thread.Sleep(2000);
                        Idmail.SendKeys(OpenQA.Selenium.Keys.Enter);
                    }
                }
                else
                {
                    MessageBox.Show("Đéo có mail");
                    Txttaikhoan.Focus();
                }

            }catch (Exception ex)

            {
                MessageBox.Show(ex.Message ,"Enrror" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }
    }


}