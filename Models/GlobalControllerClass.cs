namespace Calibration_Management_System.Models
{
    public class GlobalControllerClass
    {
        public CalibrationNotice CalibrationNoticeData { get; set; }
        public EquipmentRegistration EquipmentRegistrationData { get; set; }
        public FailureReport FailureReportData { get; set; }
        public JigRegistration JigRegistrationData { get; set; }
        public NCR NcrData { get; set; }
        public GeneralForm GeneralFormData { get; set; }
        public SuspendDisposeRegistration SuspendDisposeRegistrationData { get; set; }
        public RegistrationClass RegistrationClassData { get; set; }
        public Uncontrolled UncontrolledData { get; set; }

        public EmailList EmailList { get; set; }

        public CalibrationResultEQP CalibrationResultEQP { get; set; }
        public CalibrationResultJIG CalibrationResultJIG { get; set; }

    }
}
