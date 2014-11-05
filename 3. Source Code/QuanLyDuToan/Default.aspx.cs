using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPUserService;

using WebUS;
using WebDS;
using WebDS.CDBNames;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
        }
    }

    #region Members
    
    #endregion

    #region Private Methods
  
    #endregion

    #region Public Interface
   
    #endregion

    #region Export Excel
   
    #endregion

    #region Events
    
    #endregion
    
    protected void Timer1_Tick(object sender, EventArgs e) 
    {
        Literal1.Text = DateTime.Now.Hour + ":"+ DateTime.Now.Minute + ":" + DateTime.Now.Second + " Ngày " + DateTime.Now.Day+"/"+DateTime.Now.Month + "/" + DateTime.Now.Year; 
    } 
    
}
