using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSGHealthVaultService.Models;
using Microsoft.Health;
using Microsoft.Health.Web;
using Microsoft.Health.Web.Authentication;
namespace ConsoleApplication3
{
    class GenerateDynamicCode
    {
        internal static WebApplicationConnection GetConnection(string wcToken)
        {
            WebApplicationConnection connection =
                       new WebApplicationConnection(WebApplicationConfiguration.AppId,
                                                    WebApplicationConfiguration.HealthServiceUrl,
                                                    new WebApplicationCredential(WebApplicationConfiguration.AppId,
                                                                                 wcToken));
            connection.Authenticate();
            return connection;
        }
        public IEnumerable<HealthRecordItemCollection> getHalthVaultModuleItemCollection(string wcToken, List<HealthModel> _healthModel)
        {
            WebApplicationConnection connection = GetConnection(wcToken);
            Guid recordId = connection.GetPersonInfo().SelectedRecord.Id;
            HealthRecordAccessor accessor = new HealthRecordAccessor(connection, recordId);
            HealthRecordSearcher searcher = accessor.CreateSearcher();
            var _types = from _type in _healthModel
                         select new
                         {
                             typeName = _type.healthVaultModule.TypeIDs
                         };
            foreach (var _type in _types.ToList())
            {
                HealthRecordFilter filter = new HealthRecordFilter();
                switch (_type.typeName)
                {
                    case "Contact":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Contact.TypeId);
                        break;
                    case "BasicV2":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.BasicV2.TypeId);
                        break;
                    case "Payer":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Payer.TypeId);
                        break;
                    case "Person":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Person.TypeId);
                        break;
                    case "Personal":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Personal.TypeId);
                        break;
                    case "AerobicProfile":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.AerobicProfile.TypeId);
                        break;
                    case "AerobicWeeklyGoal":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.AerobicWeeklyGoal.TypeId);
                        break;
                    case "AllergicEpisode":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.AllergicEpisode.TypeId);
                        break;
                    case "Allergy":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Allergy.TypeId);
                        break;
                    case "Annotation":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Annotation.TypeId);
                        break;
                    case "ApplicationDataReference":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.ApplicationDataReference.TypeId);
                        break;
                    case "ApplicationSpecific":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.ApplicationSpecific.TypeId);
                        break;
                    case "Appointment":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Appointment.TypeId);
                        break;
                    case "AsthmaInhaler":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.AsthmaInhaler.TypeId);
                        break;
                    case "AsthmaInhalerUse":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.AsthmaInhalerUse.TypeId);
                        break;
                    case "Basic":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Basic.TypeId);
                        break;
                    case "BloodGlucose":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.BloodGlucose.TypeId);
                        break;
                    case "BloodOxygenSaturation":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.BloodOxygenSaturation.TypeId);
                        break;
                    case "BloodPressure":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.BloodPressure.TypeId);
                        break;
                    case "BodyComposition":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.BodyComposition.TypeId);
                        break;
                    case "BodyDimension":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.BodyDimension.TypeId);
                        break;
                    case "CalorieGuideline":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.CalorieGuideline.TypeId);
                        break;
                    case "CardiacProfile":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.CardiacProfile.TypeId);
                        break;
                    case "CarePlan":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.CarePlan.TypeId);
                        break;
                    case "CCD":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.CCD.TypeId);
                        break;
                    case "CCR":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.CCR.TypeId);
                        break;
                    case "CDA":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.CDA.TypeId);
                        break;
                    case "CholesterolProfile":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.CholesterolProfile.TypeId);
                        break;
                    case "Comment":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Comment.TypeId);
                        break;
                    case "Concern":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Concern.TypeId);
                        break;
                    case "Condition":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Condition.TypeId);
                        break;
                    case "Contraindication":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Contraindication.TypeId);
                        break;
                    case "DailyMedicationUsage":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.DailyMedicationUsage.TypeId);
                        break;
                    case "Device":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Device.TypeId);
                        break;
                    case "DiabeticProfile":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.DiabeticProfile.TypeId);
                        break;
                    case "DietaryDailyIntake":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.DietaryDailyIntake.TypeId);
                        break;
                    case "Directive":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Directive.TypeId);
                        break;
                    case "DischargeSummary":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.DischargeSummary.TypeId);
                        break;
                    case "Emotion":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Emotion.TypeId);
                        break;
                    case "Encounter":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Encounter.TypeId);
                        break;
                    case "Exercise":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Exercise.TypeId);
                        break;
                    case "ExerciseSamples":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.ExerciseSamples.TypeId);
                        break;
                    case "ExplanationOfBenefits":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.ExplanationOfBenefits.TypeId);
                        break;
                    case "FamilyHistory":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.FamilyHistory.TypeId);
                        break;
                    case "FamilyHistoryCondition":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.FamilyHistoryCondition.TypeId);
                        break;
                    case "FamilyHistoryPerson":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.FamilyHistoryPerson.TypeId);
                        break;
                    case "FamilyHistoryV3":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.FamilyHistoryV3.TypeId);
                        break;
                    case "File":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.File.TypeId);
                        break;
                    case "GeneticSnpResults":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.GeneticSnpResults.TypeId);
                        break;
                    case "GroupMembership":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.GroupMembership.TypeId);
                        break;
                    case "GroupMembershipActivity":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.GroupMembershipActivity.TypeId);
                        break;
                    case "HbA1C":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.HbA1C.TypeId);
                        break;
                    case "HealthAssessment":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.HealthAssessment.TypeId);
                        break;
                    case "HealthcareProxy":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.HealthcareProxy.TypeId);
                        break;
                    case "HealthEvent":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.HealthEvent.TypeId);
                        break;
                    case "HealthJournalEntry":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.HealthJournalEntry.TypeId);
                        break;
                    case "HeartRate":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.HeartRate.TypeId);
                        break;
                    case "Height":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Height.TypeId);
                        break;
                    case "Immunization":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Immunization.TypeId);
                        break;
                    case "InsulinInjection":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.InsulinInjection.TypeId);
                        break;
                    case "InsulinInjectionUse":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.InsulinInjectionUse.TypeId);
                        break;
                    case "LabTestResults":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.LabTestResults.TypeId);
                        break;
                    case "LifeGoal":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.LifeGoal.TypeId);
                        break;
                    case "Link":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Link.TypeId);
                        break;
                    case "MedicalImageStudy":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.MedicalImageStudy.TypeId);
                        break;
                    case "MedicalImageStudyV2":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.MedicalImageStudyV2.TypeId);
                        break;
                    case "Medication":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Medication.TypeId);
                        break;
                    case "MedicationFill":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.MedicationFill.TypeId);
                        break;
                    case "Message":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Message.TypeId);
                        break;
                    case "MicrobiologyLabResults":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.MicrobiologyLabResults.TypeId);
                        break;
                    case "PapSession":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.PapSession.TypeId);
                        break;
                    case "PasswordProtectedPackage":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.PasswordProtectedPackage.TypeId);
                        break;
                    case "PeakFlow":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.PeakFlow.TypeId);
                        break;
                    case "PersonalImage":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.PersonalImage.TypeId);
                        break;
                    case "Pregnancy":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Pregnancy.TypeId);
                        break;
                    case "Problem":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Problem.TypeId);
                        break;
                    case "Procedure":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Procedure.TypeId);
                        break;
                    case "QuestionAnswer":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.QuestionAnswer.TypeId);
                        break;
                    case "RadiologyLabResults":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.RadiologyLabResults.TypeId);
                        break;
                    case "RespiratoryProfile":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.RespiratoryProfile.TypeId);
                        break;
                    case "SleepJournalAM":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.SleepJournalAM.TypeId);
                        break;
                    case "SleepJournalPM":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.SleepJournalPM.TypeId);
                        break;
                    case "Status":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Status.TypeId);
                        break;
                    case "VitalSigns":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.VitalSigns.TypeId);
                        break;
                    case "Weight":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.Weight.TypeId);
                        break;
                    case "WeightGoal":
                        filter.TypeIds.Add(Microsoft.Health.ItemTypes.WeightGoal.TypeId);
                        break;
                }

                searcher.Filters.Add(filter);
            }
            IEnumerable<HealthRecordItemCollection> _healthRecordCollection = searcher.GetMatchingItems();
            return _healthRecordCollection;
        }

        public string createScriptForHalthVaultModuleItem(List<HealthModel> _healthModel, bool save)
        {
            StringBuilder _strModulesScript = new StringBuilder();
            _healthModel.ForEach(_model =>
            {
                StringBuilder _strModuleScript = new StringBuilder();
                #region Adding All prequisites
                _strModuleScript.Append("#r \"Microsoft.Health\"");
                _strModuleScript.Append("#r \"Microsoft.Health.ItemTypes\"");
                _strModuleScript.Append("#r \"System.Data\"");
                _strModuleScript.Append("#r \"Newtonsoft.Json\"");
                _strModuleScript.Append("#r \"System.Xml\"");
                _strModuleScript.Append("using System;");
                _strModuleScript.Append("using System.Collections.Generic;");
                _strModuleScript.Append("using Microsoft.Health;");
                _strModuleScript.Append("using Microsoft.Health.ItemTypes;");
                _strModuleScript.Append("using Microsoft.Health.Web;");
                _strModuleScript.Append("using Microsoft.Health.Web.Authentication;");
                _strModuleScript.Append("using System.Data;");
                _strModuleScript.Append("using Newtonsoft.Json;");
                #endregion

                //Start The Execute Function
                _strModuleScript.Append("public static string execute() {");
                //Createing an List instance of Current Module Item Type
                _strModuleScript.AppendFormat(" List<Microsoft.Health.ItemTypes.{0}> _{0} = _healthrecords.GetEnumerator() as List<Microsoft.Health.ItemTypes.{0}>();", _healthModel[0].healthVaultModule.TypeIDs);
                //Creating a Model for the current Module
                _strModuleScript.AppendFormat("List<{0}Model> _{0} =new List<{0}Model>();", _model.healthVaultModule.TypeName.ToString().Replace(" ", ""));

                #region Loop Through Each Item in Cureent Module Item
                var mTypeModelObject = "__" + _model.healthVaultModule.TypeName.ToString().Replace(" ", "");
                var mcurrentModelType = "__" + _healthModel[0].healthVaultModule.TypeIDs;

                _strModuleScript.AppendFormat("foreach (var __{0} in  _{0})", _healthModel[0].healthVaultModule.TypeIDs);
                _strModuleScript.Append("{");
                

                //Create a Current Module Model Type to add into to Model List
                _strModuleScript.AppendFormat("{0}Model __{0} =new {0}Model();", _model.healthVaultModule.TypeName.ToString().Replace(" ", ""));

                

                //Go Through Each Field under the Field List of the Model
                _model.healtVaultModuleields.ForEach(_localField =>
                {
                    if (_localField.isPremitive == false)
                    {
                        _strModuleScript.AppendFormat("List<{0}Model> _{0} =new List<{0}Model>();", _localField.FieldName);
                        _strModuleScript.AppendFormat("{0}Model __{0} =new {0}Model();", _localField.FieldName);
                        createForHalthVaultModuleListItemDeclaration(_localField);
                        _strModuleScript.Append(string.Join(Environment.NewLine, strdeclaration.ToArray()));
                    }
                });
                //Fetch all the premitive Types
                var premitiveTypes = _model.healtVaultModuleields.FindAll(delegate(HealthVaultFields hf) { return hf.isPremitive == true; });
                premitiveTypes.ForEach(_localPremitiveType =>
                    {

                        _strModuleScript.AppendFormat("{0}.{1}={2};", mTypeModelObject, _localPremitiveType.FieldName, createFieldAssignment(_localPremitiveType.FieldType, mcurrentModelType + "." + _localPremitiveType.FieldName));
                      
                    });
                //Fetch all the nonpremitive Types
                var nonpremitiveType = _model.healtVaultModuleields.FindAll(delegate(HealthVaultFields hf) { return hf.isPremitive == false; });
                nonpremitiveType.ForEach(_localPremitiveType =>
                {
                     _strModuleScript.Append(bindModelwithFields(_model, _localPremitiveType, mTypeModelObject, mcurrentModelType));

                });
               
                _strModuleScript.Append("}");
                #endregion

                #region Create sample Models claasess for each non premitive Items Types
                _strModuleScript.AppendFormat("public class {0}Model ", _model.healthVaultModule.TypeName.ToString().Replace(" ", "")).Append("{ ");
                _model.healtVaultModuleields.ForEach(_localField =>
                {
                    if (_localField.isPremitive == true)
                    {
                        _strModuleScript.AppendFormat(" public {0} {1}", getType(_localField.FieldType), _localField.FieldName).Append("{ get; set; }}");
                    }
                    else
                    {
                        _strModuleScript.AppendFormat(" public List<{0}Model> {0}", _localField.FieldName).Append("{ get; set; }}");
                    }
                });

                //Started the Inner Classes
                var nonpremitiveTypes = from p in _model.healtVaultModuleields
                                        where p.isPremitive = false
                                        select p;
                createForHalthVaultModuleListItem(_model.healtVaultModuleields);
                _strModuleScript.Append(string.Join(Environment.NewLine, strClassess.ToArray()));
                _strModuleScript.Append("}");
                #endregion
                _strModulesScript.Append(_strModuleScript.ToString());
            });
            return _strModulesScript.ToString();
        }
        public string createFieldAssignment(string type, string field)
        {
            if (getType(type).ToLower() == "string")
            {
                return "(!string.IsNullOrEmpty(" + field + ")) ? " + field + ":\"\";";
            }
            else if ((getType(type).ToLower() == "bool"))
            {
                return "(" + field + ".HasValue) ? Convert.ToBoolean(" + field + ".Value) : false;";
            }
            else if ((getType(type).ToLower() == "datetime"))
            {
                return "(" + field + " != null) ? " + field + ".ToDateTime() : DateTime.MinValue;";
            }
            else if ((getType(type).ToLower() == "codable"))
            {
                return "(" + field + " != null) ? " + field + ".Text : \"\";";
            }
            else if ((getType(type).ToLower() == "int"))
            {
                return "(" + field + " != null) ? " + field + " : int.MinValue;";
            }
            else
            {
                return "";
            }

        }
        public string getType(string type)
        {
            switch (type)
            {
                case "noncodable":
                    return "string";
                default:
                    return "string";

            }
        }
        List<string> strClassess = new List<string>();
        List<string> strdeclaration = new List<string>();
        public void createForHalthVaultModuleListItem(List<HealthVaultFields> _nonpremitiveTypes)
        {

            StringBuilder strClassBuilder = new System.Text.StringBuilder();
            List<HealthVaultFields> _localHealthVaultFields = null;
            _nonpremitiveTypes.ToList<HealthVaultFields>().ForEach(_localField =>
            {
                strClassBuilder.AppendFormat("public class {0}Model ", _localField.FieldName.Replace(" ", "")).Append("{ ");

                var subFields = from subfield in _nonpremitiveTypes.ToList<HealthVaultFields>()
                                where subfield.FieldID == _localField.FieldID
                                select new
                                 {
                                     __HealthVaultFields = subfield.healthVaultFields.ToList<HealthVaultFields>()
                                 };


                subFields.ToList().First().__HealthVaultFields.ForEach(_subfield =>
                {

                    if (_subfield.isPremitive == true)
                    {
                        strClassBuilder.AppendFormat("public {0} {1} ", getType(_subfield.FieldType), _subfield.FieldName).Append("{ get; set; }");
                    }
                    else
                    {
                        // getType(_subfield.FieldType)
                        strClassBuilder.AppendFormat("public List<{0}Model> {0} ", _subfield.FieldName).Append("{ get; set; }");
                        _localHealthVaultFields = new List<HealthVaultFields>();
                        _localHealthVaultFields.Add(_subfield);
                        createForHalthVaultModuleListItem(_localHealthVaultFields);
                    }
                });
                strClassBuilder.Append("}");
                strClassess.Add(strClassBuilder.ToString());
            });


        }
        public void createForHalthVaultModuleListItemDeclaration(HealthVaultFields _localField)
        {
            if (!_localField.isPremitive)
            {
                List<HealthVaultFields> subFields = new List<HealthVaultFields>();
                subFields = _localField.healthVaultFields.ToList<HealthVaultFields>().FindAll(delegate(HealthVaultFields hf) { return hf.isPremitive == false; });

                subFields.ToList<HealthVaultFields>().ForEach(_subfield =>
                {

                    if (!_subfield.isPremitive)
                    {

                        StringBuilder strDeclarationBuilder = new System.Text.StringBuilder();

                        strDeclarationBuilder.AppendFormat("List<{0}Model> _{0} =new List<{0}Model>();", _subfield.FieldName);
                        strDeclarationBuilder.AppendFormat("{0}Model __{0} =new {0}Model();", _subfield.FieldName);
                        if (!strdeclaration.Exists(delegate(string temp) { return temp == strDeclarationBuilder.ToString(); }))
                        {
                            strdeclaration.Add(strDeclarationBuilder.ToString());

                        }
                        createForHalthVaultModuleListItemDeclaration(_subfield);
                    }
                });
            }
        }
        public string bindModelwithFields(HealthModel _model, HealthVaultFields _nonPremitiveField, string mTypeModelObject, string mcurrentModelType)
        {
            StringBuilder _strModuleScript = new StringBuilder();
            _nonPremitiveField.healthVaultFields.ForEach( _field => {
                if (_field.isPremitive == false)
                {
                    _strModuleScript.Append(bindModelwithFields(_model, _field, _field.FieldName + "Model", _field.FieldType));
                }
                else
                {
                   
                    if (_field.CollectionObject)
                    { 
                        _strModuleScript.AppendFormat("{0}.{1}=\"\"", mTypeModelObject, _field.FieldName);
                        _strModuleScript.AppendFormat("foreach (var _{0} in {0}.{1})", _field.FieldName, mcurrentModelType);
                        _strModuleScript.Append("{");
                        _strModuleScript.AppendFormat("{0}.{1}={0}.{1} +{2}", mTypeModelObject, _field.FieldName, createFieldAssignment(_field.FieldType, mcurrentModelType + "." + _field.FieldName));
                        _strModuleScript.Append("}");

                    }
                    else
                    {
                        _strModuleScript.AppendFormat("{0}.{1}={2}", mTypeModelObject, _field.FieldName, createFieldAssignment(_field.FieldType, mcurrentModelType + "." + _field.FieldName));
                    }
                }
            });
            return _strModuleScript.ToString();
        }
    }
}

namespace Host
{
    public class HostObject
    {
        public IEnumerable<HealthRecordItemCollection> _healthrecords;
    }
}