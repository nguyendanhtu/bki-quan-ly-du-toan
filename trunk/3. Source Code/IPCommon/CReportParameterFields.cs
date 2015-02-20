// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;


///''import crystal

namespace IP.Core.IPCommon
{
	public class CReportParameterFields
	{
#region PUBLIC INTERFACE
		
		public void AddParameter(string i_paramName, string i_paramValue, ParameterFields o_paramFields)
		{
			
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
			ParameterValues paramValues = new ParameterValues();
			
			// Set the name of the parameter to modify.
			paramField.ParameterFieldName = i_paramName;
			
			// Set a value to the parameter.
			paramDiscreteValue.Value = i_paramValue;
			paramValues.Add(paramDiscreteValue);
			paramField.CurrentValues = paramValues;
			
			// Add the parameter to the ParameterFields collection.
			o_paramFields.Add(paramField);
			//      Return paramFields
		}
		
		public void AddParameter(string i_paramName, 
			decimal i_paramValue, 
			ParameterFields o_paramFields)
		{
			
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
			ParameterValues paramValues = new ParameterValues();
			
			// Set the name of the parameter to modify.
			paramField.ParameterFieldName = i_paramName;
			
			// Set a value to the parameter.
			paramDiscreteValue.Value = i_paramValue;
			paramValues.Add(paramDiscreteValue);
			paramField.CurrentValues = paramValues;
			
			// Add the parameter to the ParameterFields collection.
			o_paramFields.Add(paramField);
			//      Return paramFields
		}
		
		public void AddParameter(string i_paramName, 
			int i_paramValue, 
			ParameterFields o_paramFields)
		{
			
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
			ParameterValues paramValues = new ParameterValues();
			
			// Set the name of the parameter to modify.
			paramField.ParameterFieldName = i_paramName;
			
			// Set a value to the parameter.
			paramDiscreteValue.Value = i_paramValue;
			paramValues.Add(paramDiscreteValue);
			paramField.CurrentValues = paramValues;
			
			// Add the parameter to the ParameterFields collection.
			o_paramFields.Add(paramField);
			//      Return paramFields
		}
		
		public void AddParameter(string i_paramName, 
			DateTime i_paramValue, 
			ParameterFields o_paramFields)
		{
			
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
			ParameterValues paramValues = new ParameterValues();
			
			// Set the name of the parameter to modify.
			paramField.ParameterFieldName = i_paramName;
			
			// Set a value to the parameter.
			paramDiscreteValue.Value = i_paramValue;
			paramValues.Add(paramDiscreteValue);
			paramField.CurrentValues = paramValues;
			
			// Add the parameter to the ParameterFields collection.
			o_paramFields.Add(paramField);
			//      Return paramFields
		}
		
#endregion
		
#region PRIVATE METHODS
		
#endregion
	}
	
}
