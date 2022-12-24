using Group_Project.Main;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.Items
{
    public class clsItemsSQL
    {
        #region Variables

        /// <summary>
        /// Holds an SQL statement
        /// </summary>
        public string sSQL;

        /// <summary>
        /// Creates an instance of the DataAccess class
        /// </summary>
        private clsDataAccess db;

        /// <summary>
        /// Create a list to hold the list items
        /// </summary>
        public List<clsItems> lstItems { get; set; }

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public clsItemsSQL()
        {
            try
            {
                lstItems = new List<clsItems>();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        #endregion Constructor

        #region Item Description

        /// <summary>
        /// Gets the item Description
        /// </summary>
        /// <returns></returns>
        public List<clsItems> GetItemDesc()
        {
            try
            {
                db = new clsDataAccess();

                int iRet = 0;   //Number of return values
                DataSet ds = new DataSet(); //Holds the return values

                ds.AcceptChanges();

                clsItems Items;
                sSQL = "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc ";

                //Extract the passengers and put them into the DataSet
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                lstItems = new List<clsItems>();
                for (int i = 0; i < iRet; i++)
                {
                    Items = new clsItems();
                    Items.ItemCode = ds.Tables[0].Rows[i]["ItemCode"].ToString();
                    Items.ItemDesc = ds.Tables[0].Rows[i]["ItemDesc"].ToString();
                    Items.ItemCost = ds.Tables[0].Rows[i]["Cost"].ToString();

                    lstItems.Add(Items);
                }

                return lstItems;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        #endregion Item Description

        //Not used rn

        #region Item Select

        /// <summary>
        /// Selects an Item
        /// </summary>
        /// <param name="sInvoiceNum"></param>
        /// <param name="sItemCode"></param>
        /// <returns></returns>
        public string itemsSelect(int sInvoiceNum, int sItemCode)
        {
            try
            {
                sSQL = $"select ItemCode, ItemDesc, Cost from ItemDesc select distinct({sInvoiceNum}) " +
                $"from LineItems where ItemCode = {sItemCode}";

                return sSQL;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        #endregion Item Select

        //Not used rn

        #region Update Item

        /// <summary>
        /// Updates an item
        /// </summary>
        /// <param name="sItemDesc"></param>
        /// <param name="sCost"></param>
        /// <param name="sItemCode"></param>
        /// <returns></returns>
        public string itemsUpdate(string sItemDesc, double sCost, string sItemCode)
        {
            try
            {
                sSQL = $"Update ItemDesc Set ItemDesc = {sItemDesc}, Cost = {sCost} where ItemCode = {sItemCode}";
                return sSQL;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        #endregion Update Item

        #region Insert Item

        /// <summary>
        /// Inserts an Item
        /// </summary>
        /// <param name="sItemCode"></param>
        /// <param name="sItemDesc"></param>
        /// <param name="sCost"></param>
        /// <returns></returns>
        public string itemsInsert(string sItemCode, string sItemDesc, string sCost)
        {
            try
            {
                db = new clsDataAccess();

                sSQL = "INSERT INTO ItemDesc(ItemCode, ItemDesc, Cost)"
                + "VALUES('" + sItemCode + "' , '" + sItemDesc + "' , '" + sCost + "')";

                db.ExecuteNonQuery(sSQL);

                return sSQL;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        #endregion Insert Item
    }
}