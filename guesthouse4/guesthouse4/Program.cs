using System;
using System.Windows.Forms;

namespace guesthouse4
{
    internal static class Program
    {
        public static Form CurrentForm { get; set; }
        public static Login LoginForm { get; set; }
        public static Dashboard DashboardForm { get; set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm = new Login();
            CurrentForm = LoginForm;
            Application.Run(LoginForm);
        }

        public static void SwitchForm(Form newForm)
        {
            CurrentForm?.Hide();
            CurrentForm = newForm;
            newForm.Show();
        }

        public static void ReturnToDashboard()
        {
            if (DashboardForm == null || DashboardForm.IsDisposed)
            {
                DashboardForm = new Dashboard();
            }
            SwitchForm(DashboardForm);
        }
    }
}