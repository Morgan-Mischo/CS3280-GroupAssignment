using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Group_Project.Main
{
    /// <summary>
    /// This SQL gets all data on an invoice for a given InvoiceID.
    /// </summary>
    /// <param name="sInvoiceID">The InvoiceID for the invoice to retrieve all data.</param>
    public class clsMainSQL
    {
        #region Variables

        /// <summary>
        /// Creates an instance of the DataAccess class
        /// </summary>
        private clsDataAccess db;

        /// <summary>
        /// Create a list to hold the Items
        /// </summary>
        public List<clsItems> lstItems { get; set; }

        /// <summary>
        /// Holds an SQL statement
        /// </summary>
        public string sSQL;

        public int newInvoiceNum;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public clsMainSQL()
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

        #region Get Item Description

        /// <summary>
        /// Gets the Item Description
        /// </summary>
        /// <returns></returns>
        public List<clsItems> GetItemDesc()
        {
            try
            {
                db = new clsDataAccess();

                int iRet = 0;   //Number of return values
                DataSet ds = new DataSet(); //Holds the return values

                clsItems Items;
                sSQL = "SELECT ItemDesc, ItemCode, Cost FROM ItemDesc ";

                //Extract the passengers and put them into the DataSet
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                lstItems = new List<clsItems>();
                for (int i = 0; i < iRet; i++)
                {
                    Items = new clsItems();
                    Items.ItemDesc = ds.Tables[0].Rows[i]["ItemDesc"].ToString();
                    Items.ItemCode = ds.Tables[0].Rows[i]["ItemCode"].ToString();
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

        /// <summary>
        /// Inserts an Item
        /// </summary>
        /// <param name="sItemCode"></param>
        /// <param name="sItemDesc"></param>
        /// <param name="sCost"></param>
        /// <returns></returns>
        public string itemsInsert(DateTime sInvoiceDate, double sTotalCost)
        {
            try
            {
                db = new clsDataAccess();

                sSQL = "INSERT INTO Invoices (InvoiceDate, TotalCost)"
                + "VALUES('" + sInvoiceDate + "' , '" + sTotalCost + "')";

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

        public int grabMax()
        {
            try
            {
                db = new clsDataAccess();

                sSQL = "SELECT MAX(InvoiceNum) " +
                "FROM Invoices";

                db.ExecuteNonQuery(sSQL);

                newInvoiceNum = Convert.ToInt32(sSQL);

                return newInvoiceNum;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public string insertLineItems(int sNewInvoiceNum, int LineItemNumber, string ItemCode)
        {
            try
            {
                db = new clsDataAccess();

                sSQL = "INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode)"
                       + "VALUES('" + sNewInvoiceNum + "' , '" + LineItemNumber + "' , '" + ItemCode + "')";

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

        #endregion Get Item Description
    }
}