using System;
using Utility;

namespace Utility
{
    #region 是否启用
    [EnumDesc("启用状态")]
    public enum Is_Disable
    {
        ///<summary>
        ///有效
        ///<summary>
        [EnumField("0")]
        有效,
        ///<summary>
        ///无效
        ///<summary>
        [EnumField("1")]
        无效
    }
    #endregion


    #region 是否翻包装
    [EnumDesc("是否翻包装")]
    public enum IS_REPACKAGING
    {
        ///<summary>
        ///是
        ///<summary>
        [EnumField("0")]
        是,
        ///<summary>
        ///否
        ///<summary>
        [EnumField("1")]
        否
    }
    #endregion

    #region 是否删除
    [EnumDesc("删除状态")]
    public enum IsDelete
    {
        ///<summary>
        ///未删除
        ///<summary>
        [EnumField(0)]
        未删除,
        ///<summary>
        ///逻辑删除
        ///<summary>
        [EnumField(1)]
        逻辑删除,
        ///<summary>
        ///删除
        ///<summary>
        [EnumField(2)]
        删除
    }
    #endregion

    #region 登陆/修改操作类型
    [EnumDesc("操作类型")]
    public enum LoginOperationType
    {
        ///<summary>
        ///登陆
        ///<summary>
        [EnumField("login")]
        登陆,
        ///<summary>
        ///修改
        ///<summary>
        [EnumField("update")]
        修改
    }
    #endregion

    #region 登陆状态
    [EnumDesc("登陆状态")]
    public enum LoginSate
    {
        ///<summary>
        ///成功
        ///<summary>
        [EnumField("success")]
        成功,
        ///<summary>
        ///失败
        ///<summary>
        [EnumField("failed")]
        失败
    }
    #endregion

    #region 用户是否锁定
    [EnumDesc("是否锁定")]
    public enum IsLock
    {
        ///<summary>
        ///是
        ///<summary>
        [EnumField("yes")]
        是,
        ///<summary>
        ///否
        ///<summary>
        [EnumField("no")]
        否
    }
    #endregion

    #region 零件类型
    [EnumDesc("零件类型")]
    public enum PartType
    {
        ///<summary>
        ///总成
        ///<summary>
        [EnumField("assmbly")]
        总成,
        ///<summary>
        ///散件
        ///<summary>
        [EnumField("parts")]
        散件
    }
    #endregion

    #region 仓库类型
    [EnumDesc("启用状态")]
    public enum WareHouseType
    {
        ///<summary>
        ///客户
        ///<summary>
        [EnumField("customer")]
        客户,
        ///<summary>
        ///供应商
        ///<summary>
        [EnumField("supplier")]
        供应商,
        ///<summary>
        ///仓库
        ///<summary>
        [EnumField("warehouse")]
        仓库
    }
    #endregion

    #region 项目类型
    [EnumDesc("项目类型")]
    public enum ProjectType
    {
        ///<summary>
        ///大项目
        ///<summary>
        [EnumField("bigproject")]
        大项目,
        ///<summary>
        ///小项目
        ///<summary>
        [EnumField("littleproject")]
        小项目
    }
    #endregion

    #region 单据状态
    [EnumDesc("单据状态")]
    public enum pullstate
    {
        ///<summary>
        ///未执行
        ///<summary>
        [EnumField("Unf")]
        未执行,
        ///<summary>
        ///已完成
        ///<summary>
        [EnumField("Com")]
        已完成,
        ///<summary>
        ///已删除
        ///<summary>
        [EnumField("Del")]
        已删除
    }
    #endregion

    #region 拉动单类型
    [EnumDesc("拉动单类型")]
    public enum pulltype
    {
        ///<summary>
        ///炉号报验拉动
        ///<summary>
        [EnumField("fip")]
        炉号报验拉动,
        ///<summary>
        ///生产线拉动
        ///<summary>
        [EnumField("ppl", new string[] { "pull" })]
        生产线拉动,
        ///<summary>
        ///紧急拉动
        ///<summary>
        [EnumField("ep", new string[] { "pull" })]
        紧急拉动,
        ///<summary>
        ///DD拉动
        ///<summary>
        [EnumField("dd", new string[] { "pull" })]
        DD,
        ///<summary>
        ///南厂排序拉动
        ///<summary>
        [EnumField("south", new string[] { "pull" })]
        南厂排序拉动,
        ///<summary>
        ///北厂PUS拉动
        ///<summary>
        [EnumField("north", new string[] { "pull" })]
        北厂PUS拉动
    }
    #endregion

    #region 包装类型
    [EnumDesc("包装类型")]
    public enum PackageType
    {
        ///<summary>
        ///售后包装
        ///<summary>
        [EnumField("services", new string[] { "Sales" })]
        售后包装,
        ///<summary>
        ///纸箱
        ///<summary>
        [EnumField("paper", new string[] { "package" })]
        纸箱,
        ///<summary>
        ///料架
        ///<summary>
        [EnumField("rack", new string[] { "package" })]
        料架,
        ///<summary>
        ///铁皮箱
        ///<summary>
        [EnumField("iron", new string[] { "package" })]
        铁皮箱,
        ///<summary>
        ///木箱
        ///<summary>
        [EnumField("Wbox", new string[] { "package" })]
        木箱,
        ///<summary>
        ///塑料箱
        ///<summary>
        [EnumField("plastic", new string[] { "package" })]
        塑料箱,
        ///<summary>
        ///小木箱
        ///<summary>
        [EnumField("Sbox", new string[] { "package" })]
        小木箱,
        ///<summary>
        ///铁托
        ///<summary>
        [EnumField("tito", new string[] { "package" })]
        铁托,
        ///<summary>
        ///木托
        ///<summary>
        [EnumField("Wpallet", new string[] { "package" })]
        木托,
        ///<summary>
        ///小铁箱
        ///<summary>
        [EnumField("Siron", new string[] { "package" })]
        小铁箱
    }
    #endregion

    #region 生产步骤
    [EnumDesc("生产步骤")]
    public enum ProduceStep
    {
        ///<summary>
        ///生成翻包装计划
        ///<summary>
        [EnumField("producepackage")]
        生成翻包装计划,
        ///<summary>
        ///生成售后件翻包装计划
        ///<summary>
        [EnumField("produceafterpackage")]
        生成售后件翻包装计划,
        ///<summary>
        ///生成报验计划
        ///<summary>
        [EnumField("producecheck")]
        生成报验计划,
    }
    #endregion

    #region 生产类型
    [EnumDesc("生产类型")]
    public enum ProduceType
    {
        ///<summary>
        ///响应时间
        ///<summary>
        [EnumField("reactiontime")]
        响应时间,
        ///<summary>
        ///逾时时间
        ///<summary>
        [EnumField("overtime")]
        逾时时间
    }
    #endregion

    #region 计划入库表单据类型
    [EnumDesc("计划入库表单据类型")]
    public enum PlanInOrderType
    {
        ///<summary>
        ///供应计划入库
        ///<summary>
        [EnumField("")]
        供应计划入库
    }
    #endregion

    #region 供应商类型
    [EnumDesc("供应商类型")]
    public enum SuppliersType
    {
        ///<summary>
        ///进货
        ///<summary>
        [EnumField("stock")]
        进货,
        ///<summary>
        ///检验
        ///<summary>
        [EnumField("checkout")]
        检验,
        /// <summary>
        /// 拉动
        /// </summary>
        [EnumField("pull")]
        拉动,
        /// <summary>
        /// 退货
        /// </summary>
        [EnumField("returngoods")]
        退货
    }
    #endregion

    #region 订单号
    public enum OrderNo
    {
        ///<summary>
        ///收货单号
        ///<summary>
        [EnumField("A")]
        收货单号,
        ///<summary>
        ///入库单号
        ///<summary>
        [EnumField("B")]
        入库单号,
        /// <summary>
        /// 退货入库单号
        /// </summary>
        [EnumField("C")]
        退货入库单号,
        /// <summary>
        /// 工位器具入库单号
        /// </summary>
        [EnumField("D")]
        工位器具入库单号,
        /// <summary>
        /// 报验入库单号
        /// </summary>
        [EnumField("E")]
        报验入库单号,
        /// <summary>
        /// 报废单号
        /// </summary>
        [EnumField("F")]
        报废单号,
        /// <summary>
        /// 翻包装单号
        /// </summary>
        [EnumField("G")]
        翻包装单号,
        /// <summary>
        /// 移库单号
        /// </summary>
        [EnumField("H")]
        移库单号,
        /// <summary>
        /// 拣货单号
        /// </summary>
        [EnumField("I")]
        拣货单号,
        /// <summary>
        ///开箱差异单
        /// </summary>
        [EnumField("J")]
        开箱差异单,
        /// <summary>
        ///入库冲销单
        /// </summary>
        [EnumField("K")]
        入库冲销单,
        /// <summary>
        ///出库冲销单
        /// </summary>
        [EnumField("L")]
        出库冲销单,
        /// <summary>
        ///零件盘点单号
        /// </summary>
        [EnumField("M")]
        零件盘点单号,
        /// <summary>
        ///工位器具盘点单号
        /// </summary>
        [EnumField("N")]
        工位器具盘点单号,
        /// <summary>
        ///退货单号（退货给供应商）
        /// </summary>
        [EnumField("O")]
        退货到供应商单号,
        /// <summary>
        ///报验单号
        /// </summary>
        [EnumField("P")]
        报验单号,
        /// <summary>
        ///筛选信息单号
        /// </summary>
        [EnumField("Q")]
        筛选信息单号,
        /// <summary>
        ///售后发货单
        /// </summary>
        [EnumField("R")]
        售后发货单,
        /// <summary>
        ///发货单
        /// </summary>
        [EnumField("S")]
        发货单,
        /// <summary>
        /// 客户退货收货单号
        /// </summary>
        [EnumField("W")]
        客户退货收货单号,
    }
    #endregion

    #region 物料所属
    [EnumDesc("物料所属")]
    public enum PartOwner
    {
        ///<summary>
        ///帐内
        ///<summary>
        [EnumField("Account")]
        帐内,
        ///<summary>
        ///帐外
        ///<summary>
        [EnumField("OutAccount")]
        帐外,
        ///<summary>
        ///盘盈
        ///<summary>
        [EnumField("Overage")]
        盘盈,
    }
    #endregion

    #region 业务单据类型
    public enum OrderType
    {
        ///<summary>
        ///工位器具发货单
        ///<summary>
        [EnumField("packageDeliver")]
        工位器具发货单,
        ///<summary>
        ///供应商送货入库
        ///<summary>
        [EnumField("SupplierIn")]
        供应商送货入库,
        ///<summary>
        ///工位器具入库单
        ///<summary>
        [EnumField("PackageIn")]
        工位器具入库单,
        ///<summary>
        ///客户退货入库
        ///<summary>
        [EnumField("CustomerBack")]
        客户退货入库,
        ///<summary>
        ///供应商送货收货
        ///<summary>
        [EnumField("SupplierReceive")]
        供应商送货收货,
        ///<summary>
        ///客户退货收货
        ///<summary>
        [EnumField("CustBackReceive")]
        客户退货收货,
        ///<summary>
        ///报验入库
        ///<summary>
        [EnumField("InspectionIn")]
        报验入库,
        ///<summary>
        ///生产拉动
        ///<summary>
        [EnumField("PullProduce")]
        生产拉动,
        ///<summary>
        ///售后拉动
        ///<summary>
        [EnumField("ServicePull")]
        售后拉动,
        ///<summary>
        ///炉号拉动
        ///<summary>
        [EnumField("FurnacePull")]
        炉号拉动,
        ///<summary>
        ///移库单
        ///<summary>
        [EnumField("MoveOrder")]
        移库单,
        ///<summary>
        ///报验出库
        ///<summary>
        [EnumField("InspectionOut")]
        报验出库,
        ///<summary>
        ///筛选单
        ///<summary>
        [EnumField("FilterOrder")]
        筛选单,
        ///<summary>
        ///报废单
        ///<summary>
        [EnumField("ScrapOrder")]
        报废单,
        ///<summary>
        ///翻包装计划
        ///<summary>
        [EnumField("RepackageOrder")]
        翻包装计划,
        ///<summary>
        ///零件盘点计划
        ///<summary>
        [EnumField("PartCheck")]
        零件盘点计划,
        ///<summary>
        ///工位器具盘点计划
        ///<summary>
        [EnumField("PackageCheck")]
        工位器具盘点计划,
        ///<summary>
        ///冲销入库单
        ///<summary>
        [EnumField("AdjustIn")]
        冲销入库单,
        ///<summary>
        ///冲销出库单
        ///<summary>
        [EnumField("AdjustOut")]
        冲销出库单,
        ///<summary>
        ///冲销开箱
        ///<summary>
        [EnumField("AdjustOpen")]
        冲销开箱单,
        ///<summary>
        ///售后发货单
        ///<summary>
        [EnumField("ServiceSend")]
        售后发货单,
        ///<summary>
        ///发货单
        ///<summary>
        [EnumField("PartSend")]
        发货单,
        ///<summary>
        ///拣货单
        ///<summary>
        [EnumField("PickOrder")]
        拣货单,
        ///<summary>
        ///总成收货单
        ///<summary>
        [EnumField("AssemblyReceive")]
        总成收货单,
        ///<summary>
        ///总成入库单
        ///<summary>
        [EnumField("AssemblyIn")]
        总成入库单,
        ///<summary>
        ///退货到供应商
        ///<summary>
        [EnumField("BackSupplier")]
        退货到供应商
    }
    #endregion

    #region 订单状态
    public enum OrderState
    {
        /// <summary>
        /// 已发货
        /// </summary>
        [EnumField("finish")]
        已发货,
        /// <summary>
        /// 待发货
        /// </summary>
        [EnumField("wait")]
        待发货
    }
    #endregion

    #region 料箱料架发货类型
    public enum DeliverPackageType
    {
        ///<summary>
        ///拉动
        ///<summary>
        [EnumField("pull")]
        拉动,
        ///<summary>
        ///退货
        ///<summary>
        [EnumField("back")]
        退货,
        /// <summary>
        /// ,
        /// </summary>
        [EnumField("send")]
        客户送货,
        /// <summary>
        /// 业外
        /// </summary>
        [EnumField("other")]
        业外,
        ///<summary>
        ///排序发货单
        ///<summary>
        [EnumField("QueueSend")]
        排序发货单
    }
    #endregion

    #region 发货类型
    public enum SendType
    {
        /// <summary>
        /// 拉动发货
        /// </summary>
        [EnumField("pullSend")]
        拉动发货,
        /// <summary>
        /// 售后发货
        /// </summary>
        [EnumField("serviceSend")]
        售后发货,
        /// <summary>
        /// 退货发货
        /// </summary>
        [EnumField("bakcSend")]
        退货发货,
        /// <summary>
        /// 业外发货
        /// </summary>
        [EnumField("OutSideSend")]
        业外发货,
        ///<summary>
        ///排序发货单
        ///<summary>
        [EnumField("QueueSend")]
        排序发货单
    }
    #endregion

    #region 是否报验
    [EnumDesc("是否报验")]
    public enum Isinspection
    {
        ///<summary>
        ///是
        ///<summary>
        [EnumField("0")]
        Yes,
        ///<summary>
        ///否
        ///<summary>
        [EnumField("1")]
        No
    }
    #endregion

    #region 是否炉号报验
    [EnumDesc("是否炉号报验")]
    public enum Isfurnace
    {
        ///<summary>
        ///是
        ///<summary>
        [EnumField("0")]
        Yes,
        ///<summary>
        ///否
        ///<summary>
        [EnumField("1")]
        No
    }
    #endregion

    #region 是否一品两点
    [EnumDesc("是否一品两点")]
    public enum Ismutil
    {
        ///<summary>
        ///是
        ///<summary>
        [EnumField("0")]
        是,
        ///<summary>
        ///否
        ///<summary>
        [EnumField("1")]
        否
    }
    #endregion

    #region 是否WAREHOUSE检测报警
    [EnumDesc("是否WAREHOUSE检测报警")]
    public enum IsWaring
    {
        ///<summary>
        ///是
        ///<summary>
        [EnumField("1")]
        是,
        ///<summary>
        ///否
        ///<summary>
        [EnumField("0")]
        否
    }
    #endregion

    #region 质检类型
    [EnumDesc("质检类型")]
    public enum Qualitystate
    {
        ///<summary>
        ///筛选
        ///<summary>
        [EnumField("Scan")]
        筛选,
        ///<summary>
        ///待报验
        ///<summary>
        [EnumField("Inspection")]
        待报验,
        ///<summary>
        ///合格
        ///<summary>
        [EnumField("Qualified")]
        合格,
        ///<summary>
        ///不合格
        ///<summary>
        [EnumField("UnQualified")]
        不合格
    }
    #endregion

    #region 库位类型
    public enum LocType
    {
        /// <summary>
        ///正常库位
        /// </summary>
        [EnumField("Nomal")]
        正常库位,
        /// <summary>
        ///不良品库位
        /// </summary>
        [EnumField("UnNomal")]
        不良品库位,
        /// <summary>
        ///HOLD区库位
        /// </summary>
        [EnumField("Hold")]
        HOLD区库位,
        /// <summary>
        ///待报验
        /// </summary>
        [EnumField("UnInspection")]
        待报验,
        /// <summary>
        ///超市库位
        /// </summary>
        [EnumField("Package")]
        超市库位,
        /// <summary>
        ///售后件
        /// </summary>
        [EnumField("Aftermarket")]
        售后件,
        /// <summary>
        ///待发区
        /// </summary>
        [EnumField("Shipped")]
        待发区,
        /// <summary>
        ///包装处理
        /// </summary>
        [EnumField("Handle")]
        包装处理,
        /// <summary>
        ///售后件包装
        /// </summary>
        [EnumField("ServicesHandle")]
        售后件包装
    }
    #endregion

    #region 是否完成
    [EnumDesc("完成状态")]
    public enum Is_Finish
    {
        ///<summary>
        ///完成
        ///<summary>
        [EnumField("0", new string[] { "Receive" })]
        完成,
        ///<summary>
        ///未完成
        ///<summary>
        [EnumField("1", new string[] { "Receive" })]
        未完成,
        ///<summary>
        ///待拣货
        ///<summary>
        [EnumField("2", new string[] { "Package" })]
        待拣货,
        ///<summary>
        ///拣货完成
        ///<summary>
        [EnumField("3", new string[] { "Package" })]
        拣货完成,
        ///<summary>
        ///发货完成
        ///<summary>
        [EnumField("4")]
        发货完成
    }
    #endregion

    #region 入库类型
    [EnumDesc("入库类型")]
    public enum In_Order_Type
    {
        ///<summary>
        ///供应商入库
        ///<summary>
        [EnumField("SuppIn")]
        供应商送货入库,
        ///<summary>
        ///客户退货入库
        ///<summary>
        [EnumField("CustBack")]
        客户退货入库,
        ///<summary>
        ///报验入库
        ///<summary>
        [EnumField("InspecIn")]
        报验入库
    }
    #endregion

    #region 生产过程
    [EnumDesc("生产过程")]
    public enum ProduceProcess
    {
        ///<summary>
        ///生产步奏
        ///<summary>
        [EnumField(0)]
        供应商送货
    }
    #endregion

    #region 逾时操作
    [EnumDesc("逾时操作")]
    public enum OverTimeProcess
    {
        ///<summary>
        ///翻包装时间
        ///<summary>
        [EnumField("RePackage")]
        翻包装时间,
        ///<summary>
        ///售后翻包装时间
        ///<summary>
        [EnumField("ServPackage")]
        售后翻包装时间,
    }
    #endregion

    #region 工位器具单据类型
    [EnumDesc("工位器具单据类型")]
    public enum PackageOrderType
    {
        ///<summary>
        ///导入
        ///<summary>
        [EnumField(0)]
        导入,
        ///<summary>
        ///录入
        ///<summary>
        [EnumField(1)]
        录入,
        ///<summary>
        ///盘盈
        ///<summary>
        [EnumField(2)]
        收货
    }
    #endregion

    #region 导入文件类型
    [EnumDesc("导入文件类型")]
    public enum ImPortType
    {
        ///<summary>
        ///供应商月送货计划
        ///<summary>
        [EnumField("SupplierMonthPlan")]
        供应商月送货计划,
        ///<summary>
        ///工位器具收货记录
        ///<summary>
        [EnumField("PackageInStorage")]
        工位器具收货记录,
        ///<summary>
        ///翻包装日计划
        ///<summary>
        [EnumField("RePackageDaily")]
        翻包装日计划,
        ///<summary>
        ///拉动单导入
        ///<summary>
        [EnumField("PullPlanExport")]
        拉动单导入
    }
    #endregion

    #region 单位类型
    [EnumDesc("单位类型")]
    public enum MeasurementType
    {
        ///<summary>
        ///件
        ///<summary>
        [EnumField("item")]
        件,
        ///<summary>
        ///箱
        ///<summary>
        [EnumField("box")]
        箱
    }
    #endregion

    #region 拣货类型
    [EnumDesc("拣货类型")]
    public enum PickType
    {
        ///<summary>
        ///拉动拣货
        ///<summary>
        [EnumField("Pull")]
        拉动拣货,
        ///<summary>
        ///售后包装拣货
        ///<summary>
        [EnumField("Service")]
        售后包装拣货,
        ///<summary>
        ///售后包装拣货
        ///<summary>
        [EnumField("ServicePull")]
        售后发货拣货,
        ///<summary>
        ///翻包装拣货单
        ///<summary>
        [EnumField("Repackage")]
        翻包装拣货单,
        ///<summary>
        ///生产拉动拣货
        ///<summary>
        [EnumField("Production")]
        生产拉动拣货,
        ///<summary>
        ///报验出库
        ///<summary>
        [EnumField("Inspection")]
        报验出库,
        ///<summary>
        ///退货
        ///<summary>
        [EnumField("Return")]
        退货,
        ///<summary>
        ///移库
        ///<summary>
        [EnumField("Move")]
        移库
    }
    #endregion

    #region 调帐类型
    [EnumDesc("调帐类型")]
    public enum AdjustType
    {
        ///<summary>
        ///入库冲销
        ///<summary>
        [EnumField("InStorage")]
        入库冲销,
        ///<summary>
        ///出库冲销
        ///<summary>
        [EnumField("OutStorage")]
        出库冲销,
        ///<summary>
        ///开箱增加差异
        ///<summary>
        [EnumField("OpenAdd")]
        开箱增加差异,
        ///<summary>
        ///开箱减少差异
        ///<summary>
        [EnumField("OpenReduce")]
        开箱减少差异

    }
    #endregion

    #region 操作类型
    [EnumDesc("操作类型")]
    public enum OperateType
    {
        ///<summary>
        ///收货
        ///<summary>
        [EnumField("Receipt")]
        收货,
        ///<summary>
        ///入库
        ///<summary>
        [EnumField("InStorage")]
        入库,
        ///<summary>
        ///移库
        ///<summary>
        [EnumField("Move")]
        移库,
        ///<summary>
        ///拣货
        ///<summary>
        [EnumField("Pick")]
        拣货,
        ///<summary>
        ///包装
        ///<summary>
        [EnumField("Package")]
        包装,
        ///<summary>
        ///发货
        ///<summary>
        [EnumField("Send")]
        发货,
        ///<summary>
        ///筛选
        ///<summary>
        [EnumField("Filter")]
        筛选,
        ///<summary>
        ///报废
        ///<summary>
        [EnumField("Scrapped")]
        报废,
        ///<summary>
        ///入库冲销
        ///<summary>
        [EnumField("AdjustIn")]
        入库冲销,
        ///<summary>
        ///出库冲销
        ///<summary>
        [EnumField("AdjustOut")]
        出库冲销,
        ///<summary>
        ///开箱差异
        ///<summary>
        [EnumField("OpenDiff")]
        开箱差异,
        ///<summary>
        ///报验拣货
        ///<summary>
        [EnumField("Inspection")]
        报验拣货,
        ///<summary>
        ///项目借用
        ///<summary>
        [EnumField("Brrow")]
        项目借用
    }
    #endregion

    #region 工位器具入库类型
    [EnumDesc("工位器具入库类型")]
    public enum PackageInType
    {
        ///<summary>
        ///录入
        ///<summary>
        [EnumField("Input")]
        录入,
        ///<summary>
        ///导入
        ///<summary>
        [EnumField("Import")]
        导入
    }
    #endregion

    #region 是否合格
    [EnumDesc("是否合格")]
    public enum Isqualified
    {
        ///<summary>
        ///合格
        ///<summary>
        [EnumField("0")]
        是,
        ///<summary>
        ///不合格
        ///<summary>
        [EnumField("1")]
        否
    }
    #endregion

    #region 报验类型
    [EnumDesc("报验类型")]
    public enum InspectionType
    {
        ///<summary>
        ///批次报验
        ///<summary>
        [EnumField("Batch")]
        批次报验,
        ///<summary>
        ///炉号报验
        ///<summary>
        [EnumField("Furnace")]
        炉号报验
    }
    #endregion

    #region 报废类型
    [EnumDesc("报废类型")]
    public enum ScrapType
    {
        ///<summary>
        ///筛选报废
        ///<summary>
        [EnumField("Filter")]
        筛选报废,
        ///<summary>
        ///报验报废
        ///<summary>
        [EnumField("Inspection")]
        报验报废,
        ///<summary>
        ///其他报废
        ///<summary>
        [EnumField("Other")]
        其他报废
    }
    #endregion

    #region 包装状态
    [EnumDesc("包装状态")]
    public enum PackageState
    {
        ///<summary>
        ///已包装
        ///<summary>
        [EnumField("0")]
        已包装,
        ///<summary>
        ///未包装
        ///<summary>
        [EnumField("1")]
        未包装
    }
    #endregion

    #region 返空箱状态
    [EnumDesc("返空箱状态")]
    public enum BackState
    {
        ///<summary>
        ///已完成
        ///<summary>
        [EnumField("0")]
        已完成,
        ///<summary>
        ///未完成
        ///<summary>
        [EnumField("1")]
        未完成
    }
    #endregion

    #region 单据业务
    [EnumDesc("单据业务类型")]
    public enum OrderBusinessType
    {
        ///<summary>
        ///出库
        ///<summary>
        [EnumField("OutStorage")]
        出库,
        ///<summary>
        ///入库
        ///<summary>
        [EnumField("InStorage")]
        入库,
        ///<summary>
        ///拣货
        ///<summary>
        [EnumField("Pick")]
        拣货,
        ///<summary>
        ///包装
        ///<summary>
        [EnumField("Package")]
        包装,
        ///<summary>
        ///筛选
        ///<summary>
        [EnumField("Filter")]
        筛选,
        ///<summary>
        ///报废
        ///<summary>
        [EnumField("Scrapped")]
        报废,
        ///<summary>
        ///报验
        ///<summary>
        [EnumField("Inspection")]
        报验,
        ///<summary>
        ///收货
        ///<summary>
        [EnumField("Receipt")]
        收货,
        ///<summary>
        ///移库
        ///<summary>
        [EnumField("Move")]
        移库,
        ///<summary>
        ///发货
        ///<summary>
        [EnumField("Send")]
        发货,

    }
    #endregion

    #region 盘点状态
    [EnumDesc("盘点状态")]
    public enum CheckState
    {
        ///<summary>
        ///已盘点
        ///<summary>
        [EnumField("YES")]
        已盘点,
        ///<summary>
        ///未盘点
        ///<summary>
        [EnumField("NO")]
        未盘点
    }
    #endregion

    #region 报废状态
    [EnumDesc("报废状态")]
    public enum ScrapState
    {
        ///<summary>
        ///已确认报废
        ///<summary>
        [EnumField("YES")]
        已确认报废,
        ///<summary>
        ///未确认报废
        ///<summary>
        [EnumField("NO")]
        未确认报废
    }
    #endregion

    #region 移库状态
    [EnumDesc("移库状态")]
    public enum MoveState
    {
        ///<summary>
        ///已确认移库
        ///<summary>
        [EnumField("YES")]
        已确认移库,
        ///<summary>
        ///未确认移库
        ///<summary>
        [EnumField("NO")]
        未确认移库
    }
    #endregion

    #region 排序状态
    [EnumDesc("排序状态")]
    public enum OrderSatus
    {
        ///<summary>
        ///入库
        ///<summary>
        [EnumField("0")]
        排序完成,
        ///<summary>
        ///出库
        ///<summary>
        [EnumField("1")]
        排序未完成

    }
    #endregion


    #region 是否冻结
    [EnumDesc("是否冻结")]
    public enum IsFrozen
    {
        ///<summary>
        ///是
        ///<summary>
        [EnumField("1")]
        是,
        ///<summary>
        ///否
        ///<summary>
        [EnumField("0")]
        否
    }
    #endregion

    #region 工位器具仓库操作类型
    [EnumDesc("工位器具仓库操作类型")]
    public enum PackageOperateType
    {
        ///<summary>
        ///收货
        ///<summary>
        [EnumField("In")]
        收货,
        ///<summary>
        ///发货
        ///<summary>
        [EnumField("Out")]
        发货
    }
    #endregion

    #region 是否入库
    [EnumDesc("是否入库")]
    public enum IsInStorage
    {
        ///<summary>
        ///已入库
        ///<summary>
        [EnumField("In")]
        已入库,
        ///<summary>
        ///未入库
        ///<summary>
        [EnumField("NotIn")]
        未入库
    }
    #endregion

    #region 报验单状态
    [EnumDesc("报验单状态")]
    public enum InspectionState
    {
        ///<summary>
        ///报验已入库
        ///<summary>
        [EnumField("InspectionIn")]
        报验已入库,
        ///<summary>
        ///报验待入库
        ///<summary>
        [EnumField("InspectionOut")]
        报验待入库
    }
    #endregion

    #region 报验结果
    [EnumDesc("报验结果")]
    public enum InspectionResult
    {
        ///<summary>
        ///合格
        ///<summary>
        [EnumField("Qualified")]
        合格,
        ///<summary>
        ///不合格
        ///<summary>
        [EnumField("UnQualified")]
        不合格
    }
    #endregion

    #region 是否验收
    [EnumDesc("是否验收")]
    public enum IsAcceptance
    {
        ///<summary>
        ///已验收
        ///<summary>
        [EnumField("0")]
        已验收,
        ///<summary>
        ///未验收
        ///<summary>
        [EnumField("1")]
        未验收
    }
    #endregion

    #region 报验结果
    [EnumDesc("报验结果")]
    public enum IsQualified
    {
        ///<summary>
        ///合格
        ///<summary>
        [EnumField("0")]
        合格,
        ///<summary>
        ///不合格
        ///<summary>
        [EnumField("1")]
        不合格,
        ///<summary>
        ///报验中
        ///<summary>
        [EnumField("2")]
        报验中
    }
    #endregion

    #region 单据类型
    [EnumDesc("单据类型")]
    public enum DELIVERTYPE
    {
        ///<summary>
        ///拉动
        ///<summary>
        [EnumField("Pull")]
        拉动,
        ///<summary>
        ///售货
        ///<summary>
        [EnumField("Customer_service")]
        售后,
        ///<summary>
        /// 退货
        ///<summary>
        [EnumField("Return_goods")]
        退货,
        ///<summary>
        /// 业外
        ///<summary>
        [EnumField("Outside_the_industry")]
        帐外,
        ///<summary>
        ///排序发货单
        ///<summary>
        [EnumField("QueueSend")]
        排序发货单
    }
    #endregion

    #region 是否处理
    [EnumDesc("是否处理")]
    public enum IsDeal
    {
        ///<summary>
        ///是
        ///<summary>
        [EnumField("0")]
        是,
        ///<summary>
        ///否
        ///<summary>
        [EnumField("1")]
        否
    }
    #endregion

    #region 批次报验
    [EnumDesc("批次报验")]
    public enum IsInspectionBatch
    {
        ///<summary>
        ///是
        ///<summary>
        [EnumField("0")]
        是,
        ///<summary>
        ///否
        ///<summary>
        [EnumField("1")]
        否
    }
    #endregion

    #region 炉号报验
    [EnumDesc("炉号报验")]
    public enum IsInspectionFurnace
    {
        ///<summary>
        ///是
        ///<summary>
        [EnumField("0")]
        是,
        ///<summary>
        ///否
        ///<summary>
        [EnumField("1")]
        否
    }
    #endregion

    #region 是否加工
    [EnumDesc("是否加工")]
    public enum IsProcessing
    {
        ///<summary>
        ///是
        ///<summary>
        [EnumField("0")]
        是,
        ///<summary>
        ///否
        ///<summary>
        [EnumField("1")]
        否
    }
    #endregion

}
