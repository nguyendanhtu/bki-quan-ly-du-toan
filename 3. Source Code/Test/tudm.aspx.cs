using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLDataAccess;

public partial class tudm : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}
	protected void m_cmd_get_ma_so_children_Click(object sender, EventArgs e)
	{
		//string v_str_ma_so_parent = "";
		BKI_QLDTEntities db = new BKI_QLDTEntities();
		GD_DU_TOAN_THU_CHI_PHI_PHA gd = db.GD_DU_TOAN_THU_CHI_PHI_PHA.FirstOrDefault(x => x.ID == 31);
		var lst_children = db.GD_DU_TOAN_THU_CHI_PHI_PHA
			.Where(x => x.MA_SO_PARENT == gd.MA_SO)
			.ToList();
		m_txt_ma_so_children.Text = getMaSoChildrenByMaSoParent(gd.MA_SO, lst_children);
		m_txt_ma_so_parent.Text = gd.MA_SO;
	}



	public string getMaSoChildrenByMaSoParent(string ip_str_ma_so_parent, List<GD_DU_TOAN_THU_CHI_PHI_PHA> ip_lst_children)
	{
		string v_str_ma_so = "";
		Int32 v_i_max_sufix;
		//Neu chua co children
		if (ip_lst_children.Count() == 0)
		{
			v_i_max_sufix = 101;
		}
		else
		{
			//Neu da co children
			v_i_max_sufix = ip_lst_children.Select(x => Convert.ToInt32(x.MA_SO.Replace(ip_str_ma_so_parent, ""))).Max() + 1;
		}
		v_str_ma_so = ip_str_ma_so_parent + v_i_max_sufix.ToString();
		return v_str_ma_so;
	}
}