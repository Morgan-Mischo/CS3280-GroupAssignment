using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.Search
{
    public class clsSeachLogic
    {
        #region Variables
        /// <summary>
        /// Creates an intance of the DataAccess class
        /// </summary>
        clsDataAccess db;

        /// <summary>
        /// Creates an instance of the SearchSQL 
        /// </summary>
        clsSearchSQL clsSearchSQL;
        #endregion

        #region Execute SearchSQL
        /// <summary>
        /// Executes the SearchSQL
        /// </summary>
        public void exeSearchSQL()
        {
            try
            {
                clsSearchSQL = new clsSearchSQL();

                db = new clsDataAccess();
                int iRet = 0;   //Number of return values
                DataSet ds = new DataSet(); //Holds the return values

                //Extract the passengers and put them into the DataSet
                ds = db.ExecuteSQLStatement(clsSearchSQL.sSQL, ref iRet);
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

    }
}
