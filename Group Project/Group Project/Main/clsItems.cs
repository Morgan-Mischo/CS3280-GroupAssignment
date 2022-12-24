using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;  
using System.Runtime.CompilerServices;

namespace Group_Project.Main
{
    public class clsItems 
    {
        #region Attributes
        /// <summary>
        /// Create getter and setters for ItemCode, ItemDesc, and ItemCost
        /// </summary>
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }

        public string ItemCost { get; set; }


        #endregion

        #region Method

        /// <summary>
        /// Constructor for clsPassenger
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        public clsItems(string sitemDesc, string sitemCode, string sitemCost)
        {
            try
            {
                ItemDesc = sitemDesc;
                ItemCode = sitemCode;
                ItemCost = sitemCost;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Blank constructor for clas passenger
        /// </summary>
        public clsItems()
        {

        }

        /// <summary>
        /// overrides the method to display the person first and last name
        /// </summary>
        public override string ToString()
        {
            try
            {
                return ItemDesc;
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
        

