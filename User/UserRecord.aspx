<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="UserRecord.aspx.cs" Inherits="User_UserRecord" %>

<asp:Content runat="server" ID="content" ContentPlaceHolderID="MainContent">
    <div id="control_top">
        <asp:Label runat="server" Text="查詢日期:"></asp:Label>
        <asp:TextBox runat="server" TextMode="Date" ID="StartDate"></asp:TextBox>&nbsp 至
        <asp:TextBox runat="server" TextMode="Date" ID="EndDate"></asp:TextBox>
        <asp:Button runat="server" CssClass="btn btn-primary" Text="查詢" ID="TimeSearch" OnClick="TimeSearch_Click" />
    </div>
    <div class="btn-group">
        <asp:Button runat="server" UseSubmitBehavior="false" CssClass="btn btn-primary" ID="AddIncome" Text="新增收入" OnClientClick="openInCome();return false;" data-toggle="modal" data-target="#incomedialog"/>
        <asp:Button runat="server" UseSubmitBehavior="false" ID="AddExpenditure" CssClass="btn" Text="新增支出" OnClientClick="openExpenditure();return false;" data-toggle="modal" data-target="#ExpenditureDialog" />
    </div>
    <br />

        <asp:GridView ID="Record_GridView" runat="server" OnRowDataBound="Record_GridView_RowDataBound" AutoGenerateColumns="False" SelectedRowStyle-BackColor="#666699" HeaderStyle-BackColor="#C4D9F0">
            <Columns>
                <asp:BoundField DataField="RU_UserName" HeaderText="紀錄者" SortExpression="RU_UserName"></asp:BoundField>
                <asp:BoundField DataField="RU_Class" HeaderText="類別" SortExpression="RU_Class"></asp:BoundField>
                <asp:BoundField DataField="RS_Name" HeaderText="細項類別" SortExpression="RS_Name"></asp:BoundField>
                <asp:BoundField DataField="RU_Money" HeaderText="金額" SortExpression="RU_Money"></asp:BoundField>
                <asp:BoundField DataField="RU_Type" HeaderText="收支" SortExpression="RU_Type"></asp:BoundField>
                <asp:BoundField DataField="RU_CreateDate" HeaderText="日期" SortExpression="RU_CreateDate" DataFormatString="{0:d}"></asp:BoundField>
            </Columns>
        </asp:GridView>

    <%-- 收入功能 --%>
    <div class="modal fade" id="incomedialog">
        <div class="modal-dialog modal-sm ">
            <div class="modal-content">
                <div class="modal-header">
                    新增收入
                </div>
                <div class="modal-body" id="InComeBody">
                    <div class="col p-1">
                    <asp:Label runat="server">收入類別：</asp:Label>
                        <asp:DropDownList runat="server" ID="InComeClass" Width="150px" Height="25px">
                            <asp:ListItem Text="請選擇類別" Value="0" Selected="True"></asp:ListItem>
                        </asp:DropDownList>    
                    </div>
                    <div class="col p-1">
                        <asp:Label runat="server" Text="收入細項：" ></asp:Label>                
                        <asp:DropDownList runat="server" ID="InComeClassSub" Width="150px" Height="25px" Enabled="false">
                            <asp:ListItem Text="請先選取總類別" Value="0" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col p-1">
                        <asp:Label runat="server">請輸入數字：</asp:Label>
                        <asp:TextBox runat="server" TextMode="Number" ID="InComeNumber" Width="133px" Height="25px"></asp:TextBox>
                    </div>
                    <div class="col p-1">
                        <asp:Label runat="server">附註：</asp:Label>
                        <asp:TextBox runat="server" ID="InComeDetail" TextMode="MultiLine" Width="180px" Height="50px"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" CssClass="btn btn-success" ID="InComeAdd" OnClick="AddButton_Click" OnClientClick="setRecordDataStream('InComeBody');" Text="新增" />
                    <button type="button" class="btn" onclick="closeInComeDialog();" data-dismiss="modal">取消</button>
                </div> 
            </div>
        </div>
    </div>

    <%-- 支出功能 --%>
    <div class="modal fade" id="ExpenditureDialog">
        <div class="modal-dialog modal-sm ">
            <div class="modal-content">
            
                 <div class="modal-header">
                    新增支出
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel runat="server" ID="updatepanel1" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="col p-1">
                                <asp:Label runat="server">支出類別：</asp:Label>
                                <asp:DropDownList runat="server" ID="ExpenditureClass" OnSelectedIndexChanged="ExpenditureClass_SelectedIndexChanged" Width="150px" Height="25px" AutoPostBack="True">                       
                                    <asp:ListItem Text="請選擇類別" Value="0" Selected="True"></asp:ListItem>
                                </asp:DropDownList>                   
                            </div>                   
                            <div class="col p-1">
                                <asp:Label runat="server" Text="支出細項："></asp:Label>                
                                <asp:DropDownList runat="server" ID="ExpenditureClassSub" Width="150px" Height="25px">
                                    <asp:ListItem Text="請先選取總類別" Value="0" Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="col p-1">                               
                        <asp:Label runat="server">請輸入數字：</asp:Label>
                        <asp:TextBox runat="server" TextMode="Number" ID="ExpenditureNumber" Width="100px" Height="25px"></asp:TextBox>
                    </div>
                    <div class="col p-1">       
                        <asp:Label runat="server">附註：</asp:Label>
                        <asp:TextBox runat="server" ID="ExpenditureDetail" TextMode="MultiLine" Width="150px" Height="30px"></asp:TextBox>
                    </div>        
                    <div class="modal-footer">
                        <asp:Button runat="server" CssClass="btn btn-success" ID="ExpendAdd" OnClick="AddButton_Click" OnClientClick="setRecordDataStream('ExpendBody');" Text="新增" />
                        <button type="button" class="btn" onclick="closeExpenditureDialog();" data-dismiss="modal">取消</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <%--紀錄dialog資料，使後端可以呼叫它來抓取--%>
    <asp:HiddenField runat="server" ID="RecordDateStream" Value="" />

    <script src="jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script type="text/javascript">
/*
        //宣告收入、支出dialog給變數
        var incomedialog = document.querySelector("#InComeDialog");
        var expendituredialog = document.querySelector("#ExpenditureDialog");

        if (!incomedialog.showModal)
            dialogPolyfill.registerDialog(incomedialog);
        if (!expendituredialog.showModal)
            dialogPolyfill.registerDialog(expendituredialog);


        //打開收入dialog    
        function openInCome() {
            incomedialog.showModal();
        };

        //打開支出dialog    
        function openExpenditure() {
            expendituredialog.showModal();
        };

        //關閉收入dialog
        function closeInComeDialog() {
            incomedialog2.close();
        }
        //關閉支出dialog
        function closeExpenditureDialog() {
            expendituredialog.close();
        }
*/
        function setRecordDataStream(bodyname) {
            var dataString = "";
            var type = "";
            var Class;
            var ClassSub;
            var Money;
            var Detail;
            var getDialog = document.getElementById(bodyname);
            
            if (bodyname == "InComeBody")
            {
                Class = document.getElementById('<%= InComeClass.ClientID %>').value;          
                ClassSub = document.getElementById('<%= InComeClassSub.ClientID%>').value;
                Money = document.getElementById('<%= InComeNumber.ClientID%>').value;
                Detail = document.getElementById('<%= InComeDetail.ClientID%>').value;
                type = "收入";
            }
            else {
                Class = document.getElementById('<%= ExpenditureClass.ClientID %>').value;
                ClassSub = document.getElementById('<%= ExpenditureClassSub.ClientID%>').value;
                Money = document.getElementById('<%= ExpenditureNumber.ClientID%>').value;
                Detail = document.getElementById('<%= ExpenditureDetail.ClientID%>').value;
                type = "支出";
            }
            dataString = Class+","+ClassSub+","+Money+","+Detail+","+type;
            document.getElementById('<%= RecordDateStream.ClientID%>').value = dataString;
        }

    </script>
     
</asp:Content>

