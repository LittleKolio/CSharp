namespace SOLID_Lab.Lab_05
{
    public class KeyCardCheck : SecurityCheck
    {
        private ISecurityUI securityUI;

        public KeyCardCheck(ISecurityUI securityUI)
        {
            this.securityUI = securityUI;
        }

        private bool IsValid(string code)
        {
            return true;
        }

        public override bool ValidateUser()
        {
            string code = securityUI.RequestKeyCard();
            if (IsValid(code))
            {
                return true;
            }

            return false;
        }
    }
}