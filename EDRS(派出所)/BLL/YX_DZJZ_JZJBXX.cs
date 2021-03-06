﻿
using System;
using System.Data;
using System.Collections.Generic;
using EDRS.Common;
using EDRS.Model;
using EDRS.DALFactory;
using EDRS.IDAL;
namespace EDRS.BLL
{
	/// <summary>
	/// 卷宗基本信息表
	/// </summary>
	public partial class YX_DZJZ_JZJBXX
	{
		private readonly IYX_DZJZ_JZJBXX dal=DataAccess.CreateYX_DZJZ_JZJBXX();
        public YX_DZJZ_JZJBXX(System.Web.HttpRequest _context)
        {
            dal.SetHttpContext(_context);
        }
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string JZBH)
		{
			return dal.Exists(JZBH);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(EDRS.Model.YX_DZJZ_JZJBXX model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EDRS.Model.YX_DZJZ_JZJBXX model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string JZBH)
		{
			
			return dal.Delete(JZBH);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string JZBHlist )
		{
			return dal.DeleteList(JZBHlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public EDRS.Model.YX_DZJZ_JZJBXX GetModel(string JZBH)
		{
			
			return dal.GetModel(JZBH);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public EDRS.Model.YX_DZJZ_JZJBXX GetModelByCache(string JZBH)
		{
			
			string CacheKey = "YX_DZJZ_JZJBXXModel-" + JZBH;
			object objModel = EDRS.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(JZBH);
					if (objModel != null)
					{
						int ModelCache = EDRS.Common.ConfigHelper.GetConfigInt("ModelCache");
						EDRS.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (EDRS.Model.YX_DZJZ_JZJBXX)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet GetList(string strWhere, params object[] objValues)
		{
			return dal.GetList(strWhere,objValues);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<EDRS.Model.YX_DZJZ_JZJBXX> GetModelList(string strWhere, params object[] objValues)
		{
			DataSet ds = dal.GetList(strWhere,objValues);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<EDRS.Model.YX_DZJZ_JZJBXX> DataTableToList(DataTable dt)
		{
			List<EDRS.Model.YX_DZJZ_JZJBXX> modelList = new List<EDRS.Model.YX_DZJZ_JZJBXX>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				EDRS.Model.YX_DZJZ_JZJBXX model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public int GetRecordCount(string strWhere, params object[] objValues)
		{
			return dal.GetRecordCount(strWhere,objValues);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, params object[] objValues)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex,objValues);
		}
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCountPower(string strWhere, params object[] objValues)
        {
            return dal.GetRecordCountPower(strWhere, objValues);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPagePower(string strWhere, string orderby, int startIndex, int endIndex, params object[] objValues)
        {
            return dal.GetListByPagePower(strWhere, orderby, startIndex, endIndex, objValues);
        }
        /// <summary>
        /// 解锁
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool LockByModelList(List<EDRS.Model.YX_DZJZ_JZJBXX> modelList)
        {
            return dal.LockByModelList(modelList);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EDRS.Model.YX_DZJZ_JZJBXX GetModelByBMSAH(string BMSAH)
        {
            return dal.GetModelByBMSAH(BMSAH);
        }

        /// <summary>
        /// 批量审核数据
        /// </summary>
        public bool UpdateByZZZTList(string BMSAHlist, string SHR, DateTime SHSJ, string SHRGH, string ZZZT, string JZPZ)
        { 
            return dal.UpdateByZZZTList(BMSAHlist, SHR, SHSJ, SHRGH, ZZZT, JZPZ);
        }

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

        /// <summary>
        /// 获取卷宗基本信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetJzjbxxByBmsah(string bmsah, string dwbm)
        {
            return dal.GetJzjbxxByBmsah(bmsah, dwbm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bmsahs"></param>
        /// <param name="dwbm"></param>
        /// <returns></returns>
        public DataSet GetJzjbxxByBmsahList(string bmsahs, string dwbm)
        {
            return dal.GetJzjbxxByBmsahList(bmsahs,dwbm);
        }

		#endregion  ExtensionMethod
	}
}

