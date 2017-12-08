using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CDMS.Entity;
using CDMS.Utility;

namespace CDMS.Data
{
    public interface IMenuTableRepository : IRepository<MenuTable>
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        LayuiPaginationOut GetList(LayuiPaginationIn p);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool Delete(int[] ids);
    }

    public class MenuTableRepository : RepositoryBase<MenuTable>, IMenuTableRepository
    {
        public LayuiPaginationOut GetList(LayuiPaginationIn p)
        {
            sql.SelectAll();
            sql.Where(m => m.ENABLED == true);

            MenuTable table = p.json.ToObject<MenuTable>();
            if (table.MENUID > 0) sql.And(m => m.MENUID == table.MENUID);
            if (!table.TABLENAME.IsEmpty())
            {
                sql.And(m => m.TABLENAME.Contains(table.TABLENAME));
            }

            sql.OrderBy(m => m.SORTID);

            var list = GetPageList(p);
            return new LayuiPaginationOut(p, list);
        }

        public bool Delete(int[] ids)
        {
            sql.In(m => m.ID, ids);

            sql.Update(new { ENABLED = false }, m => m.ENABLED);

            int count = Execute();

            return count > 0;
        }
    }
}
