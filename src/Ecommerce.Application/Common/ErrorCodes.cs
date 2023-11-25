using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Common
{
    public enum ErrorCodes
    {
        Success=0,
        Cannot_Get_Cart_From_DataStore=-1001,
        Cannot_Get_Product_From_ItemCataloge = -1002,
        Product_Balance_Is_Less_Than_The_Required_Qty = -1003,
        Cannot_Store_Data_To_DataStore = -1004,
        Cannot_Confirm_Order_With_Not_Existing_Cart= -1005,
        Cannot_Confirm_Order  = -1006,
        Invalid_Order_Details = -1007,
        Invalid_Payment_Details = -1008,
        Invalid_Shipping_Details = -1009,

    }
}
