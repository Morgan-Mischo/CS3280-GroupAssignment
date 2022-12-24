﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.Items
{
    public class clsItemsLogic
    {
        #region Variables
        /// <summary>
        /// Creates an instance of the DataAccess class
        /// </summary>
        clsDataAccess db;

        /// <summary>
        /// Creates an instance of the ItemsSQL class
        /// </summary>
        clsItemsSQL clsItemsSQL;
        #endregion

        #region Execute Items SQL
        /// <summary>
        /// executes the itemsSQL statement when called
        /// </summary>
        public void exeItemsSQL()
        {
            try
            {
                clsItemsSQL = new clsItemsSQL();

                db = new clsDataAccess();
                int iRet = 0;   //Number of return values
                DataSet ds = new DataSet(); //Holds the return values

                //Extract the passengers and put them into the DataSet
                ds = db.ExecuteSQLStatement(clsItemsSQL.sSQL, ref iRet);
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
