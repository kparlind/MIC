'(20 Des 2012) Added some variable.
'(25 Des 2012) Added some variable.
'(29 Des 2012) Added some variable.

Public Class GlobalVar
    'Public ConnString As String
    Public Structure DataType
        Private varEnum As String

        Const TypeString As String = "System.String"
        Const TypeInt16 As String = "System.Int16"
        Const TypeInt32 As String = "System.Int32"
        Const TypeBoolean As String = "System.Boolean"
        Const TypeDateTime As String = "System.DateTime"
        Const TypeDecimal As String = "System.Decimal"
        Const TypeDouble As String = "System.Double"
    End Structure

    'Public Const ConnString As String = "Password=;Persist Security Info=True;User ID=sa;Initial Catalog=MIC"
    'Public Const ConnString As String = "Password=admin123;Persist Security Info=True;User ID=sa;Initial Catalog=MIC;Data Source=ADSDB"
    'Public Const ConnString As String = "Password=admin123;Persist Security Info=True;User ID=sa;Initial Catalog=MIC;Data Source=XPWINDOWS7"
    Public Const ExitMenu As String = "OG999"

    '==================== Added per 11 Okt 2012
    Public Const FrmSurvey_Name As String = "frmSurvey"
    Public Const ServiceOngkos As String = "JS006"
    Public Const WarehouseReject As String = "WH003"

    Public Structure Fields
        Private varEnum As String

        Const Supp_ID As String = "Supp_ID"
        Const Supp_Name As String = "Nama"
        Const Supp_Address As String = "Alamat"
        Const Supp_Telp As String = "Telp"
        Const Supp_Fax As String = "Fax"

        Const Cust_ID As String = "Cust_ID"
        'Const Cust_Name As String = "Name"
        'Const Cust_Address As String = "Address"
        Const Cust_Name As String = "Nama" 'change lia
        Const Cust_Address As String = "Alamat" 'change lia
        Const Cust_PhoneNo As String = "Telp" 'add lia

        Const Curr_ID As String = "Currency_ID"
        Const Curr_Name As String = "Currency_Name"
        Const Curr_Prefix As String = "Curr_Prefix"
        Const Item_ID As String = "Item_ID"
        Const Item_Name As String = "Item_Name"
        Const Item_Desc As String = "Item_Desc"
        Const Item_UOM As String = "UOM"
        Const Item_Size As String = "Size"
        Const Item_Diskon As String = "Diskon"
        Const Item_Price As String = "Price"
        Const Item_Remarks As String = "Remarks"
        Const Enum_Value As String = "Enum_Value"
        Const Value_Desc As String = "Value_Desc"
        Const Bank_ID As String = "Bank_ID"
        Const Bank_Name As String = "Bank_Name"
        Const Item_harga As String = "Harga"
        Const Sales_Price As String = "Sales_Price"
        Const SubTotal As String = "SubTotal"
        Const Bank_TransferAcct As String = "Bank_TransferAcct"

        Const Rate As String = "Rate"
        Const Qty As String = "qty"
        Const QtyRec As String = "qty_Rec"
        Const diskon As String = "diskon"

        Const ActiveFlag As String = "Active_Flag"
        Const ID_Created As String = "id_created"
        Const DT_Created As String = "dt_created"
        Const ID_LastUpdated As String = "id_lastupdated"
        Const DT_LastUpdated As String = "dt_lastupdated"

        Const PO_No As String = "PO_No"
        Const PO_Date As String = "PO_Date"
        Const PO_Remark As String = "Remark"
        Const PO_SeqNum As String = "SeqNum"
        Const PO_Curr As String = "Curr_ID"
        Const PO_CurrName As String = "Curr_Name"
        Const PO_RecGoodDt As String = "RecGood_Date"
        Const PO_PRNo As String = "PR_No"
        Const PO_SuppID As String = "Supplier_ID"

        Const Warehouse_ID As String = "Warehouse_ID"
        Const Warehouse_Name As String = "Warehouse_Name"

        Const Status_ID As String = "Status_ID"
        Const Status_Name As String = "Status_Name"

        Const DPS_No As String = "DP_No"
        Const DPS_Date As String = "DP_Date"
        Const DPS_Contract As String = "Contract_No"
        Const DPS_PaymentCategory As String = "Payment_Method"
        Const DPS_Bank As String = "Bank_ID"
        Const DPS_Curr As String = "DP_Curr"
        Const DPS_Amt As String = "DP_Amt"
        Const DPS_Rate As String = "DP_Rate"
        Const DPS_Remark As String = "Remark"
        Const DPS_PaidBy As String = "Paid_By"

        Const TB_No As String = "TB_No"
        Const TB_Date As String = "TB_Date"
        Const TB_Remark As String = "Remark"
        Const TB_SeqNum As String = "SeqNum"
        Const TB_Curr As String = "Currency_ID"
        Const TB_CurrName As String = "Currency_Name"
        Const TB_RecGoodDt As String = "RecGood_Date"
        Const TB_PRNo As String = "PR_No"
        Const Account_Name = "Account_Name"
        Const Item_ID_Dtl = "Item_ID_Dtl"
        Const Item_Remark = "Item_Remark"
        '====================Ditambah oleh Indah
        Const CSH_ContractNo As String = "Contract_No"
        Const CSH_ContractDate As String = "Contract_Date"
        Const CSH_SurveyNo As String = "Survey_No"
        Const CSH_SurveyAmd As String = "Survey_Amd"
        Const CSH_QuotationNo As String = "Quotation_No"
        Const CSH_QuotationAmd As String = "Quotation_Amd"
        Const CSH_CustID As String = "Cust_ID"
        Const CSH_Location As String = "Location"
        Const CSH_PaymentCategory As String = "Payment_Category"
        Const CSH_BankID As String = "Bank_ID"
        Const CSH_CurrID As String = "Curr_ID"
        Const CSH_CurrRate As String = "Curr_Rate"
        Const CSH_TotalDetail As String = "Total_Detail"
        Const CSH_Remark As String = "Remark"

        Const CSD_ContractNo As String = "Contract_No"
        Const CSD_SeqNum As String = "Seq_Num"
        Const CSD_ItemID As String = "Item_ID"
        Const CSD_Qty As String = "Qty"
        Const CSD_SalesPrice As String = "Sales_Price"
        Const CSD_Discount As String = "Disc"
        Const CSD_TotalPrice As String = "Total_Price"

        '====================Survey Table by Indah
        Const SURH_SurveyNo As String = "Survey_No"
        Const SURH_SurveyDate As String = "Survey_Date"
        Const SURH_LoM As String = "LoM_No"
        Const SURH_CustID As String = "Cust_ID"
        Const SURH_Remark As String = "Survey_Remark"
        Const SURH_Status As String = "Status_ID"
        Const SURH_MarketingID As String = "Marketing_ID"

        Const SURD_SeqNum As String = "Seq_Num"
        Const SURD_ItemID As String = "Item_ID"
        Const SURD_ItemUOM As String = "Item_UOM"
        Const SURD_ItemQty As String = "Item_Qty"
        Const SURD_ItemRemark As String = "Item_Remark"
        Const SURD_ItemComponent As String = "Item_Component"
        '=====================MDI Access by Indah

        Const GroupObject As String = "ObjGrp_ID"
        Const ObjectID As String = "Object_ID"
        Const ObjectDesc As String = "Object_Desc"
        Const GroupObjectName As String = "ObjGrp_Desc"

        '====================AR Table By Liana
        Const AR_PaymentNo As String = "Payment_No"
        Const AR_PaymentDate As String = "Payment_Date"
        Const AR_PaymentAmt As String = "Payment_Amt"
        Const AR_PaymentMethod As String = "Payment_Method"
        Const AR_PaymentRate As String = "Payment_Rate"
        Const AR_PaymentCurr As String = "Payment_Curr"
        Const AR_BankID As String = "Bank_ID"
        Const AR_Remark As String = "Remark"
        Const AR_TransType As String = "Trans_Type"
        Const AR_Trans_No As String = "Trans_No"
        Const AR_ActiveFlag As String = "Active_Flag"
        Const AR_IDCreated As String = "id_created"
        Const AR_DtCreated As String = "dt_created"
        Const AR_IDLastUpdated As String = "id_lastupdated"
        Const AR_DtLastUpdated As String = "dt_lastupdated"
        Const AR_Paid_Amt As String = "Paid_Amt"
        '====================Bagian Pabrikasi
        Const OP_No As String = "OP_No"
        Const OP_Dt As String = "OP_Date"
        Const Qty_Order As String = "Qty_Order"
        Const Qty_Jadi As String = "Qty_Jadi"
        '====================Trans Sales
        Const TS_InvoiceNo As String = "Invoice_No"
        '=========Jasa
        Const Jasa_ID As String = "Jasa_ID"
        Const Jasa_Name As String = "Jasa_Name"
        Const Jlh_Hari As String = "Jlh_Hari"
        Const JasaOngkos As String = "Ongkos"
        Const JasaSubTotal As String = "SubTotal"
        Const JasaRemarks As String = "Remarks"

        Const Item_Category As String = "Item_Category"
        Const Item_Type As String = "Item_Type"
        Const EmployeeID As String = "Employee_ID"
        Const EmployeeName As String = "Name"

        Const SURH_SurveySiteDate As String = "Survey_Site_Date"
        Const SURH_SPKNo As String = "SPK_No"
        Const SURH_SurveyorID As String = "Surveyor_ID"
        Const SURH_MeetWith As String = "Meet_With"
        Const SURH_PenanggungProject As String = "Penanggung_Project"
        Const SURH_PenanggungProjectHP As String = "Penanggung_Project_HP"
        Const SURH_CustHP As String = "Cust_HP"
        Const SURH_Manifold As String = "Manifold"
        Const SURH_Pipe As String = "PipeToKitchen"
        Const SURH_TitikApi As String = "TitikApi"
        Const SURH_Supporting As String = "SupportingMaterial"

        Const PHPro_SalesPrice As String = "Sales_Price"

        Const KBH_TransNo As String = "KB_No"
        Const KBH_TransDate As String = "KB_Date"
        Const KBH_TransType As String = "KB_Type"
        Const KBH_ReferNo As String = "Refer_No"
        Const KBH_Remarks As String = "Remarks"
        Const KBH_Status As String = "Status_ID"

        Const KBD_ItemID As String = "Item_ID"
        Const KBD_ItemQty As String = "Qty"
        Const KBD_Good As String = "isGood"
        Const KBD_RSupplier As String = "isRejectSupplier"
        Const KBD_RPakai As String = "isRejectPakai"
        Const KBD_Remarks As String = "Remarks"

        Const PB_TransNo As String = "PB_No"
        Const PB_TransDate As String = "PB_Date"
        Const PB_SPK As String = "SPK_No"
        Const PB_Remarks As String = "Remarks"
        Const PB_Status As String = "Status_ID"

        Const Item_Warehouse As String = "Warehouse_ID"

        Const PB_PHM As String = "PHM_No"
        Const PBD_ItemDate As String = "Date_Pakai"
        Const PBD_ItemQtyPakai As String = "Qty_Pakai"
        Const PBD_isPHM As String = "isPHM"         'ifebrian
        Const PBD_ItemPrice As String = "Item_Price"    'ifebrian
    End Structure

    Public Structure AccGL
        Private varEnum As String

        Const Acc_PersediaanSparepart As String = "161"
        Const Acc_WIPProject As String = "162"
        Const Acc_WIPPabrikasi As String = "163"
        Const Acc_WIPLabour As String = "164"
        Const Acc_WIPOverhead As String = "166"
        Const Acc_HargaPokokPenjualan As String = "531"
    End Structure

    Public Structure TransStatus
        Private varEnum As String
        Const NoStatus As String = ""
        Const NewStatus As String = "NEW"
        Const EditStatus As String = "EDIT"
        Const FindStatus As String = "FIND"
        Const DeleteStatus As String = "DELETE"
        Const RevisionStatus As String = "REVISION"
    End Structure

    Public Structure DefaultValue
        Private varEnum As String

        Const Currency As String = "IDR"
        Const PaymentCategory As String = "CASH"
        Const NonBankPayment As String = "CASH"
    End Structure

    Public Structure Status
        Private varEnum As String

        Const Draft As String = "DRAFT"
        Const SURVEY_Saved As String = "WAMH"
        Const SURVEY_Approved As String = "PPA"
        Const SURVEY_Rejected As String = "RBS"
        Const HISTORY_Insert As String = "INSERT"
        Const HISTORY_Update As String = "UPDATE"

        Const HISTORY_Delete As String = "DELETE"
        Const PHProject_Saved As String = "WATH"
        Const PHProject_Completed As String = "CMP"
        Const PHProject_Cancelled As String = "CAP"
        Const PHMarketing_Saved As String = "WAMH"
        Const PHMarketing_Completed As String = "CMP"
        Const PHMarketing_Cancelled As String = "CAP"

        Const BK_Saved As String = "WAWA"
        Const BK_Rejected As String = "RBWA"
        Const BK_Approved As String = "CMP"

        Const PB_Saved As String = "WATH"
        Const PB_Rejected As String = "RBTH"
        Const PB_Approved As String = "PMH"        
        Const PB_Confirmed As String = "CMP"

        Const HISTORY_Approved As String = "APPROVE"
        Const HISTORY_Rejected As String = "REJECT"
        Const HISTORY_Confirmed As String = "CONFIRMED"

        Const SPK_Saved As String = "WAFS"              'added ifebrian
        Const SPK_Completed As String = "CMP"           'added ifebrian
        Const PHProject_ReadyToProcessed As String = "WAMA"   'added ifebrian
        Const PHProject_Rejected As String = "RBMA"         'added ifebrian
    End Structure

    Public Structure Hirarki
        Private varEnum As String

        Const SURVEY_Saved As String = "Marketing Head"
        Const SURVEY_Approved As String = "Project Admin"
        Const SURVEY_Rejected As String = "Marketing Admin"
        Const BK_Saved As String = "Warehouse Admin"
        Const BK_Rejected As String = "Project Admin"
        Const PB_Saved As String = "Project Head"
        Const PB_Rejected As String = "Project Admin"
        Const PB_Approved As String = "Marketing Head"
        Const PHM_Saved As String = "Marketing_Head"
        Const SPK_Saved As String = "Project Head"          'ifebrian
        Const PHProject_Saved As String = "Project Head"    'ifebrian
        Const PHProject_ReadyToProcessed As String = "Marketing Admin"      'ifebrian
        Const PHProject_Rejected As String = "Project Admin"    'ifebrian
    End Structure

    Public Structure Role
        Private varEnum As String

        Const MarketingAdmin As String = "AC011"
        Const MarketingHead As String = "AC004"
        Const ProjectAdmin As String = "AC010"
        Const ProjectHead As String = "AC003"
        Const GudangAdmin As String = "AC012"
        Const GudangHead As String = "AC006"
        Const SuperAdmin As String = "AC999"
        Const AdminToko As String = "AC016"         'ifebrian
    End Structure

    Public Structure FF     'Function Form
        Private varEnum As String

        Const NewFunction As String = "FN001"
        Const EditFunction As String = "FN002"
        Const DeleteFunction As String = "FN003"
        Const PrintFunction As String = "FN005"
        Const ExportFunction As String = "FN006"
        Const SaveOrCancelFunction As String = "FN004"
        Const ApproveOrRejectFunction As String = "FN007"
        Const ConfirmFunction As String = "FN008"
        Const GenerateMOUFunction As String = "FN009"
        Const GenerateProjectFunction As String = "FN010"
    End Structure

    Public Structure ITEM_TYPE
        Private varEnum As String

        Const UTAMA As String = "Utama"
        Const SUPPORT As String = "Pendukung"
    End Structure

    Public Structure MappingName        'added by ifebrian
        Private varEnum As String

        Const PB_WIP As String = "WIP Journal"
        Const PB_DP As String = "DP Pengakuan"
    End Structure
End Class

Public Class UserLogin
    Public UserName As String
    Public EmployeeID As String
    Public EmployeeName As String
    Public AccessID As String
    Public IsUser As String
    Public Address1 As String
    Public Address2 As String
    Public Phone1 As String
    Public Phone2 As String
    Public Mobile As String
    Public Email As Boolean
    Public Active_Flag As String
    Public HireDate As Date
    Public Sex As String
    Public Show_Supplier As String
    Public Insert_Price As String
    Public Access_Desc As String
    Public Department_ID As String
End Class


