using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.Items
{
    public class clsItemCode
    {
        #region Attributes
        /// <summary>
        /// Creates attributes for Item Description, Item Cost, and Item Code
        /// </summary>
        public string sItemDesc;
        public string sItemCost;
        public string sItemCode;

        #endregion

        #region Method

        /// <summary>
        /// Constructor for clsPassenger
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        public clsItemCode(string itemDesc, string itemCode, string itemCost)
        {
            try
            {
                sItemDesc = itemDesc;
                sItemCode = itemCode;
                sItemCost = itemCost;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Blank constructor for clas passenger
        /// </summary>
        public clsItemCode()
        {

        }

        /// <summary>
        /// overrides the method to display the person first and last name
        /// </summary>
        public override string ToString()
        {
            try
            {
                return sItemDesc;
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
