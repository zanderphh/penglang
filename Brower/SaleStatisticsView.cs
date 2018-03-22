﻿using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using Sau.Util;

namespace PengLang 
{
	public class SaleStatisticsView : BaseBandView
	{
        public string ArtNo = string.Empty;
        public string BeginDate = string.Empty;
        public string EndDate = string.Empty;

        protected  int BeginSizeNoIndex = 2;
        protected int EndSizeNoIndex = 35; 

        #region 构造函数

        public SaleStatisticsView()
        {
            listClothes = MemoryTable.Instance.ListClothes;
        }

        public SaleStatisticsView(BandedGridView view)
        {
            base.SetGridView(view);
            listClothes = MemoryTable.Instance.ListClothes;
        }
        
        #endregion

        #region 类成员
        
        protected List<Clothes> listClothes;

        InventoryItem invtItem;
        InventoryItem inbondItem;
        InventoryItem outboundItem;

        #endregion
        
        #region GridBand

        protected GridBand bandRowKind;    
        protected GridBand bandLotNo;     //Art#

        protected GridBand bandRegular;   //Regular
        protected GridBand bandLong;      //Long
        protected GridBand bandShort;     //Short	

        protected GridBand bandRegular36; //36 
        protected GridBand bandRegular38; //38 
        protected GridBand bandRegular40; //40 
        protected GridBand bandRegular42; //42 
        protected GridBand bandRegular44; //44 
        protected GridBand bandRegular46; //46 
        protected GridBand bandRegular48; //48 
        protected GridBand bandRegular50; //50 
        protected GridBand bandRegular52; //52 
        protected GridBand bandRegular54; //54 
        protected GridBand bandRegular56; //56 
        protected GridBand bandRegular58; //58 
        protected GridBand bandRegular60; //60 
        protected GridBand bandRegular62; //62 

        protected GridBand bandLong38; //38 
        protected GridBand bandLong40; //40 
        protected GridBand bandLong42; //42 
        protected GridBand bandLong44; //44 
        protected GridBand bandLong46; //46 
        protected GridBand bandLong48; //48 
        protected GridBand bandLong50; //50 
        protected GridBand bandLong52; //52 
        protected GridBand bandLong54; //54 
        protected GridBand bandLong56; //56 
        protected GridBand bandLong58; //58 
        protected GridBand bandLong60; //60 
        protected GridBand bandLong62; //62 

        protected GridBand bandShort34; //36
        protected GridBand bandShort36; //36 
        protected GridBand bandShort38; //38 
        protected GridBand bandShort40; //40 
        protected GridBand bandShort42; //42 
        protected GridBand bandShort44; //44 
        protected GridBand bandShort46; //46 	

        protected GridBand bandSubTotal; 

        #endregion

        #region  GridColumn

        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colRowKind; 
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLotNo;

        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR36;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR38;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR40;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR42;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR44;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR46;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR48;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR50;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR52;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR54;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR56;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR58;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR60;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR62;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL38;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL40;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL42;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL44;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL46;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL48;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL50;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL52;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL54;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL56;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL58;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL60;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL62;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colS34;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colS36;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colS38;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colS40;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colS42;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colS44;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colS46;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSubTotal; 

        #endregion

        #region 初始化

        //初始化视图
        protected override void InitGridView()
        {
            BandedGridView view = gridView;
            if (view == null)
                return;
            //修改附加选项
            view.OptionsView.ShowColumnHeaders = false;                         //因为有Band列了，所以把ColumnHeader隐藏
            view.OptionsView.ShowGroupPanel = false;                            //如果没必要分组，就把它去掉
            view.OptionsView.EnableAppearanceEvenRow = true;
            view.OptionsView.EnableAppearanceOddRow = true;
            view.OptionsView.ColumnAutoWidth = false;

            view.Appearance.OddRow.BackColor = Color.White;
            view.Appearance.EvenRow.BackColor = Color.LightCyan;

            view.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;   //是否显示过滤面板
            view.OptionsCustomization.AllowColumnMoving = false;                //是否允许移动列
            view.OptionsCustomization.AllowColumnResizing = true;              //是否允许调整列宽
            view.OptionsCustomization.AllowGroup = false;                       //是否允许分组
            view.OptionsCustomization.AllowFilter = false;                      //是否允许过滤
            view.OptionsCustomization.AllowSort = true;                         //是否允许排序
            view.OptionsCustomization.AllowBandMoving = false;


            view.OptionsSelection.EnableAppearanceFocusedCell = true;           //
            view.OptionsBehavior.Editable = false;                               //是否允许用户编辑单元格  
            view.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            view.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            view.OptionsBehavior.ReadOnly = true;

            view.OptionsHint.ShowBandHeaderHints = false;
            view.OptionsHint.ShowCellHints = false;
            view.OptionsHint.ShowColumnHeaderHints = false;
            view.OptionsHint.ShowFooterHints = false;
            view.OptionsMenu.EnableColumnMenu = false;
            view.OptionsMenu.EnableFooterMenu = false;

            view.OptionsSelection.MultiSelect = true;
            view.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
           
            view.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(this.OnCustomDrawRowIndicator); 
        }

        //初始化列表
        protected override void CreateGridBand()
        {
            if (gridView == null)
                return;

            BandedGridView view = gridView;
            view.Bands.Clear();
        
            bandLotNo = view.Bands.AddBand("Art#");
            bandLotNo.Width = 0;
            bandLotNo.Visible = false;
             

            bandRowKind = view.Bands.AddBand("Category");
            bandRowKind.Width = 100;
            bandRowKind.Visible = true;

    
            bandRegular = view.Bands.AddBand("Regular");
            bandLong = view.Bands.AddBand("Long");
            bandShort = view.Bands.AddBand("Short");

            //列标题对齐方式 
            bandRowKind.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center; 
            bandLotNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bandRegular.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bandLong.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bandShort.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            bandRegular36 = bandRegular.Children.AddBand("36");
            bandRegular38 = bandRegular.Children.AddBand("38");
            bandRegular40 = bandRegular.Children.AddBand("40");
            bandRegular42 = bandRegular.Children.AddBand("42");
            bandRegular44 = bandRegular.Children.AddBand("44");
            bandRegular46 = bandRegular.Children.AddBand("46");
            bandRegular48 = bandRegular.Children.AddBand("48");
            bandRegular50 = bandRegular.Children.AddBand("50");
            bandRegular52 = bandRegular.Children.AddBand("52");
            bandRegular54 = bandRegular.Children.AddBand("54");
            bandRegular56 = bandRegular.Children.AddBand("56");
            bandRegular58 = bandRegular.Children.AddBand("58");
            bandRegular60 = bandRegular.Children.AddBand("60");
            bandRegular62 = bandRegular.Children.AddBand("62");

            bandLong38 = bandLong.Children.AddBand("38");
            bandLong40 = bandLong.Children.AddBand("40");
            bandLong42 = bandLong.Children.AddBand("42");
            bandLong44 = bandLong.Children.AddBand("44");
            bandLong46 = bandLong.Children.AddBand("46");
            bandLong48 = bandLong.Children.AddBand("48");
            bandLong50 = bandLong.Children.AddBand("50");
            bandLong52 = bandLong.Children.AddBand("52");
            bandLong54 = bandLong.Children.AddBand("54");
            bandLong56 = bandLong.Children.AddBand("56");
            bandLong58 = bandLong.Children.AddBand("58");
            bandLong60 = bandLong.Children.AddBand("60");
            bandLong62 = bandLong.Children.AddBand("62");

            bandShort34 = bandShort.Children.AddBand("34");
            bandShort36 = bandShort.Children.AddBand("36");
            bandShort38 = bandShort.Children.AddBand("38");
            bandShort40 = bandShort.Children.AddBand("40");
            bandShort42 = bandShort.Children.AddBand("42");
            bandShort44 = bandShort.Children.AddBand("44");
            bandShort46 = bandShort.Children.AddBand("46");

            bandSubTotal = view.Bands.AddBand("Sub Total");
            bandSubTotal.Width = 60;
            bandSubTotal.MinWidth = 40;
            bandSubTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;



            GridBand bandSize = bandRegular;
            int cnt = bandSize.Children.Count;
            for (int i = 0; i < cnt; i++)
            {
                bandSize.Children[i].MinWidth = 30;
                bandSize.Children[i].Width = 35;
                bandSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }

            bandSize = bandLong;
            cnt = bandSize.Children.Count;
            for (int i = 0; i < cnt; i++)
            {
                bandSize.Children[i].MinWidth = 30;
                bandSize.Children[i].Width = 35;
                bandSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }

            bandSize = bandShort;
            cnt = bandSize.Children.Count;
            for (int i = 0; i < cnt; i++)
            {
                bandSize.Children[i].MinWidth = 30;
                bandSize.Children[i].Width = 35;
                bandSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }

        protected override void CreateGridColumns()
        {
            this.colRowKind = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();  
            this.colLotNo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
         
            this.colR36 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR38 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR40 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR42 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR44 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR46 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR48 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR50 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR52 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR54 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR56 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR58 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR60 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR62 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL38 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL40 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL42 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL44 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL46 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL48 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL50 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL52 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL54 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL56 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL58 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL60 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL62 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colS34 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colS36 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colS38 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colS40 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colS42 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colS44 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colS46 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSubTotal = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
           
            Columns = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {  
            this.colLotNo,
            this.colRowKind, 
            this.colR36,
            this.colR38,
            this.colR40,
            this.colR42,
            this.colR44,
            this.colR46,
            this.colR48,
            this.colR50,
            this.colR52,
            this.colR54,
            this.colR56,
            this.colR58,
            this.colR60,
            this.colR62,
            this.colL38,
            this.colL40,
            this.colL42,
            this.colL44,
            this.colL46,
            this.colL48,
            this.colL50,
            this.colL52,
            this.colL54,
            this.colL56,
            this.colL58,
            this.colL60,
            this.colL62,
            this.colS34,
            this.colS36,
            this.colS38,
            this.colS40,
            this.colS42,
            this.colS44,
            this.colS46,
            this.colSubTotal  };
            // 
            // colRowKind
            // 
            this.colRowKind.Caption = "Category";
            this.colRowKind.FieldName = "RowKind";
            this.colRowKind.Name = "colRowKind";
            this.colRowKind.Visible = true;
            this.colRowKind.Width = 100;
            this.colRowKind.UnboundType = DevExpress.Data.UnboundColumnType.String;
                       
            // 
            // colLotNo
            // 
            this.colLotNo.Caption = "Art#";
            this.colLotNo.FieldName = "LotNo";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colLotNo.Visible = true;
            //this.colLotNo.MinWidth = 80;
            this.colLotNo.Width = 100;
            
            // 
            // colR36
            // 
            this.colR36.Caption = "36";
            this.colR36.FieldName = "R36";
            this.colR36.MinWidth = 15;
            this.colR36.Name = "colR36";
            this.colR36.Visible = true;
            this.colR36.Width = 35;
            // 
            // colR38
            // 
            this.colR38.Caption = "38";
            this.colR38.FieldName = "R38";
            this.colR38.MinWidth = 15;
            this.colR38.Name = "colR38";
            this.colR38.Visible = true;
            this.colR38.Width = 35;
            // 
            // colR40
            // 
            this.colR40.Caption = "40";
            this.colR40.FieldName = "R40";
            this.colR40.MinWidth = 15;
            this.colR40.Name = "colR40";
            this.colR40.Visible = true;
            this.colR40.Width = 35;
            // 
            // colR42
            // 
            this.colR42.Caption = "42";
            this.colR42.FieldName = "R42";
            this.colR42.MinWidth = 15;
            this.colR42.Name = "colR42";
            this.colR42.Visible = true;
            this.colR42.Width = 35;
            // 
            // colR44
            // 
            this.colR44.Caption = "44";
            this.colR44.FieldName = "R44";
            this.colR44.MinWidth = 15;
            this.colR44.Name = "colR44";
            this.colR44.Visible = true;
            this.colR44.Width = 35;
            // 
            // colR46
            // 
            this.colR46.Caption = "46";
            this.colR46.FieldName = "R46";
            this.colR46.MinWidth = 15;
            this.colR46.Name = "colR46";
            this.colR46.Visible = true;
            this.colR46.Width = 35;
            // 
            // colR48
            // 
            this.colR48.Caption = "48";
            this.colR48.FieldName = "R48";
            this.colR48.MinWidth = 15;
            this.colR48.Name = "colR48";
            this.colR48.Visible = true;
            this.colR48.Width = 35;
            // 
            // colR50
            // 
            this.colR50.Caption = "50";
            this.colR50.FieldName = "R50";
            this.colR50.MinWidth = 15;
            this.colR50.Name = "colR50";
            this.colR50.Visible = true;
            this.colR50.Width = 35;
            // 
            // colR52
            // 
            this.colR52.Caption = "52";
            this.colR52.FieldName = "R52";
            this.colR52.MinWidth = 15;
            this.colR52.Name = "colR52";
            this.colR52.Visible = true;
            this.colR52.Width = 35;
            // 
            // colR54
            // 
            this.colR54.Caption = "54";
            this.colR54.FieldName = "R54";
            this.colR54.MinWidth = 15;
            this.colR54.Name = "colR54";
            this.colR54.Visible = true;
            this.colR54.Width = 35;
            // 
            // colR56
            // 
            this.colR56.Caption = "56";
            this.colR56.FieldName = "R56";
            this.colR56.MinWidth = 15;
            this.colR56.Name = "colR56";
            this.colR56.Visible = true;
            this.colR56.Width = 35;
            // 
            // colR58
            // 
            this.colR58.Caption = "58";
            this.colR58.FieldName = "R58";
            this.colR58.MinWidth = 15;
            this.colR58.Name = "colR58";
            this.colR58.Visible = true;
            this.colR58.Width = 35;
            // 
            // colR60
            // 
            this.colR60.Caption = "60";
            this.colR60.FieldName = "R60";
            this.colR60.MinWidth = 15;
            this.colR60.Name = "colR60";
            this.colR60.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colR60.Visible = true;
            this.colR60.Width = 35;
            // 
            // colR62
            // 
            this.colR62.Caption = "62";
            this.colR62.FieldName = "R62";
            this.colR62.MinWidth = 15;
            this.colR62.Name = "colR62"; 
            this.colR62.Visible = true;
            this.colR62.Width = 35;
            // 
            // colL38
            // 
            this.colL38.Caption = "38";
            this.colL38.FieldName = "L38";
            this.colL38.MinWidth = 15;
            this.colL38.Name = "colL38"; 
            this.colL38.Visible = true;
            this.colL38.Width = 35;
            // 
            // colL40
            // 
            this.colL40.Caption = "40";
            this.colL40.FieldName = "L40";
            this.colL40.MinWidth = 15;
            this.colL40.Name = "colL40";
            this.colL40.Visible = true;
            this.colL40.Width = 35;
            // 
            // colL42
            // 
            this.colL42.Caption = "42";
            this.colL42.FieldName = "L42";
            this.colL42.MinWidth = 15;
            this.colL42.Name = "colL42"; 
            this.colL42.Visible = true;
            this.colL42.Width = 35;
            // 
            // colL44
            // 
            this.colL44.Caption = "44";
            this.colL44.FieldName = "L44";
            this.colL44.MinWidth = 15;
            this.colL44.Name = "colL44"; 
            this.colL44.Visible = true;
            this.colL44.Width = 35;
            // 
            // colL46
            // 
            this.colL46.Caption = "46";
            this.colL46.FieldName = "L46";
            this.colL46.MinWidth = 15;
            this.colL46.Name = "colL46"; 
            this.colL46.Visible = true;
            this.colL46.Width = 35;
            // 
            // colL48
            // 
            this.colL48.Caption = "48";
            this.colL48.FieldName = "L48";
            this.colL48.MinWidth = 15;
            this.colL48.Name = "colL48"; 
            this.colL48.Visible = true;
            this.colL48.Width = 35;
            // 
            // colL50
            // 
            this.colL50.Caption = "50";
            this.colL50.FieldName = "L50";
            this.colL50.MinWidth = 15;
            this.colL50.Name = "colL50"; 
            this.colL50.Visible = true;
            this.colL50.Width = 35;
            // 
            // colL52
            // 
            this.colL52.Caption = "52";
            this.colL52.FieldName = "L52";
            this.colL52.MinWidth = 15;
            this.colL52.Name = "colL52"; 
            this.colL52.Visible = true;
            this.colL52.Width = 35;
            // 
            // colL54
            // 
            this.colL54.Caption = "54";
            this.colL54.FieldName = "L54";
            this.colL54.MinWidth = 15;
            this.colL54.Name = "colL54"; 
            this.colL54.Visible = true;
            this.colL54.Width = 35;
            // 
            // colL56
            // 
            this.colL56.Caption = "56";
            this.colL56.FieldName = "L56";
            this.colL56.MinWidth = 15;
            this.colL56.Name = "colL56"; 
            this.colL56.Visible = true;
            this.colL56.Width = 35;
            // 
            // colL58
            // 
            this.colL58.Caption = "58";
            this.colL58.FieldName = "L58";
            this.colL58.MinWidth = 15;
            this.colL58.Name = "colL58"; 
            this.colL58.Visible = true;
            this.colL58.Width = 35;
            // 
            // colL60
            // 
            this.colL60.Caption = "60";
            this.colL60.FieldName = "L60";
            this.colL60.MinWidth = 15;
            this.colL60.Name = "colL60"; 
            this.colL60.Visible = true;
            this.colL60.Width = 35;
            // 
            // colL62
            // 
            this.colL62.Caption = "62";
            this.colL62.FieldName = "L62";
            this.colL62.MinWidth = 15;
            this.colL62.Name = "colL62"; 
            this.colL62.Visible = true;
            this.colL62.Width = 35;
            // 
            // colS34
            // 
            this.colS34.Caption = "34";
            this.colS34.FieldName = "S34";
            this.colS34.MinWidth = 15;
            this.colS34.Name = "colS34"; 
            this.colS34.Visible = true;
            this.colS34.Width = 35;
            // 
            // colS36
            // 
            this.colS36.Caption = "36";
            this.colS36.FieldName = "S36";
            this.colS36.MinWidth = 15;
            this.colS36.Name = "colS36"; 
            this.colS36.Visible = true;
            this.colS36.Width = 35;
            // 
            // colS38
            // 
            this.colS38.Caption = "38";
            this.colS38.FieldName = "S38";
            this.colS38.MinWidth = 15;
            this.colS38.Name = "colS38"; 
            this.colS38.Visible = true;
            this.colS38.Width = 35;
            // 
            // colS40
            // 
            this.colS40.Caption = "40";
            this.colS40.FieldName = "S40";
            this.colS40.MinWidth = 15;
            this.colS40.Name = "colS40"; 
            this.colS40.Visible = true;
            this.colS40.Width = 35;
            // 
            // colS42
            // 
            this.colS42.Caption = "42";
            this.colS42.FieldName = "S42";
            this.colS42.MinWidth = 15;
            this.colS42.Name = "colS42"; 
            this.colS42.Visible = true;
            this.colS42.Width =35;
            // 
            // colS44
            // 
            this.colS44.Caption = "44";
            this.colS44.FieldName = "S44";
            this.colS44.MinWidth = 15;
            this.colS44.Name = "colS44"; 
            this.colS44.Visible = true;
            this.colS44.Width = 35;
            // 
            // colS46
            // 
            this.colS46.Caption = "46";
            this.colS46.FieldName = "S46";
            this.colS46.MinWidth = 15;
            this.colS46.Name = "colS46"; 
            this.colS46.Visible = true;
            this.colS46.Width = 35;
            // 
            // colSubTotal
            // 
            this.colSubTotal.Caption = "Total";
            this.colSubTotal.FieldName = "SubTotal";
            this.colSubTotal.MinWidth = 30;
            this.colSubTotal.Name = "colSubTotal"; 
            this.colSubTotal.Visible = true;
            this.colSubTotal.Width = 60;
            this.colSubTotal.OptionsColumn.AllowEdit = false;
             

        }

        protected override void BindingBandColumn()
        {
            if (gridView == null)
                return;
            BandedGridView view = gridView;

            view.Columns["RowKind"].OwnerBand = bandRowKind;  
            view.Columns["LotNo"].OwnerBand = bandLotNo; 
            view.Columns["SubTotal"].OwnerBand = bandSubTotal; 

            view.Columns["R36"].OwnerBand = bandRegular36;
            view.Columns["R38"].OwnerBand = bandRegular38;
            view.Columns["R40"].OwnerBand = bandRegular40;
            view.Columns["R42"].OwnerBand = bandRegular42;
            view.Columns["R44"].OwnerBand = bandRegular44;
            view.Columns["R46"].OwnerBand = bandRegular46;
            view.Columns["R48"].OwnerBand = bandRegular48;
            view.Columns["R50"].OwnerBand = bandRegular50;
            view.Columns["R52"].OwnerBand = bandRegular52;
            view.Columns["R54"].OwnerBand = bandRegular54;
            view.Columns["R56"].OwnerBand = bandRegular56;
            view.Columns["R58"].OwnerBand = bandRegular58;
            view.Columns["R60"].OwnerBand = bandRegular60;
            view.Columns["R62"].OwnerBand = bandRegular62;

            view.Columns["L38"].OwnerBand = bandLong38;
            view.Columns["L40"].OwnerBand = bandLong40;
            view.Columns["L42"].OwnerBand = bandLong42;
            view.Columns["L44"].OwnerBand = bandLong44;
            view.Columns["L46"].OwnerBand = bandLong46;
            view.Columns["L48"].OwnerBand = bandLong48;
            view.Columns["L50"].OwnerBand = bandLong50;
            view.Columns["L52"].OwnerBand = bandLong52;
            view.Columns["L54"].OwnerBand = bandLong54;
            view.Columns["L56"].OwnerBand = bandLong56;
            view.Columns["L58"].OwnerBand = bandLong58;
            view.Columns["L60"].OwnerBand = bandLong60;
            view.Columns["L62"].OwnerBand = bandLong62;
           
            view.Columns["S34"].OwnerBand = bandShort34;
            view.Columns["S36"].OwnerBand = bandShort36;
            view.Columns["S38"].OwnerBand = bandShort38;
            view.Columns["S40"].OwnerBand = bandShort40;
            view.Columns["S42"].OwnerBand = bandShort42;
            view.Columns["S44"].OwnerBand = bandShort44;
            view.Columns["S46"].OwnerBand = bandShort46;

            ColumnTag tag = null;
            for (int i = BeginSizeNoIndex; i <= EndSizeNoIndex; i++)
            {
                tag = new ColumnTag();
                tag.DataType = ColumnTag.DataType_Integer;
                gridView.Columns[i].UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                gridView.Columns[i].Tag = tag;
                gridView.Columns[i].Width = 50;
            }

        }

        #endregion
       
        #region 加载库存数据

        public void AddInboundCount(int cnt)
        {
            if (dataTable.Rows.Count > 4)
            {
                for (int i = dataTable.Rows.Count - 1; i >= 4; i--)
                    dataTable.Rows.RemoveAt(i);
            }
            AddOrderQuntity(cnt);
            CalculateItemQnt(cnt);
        }
      
        //加载库存数据
        public override void Loading()
        {
            if( dataTable != null)
                dataTable.Clear();
            
            if (gridView == null)
                return;

            
            invtItem = LoadInventory();
            AddDataTableRows(invtItem, "库存数量");
             
            inbondItem = LoadInbound();
            AddDataTableRows(inbondItem, "进货数量");

            outboundItem = LoadOutbound();
            AddDataTableRows(outboundItem, "销售数量");

            CalculateSaleRatio();

            gridView.BeginUpdate();//开始视图的编辑，防止触发其他事件
            gridView.BeginDataUpdate(); //开始数据的编辑

            gridView.GridControl.DataSource = dataTable;

            gridView.EndDataUpdate();
            if (dataTable.Rows.Count > 0)
                gridView.IndicatorWidth = 25 + (dataTable.Rows.Count.ToString().Length + 1) * 5;
            gridView.MoveFirst();
            gridView.EndUpdate();

        }

        private InventoryItem LoadInventory()
        {
           // List<InventoryItem> list = new List<InventoryItem>();

            InventoryItem item = null;
            DataTable dt = null;

            string sql = string.Format("Select SizeNo, Sum(Quantity) as Cnt From T_Inventory where {0} ",
                GetSelectionArts(ArtNo) ) ;
              
            sql += " Group by SizeNo ";
            sql += " Order by SizeNo ";

            dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return item;
              
            //将DataTable转换为ListItem
            string sizeNo = "";
            int quantity = 0, sum = 0;

            DataRow dr = null;
            item = new InventoryItem();

            for (int i = 0, cnt = dt.Rows.Count; i < cnt; i++)
            {
                dr = dt.Rows[i];
                
                sizeNo = dr["SizeNo"].ToString();
                quantity = Convert.ToInt32(dr["Cnt"]);
                sum += quantity;
                item.SubTotal = sum;
                item.Set(sizeNo, quantity);

            }

            dt.Clear();

            return  item;
        }

        private InventoryItem LoadInbound()
        {

            InventoryItem item = null;
           // List<InventoryItem> list = new List<InventoryItem>();

            DataTable dt = null;
            string sql = String.Format("Select SizeNo, sum(NumofPlan) As Cnt  From V_InboundDetail where {0}",
                GetSelectionArts(ArtNo));

            if (string.IsNullOrEmpty(BeginDate) == false)
                sql += string.Format(" and ShipDate >= '{0}'", BeginDate);

            if( string.IsNullOrEmpty(EndDate) == false )
                sql += string.Format(" and ShipDate <= '{0}'", EndDate);

            sql += " Group by  SizeNo ";
            sql += " Order by  SizeNo ";

            dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
            {
                return  item;
            }

            //将DataTable转换为ListItem
            string  sizeNo = "";
            int quantity = 0, sum = 0;

            DataRow dr = null;
            item = new InventoryItem();
            for (int i = 0, cnt = dt.Rows.Count; i < cnt; i++)
            {
                dr = dt.Rows[i];
                sizeNo = dr["SizeNo"].ToString();
                quantity = Convert.ToInt32(dr["Cnt"]);
                sum += quantity;
                item.SubTotal = sum;
                item.Set(sizeNo, quantity);

            }

            dt.Clear();

            return  item;

        }

        private InventoryItem LoadOutbound()
        {
            InventoryItem item = null;
           // List<InventoryItem> list = new List<InventoryItem>();

            DataTable dt = null;
            string sql = String.Format("Select SizeNo, Sum( NumofPlan) As Cnt  From V_OutboundDetail where {0}", 
                GetSelectionArts(ArtNo) );

            if (string.IsNullOrEmpty(BeginDate) == false)
                sql += string.Format(" and ShipDate >= '{0}'", BeginDate);

            if (string.IsNullOrEmpty(EndDate) == false)
                sql += string.Format(" and ShipDate <= '{0}'", EndDate);


            sql += " Group by  SizeNo ";
            sql += " Order by  SizeNo ";
         

            dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
            {
                return item;
            }

            //将DataTable转换为ListItem
            string sizeNo = "";
            int quantity = 0, sum = 0;

            
            DataRow dr = null;
            item = new InventoryItem();
            for (int i = 0, cnt = dt.Rows.Count; i < cnt; i++)
            {
                dr = dt.Rows[i];
                
                sizeNo = dr["SizeNo"].ToString();

                quantity = Convert.ToInt32(dr["Cnt"]);
                sum += quantity;
                item.SubTotal = sum;
                item.Set(sizeNo, quantity);

            }

            dt.Clear();

            return item;

        }

        //添加数据行
        protected void AddDataTableRows(InventoryItem item, string kind)
        {
            DataTable dt = this.dataTable;

            //InventoryItem item = null;
            System.Data.DataRow dataRow = null;

            //for (int i = 0, cnt = listInventory.Count; i < cnt; i++)
            //{
            dataRow = dt.NewRow();
            // item = listInventory[i];
            dataRow["RowKind"] = kind;
            if (item == null)
            {
                dt.Rows.Add(dataRow);
                return;
            }
            dataRow["LotNo"] = item.LotNo;

            dataRow["R36"] = item.R36 == 0 ? "" : item.R36.ToString();
            dataRow["R38"] = item.R38 == 0 ? "" : item.R38.ToString();
            dataRow["R40"] = item.R40 == 0 ? "" : item.R40.ToString();
            dataRow["R42"] = item.R42 == 0 ? "" : item.R42.ToString();
            dataRow["R44"] = item.R44 == 0 ? "" : item.R44.ToString();
            dataRow["R46"] = item.R46 == 0 ? "" : item.R46.ToString();
            dataRow["R48"] = item.R48 == 0 ? "" : item.R48.ToString();
            dataRow["R50"] = item.R50 == 0 ? "" : item.R50.ToString();
            dataRow["R52"] = item.R52 == 0 ? "" : item.R52.ToString();
            dataRow["R54"] = item.R54 == 0 ? "" : item.R54.ToString();
            dataRow["R56"] = item.R56 == 0 ? "" : item.R56.ToString();
            dataRow["R58"] = item.R58 == 0 ? "" : item.R58.ToString();
            dataRow["R60"] = item.R60 == 0 ? "" : item.R60.ToString();
            dataRow["R62"] = item.R62 == 0 ? "" : item.R62.ToString();

            dataRow["L38"] = item.L38 == 0 ? "" : item.L38.ToString();
            dataRow["L40"] = item.L40 == 0 ? "" : item.L40.ToString();
            dataRow["L42"] = item.L42 == 0 ? "" : item.L42.ToString();
            dataRow["L44"] = item.L44 == 0 ? "" : item.L44.ToString();
            dataRow["L46"] = item.L46 == 0 ? "" : item.L46.ToString();
            dataRow["L48"] = item.L48 == 0 ? "" : item.L48.ToString();
            dataRow["L50"] = item.L50 == 0 ? "" : item.L50.ToString();
            dataRow["L52"] = item.L52 == 0 ? "" : item.L52.ToString();
            dataRow["L54"] = item.L54 == 0 ? "" : item.L54.ToString();
            dataRow["L56"] = item.L56 == 0 ? "" : item.L56.ToString();
            dataRow["L58"] = item.L58 == 0 ? "" : item.L58.ToString();
            dataRow["L60"] = item.L60 == 0 ? "" : item.L60.ToString();
            dataRow["L62"] = item.L62 == 0 ? "" : item.L62.ToString();

            dataRow["S34"] = item.S34 == 0 ? "" : item.S34.ToString();
            dataRow["S36"] = item.S36 == 0 ? "" : item.S36.ToString();
            dataRow["S38"] = item.S38 == 0 ? "" : item.S38.ToString();
            dataRow["S40"] = item.S40 == 0 ? "" : item.S40.ToString();
            dataRow["S42"] = item.S42 == 0 ? "" : item.S42.ToString();
            dataRow["S44"] = item.S44 == 0 ? "" : item.S44.ToString();
            dataRow["S46"] = item.S46 == 0 ? "" : item.S46.ToString();

            dataRow["SubTotal"] = item.SubTotal == 0 ? "" : item.SubTotal.ToString();

            dt.Rows.Add(dataRow);
            //  }


        }

        //计算销售比
        private void CalculateSaleRatio()
        {
            int qnt = 0;
            if (outboundItem == null)
                return;
            qnt = outboundItem.SubTotal;

            InventoryItem item = outboundItem;
            DataTable dt = this.dataTable;
            System.Data.DataRow dataRow = null;

            dataRow = dt.NewRow();
            
            dataRow["RowKind"] = "销售%比";
            dataRow["LotNo"] = item.LotNo;

            dataRow["R36"] = item.R36 == 0 ? "" : string.Format("{0:0.00%}", item.R36 / (1.0 * qnt));
            dataRow["R38"] = item.R38 == 0 ? "" : string.Format("{0:0.00%}", item.R38 / (1.0 * qnt));
            dataRow["R40"] = item.R40 == 0 ? "" : string.Format("{0:0.00%}", item.R40 / (1.0 * qnt));
            dataRow["R42"] = item.R42 == 0 ? "" : string.Format("{0:0.00%}", item.R42 / (1.0 * qnt));
            dataRow["R44"] = item.R44 == 0 ? "" : string.Format("{0:0.00%}", item.R44 / (1.0 * qnt));
            dataRow["R46"] = item.R46 == 0 ? "" : string.Format("{0:0.00%}", item.R46 / (1.0 * qnt));
            dataRow["R48"] = item.R48 == 0 ? "" : string.Format("{0:0.00%}", item.R48 / (1.0 * qnt));
            dataRow["R50"] = item.R50 == 0 ? "" : string.Format("{0:0.00%}", item.R50 / (1.0 * qnt));
            dataRow["R52"] = item.R52 == 0 ? "" : string.Format("{0:0.00%}", item.R52 / (1.0 * qnt));
            dataRow["R54"] = item.R54 == 0 ? "" : string.Format("{0:0.00%}", item.R54 / (1.0 * qnt));
            dataRow["R56"] = item.R56 == 0 ? "" : string.Format("{0:0.00%}", item.R56 / (1.0 * qnt));
            dataRow["R58"] = item.R58 == 0 ? "" : string.Format("{0:0.00%}", item.R58 / (1.0 * qnt));
            dataRow["R60"] = item.R60 == 0 ? "" : string.Format("{0:0.00%}", item.R60 / (1.0 * qnt));
            dataRow["R62"] = item.R62 == 0 ? "" : string.Format("{0:0.00%}", item.R62 / (1.0 * qnt));

            dataRow["L38"] = item.L38 == 0 ? "" : string.Format("{0:0.00%}", item.L38 / (1.0 * qnt));
            dataRow["L40"] = item.L40 == 0 ? "" : string.Format("{0:0.00%}", item.L40 / (1.0 * qnt));
            dataRow["L42"] = item.L42 == 0 ? "" : string.Format("{0:0.00%}", item.L42 / (1.0 * qnt));
            dataRow["L44"] = item.L44 == 0 ? "" : string.Format("{0:0.00%}", item.L44 / (1.0 * qnt));
            dataRow["L46"] = item.L46 == 0 ? "" : string.Format("{0:0.00%}", item.L46 / (1.0 * qnt));
            dataRow["L48"] = item.L48 == 0 ? "" : string.Format("{0:0.00%}", item.L48 / (1.0 * qnt));
            dataRow["L50"] = item.L50 == 0 ? "" : string.Format("{0:0.00%}", item.L50 / (1.0 * qnt));
            dataRow["L52"] = item.L52 == 0 ? "" : string.Format("{0:0.00%}", item.L52 / (1.0 * qnt));
            dataRow["L54"] = item.L54 == 0 ? "" : string.Format("{0:0.00%}", item.L54 / (1.0 * qnt));
            dataRow["L56"] = item.L56 == 0 ? "" : string.Format("{0:0.00%}", item.L56 / (1.0 * qnt));
            dataRow["L58"] = item.L58 == 0 ? "" : string.Format("{0:0.00%}", item.L58 / (1.0 * qnt));
            dataRow["L60"] = item.L60 == 0 ? "" : string.Format("{0:0.00%}", item.L60 / (1.0 * qnt));
            dataRow["L62"] = item.L62 == 0 ? "" : string.Format("{0:0.00%}", item.L62 / (1.0 * qnt));

            dataRow["S34"] = item.S34 == 0 ? "" : string.Format("{0:0.00%}", item.S34 / (1.0 * qnt));
            dataRow["S36"] = item.S36 == 0 ? "" : string.Format("{0:0.00%}", item.S36 / (1.0 * qnt));
            dataRow["S38"] = item.S38 == 0 ? "" : string.Format("{0:0.00%}", item.S38 / (1.0 * qnt));
            dataRow["S40"] = item.S40 == 0 ? "" : string.Format("{0:0.00%}", item.S40 / (1.0 * qnt));
            dataRow["S42"] = item.S42 == 0 ? "" : string.Format("{0:0.00%}", item.S42 / (1.0 * qnt));
            dataRow["S44"] = item.S44 == 0 ? "" : string.Format("{0:0.00%}", item.S44 / (1.0 * qnt));
            dataRow["S46"] = item.S46 == 0 ? "" : string.Format("{0:0.00%}", item.S46 / (1.0 * qnt));

            
            dt.Rows.Add(dataRow);
        }

        private void AddOrderQuntity(int cnt)
        {
            string qnt = cnt.ToString();
            if (outboundItem == null)
                return;
           
            InventoryItem item = outboundItem;
            DataTable dt = this.dataTable;
            System.Data.DataRow dataRow = null;

            
            dataRow = dt.NewRow();
            dataRow["RowKind"] = "新订单数量";
            dataRow["LotNo"] = item.LotNo;

            for (int i = BeginSizeNoIndex; i <= EndSizeNoIndex; i++)
                dataRow[i] = qnt;

            dt.Rows.Add(dataRow);
        }

        //新订单搭配
        private void CalculateItemQnt(int addCnt )
        {
            if (outboundItem == null)
                return;
            
            InventoryItem item = outboundItem;
            DataTable dt = this.dataTable;
            System.Data.DataRow dataRow = null;
            int qnt = item.SubTotal;

            dataRow = dt.NewRow();
            dataRow["RowKind"] = "新订单搭配";
            dataRow["LotNo"] = item.LotNo;

            dataRow["R36"] = item.R36 == 0 ? "" : string.Format("{0:0}", item.R36 * addCnt / (1.0 * qnt));
            dataRow["R38"] = item.R38 == 0 ? "" : string.Format("{0:0}", item.R38 * addCnt / (1.0 * qnt));
            dataRow["R40"] = item.R40 == 0 ? "" : string.Format("{0:0}", item.R40 * addCnt / (1.0 * qnt));
            dataRow["R42"] = item.R42 == 0 ? "" : string.Format("{0:0}", item.R42 * addCnt / (1.0 * qnt));
            dataRow["R44"] = item.R44 == 0 ? "" : string.Format("{0:0}", item.R44 * addCnt / (1.0 * qnt));
            dataRow["R46"] = item.R46 == 0 ? "" : string.Format("{0:0}", item.R46 * addCnt / (1.0 * qnt));
            dataRow["R48"] = item.R48 == 0 ? "" : string.Format("{0:0}", item.R48 * addCnt / (1.0 * qnt));
            dataRow["R50"] = item.R50 == 0 ? "" : string.Format("{0:0}", item.R50 * addCnt / (1.0 * qnt));
            dataRow["R52"] = item.R52 == 0 ? "" : string.Format("{0:0}", item.R52 * addCnt / (1.0 * qnt));
            dataRow["R54"] = item.R54 == 0 ? "" : string.Format("{0:0}", item.R54 * addCnt / (1.0 * qnt));
            dataRow["R56"] = item.R56 == 0 ? "" : string.Format("{0:0}", item.R56 * addCnt / (1.0 * qnt));
            dataRow["R58"] = item.R58 == 0 ? "" : string.Format("{0:0}", item.R58 * addCnt / (1.0 * qnt));
            dataRow["R60"] = item.R60 == 0 ? "" : string.Format("{0:0}", item.R60 * addCnt / (1.0 * qnt));
            dataRow["R62"] = item.R62 == 0 ? "" : string.Format("{0:0}", item.R62 * addCnt / (1.0 * qnt));

            dataRow["L38"] = item.L38 == 0 ? "" : string.Format("{0:0}", item.L38 * addCnt / (1.0 * qnt));
            dataRow["L40"] = item.L40 == 0 ? "" : string.Format("{0:0}", item.L40 * addCnt / (1.0 * qnt));
            dataRow["L42"] = item.L42 == 0 ? "" : string.Format("{0:0}", item.L42 * addCnt / (1.0 * qnt));
            dataRow["L44"] = item.L44 == 0 ? "" : string.Format("{0:0}", item.L44 * addCnt / (1.0 * qnt));
            dataRow["L46"] = item.L46 == 0 ? "" : string.Format("{0:0}", item.L46 * addCnt / (1.0 * qnt));
            dataRow["L48"] = item.L48 == 0 ? "" : string.Format("{0:0}", item.L48 * addCnt / (1.0 * qnt));
            dataRow["L50"] = item.L50 == 0 ? "" : string.Format("{0:0}", item.L50 * addCnt / (1.0 * qnt));
            dataRow["L52"] = item.L52 == 0 ? "" : string.Format("{0:0}", item.L52 * addCnt / (1.0 * qnt));
            dataRow["L54"] = item.L54 == 0 ? "" : string.Format("{0:0}", item.L54 * addCnt / (1.0 * qnt));
            dataRow["L56"] = item.L56 == 0 ? "" : string.Format("{0:0}", item.L56 * addCnt / (1.0 * qnt));
            dataRow["L58"] = item.L58 == 0 ? "" : string.Format("{0:0}", item.L58 * addCnt / (1.0 * qnt));
            dataRow["L60"] = item.L60 == 0 ? "" : string.Format("{0:0}", item.L60 * addCnt / (1.0 * qnt));
            dataRow["L62"] = item.L62 == 0 ? "" : string.Format("{0:0}", item.L62 * addCnt / (1.0 * qnt));

            dataRow["S34"] = item.S34 == 0 ? "" : string.Format("{0:0}", item.S34 * addCnt / (1.0 * qnt));
            dataRow["S36"] = item.S36 == 0 ? "" : string.Format("{0:0}", item.S36 * addCnt / (1.0 * qnt));
            dataRow["S38"] = item.S38 == 0 ? "" : string.Format("{0:0}", item.S38 * addCnt / (1.0 * qnt));
            dataRow["S40"] = item.S40 == 0 ? "" : string.Format("{0:0}", item.S40 * addCnt / (1.0 * qnt));
            dataRow["S42"] = item.S42 == 0 ? "" : string.Format("{0:0}", item.S42 * addCnt / (1.0 * qnt));
            dataRow["S44"] = item.S44 == 0 ? "" : string.Format("{0:0}", item.S44 * addCnt / (1.0 * qnt));
            dataRow["S46"] = item.S46 == 0 ? "" : string.Format("{0:0}", item.S46 * addCnt / (1.0 * qnt));

            int sum = 0;
            string tmp;
            for (int i = BeginSizeNoIndex; i <= EndSizeNoIndex; i++)
            {
                tmp = dataRow[i].ToString();
                if (string.IsNullOrEmpty(tmp) == false)
                    sum += Convert.ToInt32(tmp);
            }
            dataRow["SubTotal"] = sum;

            dt.Rows.Add(dataRow);
            
        }

        private void GetClothesData(InventoryItem item, string lotNo)
        {
            int cnt = listClothes.Count;
            for (int i = 0; i < cnt; i++)
            {
                if (listClothes[i].LotNo != lotNo)
                    continue;

                item.StyleNo = listClothes[i].StyleNo;
                item.ShellNo = listClothes[i].ShellNo;
                item.Shell = listClothes[i].Shell;
                item.Model = listClothes[i].Model;
                item.Color = listClothes[i].Color;

                return;
            }
        }

        private string GetSelectionArts(string keywords)
        {
            string sql = " ", temp = "";
            if (keywords.Length > 0)
            {
                string[] keys = keywords.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                int cnt = keys.Length;
                if (cnt > 0)
                    sql += string.Format("( LotNo = '{0}' ", keys[0].Replace("'", "''") );
                for (int i = 1; i < cnt; i++)
                {
                    temp = String.Format(" or LotNo = '{0}' ", keys[i].Replace("'", "''"));
                    sql += temp;
                }
                sql += " ) ";
            }

            return sql;
        }
      
        #endregion

        #region 求小计

        protected int GetSubTotal(int rowHandle)
        {
            int sum = 0;
            //string temp = "";
            Object obj = null;
            for (int i = BeginSizeNoIndex; i <= EndSizeNoIndex; i++)
            {
                //temp = gridView.Columns[i].FieldName;
                obj = gridView.GetRowCellValue(rowHandle, gridView.Columns[i]);
                if (obj == null) continue;
                if (string.IsNullOrEmpty(obj.ToString()))
                    continue;
                sum += Convert.ToInt32(obj);
            }

            return sum;
        }

        #endregion

    }
}
