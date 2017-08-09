namespace SOLID_Lab.Lab_05
{
    public class Lab_05_Security_Door
    {
        public static void Main() 
        {
            ScannerUI scannerUi = new ScannerUI();
            KeyCardCheck keyCardCheck = new KeyCardCheck(scannerUi);
            PinCodeCheck pinCodeCheck = new PinCodeCheck(scannerUi);
            SecurityManager manager = new SecurityManager(keyCardCheck, pinCodeCheck);
            manager.Check();
        }
    }
}
