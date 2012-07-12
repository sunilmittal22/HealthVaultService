using Microsoft.Health.ItemTypes;

using Microsoft.Health.Web;
using Microsoft.Health.Web.Authentication;
using System.Data;
using Newtonsoft.Json;
public static string execute() { 

    List<Microsoft.Health.ItemTypes.Person> _Person = _healthrecords.GetEnumerator() as List<Microsoft.Health.ItemTypes.Person>();
    List<BasicDemographicsInformationModel> _BasicDemographicsInformation =new List<BasicDemographicsInformationModel>();
    foreach (var __Person in  _Person){
        BasicDemographicsInformationModel __BasicDemographicsInformation =new BasicDemographicsInformationModel();
        List<LanguagesModel> _Languages =new List<LanguagesModel>();
        LanguagesModel __Languages =new LanguagesModel();
        List<AddressModel> _Address =new List<AddressModel>();
        List<PhoneModel> _Phone =new List<PhoneModel>();
        List<EmailModel> _Email =new List<EmailModel>();
        List<LanguageModel> _Language =new List<LanguageModel>();

    foreach (var __Languages in __Person.Languages){
        LanguagesModel objLanguages = new LanguagesModel();
        __Language.IsPrimary=(!string.IsNullOrEmpty(__Language.IsPrimary)) ? __Language.IsPrimary:"";
        __Language.SpokenLanguage=(!string.IsNullOrEmpty(__Language.SpokenLanguage)) ? __Language.SpokenLanguage:"";
        _Languages.Add(objLanguages);
    }
    Languages.Model.Add(_Languages);

__BasicDemographicsInformation.Gender=(!string.IsNullOrEmpty(__Person.Gender)) ? __Person.Gender:"";
__BasicDemographicsInformation.BirthYear=(!string.IsNullOrEmpty(__Person.BirthYear)) ? __Person.BirthYear:"";
__BasicDemographicsInformation.Country=(!string.IsNullOrEmpty(__Person.Country)) ? __Person.Country:"";
__BasicDemographicsInformation.PostalCode=(!string.IsNullOrEmpty(__Person.PostalCode)) ? __Person.PostalCode:"";
__BasicDemographicsInformation.City=(!string.IsNullOrEmpty(__Person.City)) ? __Person.City:"";
__BasicDemographicsInformation.State=(!string.IsNullOrEmpty(__Person.State)) ? __Person.State:"";
__BasicDemographicsInformation.firstdow=(!string.IsNullOrEmpty(__Person.firstdow)) ? __Person.firstdow:"";

}