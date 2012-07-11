using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
namespace TSGHealthVaultService.Models
{
    public class HealthModel
    {
        public HealthVaultType healthVaultModule { get; set; }
        public List<HealthVaultFields> healtVaultModuleields { get; set; }
    }
    public class HealthVaultType
    {
        public int ID { get; set; }
        public string TypeName { get; set; }
        public Guid ModuleID { get; set; }
        public string TypeIDs { get; set; }
        public string ClassName { get; set; }
        public string keyColumn { get; set; }
        public string keyColumnValue { get; set; }

    }
    public class HealthVaultFields
    {
        public int FieldID { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public bool isPremitive { get; set; }
        public string PremitiveType { get; set; }
        public List<HealthVaultFields> healthVaultFields { get; set; }
    }
    public class HealthVaultFieldsMapping
    {
        public int MappingID { get; set; }
        public int MasterFieldID { get; set; }
        public int SubFieldID { get; set; }
        public bool isRequired { get; set; }
    }
    public class HealthVaultTypeFieldMapping
    {
        public int MappingID { get; set; }
        public int ModuleID { get; set; }
        public int MasterTypeID { get; set; }
        public int FieldID { get; set; }

    }
    public enum PremitiveTypes
    {
        codable = 1,
        str = 2,
        dte = 3,
        bol = 4,
        coded = 5,
        dbl = 6,
        inte = 7
    }
}