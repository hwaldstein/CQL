namespace Data.Models.Session
{
    public class Instructor
    {
        public int id { get; set; }
        public object url { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public object generation { get; set; }
        public object birthDate { get; set; }
        public object edsMruid { get; set; }
        public string edsActive { get; set; }
        public string hawkid { get; set; }
        public object univid { get; set; }
        public object ssn { get; set; }
        public object mfXrefid { get; set; }
        public object gender { get; set; }
        public object parkingAcctId { get; set; }
        public object vaultId { get; set; }
        public string name { get; set; }
        public string fullName { get; set; }
        public string role { get; set; }
        public string iconRole { get; set; }
        public object indStudyNo { get; set; }
        public string email { get; set; }
        public int sortOrder { get; set; }
        public object studentId { get; set; }
        public object academicId { get; set; }
        public object prospectId { get; set; }
        public object applicantId { get; set; }
        public object billingAccountId { get; set; }
        public object aidApplicantId { get; set; }
        public bool currentStudent { get; set; }
        public bool honors { get; set; }
    }
}
