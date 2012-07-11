using System;
using System.Collections.Generic;
using System.ComponentModel;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;
using Roslyn.Services.CSharp;
using Roslyn.Scripting.CSharp;
using Roslyn.Scripting;
using System.Reflection;
using System.Linq;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using TSGHealthVaultService.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using TSGHealthVaultService;
using System.Threading;

namespace TSGHealtVaultService
{

    static class loadHealthVaultStructure
    {
        // creating an object for storing values of HealthVaultModules table
        static List<TSGHealthVaultService.Models.HealthVaultType> _healthvaultTypes = new List<TSGHealthVaultService.Models.HealthVaultType>();

        // creating an object for storing values of HealthVaultTypes table
        static List<TSGHealthVaultService.Models.HealthVaultFields> _fields = new List<TSGHealthVaultService.Models.HealthVaultFields>();

        // creating an object for storing values of HealthVaultModuleTypeMapping table
        static List<HealthVaultFieldsMapping> _mappings = new List<HealthVaultFieldsMapping>();

        // creating an object for storing values of HealthTypeMapping table        
        static List<HealthVaultTypeFieldMapping> _typemappings = new List<HealthVaultTypeFieldMapping>();
       
        /// <summary>
        /// This variable keeps the track of number of asynchronous calls 
        /// </summary>
        private static int counter = 0;

        internal static bool getHealthVaultModelData()
        {
            string connectionString = string.Empty;
            connectionString = @"Data Source=dev05\sql2k8;Initial Catalog=TSGPK_Healthvault;Integrated Security=True;Asynchronous Processing=true";
            Database dbGetHealthVaultModules = new SqlDatabase(connectionString);
            Database dbGetHealthVaultTypes = new SqlDatabase(connectionString);
            Database dbGetHealthTypeMapping = new SqlDatabase(connectionString);
            Database dbGetHealthVaultModuleTypeMapping = new SqlDatabase(connectionString);
            DbCommand cmdHealthVaultModules = dbGetHealthVaultModules.GetStoredProcCommand("TSG_HV_GetHealthVaultModules");
            DbCommand cmdHealthVaultTypes = dbGetHealthVaultTypes.GetStoredProcCommand("TSG_HV_GetHealthVaultTypes");
            DbCommand cmdHealthTypeMapping = dbGetHealthTypeMapping.GetStoredProcCommand("TSG_HV_GetHealthTypeMapping");
            DbCommand cmdHealthVaultModuleTypeMapping = dbGetHealthVaultModuleTypeMapping.GetStoredProcCommand("TSG_HV_GetHealthVaultModuleTypeMapping");
 
            try
            {

                IAsyncResult HealthVaultModules = dbGetHealthVaultModules.BeginExecuteReader(cmdHealthVaultModules, (res1) =>
                 {
                     Database db1 = (Database)res1.AsyncState;
                     using (IDataReader reader = db1.EndExecuteReader(res1))
                     {
                       while (reader.Read())
                         {
                             Console.WriteLine("HealthvaultModule");
                             var _healthvaultType = new HealthVaultType();
                             _healthvaultType.ID = Convert.ToInt32(reader["Id"]);
                             _healthvaultType.TypeName = Convert.ToString(reader["TypeName"]);
                             _healthvaultType.ModuleID = new Guid(reader["ModuleID"].ToString());
                             _healthvaultType.TypeIDs = Convert.ToString(reader["TypeIDs"]);
                             _healthvaultType.ClassName = Convert.ToString(reader["ClassName"]);
                             _healthvaultType.keyColumn = Convert.ToString(reader["KeyColumn"]);
                             _healthvaultType.keyColumnValue = Convert.ToString(reader["KeyColumnValue"]);
                             _healthvaultTypes.Add(_healthvaultType);
                         }
                         Interlocked.Increment(ref counter);
                         reader.Close();
                     }
                 }, dbGetHealthVaultModules);
               
                IAsyncResult HealthVaultFields = dbGetHealthVaultTypes.BeginExecuteReader(cmdHealthVaultTypes, (res2) =>
                {
                    Database db2 = (Database)res2.AsyncState;
                    using (IDataReader reader = db2.EndExecuteReader(res2))
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("HealthvaultModuleField");
                            var _field = new HealthVaultFields();
                            _field.FieldID = Convert.ToInt32(reader["DetailId"]);
                            _field.FieldName = Convert.ToString(reader["Name"]);
                            _field.FieldType = (Convert.ToBoolean(reader["isLookUp"])) ? "Codable" : "noncodable";
                            _field.isPremitive = Convert.ToBoolean(reader["isPremitiveType"]);
                            _field.PremitiveType = Convert.ToString(reader["PremitiveType"]);
                            _fields.Add(_field);
                        }
                        Interlocked.Increment(ref counter);
                        reader.Close();
                    }

                }, dbGetHealthVaultTypes);
            
                IAsyncResult HealthVaultModuleTypeMapping = dbGetHealthTypeMapping.BeginExecuteReader(cmdHealthTypeMapping, (res3) =>
                {
                    Database db3 = (Database)res3.AsyncState;
                    using (IDataReader reader = db3.EndExecuteReader(res3))
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("HealthvaultModuleTypeMapping");
                            var _subfield = new HealthVaultFieldsMapping();

                            _subfield.MappingID = Convert.ToInt32(reader["MappingID"]);
                            _subfield.MasterFieldID = Convert.ToInt32(reader["MasterTypeID"]);
                            _subfield.SubFieldID = Convert.ToInt32(reader["SubTypeID"]);
                            _subfield.isRequired = Convert.ToBoolean(reader["isRequired"]);
                            _mappings.Add(_subfield);
                        }
                        Interlocked.Increment(ref counter);
                        reader.Close();
                    }

                }, dbGetHealthTypeMapping);
                
                  IAsyncResult HealthTypeMapping = dbGetHealthVaultModuleTypeMapping.BeginExecuteReader(cmdHealthVaultModuleTypeMapping, (res4) =>
                {
                    Database db4 = (Database)res4.AsyncState;
                    using (IDataReader reader = db4.EndExecuteReader(res4))
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("HealthvaultModuleFieldeMapping");
                            var _typemapping = new HealthVaultTypeFieldMapping();

                            _typemapping.MappingID = Convert.ToInt32(reader["ID"]);
                            _typemapping.ModuleID = Convert.ToInt32(reader["ModuleID"]);
                            _typemapping.MasterTypeID = Convert.ToInt32(reader["MasterTypeID"]);
                            _typemapping.FieldID = Convert.ToInt32(reader["isRequired"]);
                            _typemappings.Add(_typemapping);
                        }
                      Interlocked.Increment(ref counter);
                      reader.Close();
                    }
                }, dbGetHealthVaultModuleTypeMapping);

                  while (counter < 4)
                  {
                      System.Threading.Thread.Sleep(10);
                  }
                  List<HealthModel> a = gethealthVaultModelStructure();
                  ConsoleApplication3.GenerateDynamicCode module = new ConsoleApplication3.GenerateDynamicCode();
                  module.createScriptForHalthVaultModuleItem(a, true);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        internal static List<HealthModel> gethealthVaultModelStructure()
        {
            List<HealthModel> healthVaultModules = new List<HealthModel>();

            #region This Will loop through All Healthvault Modules fetched from Database
            foreach (var _healthvaultModule in _healthvaultTypes)
            {
                //Create a new HealthModel Once We fetch It Will will add it into List<HealthModel>
                //Instantiate new Health model
                var healthVaultModule = new HealthModel();
                //Instantiate new Healthvault Module Type so that to add it into HealthModel

                #region Fetch Healthvault Module Type
                var __healthVaultModule = new HealthVaultType();
                var __healthVaultModuleFields = new List<HealthVaultFields>();

                #region Fetch Basic Healthvault Type Fields
                __healthVaultModule.ID = _healthvaultModule.ID;
                __healthVaultModule.TypeName = _healthvaultModule.TypeName;
                __healthVaultModule.ModuleID = new Guid(Convert.ToString(_healthvaultModule.ModuleID));
                __healthVaultModule.TypeIDs = _healthvaultModule.TypeIDs;
                __healthVaultModule.ClassName = _healthvaultModule.ClassName;
                __healthVaultModule.keyColumn = _healthvaultModule.keyColumn;
                __healthVaultModule.keyColumnValue = _healthvaultModule.keyColumnValue;
                healthVaultModule.healthVaultModule = __healthVaultModule;
                #endregion

                //Fetch All  Module to Type mappings in P for the present Module
                var p = from mapping in _typemappings
                        where mapping.ModuleID == healthVaultModule.healthVaultModule.ID
                        select mapping;

                #region Go through Each Field Fetched from Datbases and Compare it against the Fields for this module
                _fields.ForEach(
                #region _field contains the present value from _fields in Enemurator ( ie health valut data types)
_field => p.ToList<HealthVaultTypeFieldMapping>().ForEach(
#region _p contains the present value from Module Field Mapping so as to compare with all fields for present Module
_p =>
{
    // Compare with Typemapping table MastertypeId with HelthVault table FiledId for Module to Field Mapping
    if (_p.MasterTypeID == _field.FieldID)
    {

        #region If the current field in Feild collection is found in Type Mapping Collection
        var _fieldModel = new HealthVaultFields();
        // Fetching All the Field - Field Mapping for Current Field

        _fieldModel.FieldID = _field.FieldID;
        _fieldModel.FieldName = _field.FieldName;
        _fieldModel.FieldType = _field.FieldType;
        _fieldModel.isPremitive = _field.isPremitive;
        _fieldModel.PremitiveType = _field.PremitiveType;
        if (_p.isCollection)
        {
            _fieldModel.CollectionObject = true;
        }
        //If the Field Does Have any more fields inside
        if (_field.isPremitive == false)
        {
            _fieldModel.healthVaultFields = getChildFields(_field);
        }
        __healthVaultModuleFields.Add(_fieldModel);

        #endregion
    }

    healthVaultModule.healtVaultModuleields = __healthVaultModuleFields;
}
#endregion
)
                #endregion
);
                #endregion
                #endregion
                healthVaultModules.Add(healthVaultModule);
            }
            #endregion
            return healthVaultModules;
        }

        internal static List<HealthVaultFields> getChildFields(HealthVaultFields _field)
        {

            var __healthVaultFieldList = new List<HealthVaultFields>();
            #region _m contains the present value from Module Field Mapping so as to compare with all fields for present Module

            var _m = from _fieldMappping in _mappings
                     where _fieldMappping.MasterFieldID == _field.FieldID
                     select _fieldMappping;
            _fields.ForEach(
             _subfield => _m.ToList<HealthVaultFieldsMapping>().ForEach
             (_subm =>
                {
                    // Compare with Typemapping table MastertypeId with HelthVault table FiledId for Module to Field Mapping
                    if (_subm.SubFieldID == _subfield.FieldID)
                    {
                        #region If the current field in Feild collection is found in Type Mapping Collection

                        var __healthVaultField = new HealthVaultFields();
                        if (_subm.isCollection)
                        {
                            __healthVaultField.CollectionObject = true;
                        }
                        else
                        {
                            __healthVaultField.CollectionObject = false;
                        }
                        __healthVaultField = _subfield;
                        //If the Field Does Have any more fields inside
                        if (_subfield.isPremitive == false)
                        {
                            __healthVaultField.healthVaultFields = getChildFields(_subfield);
                        }
                        __healthVaultFieldList.Add(__healthVaultField);
                        #endregion
                    }
                }
             )
            );
            #endregion
            //HealthVaultFields
            return __healthVaultFieldList;//null;
        }
    }
}