using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SecureForensicData.BLL
{
    public class SFDBLL
    {
        SecureForensicData.DAL.SFDDAL objDAL = null;

        public int LoginVerify(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.LoginVerify(objDTO);
        }
        public string CreateArea(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.CreateArea(objDTO);
        }
        public DataTable GetArea()
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.GetArea();
        }
        public string CreatePoliceStation(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.CreatePoliceStation(objDTO);
        }
        public DataTable GetPoliceStation()
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.GetPoliceStation();
        }
        public string CreateHigherOfficer(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.CreateHigherOfficer(objDTO);
        }
        public string CreateForensicStaff(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.CreateForensicStaff(objDTO);
        }
        public string CreateDoctor(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.CreateDoctor(objDTO);
        }
        public string AddCrime(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.AddCrime(objDTO);
        }
        
        public DataTable GetCrime(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.GetCrime(objDTO);
        }
        public string AddForensicDC(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.AddForensicDC(objDTO);
        }
        public string CreateTable_FSRG(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.CreateTable_FSRG(objDTO);
        }
        public string CreateTable_DRG(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.CreateTable_DRG(objDTO);
        }
        public DataTable GetFSReport(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.GetFSReport(objDTO);
        }
        public string FSRequest(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.FSRequest(objDTO);
        }
        public string GetFSReportData(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.GetFSReportData(objDTO);
        }
        public string GetMedicalReportData(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.GetMedicalReportData(objDTO);
        }
        public DataTable GetCrimeLog_HO(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.GetCrimeLog_HO(objDTO);
        }
        public string CrimeRequest(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.CrimeRequest(objDTO);
        }
        
        public string PostMessage(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.PostMessage(objDTO);
        }
        public DataTable GetMessage_HOPSId(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.GetMessage_HOPSId(objDTO);
        }
        public string UpdateCrimeStatus(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.UpdateCrimeStatus(objDTO);
        }
        public string CreateTable_CSL(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.CreateTable_CSL(objDTO);
        }
        public string ChkFSCaseTamper(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.ChkFSCaseTamper(objDTO);
        }
        public string FSCaseRecover(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.FSCaseRecover(objDTO);
        }
        public string ChkDRCaseTamper(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.ChkDRCaseTamper(objDTO);
        }
        public string DRCaseRecover(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.DRCaseRecover(objDTO);
        }

        public string ChkCCaseTamper(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.ChkCCaseTamper(objDTO);
        }
        public string CCaseRecover(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.CCaseRecover(objDTO);
        }
        public string GetCrimeCS(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.GetCrimeCS(objDTO);
        }
        public int ChangePassword(SecureForensicData.DTO.SFDDTO objDTO)
        {
            objDAL = new DAL.SFDDAL();
            return objDAL.ChangePassword(objDTO);
        }
    }
}