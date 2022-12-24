using System;
using System.Collections.Generic;
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
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        #region Variables
        /// <summary>
        /// Creates an instance of clsSearchInvoiceNum
        /// </summary>
        Search.clsSearchInvoiceNum SearchInvoiceNum;

        /// <summary>
        /// Creates an instance of clsSearchInvoiceDate
        /// </summary>
        Search.clsSearchInvoiceDate SearchInvoiceDate;

        /// <summary>
        /// Creates an instance of clsSearchInvoiceCost
        /// </summary>
        Search.clsSearchInvoiceCost SearchInvoiceCost;

        /// <summary>
        /// Creates an instance of clsSearchSQL
        /// </summary>
        Search.clsSearchSQL SearchSQL;


        /// <summary>
        /// Creates a list for data
        /// </summary>
        public List<Search.clsSearchInvoiceCost> lstData;


        /// <summary>
        /// Creates an instance list for invoice num
        /// </summary>
        public List<Search.clsSearchInvoiceNum> lstInvoiceNum;

        /// <summary>
        /// Creates an instance list for invoice date 
        /// </summary>
        public List<Search.clsSearchInvoiceDate> lstInvoiceDate;

        /// <summary>
        /// Creates an instance list for invoice cost
        /// </summary>
        public List<Search.clsSearchInvoiceCost> lstInvoiceCost;

        /// <summary>
        /// boolean variable to selection
        /// </summary>
        private bool selection = false;
        #endregion

        #region Constructor 
        /// <summary>
        /// Constructor
        /// </summary>  
        public wndSearch()
        {
            try
            {
                InitializeComponent();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

                SearchSQL = new Search.clsSearchSQL();
                SearchInvoiceNum = new Search.clsSearchInvoiceNum();
                SearchInvoiceDate = new Search.clsSearchInvoiceDate();
                SearchInvoiceCost = new Search.clsSearchInvoiceCost();
                updateItem();
                updateInvoiceNum();
                fillcboInvoiceNumber();
                updateInvoiceCost();
                fillcboInvoiceCost();
                updateInvoiceDate();
                fillcboInvoiceDate();
                dealWithDataGrid();
                btnSelection.IsEnabled = false;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Filter DataGrid
        /// <summary>
        /// puts info into the datagrid
        /// </summary>
        public void dealWithDataGrid()
        {
            try
            {
                DataGridSearch.ItemsSource = SearchSQL.lstSearchDataGrid;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// puts info into the datagrid
        /// </summary>
        public void dealWithFilter5000()
        {
            try
            {
                DataGridSearch.ItemsSource = SearchSQL.lstFliter5000;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// puts info into the datagrid
        /// </summary>
        public void dealWithFilter5001()
        {
            try
            {
                DataGridSearch.ItemsSource = SearchSQL.lstFliter5001;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// puts info into the datagrid
        /// </summary>
        public void dealWithFilter5002()
        {
            try
            {
                DataGridSearch.ItemsSource = SearchSQL.lstFliter5002;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// puts info into the datagrid
        /// </summary>
        public void dealWithFilter5003()
        {
            try
            {
                DataGridSearch.ItemsSource = SearchSQL.lstFliter5003;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// puts info into the datagrid
        /// </summary>
        public void dealWithFilterDate5000()
        {
            try
            {
                DataGridSearch.ItemsSource = SearchSQL.lstFliterDate5000;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// puts info into the datagrid
        /// </summary>
        public void dealWithFilterDate5001()
        {
            try
            {
                DataGridSearch.ItemsSource = SearchSQL.lstFliterDate5001;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// puts info into the datagrid
        /// </summary>
        public void dealWithFilterDate5002()
        {
            try
            {
                DataGridSearch.ItemsSource = SearchSQL.lstFliterDate5002;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// puts info into the datagrid
        /// </summary>
        public void dealWithFilterCost5000()
        {
            try
            {
                DataGridSearch.ItemsSource = SearchSQL.lstFliterCost5000;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// puts info into the datagrid
        /// </summary>
        public void dealWithFilterCost5001()
        {
            try
            {
                DataGridSearch.ItemsSource = SearchSQL.lstFliterCost5001;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// puts info into the datagrid
        /// </summary>
        public void dealWithFilterCost5002()
        {
            try
            {
                DataGridSearch.ItemsSource = SearchSQL.lstFliterCost5002;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        
        /// <summary>
        /// puts info into the datagrid
        /// </summary>
        public void dealWithFilterCost5003()
        {
            try
            {
                DataGridSearch.ItemsSource = SearchSQL.lstFliterCost5003;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Update Item
        /// <summary>
        /// Update the item
        /// </summary>
        public void updateItem()
        {
            try
            {
                lstData = SearchSQL.getSearchDataGrid();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Selection Button
        /// <summary>
        /// Selection button that goes back to the main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Create new instance of main window
                MainWindow wndMain = new MainWindow();
                string selectedItem;
                if (selection == true)
                {
                    selectedItem = DataGridSearch.SelectedItem.ToString();
                }
                //Show main window
                this.Hide();
                wndMain.ShowDialog();
                this.Show();

                //Open the selected invoice up for viewing on the main window 
                //where the user can then edit or delete the invoice
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region dataGridSearch Selection
        /// <summary>
        /// When data grid selection is clicked, all of this happens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                selection = true;
                if (selection == false)
                {
                    btnSelection.IsEnabled = false;
                }
                btnSelection.IsEnabled = true;
                string selectedItem;
                selectedItem = DataGridSearch.SelectedItems.ToString();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region Cancel Button
        /// <summary>
        /// Cancel button that goes back to the main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Create new instance of main window
                MainWindow wndMain = new MainWindow();

                //Show main window
                this.Hide();
                wndMain.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region Combo Invoice Number
        /// <summary>
        /// User selects an invoice number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboInvoiceNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //display the invoice that has the matching invoice number

                //cboInvoiceNumber.ItemsSource = SearchSQL.GetInvoiceNum();

                if (cboInvoiceNumber.SelectedItem == cboInvoiceNumber.Items[0])
                {
                    SearchSQL.GetInvoiceNumber5000();
                    dealWithFilter5000();
                }
                else if (cboInvoiceNumber.SelectedItem == cboInvoiceNumber.Items[1])
                {
                    SearchSQL.GetInvoiceNumber5001();
                    dealWithFilter5001();
                }
                else if (cboInvoiceNumber.SelectedItem == cboInvoiceNumber.Items[2])
                {
                    SearchSQL.GetInvoiceNumber5002();
                    dealWithFilter5002();
                }
                else if (cboInvoiceNumber.SelectedItem == cboInvoiceNumber.Items[3])
                {
                    SearchSQL.GetInvoiceNumber5003();
                    dealWithFilter5003();
                }
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region combo Invoice Cost
        /// <summary>
        /// User selects an Invoice cost
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboInvoiceCost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //display the invoice that has the matching invoice cost
                //cboInvoiceCost.ItemsSource = SearchSQL.GetInvoiceCost();
                if (cboInvoiceCost.SelectedItem == cboInvoiceCost.Items[3])
                {
                    SearchSQL.GetTotalCost5000();
                    dealWithFilterCost5000();
                }
                else if (cboInvoiceCost.SelectedItem == cboInvoiceCost.Items[2])
                {
                    SearchSQL.GetTotalCost5001();
                    dealWithFilterCost5001();
                }
                else if (cboInvoiceCost.SelectedItem == cboInvoiceCost.Items[1])
                {
                    SearchSQL.GetTotalCost5002();
                    dealWithFilterCost5002();
                }
                else if (cboInvoiceCost.SelectedItem == cboInvoiceCost.Items[0])
                {
                    SearchSQL.GetTotalCost5003();
                    dealWithFilterCost5003();
                }
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region combo Invoice Date
        /// <summary>
        /// User selects an invoice date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboInvoiceDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //display the invoice that has the matching invoice date
                //cboInvoiceDate.ItemsSource = SearchSQL.GetInvoiceDates();
                if (cboInvoiceDate.SelectedItem == cboInvoiceDate.Items[0])
                {
                    SearchSQL.GetInvoiceDate5000();
                    dealWithFilterDate5000();
                }
                else if (cboInvoiceDate.SelectedItem == cboInvoiceDate.Items[1])
                {
                    SearchSQL.GetInvoiceDate5001();
                    dealWithFilterDate5001();
                }
                else if (cboInvoiceDate.SelectedItem == cboInvoiceDate.Items[2])
                {
                    SearchSQL.GetInvoiceDate5001();
                    dealWithFilterDate5001();
                }
                else if (cboInvoiceDate.SelectedItem == cboInvoiceDate.Items[3])
                {
                    SearchSQL.GetInvoiceDate5002();
                    dealWithFilterDate5002();
                }
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region Clear Button
        /// <summary>
        /// Clear the data grid and combo boxes selections
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //clear the data grid and the combo boxes go back to normal
                cboInvoiceCost.SelectedItem = "";
                updateInvoiceCost();
                fillcboInvoiceCost();
                cboInvoiceDate.SelectedItem = "";
                updateInvoiceDate();
                fillcboInvoiceDate();
                cboInvoiceNumber.SelectedItem = "";
                updateInvoiceNum();
                fillcboInvoiceNumber();
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

        #region Updates
        /// <summary>
        /// Update Invoice Number
        /// </summary>
        public void updateInvoiceNum()
        {
            try
            {
                lstInvoiceNum = SearchSQL.GetInvoiceNum();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Update Invoice Cost
        /// </summary>
        public void updateInvoiceCost()
        {
            try
            {
                lstInvoiceCost = SearchSQL.GetInvoiceCost();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Update Invoice Date
        /// </summary>
        public void updateInvoiceDate()
        {
            try
            {
                lstInvoiceDate = SearchSQL.GetInvoiceDates();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Fill
        /// <summary>
        /// Fill the Invoice Number combobox
        /// </summary>
        public void fillcboInvoiceNumber()
        {
            try
            {
                cboInvoiceNumber.ItemsSource = lstInvoiceNum;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Fill the Invoice Cost combobox
        /// </summary>
        public void fillcboInvoiceCost()
        {
            try
            {
                cboInvoiceCost.ItemsSource = lstInvoiceCost;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Fill the Invoice Date combobox
        /// </summary>
        public void fillcboInvoiceDate()
        {
            try
            {
                cboInvoiceDate.ItemsSource = lstInvoiceDate;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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
