using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Group_Project
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        #region Variables
        /// <summary>
        /// Creates an instance of the Items SQL class
        /// </summary>
        private Items.clsItemsSQL ItemsSql;

        /// <summary>
        /// Creates a list to hold Items data
        /// </summary>
        public List<Main.clsItems> lstData;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public wndItems()
        {
            try
            {
                ItemsSql = new Items.clsItemsSQL();
                InitializeComponent();
                updateItem();
                dealWithDataGrid();
            }
            catch (Exception ex)
            {
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            //create getters and setters maybe in another class?
        }
        #endregion

        #region Methods
        /// <summary>
        /// Print information out to the DataGrid
        /// </summary>
        public void dealWithDataGrid()
        {
            try
            {
                DataGridItems.ItemsSource = ItemsSql.lstItems;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Updates the list by using items SQL class
        /// </summary>
        public void updateItem()
        {
            try
            {
                lstData = ItemsSql.GetItemDesc();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// We ended up not using this 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowBinding(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Add new Item
        /// <summary>
        /// Add a new item to the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sCode = txtAddItemCode.Text;
                string sDesc = txtAddItemDesc.Text;
                string dCost = txtIAddtemCost.Text;

                ItemsSql.itemsInsert(sCode, sDesc, dCost);
                updateItem();
                dealWithDataGrid();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region Edit Button
        /// <summary>
        /// Edits an item in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditExisting_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //when this button is clicked update the item in the list that will be passed to the 
                //main window to display in the combo box
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region Delete Button
        /// <summary>
        /// Deletes an item from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteExistingItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //when this button is clicked item in the list will be deleted and that list will be passed to the 
                //main window to display in the combo box
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region Error Handling 
        /// <summary>
        /// Handle the error.
        /// </summary>
        /// <param name="sClass">The class in which the error occurred in.</param>
        /// <param name="sMethod">The method in which the error occurred in.</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                //Would write to a file or database here.
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }

        #endregion
    }
}
