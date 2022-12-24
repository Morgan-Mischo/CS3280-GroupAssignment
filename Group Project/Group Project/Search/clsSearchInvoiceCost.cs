using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.Search
{
    public class clsSearchInvoiceCost
    {
        #region Attributes

        /// <summary>
        /// Creates getter and setters for InvoiceNum, InvoiceDate, TotalCost, and sInvoiceCost
        /// </summary>
        public string InvoiceNum { get; set; }
        public string InvoiceDate { get; set; }
        public string TotalCost { get; set; }
        public string sInvoiceCost { get; set; }


        #endregion

        #region Method

        /// <summary>
        /// Constructor for clsPassenger
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        public clsSearchInvoiceCost(string InvoiceCost, string sInvoiceNum, string sInvoiceDate, string sTotalCost)
        {
            try
            {
                sInvoiceCost = InvoiceCost;
                InvoiceNum = sInvoiceNum;
                InvoiceDate = sInvoiceDate;
                TotalCost = sTotalCost;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Blank constructor for clas passenger
        /// </summary>
        public clsSearchInvoiceCost()
        {

        }

        /// <summary>
        /// overrides the method to display the person first and last name
        /// </summary>
        public override string ToString()
        {
            try
            {
                return sInvoiceCost;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        #endregion
    }
}
