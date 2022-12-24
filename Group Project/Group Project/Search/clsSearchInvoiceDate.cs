using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.Search
{
    public class clsSearchInvoiceDate
    {
        #region Attributes
        /// <summary>
        /// Variable for sInvoiceDate
        /// </summary>
        public string sInvoiceDate;

        #endregion

        #region Method

        /// <summary>
        /// Constructor for clsPassenger
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        public clsSearchInvoiceDate(string InvoiceDate)
        {
            try
            {
                sInvoiceDate = InvoiceDate;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Blank constructor for clas passenger
        /// </summary>
        public clsSearchInvoiceDate()
        {

        }

        /// <summary>
        /// overrides the method to display the person first and last name
        /// </summary>
        public override string ToString()
        {
            try
            {
                return sInvoiceDate;
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
