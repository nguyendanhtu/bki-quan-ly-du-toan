// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports



namespace IP.Core.IPCommon
{
	public enum SearchType
	{
		fromStart = 0,
		fromNextRow = 1
	}
	
	public interface ISearchable
	{
		bool startSearch(IFoundCondition i_PatternSearch, SearchType 
			i_SearchType);
	}
	
	public interface IFoundCondition
	{
		bool MatchThePattern(object i_Data2Compare);
	}
	
	public interface ISearchForm
	{
		void displaySearch(ISearchable i_form2Search);
	}
}
