using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.Search
{
    public class clsSearchSQL
    {
        #region Variables
        /// <summary>
        /// Holds an SQL statement
        /// </summary>
        public string sSQL;    

        /// <summary>
        /// Creates an instance of the DataAccess class
        /// </summary>
        clsDataAccess db;
        #endregion

        #region Lists
        /// <summary>
        /// Creates lists for everything
        /// </summary>
        public List<clsSearchInvoiceNum> lstInvoiceNum { get; set; }

        public List<clsSearchInvoiceDate> lstInvoiceDate { get; set; }

        public List<clsSearchInvoiceCost> lstInvoiceCost { get; set; }

        public List<clsSearchInvoiceCost> lstSearchDataGrid { get; set; }

        public List<clsSearchInvoiceCost> lstFliter5000 { get; set; }
        public List<clsSearchInvoiceCost> lstFliter5001 { get; set; }
        public List<clsSearchInvoiceCost> lstFliter5002 { get; set; }
        public List<clsSearchInvoiceCost> lstFliter5003 { get; set; }

        public List<clsSearchInvoiceCost> lstFliterDate5000 { get; set; }

        public List<clsSearchInvoiceCost> lstFliterDate5001 { get; set; }

        public List<clsSearchInvoiceCost> lstFliterDate5002 { get; set; }

        public List<clsSearchInvoiceCost> lstFliterCost5000 { get; set; }
        public List<clsSearchInvoiceCost> lstFliterCost5001 { get; set; }
        public List<clsSearchInvoiceCost> lstFliterCost5002{ get; set; }
        public List<clsSearchInvoiceCost> lstFliterCost5003 { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public clsSearchSQL()
        {
            lstFliterCost5000 = new List<clsSearchInvoiceCost>();
            lstFliterCost5001 = new List<clsSearchInvoiceCost>();
            lstFliterCost5002 = new List<clsSearchInvoiceCost>();
            lstFliterCost5003 = new List<clsSearchInvoiceCost>();
            lstFliterDate5000 = new List<clsSearchInvoiceCost>();
            lstFliterDate5001 = new List<clsSearchInvoiceCost>();
            lstFliterDate5002 = new List<clsSearchInvoiceCost>();
            lstFliter5000 = new List<clsSearchInvoiceCost>();
            lstFliter5001 = new List<clsSearchInvoiceCost>();
            lstFliter5002 = new List<clsSearchInvoiceCost>();
            lstFliter5003 = new List<clsSearchInvoiceCost>();
            lstInvoiceNum = new List<clsSearchInvoiceNum>();
            lstInvoiceDate = new List<clsSearchInvoiceDate>();
            lstInvoiceCost = new List<clsSearchInvoiceCost>();
            lstSearchDataGrid = new List<clsSearchInvoiceCost>();
        }
        #endregion

        #region Get invoice Num
        /// <summary>
        /// Gets the invoice Num
        /// </summary>
        /// <returns></returns>
        public List<clsSearchInvoiceNum> GetInvoiceNum()
        {
            try
            {
                db = new clsDataAccess();

                int iRet = 0;   //Number of return values
                DataSet ds = new DataSet(); //Holds the return values

                clsSearchInvoiceNum searchInvoice;
                sSQL = $"SELECT InvoiceNum FROM Invoices ";

                //Extract the passengers and put them into the DataSet
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                lstInvoiceNum = new List<clsSearchInvoiceNum>();
                for (int i = 0; i < iRet; i++)
                {
                    searchInvoice = new clsSearchInvoiceNum();
                    searchInvoice.sInvoiceNumber = ds.Tables[0].Rows[i]["InvoiceNum"].ToString();

                    lstInvoiceNum.Add(searchInvoice);
                }

                return lstInvoiceNum;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Get Invoice Cost
        /// <summary>
        /// Get Invoice Cost
        /// </summary>
        /// <returns></returns>
        public List<clsSearchInvoiceCost> GetInvoiceCost()
        {
            try
            {
                db = new clsDataAccess();

                int iRet = 0;   //Number of return values
                DataSet ds = new DataSet(); //Holds the return values

                clsSearchInvoiceCost searchCost;
                sSQL = $"SELECT TotalCost FROM Invoices ORDER BY TotalCost";

                //Extract the passengers and put them into the DataSet
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                lstInvoiceCost = new List<clsSearchInvoiceCost>();
                for (int i = 0; i < iRet; i++)
                {
                    searchCost = new clsSearchInvoiceCost();
                    searchCost.sInvoiceCost = ds.Tables[0].Rows[i]["TotalCost"].ToString();

                    lstInvoiceCost.Add(searchCost);
                }

                return lstInvoiceCost;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Get Invoice Date
        /// <summary>
        /// Get Invoice Date
        /// </summary>
        /// <returns></returns>
        public List<clsSearchInvoiceDate> GetInvoiceDates()
        {
            try
            {
                db = new clsDataAccess();

                int iRet = 0;   //Number of return values
                DataSet ds = new DataSet(); //Holds the return values

                clsSearchInvoiceDate searchDate;
                sSQL = $"SELECT InvoiceDate FROM Invoices ";

                //Extract the passengers and put them into the DataSet
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                lstInvoiceDate = new List<clsSearchInvoiceDate>();
                for (int i = 0; i < iRet; i++)
                {
                    searchDate = new clsSearchInvoiceDate();
                    searchDate.sInvoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();

                    lstInvoiceDate.Add(searchDate);
                }

                return lstInvoiceDate;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region intial state of search DataGrid
        /// <summary>
        /// intial state of search DataGrid
        /// </summary>
        /// <returns></returns>
        public List<clsSearchInvoiceCost> getSearchDataGrid()
        {
            try
            {
                db = new clsDataAccess();

                int iRet = 0;   //Number of return values
                DataSet ds = new DataSet(); //Holds the return values

                clsSearchInvoiceCost DataGrid;
                sSQL = $"SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices";

                //Extract the passengers and put them into the DataSet
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                lstSearchDataGrid = new List<clsSearchInvoiceCost>();
                for (int i = 0; i < iRet; i++)
                {
                    DataGrid = new clsSearchInvoiceCost();
                    DataGrid.InvoiceNum = ds.Tables[0].Rows[i]["InvoiceNum"].ToString();
                    DataGrid.InvoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();
                    DataGrid.TotalCost = ds.Tables[0].Rows[i]["TotalCost"].ToString();


                    lstSearchDataGrid.Add(DataGrid);
                }

                return lstSearchDataGrid;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region GetInvoiceNums Filter
        /// <summary>
        /// GetInvoiceNums Filter for 5000
        /// </summary>
        /// <returns></returns>
        public List<clsSearchInvoiceCost> GetInvoiceNumber5000()
        {
            try
            {
                db = new clsDataAccess();

                int iRet = 0;   //Number of return values
                DataSet ds = new DataSet(); //Holds the return values

                clsSearchInvoiceCost DataGrid;
                sSQL = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = 5000 ";

                //Extract the passengers and put them into the DataSet
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                lstFliter5000 = new List<clsSearchInvoiceCost>();
                for (int i = 0; i < iRet; i++)
                {
                    DataGrid = new clsSearchInvoiceCost();
                    DataGrid.InvoiceNum = ds.Tables[0].Rows[i]["InvoiceNum"].ToString();
                    DataGrid.InvoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();
                    DataGrid.TotalCost = ds.Tables[0].Rows[i]["TotalCost"].ToString();


                    lstFliter5000.Add(DataGrid);
                }
                return lstFliter5000;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// GetInvoiceNumber for 5001
        /// </summary>
        /// <returns></returns>
        public List<clsSearchInvoiceCost> GetInvoiceNumber5001()
        {
            try
            {
                db = new clsDataAccess();

                int iRet = 0;   //Number of return values
                DataSet ds = new DataSet(); //Holds the return values

                clsSearchInvoiceCost DataGrid;
                sSQL = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = 5001 ";

                //Extract the passengers and put them into the DataSet
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                lstFliter5001 = new List<clsSearchInvoiceCost>();
                for (int i = 0; i < iRet; i++)
                {
                    DataGrid = new clsSearchInvoiceCost();
                    DataGrid.InvoiceNum = ds.Tables[0].Rows[i]["InvoiceNum"].ToString();
                    DataGrid.InvoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();
                    DataGrid.TotalCost = ds.Tables[0].Rows[i]["TotalCost"].ToString();


                    lstFliter5001.Add(DataGrid);
                }
                return lstFliter5001;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// GetInvoiceNumber for 5002
        /// </summary>
        /// <returns></returns>
        public List<clsSearchInvoiceCost> GetInvoiceNumber5002()
        {
            try
            {
                db = new clsDataAccess();

                int iRet = 0;   //Number of return values
                DataSet ds = new DataSet(); //Holds the return values

                clsSearchInvoiceCost DataGrid;
                sSQL = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = 5002 ";

                //Extract the passengers and put them into the DataSet
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                lstFliter5002 = new List<clsSearchInvoiceCost>();
                for (int i = 0; i < iRet; i++)
                {
                    DataGrid = new clsSearchInvoiceCost();
                    DataGrid.InvoiceNum = ds.Tables[0].Rows[i]["InvoiceNum"].ToString();
                    DataGrid.InvoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();
                    DataGrid.TotalCost = ds.Tables[0].Rows[i]["TotalCost"].ToString();


                    lstFliter5002.Add(DataGrid);
                }
                return lstFliter5002;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// GetInvoiceNumber for 5003
        /// </summary>
        /// <returns></returns>
        public List<clsSearchInvoiceCost> GetInvoiceNumber5003()
        {
            try
            {
                db = new clsDataAccess();

                int iRet = 0;   //Number of return values
                DataSet ds = new DataSet(); //Holds the return values

                clsSearchInvoiceCost DataGrid;
                sSQL = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = 5003 ";

                //Extract the passengers and put them into the DataSet
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                lstFliter5003 = new List<clsSearchInvoiceCost>();
                for (int i = 0; i < iRet; i++)
                {
                    DataGrid = new clsSearchInvoiceCost();
                    DataGrid.InvoiceNum = ds.Tables[0].Rows[i]["InvoiceNum"].ToString();
                    DataGrid.InvoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();
                    DataGrid.TotalCost = ds.Tables[0].Rows[i]["TotalCost"].ToString();


                    lstFliter5003.Add(DataGrid);
                }
                return lstFliter5003;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region GetInvoiceDate Filter
        /// <summary>
        /// GetInvoiceDate for 5000
        /// </summary>
        /// <returns></returns>
        public List<clsSearchInvoiceCost> GetInvoiceDate5000()
        {
            try
            {
                db = new clsDataAccess();

                int iRet = 0;   //Number of return values
                DataSet ds = new DataSet(); //Holds the return values

                clsSearchInvoiceCost DataGrid;
                sSQL = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceDate LIKE '4/23/2018' ";

                //Extract the passengers and put them into the DataSet
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                lstFliterDate5000 = new List<clsSearchInvoiceCost>();
                for (int i = 0; i < iRet; i++)
                {
                    DataGrid = new clsSearchInvoiceCost();
                    DataGrid.InvoiceNum = ds.Tables[0].Rows[i]["InvoiceNum"].ToString();
                    DataGrid.InvoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();
                    DataGrid.TotalCost = ds.Tables[0].Rows[i]["TotalCost"].ToString();


                    lstFliterDate5000.Add(DataGrid);
                }
                return lstFliterDate5000;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// GetInvoiceDate for 5001
        /// </summary>
        /// <returns></returns>
        public List<clsSearchInvoiceCost> GetInvoiceDate5001()
        {
            try
            {
                db = new clsDataAccess();

                int iRet = 0;   //Number of return values
                DataSet ds = new DataSet(); //Holds the return values

                clsSearchInvoiceCost DataGrid;
                sSQL = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceDate LIKE '4/25/2018' ";

                //Extract the passengers and put them into the DataSet
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                lstFliterDate5001 = new List<clsSearchInvoiceCost>();
                for (int i = 0; i < iRet; i++)
                {
                    DataGrid = new clsSearchInvoiceCost();
                    DataGrid.InvoiceNum = ds.Tables[0].Rows[i]["InvoiceNum"].ToString();
                    DataGrid.InvoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();
                    DataGrid.TotalCost = ds.Tables[0].Rows[i]["TotalCost"].ToString();

                    lstFliterDate5001.Add(DataGrid);
                }
                return lstFliterDate5001;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// GetInvoiceDate for 5002
        /// </summary>
        /// <returns></returns>
        public List<clsSearchInvoiceCost> GetInvoiceDate5002()
        {
            try
            {
                db = new clsDataAccess();

                int iRet = 0;   //Number of return values
                DataSet ds = new DataSet(); //Holds the return values

                clsSearchInvoiceCost DataGrid;
                sSQL = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceDate LIKE '5/19/2018' ";

                //Extract the passengers and put them into the DataSet
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                lstFliterDate5002 = new List<clsSearchInvoiceCost>();
                for (int i = 0; i < iRet; i++)
                {
                    DataGrid = new clsSearchInvoiceCost();
                    DataGrid.InvoiceNum = ds.Tables[0].Rows[i]["InvoiceNum"].ToString();
                    DataGrid.InvoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();
                    DataGrid.TotalCost = ds.Tables[0].Rows[i]["TotalCost"].ToString();


                    lstFliterDate5002.Add(DataGrid);
                }
                return lstFliterDate5002;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region GetTotalCost Filter
        /// <summary>
        /// GetTotalCost for 5000
        /// </summary>
        /// <returns></returns>
        public List<clsSearchInvoiceCost> GetTotalCost5000()
        {
            try
            {
                db = new clsDataAccess();

                int iRet = 0;   //Number of return values
                DataSet ds = new DataSet(); //Holds the return values

                clsSearchInvoiceCost DataGrid;
                sSQL = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE TotalCost = 201 ";

                //Extract the passengers and put them into the DataSet
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                lstFliterCost5000 = new List<clsSearchInvoiceCost>();
                for (int i = 0; i < iRet; i++)
                {
                    DataGrid = new clsSearchInvoiceCost();
                    DataGrid.InvoiceNum = ds.Tables[0].Rows[i]["InvoiceNum"].ToString();
                    DataGrid.InvoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();
                    DataGrid.TotalCost = ds.Tables[0].Rows[i]["TotalCost"].ToString();


                    lstFliterCost5000.Add(DataGrid);
                }
                return lstFliterCost5000;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// GetTotalCost for 5001
        /// </summary>
        /// <returns></returns>
        public List<clsSearchInvoiceCost> GetTotalCost5001()
        {
            try
            {
                db = new clsDataAccess();

                int iRet = 0;   //Number of return values
                DataSet ds = new DataSet(); //Holds the return values

                clsSearchInvoiceCost DataGrid;
                sSQL = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE TotalCost = 110 ";

                //Extract the passengers and put them into the DataSet
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                lstFliterCost5001 = new List<clsSearchInvoiceCost>();
                for (int i = 0; i < iRet; i++)
                {
                    DataGrid = new clsSearchInvoiceCost();
                    DataGrid.InvoiceNum = ds.Tables[0].Rows[i]["InvoiceNum"].ToString();
                    DataGrid.InvoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();
                    DataGrid.TotalCost = ds.Tables[0].Rows[i]["TotalCost"].ToString();


                    lstFliterCost5001.Add(DataGrid);
                }
                return lstFliterCost5001;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// GetTotalCost for 5002
        /// </summary>
        /// <returns></returns>
        public List<clsSearchInvoiceCost> GetTotalCost5002()
        {
            try
            {
                db = new clsDataAccess();

                int iRet = 0;   //Number of return values
                DataSet ds = new DataSet(); //Holds the return values

                clsSearchInvoiceCost DataGrid;
                sSQL = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE TotalCost = 40 ";

                //Extract the passengers and put them into the DataSet
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                lstFliterCost5002 = new List<clsSearchInvoiceCost>();
                for (int i = 0; i < iRet; i++)
                {
                    DataGrid = new clsSearchInvoiceCost();
                    DataGrid.InvoiceNum = ds.Tables[0].Rows[i]["InvoiceNum"].ToString();
                    DataGrid.InvoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();
                    DataGrid.TotalCost = ds.Tables[0].Rows[i]["TotalCost"].ToString();


                    lstFliterCost5002.Add(DataGrid);
                }
                return lstFliterCost5002;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// GetTotalCost for 5003
        /// </summary>
        /// <returns></returns>
        public List<clsSearchInvoiceCost> GetTotalCost5003()
        {
            try
            {
                db = new clsDataAccess();

                int iRet = 0;   //Number of return values
                DataSet ds = new DataSet(); //Holds the return values

                clsSearchInvoiceCost DataGrid;
                sSQL = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE TotalCost = 20 ";

                //Extract the passengers and put them into the DataSet
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                lstFliterCost5003 = new List<clsSearchInvoiceCost>();
                for (int i = 0; i < iRet; i++)
                {
                    DataGrid = new clsSearchInvoiceCost();
                    DataGrid.InvoiceNum = ds.Tables[0].Rows[i]["InvoiceNum"].ToString();
                    DataGrid.InvoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();
                    DataGrid.TotalCost = ds.Tables[0].Rows[i]["TotalCost"].ToString();


                    lstFliterCost5003.Add(DataGrid);
                }
                return lstFliterCost5003;
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
