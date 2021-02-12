﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NapelliVO;
using NapelliWebAPI.Models;

namespace NapelliWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpPost, Route("UserLogin")]
        [Authorize(AuthenticationSchemes = "Bearer")]        
        public IActionResult UserLogin(UserRegisterVO urVO)
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.UserLogin(urVO);
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpPost, Route("RegisterUser")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult RegisterUser(UserRegisterVO uVO)
        {
            UserDetailsModel umodel = new UserDetailsModel();
            try
            {
                DataTable dt = umodel.CheckMail(uVO.Email_id, uVO.Mobile_number);
                if (dt.Rows.Count != 0)
                {
                    return Ok(new { error = "Already exists" });
                }
                string count = umodel.RegisterUser(uVO);
                if (umodel.errorcode != 0)
                {
                    return Ok(new { Error = umodel.error });
                }
                else if (count == "Inserted")
                {
                    return Ok(new { sucess = "Inserted Successfully" });
                }
                else
                {
                    return Ok(new { error = "Not inserted" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpPost, Route("FamilyDetails")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult FamilyDetails(FamilyVO fVO)
        {
            UserDetailsModel umodel = new UserDetailsModel();
            try
            {
                string count = umodel.FamilyDetails(fVO);
                if (umodel.errorcode != 0)
                {
                    return Ok(new { Error = umodel.error });
                }
                else if (count == "Inserted")
                {
                    return Ok(new { sucess = "Inserted Successfully" });
                }
                else
                {
                    return Ok(new { error = "Not inserted" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpPost, Route("ProfessionalDetails")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult ProfessionalDetails(ProfessionalVo pVO)
        {
            UserDetailsModel umodel = new UserDetailsModel();
            try
            {
                string count = umodel.ProfessionalDetails(pVO);
                if (umodel.errorcode != 0)
                {
                    return Ok(new { Error = umodel.error });
                }
                else if (count == "Inserted")
                {
                    return Ok(new { sucess = "Inserted Successfully" });
                }
                else
                {
                    return Ok(new { error = "Not inserted" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpPost, Route("PartnerPreference")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult PartnerPreference(PartnerPrefVO parVO)
        {
            UserDetailsModel umodel = new UserDetailsModel();
            try
            {
                string count = umodel.PartnerPreference(parVO);
                if (umodel.errorcode != 0)
                {
                    return Ok(new { Error = umodel.error });
                }
                else if (count == "Inserted")
                {
                    return Ok(new { sucess = "Inserted Successfully" });
                }
                else
                {
                    return Ok(new { error = "Not inserted" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpPost, Route("PersonalEducation")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult PersonalEducation(PersonalEduVO perEduVO)
        {
            UserDetailsModel umodel = new UserDetailsModel();
            try
            {
                string count = umodel.PersonalEducation(perEduVO);
                if (umodel.errorcode != 0)
                {
                    return Ok(new { Error = umodel.error });
                }
                else if (count == "Inserted")
                {
                    return Ok(new { sucess = "Inserted Successfully" });
                }
                else
                {
                    return Ok(new { error = "Not inserted" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpPost, Route("PackageCupons")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult PackageCupons(int user_id, int package_id, string cupon_code)
        {
            UserDetailsModel umodel = new UserDetailsModel();

            try
            {
                if (cupon_code == "" || cupon_code == string.Empty || cupon_code == null)
                {
                    cupon_code = "NA";
                }
                
                DataTable dt = umodel.PackageCupons(user_id, package_id, cupon_code);
                if (umodel.errorcode != 0)
                {
                    return Ok(new { Error = umodel.error });
                }
                //else if (dt.Rows.Count == 1)
                //{
                //    return Ok(new { info = "Inserted Successfully" });
                //}
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpPost, Route("InsertImage")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult InsertImage(ImageVO iVO)
        {
            UserDetailsModel umodel = new UserDetailsModel();
            try
            {
                string count = umodel.InsertImage(iVO);
                if (umodel.errorcode != 0)
                {
                    return Ok(new { Error = umodel.error });
                }
                else if (count == "Inserted")
                {
                    return Ok(new { sucess = "Inserted Successfully" });
                }
                else
                {
                    return Ok(new { error = "Not inserted" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpGet, Route("GetCaste")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetCaste()
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.GetCaste();
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }
        [HttpGet, Route("GetCities")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetCities()
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.GetCities();
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }
        [HttpGet, Route("GetCountries")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetCountries()
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.GetCountries();
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }
        [HttpGet, Route("GetDesgination")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetDesgination()
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.GetDesgination();
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpGet, Route("GetLanguage")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetLanguage()
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.GetLanguage();
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpGet, Route("GetQualification")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetQualification()
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.GetQualification();
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpGet, Route("GetRasi")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetRasi()
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.GetRasi();
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetReligion()
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.GetReligion();
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpGet, Route("GetStar")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetStar()
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.GetStar();
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }       

        [HttpGet, Route("GetStates")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetStates()
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.GetStates();
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpGet, Route("GetSubCast")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetSubCast()
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.GetSubCast();
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }
        
        [HttpGet, Route("GetPackage")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetPackage()
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.GetPackage();
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpGet, Route("GetPackageDetails")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetPackageDetails(int pack_id)
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.GetPackageDetails(pack_id);
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpGet, Route("GetPackCoupCalculation")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetPackCoupCalculation(int pack_id, string coupCode)
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.GetPackCoupCalculation(pack_id, coupCode);
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpGet, Route("GeneralSearch")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GeneralSearch(string gender, int age_from, int age_to, int religion)
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.GeneralSearch(gender, age_from, age_to, religion);
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpGet, Route("SendEmail")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult SendEmail(string FromEmailID, string ToEmailIds, string subject, string htmlContent)
        {
            SendGridModel email = new SendGridModel();
            var result = email.SendEmail(FromEmailID, ToEmailIds, subject, htmlContent);
            return Ok(new { info = result });
            //if (result.IsCompleted == true)
            //{
            //    return Ok(new { info = "Mail not sent" });
            //}
            //else
            //{
            //    return Ok(new { info = "Mail sent successfully" });
            //}           
        }

        [HttpGet, Route("GetFamilyDetails")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetFamilyDetails(int user_id)
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.GetFamilyDetails(user_id);
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpGet, Route("GetPersonalEducationalDetails")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetPersonalEducationalDetails(int user_id)
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.GetPersonalEducationalDetails(user_id);
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpGet, Route("GetProfessionalDetails")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetProfessionalDetails(int user_id)
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.GetProfessionalDetails(user_id);
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }


        [HttpGet, Route("GetPartnerPreferencesDetails")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetPartnerPreferencesDetails(int user_id)
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.GetProfessionalDetails(user_id);
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpGet, Route("GetImages")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetImages(int user_id)
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.GetImages(user_id);
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpGet, Route("GetPackageCuponsDetails")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetPackageCuponsDetails(int user_id)
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.GetPackageCuponsDetails(user_id);
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpPut, Route("UpdateFamily")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult UpdateFamily(FamilyVO fVO)
        {
            UserDetailsModel umodel = new UserDetailsModel();
            try
            {
                string count = umodel.UpdateFamily(fVO);
                if (umodel.errorcode != 0)
                {
                    return Ok(new { Error = umodel.error });
                }
                else if (count == "Updated")
                {
                    return Ok(new { sucess = "Updated Successfully" });
                }
                else
                {
                    return Ok(new { error = "Not Updated" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpPut, Route("UpdateProfessional")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult UpdateProfessional(ProfessionalVo pVO)
        {
            UserDetailsModel umodel = new UserDetailsModel();
            try
            {
                string count = umodel.UpdateProfessional(pVO);
                if (umodel.errorcode != 0)
                {
                    return Ok(new { Error = umodel.error });
                }
                else if (count == "Updated")
                {
                    return Ok(new { sucess = "Updated Successfully" });
                }
                else
                {
                    return Ok(new { error = "Not Updated" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpPut, Route("UpdatePartnerPreference")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult UpdatePartnerPreference(PartnerPrefVO parVO)
        {
            UserDetailsModel umodel = new UserDetailsModel();
            try
            {
                string count = umodel.UpdatePartnerPreference(parVO);
                if (umodel.errorcode != 0)
                {
                    return Ok(new { Error = umodel.error });
                }
                else if (count == "Updated")
                {
                    return Ok(new { sucess = "Updated Successfully" });
                }
                else
                {
                    return Ok(new { error = "Not Updated" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpPut, Route("UpdatePersonalEdu")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult UpdatePersonalEdu(PersonalEduVO perEduVO)
        {
            UserDetailsModel umodel = new UserDetailsModel();
            try
            {
                string count = umodel.UpdatePersonalEdu(perEduVO);
                if (umodel.errorcode != 0)
                {
                    return Ok(new { Error = umodel.error });
                }
                else if (count == "Updated")
                {
                    return Ok(new { sucess = "Updated Successfully" });
                }
                else
                {
                    return Ok(new { error = "Not Updated" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpPut, Route("UpdateImage")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult UpdateImage(ImageVO iVO)
        {
            UserDetailsModel umodel = new UserDetailsModel();
            try
            {
                string count = umodel.UpdateImage(iVO);
                if (umodel.errorcode != 0)
                {
                    return Ok(new { Error = umodel.error });
                }
                else if (count == "Updated")
                {
                    return Ok(new { sucess = "Updated Successfully" });
                }
                else
                {
                    return Ok(new { error = "Not Updated" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }

        [HttpGet, Route("ViewProfile")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult ViewProfile(int user_id)
        {
            UserDetailsModel objUserMol = new UserDetailsModel();
            DataTable dt = new DataTable();
            try
            {
                dt = objUserMol.ViewProfile(user_id);
                if (objUserMol.errorcode != 0)
                {
                    return Ok(new { Error = objUserMol.error });
                }
                else if (dt.Rows.Count == 0)
                {
                    return Ok(new { info = "No Record found" });
                }
                else
                {
                    return Ok(dt);
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }
    }
}
