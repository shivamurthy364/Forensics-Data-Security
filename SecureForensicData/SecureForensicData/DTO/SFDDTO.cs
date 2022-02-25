using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecureForensicData.DTO
{
    public class SFDDTO
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        public int AreaId { get; set; }
        public string AreaName { get; set; }

        public int PoliceStationId { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }

        public int HOId { get; set; }
        public int FSId { get; set; }
        public int DoctorId { get; set; }

        public string Role { get; set; }

        public int CrimeId { get; set; }
        public string CrimeName { get; set; }
        public string CrimeDate { get; set; }
        public string Status { get; set; }
        public string CrimePlace { get; set; }
        public string Description { get; set; }

        public string TableName { get; set; }
        public string CaseSummary { get; set; }

        public string FilePath { get; set; }

        public int SlNo { get; set; }

        public int AccessKey { get; set; }

        public string LogDate { get; set; }

        public string Message { get; set; }
    }
}