using System;
using Utility;

namespace Utility
{
    #region �Ƿ�����
    [EnumDesc("����״̬")]
    public enum Is_Disable
    {
        ///<summary>
        ///��Ч
        ///<summary>
        [EnumField("0")]
        ��Ч,
        ///<summary>
        ///��Ч
        ///<summary>
        [EnumField("1")]
        ��Ч
    }
    #endregion


    #region �Ƿ񷭰�װ
    [EnumDesc("�Ƿ񷭰�װ")]
    public enum IS_REPACKAGING
    {
        ///<summary>
        ///��
        ///<summary>
        [EnumField("0")]
        ��,
        ///<summary>
        ///��
        ///<summary>
        [EnumField("1")]
        ��
    }
    #endregion

    #region �Ƿ�ɾ��
    [EnumDesc("ɾ��״̬")]
    public enum IsDelete
    {
        ///<summary>
        ///δɾ��
        ///<summary>
        [EnumField(0)]
        δɾ��,
        ///<summary>
        ///�߼�ɾ��
        ///<summary>
        [EnumField(1)]
        �߼�ɾ��,
        ///<summary>
        ///ɾ��
        ///<summary>
        [EnumField(2)]
        ɾ��
    }
    #endregion

    #region ��½/�޸Ĳ�������
    [EnumDesc("��������")]
    public enum LoginOperationType
    {
        ///<summary>
        ///��½
        ///<summary>
        [EnumField("login")]
        ��½,
        ///<summary>
        ///�޸�
        ///<summary>
        [EnumField("update")]
        �޸�
    }
    #endregion

    #region ��½״̬
    [EnumDesc("��½״̬")]
    public enum LoginSate
    {
        ///<summary>
        ///�ɹ�
        ///<summary>
        [EnumField("success")]
        �ɹ�,
        ///<summary>
        ///ʧ��
        ///<summary>
        [EnumField("failed")]
        ʧ��
    }
    #endregion

    #region �û��Ƿ�����
    [EnumDesc("�Ƿ�����")]
    public enum IsLock
    {
        ///<summary>
        ///��
        ///<summary>
        [EnumField("yes")]
        ��,
        ///<summary>
        ///��
        ///<summary>
        [EnumField("no")]
        ��
    }
    #endregion

    #region �������
    [EnumDesc("�������")]
    public enum PartType
    {
        ///<summary>
        ///�ܳ�
        ///<summary>
        [EnumField("assmbly")]
        �ܳ�,
        ///<summary>
        ///ɢ��
        ///<summary>
        [EnumField("parts")]
        ɢ��
    }
    #endregion

    #region �ֿ�����
    [EnumDesc("����״̬")]
    public enum WareHouseType
    {
        ///<summary>
        ///�ͻ�
        ///<summary>
        [EnumField("customer")]
        �ͻ�,
        ///<summary>
        ///��Ӧ��
        ///<summary>
        [EnumField("supplier")]
        ��Ӧ��,
        ///<summary>
        ///�ֿ�
        ///<summary>
        [EnumField("warehouse")]
        �ֿ�
    }
    #endregion

    #region ��Ŀ����
    [EnumDesc("��Ŀ����")]
    public enum ProjectType
    {
        ///<summary>
        ///����Ŀ
        ///<summary>
        [EnumField("bigproject")]
        ����Ŀ,
        ///<summary>
        ///С��Ŀ
        ///<summary>
        [EnumField("littleproject")]
        С��Ŀ
    }
    #endregion

    #region ����״̬
    [EnumDesc("����״̬")]
    public enum pullstate
    {
        ///<summary>
        ///δִ��
        ///<summary>
        [EnumField("Unf")]
        δִ��,
        ///<summary>
        ///�����
        ///<summary>
        [EnumField("Com")]
        �����,
        ///<summary>
        ///��ɾ��
        ///<summary>
        [EnumField("Del")]
        ��ɾ��
    }
    #endregion

    #region ����������
    [EnumDesc("����������")]
    public enum pulltype
    {
        ///<summary>
        ///¯�ű�������
        ///<summary>
        [EnumField("fip")]
        ¯�ű�������,
        ///<summary>
        ///����������
        ///<summary>
        [EnumField("ppl", new string[] { "pull" })]
        ����������,
        ///<summary>
        ///��������
        ///<summary>
        [EnumField("ep", new string[] { "pull" })]
        ��������,
        ///<summary>
        ///DD����
        ///<summary>
        [EnumField("dd", new string[] { "pull" })]
        DD,
        ///<summary>
        ///�ϳ���������
        ///<summary>
        [EnumField("south", new string[] { "pull" })]
        �ϳ���������,
        ///<summary>
        ///����PUS����
        ///<summary>
        [EnumField("north", new string[] { "pull" })]
        ����PUS����
    }
    #endregion

    #region ��װ����
    [EnumDesc("��װ����")]
    public enum PackageType
    {
        ///<summary>
        ///�ۺ��װ
        ///<summary>
        [EnumField("services", new string[] { "Sales" })]
        �ۺ��װ,
        ///<summary>
        ///ֽ��
        ///<summary>
        [EnumField("paper", new string[] { "package" })]
        ֽ��,
        ///<summary>
        ///�ϼ�
        ///<summary>
        [EnumField("rack", new string[] { "package" })]
        �ϼ�,
        ///<summary>
        ///��Ƥ��
        ///<summary>
        [EnumField("iron", new string[] { "package" })]
        ��Ƥ��,
        ///<summary>
        ///ľ��
        ///<summary>
        [EnumField("Wbox", new string[] { "package" })]
        ľ��,
        ///<summary>
        ///������
        ///<summary>
        [EnumField("plastic", new string[] { "package" })]
        ������,
        ///<summary>
        ///Сľ��
        ///<summary>
        [EnumField("Sbox", new string[] { "package" })]
        Сľ��,
        ///<summary>
        ///����
        ///<summary>
        [EnumField("tito", new string[] { "package" })]
        ����,
        ///<summary>
        ///ľ��
        ///<summary>
        [EnumField("Wpallet", new string[] { "package" })]
        ľ��,
        ///<summary>
        ///С����
        ///<summary>
        [EnumField("Siron", new string[] { "package" })]
        С����
    }
    #endregion

    #region ��������
    [EnumDesc("��������")]
    public enum ProduceStep
    {
        ///<summary>
        ///���ɷ���װ�ƻ�
        ///<summary>
        [EnumField("producepackage")]
        ���ɷ���װ�ƻ�,
        ///<summary>
        ///�����ۺ������װ�ƻ�
        ///<summary>
        [EnumField("produceafterpackage")]
        �����ۺ������װ�ƻ�,
        ///<summary>
        ///���ɱ���ƻ�
        ///<summary>
        [EnumField("producecheck")]
        ���ɱ���ƻ�,
    }
    #endregion

    #region ��������
    [EnumDesc("��������")]
    public enum ProduceType
    {
        ///<summary>
        ///��Ӧʱ��
        ///<summary>
        [EnumField("reactiontime")]
        ��Ӧʱ��,
        ///<summary>
        ///��ʱʱ��
        ///<summary>
        [EnumField("overtime")]
        ��ʱʱ��
    }
    #endregion

    #region �ƻ�����������
    [EnumDesc("�ƻ�����������")]
    public enum PlanInOrderType
    {
        ///<summary>
        ///��Ӧ�ƻ����
        ///<summary>
        [EnumField("")]
        ��Ӧ�ƻ����
    }
    #endregion

    #region ��Ӧ������
    [EnumDesc("��Ӧ������")]
    public enum SuppliersType
    {
        ///<summary>
        ///����
        ///<summary>
        [EnumField("stock")]
        ����,
        ///<summary>
        ///����
        ///<summary>
        [EnumField("checkout")]
        ����,
        /// <summary>
        /// ����
        /// </summary>
        [EnumField("pull")]
        ����,
        /// <summary>
        /// �˻�
        /// </summary>
        [EnumField("returngoods")]
        �˻�
    }
    #endregion

    #region ������
    public enum OrderNo
    {
        ///<summary>
        ///�ջ�����
        ///<summary>
        [EnumField("A")]
        �ջ�����,
        ///<summary>
        ///��ⵥ��
        ///<summary>
        [EnumField("B")]
        ��ⵥ��,
        /// <summary>
        /// �˻���ⵥ��
        /// </summary>
        [EnumField("C")]
        �˻���ⵥ��,
        /// <summary>
        /// ��λ������ⵥ��
        /// </summary>
        [EnumField("D")]
        ��λ������ⵥ��,
        /// <summary>
        /// ������ⵥ��
        /// </summary>
        [EnumField("E")]
        ������ⵥ��,
        /// <summary>
        /// ���ϵ���
        /// </summary>
        [EnumField("F")]
        ���ϵ���,
        /// <summary>
        /// ����װ����
        /// </summary>
        [EnumField("G")]
        ����װ����,
        /// <summary>
        /// �ƿⵥ��
        /// </summary>
        [EnumField("H")]
        �ƿⵥ��,
        /// <summary>
        /// �������
        /// </summary>
        [EnumField("I")]
        �������,
        /// <summary>
        ///������쵥
        /// </summary>
        [EnumField("J")]
        ������쵥,
        /// <summary>
        ///��������
        /// </summary>
        [EnumField("K")]
        ��������,
        /// <summary>
        ///���������
        /// </summary>
        [EnumField("L")]
        ���������,
        /// <summary>
        ///����̵㵥��
        /// </summary>
        [EnumField("M")]
        ����̵㵥��,
        /// <summary>
        ///��λ�����̵㵥��
        /// </summary>
        [EnumField("N")]
        ��λ�����̵㵥��,
        /// <summary>
        ///�˻����ţ��˻�����Ӧ�̣�
        /// </summary>
        [EnumField("O")]
        �˻�����Ӧ�̵���,
        /// <summary>
        ///���鵥��
        /// </summary>
        [EnumField("P")]
        ���鵥��,
        /// <summary>
        ///ɸѡ��Ϣ����
        /// </summary>
        [EnumField("Q")]
        ɸѡ��Ϣ����,
        /// <summary>
        ///�ۺ󷢻���
        /// </summary>
        [EnumField("R")]
        �ۺ󷢻���,
        /// <summary>
        ///������
        /// </summary>
        [EnumField("S")]
        ������,
        /// <summary>
        /// �ͻ��˻��ջ�����
        /// </summary>
        [EnumField("W")]
        �ͻ��˻��ջ�����,
    }
    #endregion

    #region ��������
    [EnumDesc("��������")]
    public enum PartOwner
    {
        ///<summary>
        ///����
        ///<summary>
        [EnumField("Account")]
        ����,
        ///<summary>
        ///����
        ///<summary>
        [EnumField("OutAccount")]
        ����,
        ///<summary>
        ///��ӯ
        ///<summary>
        [EnumField("Overage")]
        ��ӯ,
    }
    #endregion

    #region ҵ�񵥾�����
    public enum OrderType
    {
        ///<summary>
        ///��λ���߷�����
        ///<summary>
        [EnumField("packageDeliver")]
        ��λ���߷�����,
        ///<summary>
        ///��Ӧ���ͻ����
        ///<summary>
        [EnumField("SupplierIn")]
        ��Ӧ���ͻ����,
        ///<summary>
        ///��λ������ⵥ
        ///<summary>
        [EnumField("PackageIn")]
        ��λ������ⵥ,
        ///<summary>
        ///�ͻ��˻����
        ///<summary>
        [EnumField("CustomerBack")]
        �ͻ��˻����,
        ///<summary>
        ///��Ӧ���ͻ��ջ�
        ///<summary>
        [EnumField("SupplierReceive")]
        ��Ӧ���ͻ��ջ�,
        ///<summary>
        ///�ͻ��˻��ջ�
        ///<summary>
        [EnumField("CustBackReceive")]
        �ͻ��˻��ջ�,
        ///<summary>
        ///�������
        ///<summary>
        [EnumField("InspectionIn")]
        �������,
        ///<summary>
        ///��������
        ///<summary>
        [EnumField("PullProduce")]
        ��������,
        ///<summary>
        ///�ۺ�����
        ///<summary>
        [EnumField("ServicePull")]
        �ۺ�����,
        ///<summary>
        ///¯������
        ///<summary>
        [EnumField("FurnacePull")]
        ¯������,
        ///<summary>
        ///�ƿⵥ
        ///<summary>
        [EnumField("MoveOrder")]
        �ƿⵥ,
        ///<summary>
        ///�������
        ///<summary>
        [EnumField("InspectionOut")]
        �������,
        ///<summary>
        ///ɸѡ��
        ///<summary>
        [EnumField("FilterOrder")]
        ɸѡ��,
        ///<summary>
        ///���ϵ�
        ///<summary>
        [EnumField("ScrapOrder")]
        ���ϵ�,
        ///<summary>
        ///����װ�ƻ�
        ///<summary>
        [EnumField("RepackageOrder")]
        ����װ�ƻ�,
        ///<summary>
        ///����̵�ƻ�
        ///<summary>
        [EnumField("PartCheck")]
        ����̵�ƻ�,
        ///<summary>
        ///��λ�����̵�ƻ�
        ///<summary>
        [EnumField("PackageCheck")]
        ��λ�����̵�ƻ�,
        ///<summary>
        ///������ⵥ
        ///<summary>
        [EnumField("AdjustIn")]
        ������ⵥ,
        ///<summary>
        ///�������ⵥ
        ///<summary>
        [EnumField("AdjustOut")]
        �������ⵥ,
        ///<summary>
        ///��������
        ///<summary>
        [EnumField("AdjustOpen")]
        �������䵥,
        ///<summary>
        ///�ۺ󷢻���
        ///<summary>
        [EnumField("ServiceSend")]
        �ۺ󷢻���,
        ///<summary>
        ///������
        ///<summary>
        [EnumField("PartSend")]
        ������,
        ///<summary>
        ///�����
        ///<summary>
        [EnumField("PickOrder")]
        �����,
        ///<summary>
        ///�ܳ��ջ���
        ///<summary>
        [EnumField("AssemblyReceive")]
        �ܳ��ջ���,
        ///<summary>
        ///�ܳ���ⵥ
        ///<summary>
        [EnumField("AssemblyIn")]
        �ܳ���ⵥ,
        ///<summary>
        ///�˻�����Ӧ��
        ///<summary>
        [EnumField("BackSupplier")]
        �˻�����Ӧ��
    }
    #endregion

    #region ����״̬
    public enum OrderState
    {
        /// <summary>
        /// �ѷ���
        /// </summary>
        [EnumField("finish")]
        �ѷ���,
        /// <summary>
        /// ������
        /// </summary>
        [EnumField("wait")]
        ������
    }
    #endregion

    #region �����ϼܷ�������
    public enum DeliverPackageType
    {
        ///<summary>
        ///����
        ///<summary>
        [EnumField("pull")]
        ����,
        ///<summary>
        ///�˻�
        ///<summary>
        [EnumField("back")]
        �˻�,
        /// <summary>
        /// ,
        /// </summary>
        [EnumField("send")]
        �ͻ��ͻ�,
        /// <summary>
        /// ҵ��
        /// </summary>
        [EnumField("other")]
        ҵ��,
        ///<summary>
        ///���򷢻���
        ///<summary>
        [EnumField("QueueSend")]
        ���򷢻���
    }
    #endregion

    #region ��������
    public enum SendType
    {
        /// <summary>
        /// ��������
        /// </summary>
        [EnumField("pullSend")]
        ��������,
        /// <summary>
        /// �ۺ󷢻�
        /// </summary>
        [EnumField("serviceSend")]
        �ۺ󷢻�,
        /// <summary>
        /// �˻�����
        /// </summary>
        [EnumField("bakcSend")]
        �˻�����,
        /// <summary>
        /// ҵ�ⷢ��
        /// </summary>
        [EnumField("OutSideSend")]
        ҵ�ⷢ��,
        ///<summary>
        ///���򷢻���
        ///<summary>
        [EnumField("QueueSend")]
        ���򷢻���
    }
    #endregion

    #region �Ƿ���
    [EnumDesc("�Ƿ���")]
    public enum Isinspection
    {
        ///<summary>
        ///��
        ///<summary>
        [EnumField("0")]
        Yes,
        ///<summary>
        ///��
        ///<summary>
        [EnumField("1")]
        No
    }
    #endregion

    #region �Ƿ�¯�ű���
    [EnumDesc("�Ƿ�¯�ű���")]
    public enum Isfurnace
    {
        ///<summary>
        ///��
        ///<summary>
        [EnumField("0")]
        Yes,
        ///<summary>
        ///��
        ///<summary>
        [EnumField("1")]
        No
    }
    #endregion

    #region �Ƿ�һƷ����
    [EnumDesc("�Ƿ�һƷ����")]
    public enum Ismutil
    {
        ///<summary>
        ///��
        ///<summary>
        [EnumField("0")]
        ��,
        ///<summary>
        ///��
        ///<summary>
        [EnumField("1")]
        ��
    }
    #endregion

    #region �Ƿ�WAREHOUSE��ⱨ��
    [EnumDesc("�Ƿ�WAREHOUSE��ⱨ��")]
    public enum IsWaring
    {
        ///<summary>
        ///��
        ///<summary>
        [EnumField("1")]
        ��,
        ///<summary>
        ///��
        ///<summary>
        [EnumField("0")]
        ��
    }
    #endregion

    #region �ʼ�����
    [EnumDesc("�ʼ�����")]
    public enum Qualitystate
    {
        ///<summary>
        ///ɸѡ
        ///<summary>
        [EnumField("Scan")]
        ɸѡ,
        ///<summary>
        ///������
        ///<summary>
        [EnumField("Inspection")]
        ������,
        ///<summary>
        ///�ϸ�
        ///<summary>
        [EnumField("Qualified")]
        �ϸ�,
        ///<summary>
        ///���ϸ�
        ///<summary>
        [EnumField("UnQualified")]
        ���ϸ�
    }
    #endregion

    #region ��λ����
    public enum LocType
    {
        /// <summary>
        ///������λ
        /// </summary>
        [EnumField("Nomal")]
        ������λ,
        /// <summary>
        ///����Ʒ��λ
        /// </summary>
        [EnumField("UnNomal")]
        ����Ʒ��λ,
        /// <summary>
        ///HOLD����λ
        /// </summary>
        [EnumField("Hold")]
        HOLD����λ,
        /// <summary>
        ///������
        /// </summary>
        [EnumField("UnInspection")]
        ������,
        /// <summary>
        ///���п�λ
        /// </summary>
        [EnumField("Package")]
        ���п�λ,
        /// <summary>
        ///�ۺ��
        /// </summary>
        [EnumField("Aftermarket")]
        �ۺ��,
        /// <summary>
        ///������
        /// </summary>
        [EnumField("Shipped")]
        ������,
        /// <summary>
        ///��װ����
        /// </summary>
        [EnumField("Handle")]
        ��װ����,
        /// <summary>
        ///�ۺ����װ
        /// </summary>
        [EnumField("ServicesHandle")]
        �ۺ����װ
    }
    #endregion

    #region �Ƿ����
    [EnumDesc("���״̬")]
    public enum Is_Finish
    {
        ///<summary>
        ///���
        ///<summary>
        [EnumField("0", new string[] { "Receive" })]
        ���,
        ///<summary>
        ///δ���
        ///<summary>
        [EnumField("1", new string[] { "Receive" })]
        δ���,
        ///<summary>
        ///�����
        ///<summary>
        [EnumField("2", new string[] { "Package" })]
        �����,
        ///<summary>
        ///������
        ///<summary>
        [EnumField("3", new string[] { "Package" })]
        ������,
        ///<summary>
        ///�������
        ///<summary>
        [EnumField("4")]
        �������
    }
    #endregion

    #region �������
    [EnumDesc("�������")]
    public enum In_Order_Type
    {
        ///<summary>
        ///��Ӧ�����
        ///<summary>
        [EnumField("SuppIn")]
        ��Ӧ���ͻ����,
        ///<summary>
        ///�ͻ��˻����
        ///<summary>
        [EnumField("CustBack")]
        �ͻ��˻����,
        ///<summary>
        ///�������
        ///<summary>
        [EnumField("InspecIn")]
        �������
    }
    #endregion

    #region ��������
    [EnumDesc("��������")]
    public enum ProduceProcess
    {
        ///<summary>
        ///��������
        ///<summary>
        [EnumField(0)]
        ��Ӧ���ͻ�
    }
    #endregion

    #region ��ʱ����
    [EnumDesc("��ʱ����")]
    public enum OverTimeProcess
    {
        ///<summary>
        ///����װʱ��
        ///<summary>
        [EnumField("RePackage")]
        ����װʱ��,
        ///<summary>
        ///�ۺ󷭰�װʱ��
        ///<summary>
        [EnumField("ServPackage")]
        �ۺ󷭰�װʱ��,
    }
    #endregion

    #region ��λ���ߵ�������
    [EnumDesc("��λ���ߵ�������")]
    public enum PackageOrderType
    {
        ///<summary>
        ///����
        ///<summary>
        [EnumField(0)]
        ����,
        ///<summary>
        ///¼��
        ///<summary>
        [EnumField(1)]
        ¼��,
        ///<summary>
        ///��ӯ
        ///<summary>
        [EnumField(2)]
        �ջ�
    }
    #endregion

    #region �����ļ�����
    [EnumDesc("�����ļ�����")]
    public enum ImPortType
    {
        ///<summary>
        ///��Ӧ�����ͻ��ƻ�
        ///<summary>
        [EnumField("SupplierMonthPlan")]
        ��Ӧ�����ͻ��ƻ�,
        ///<summary>
        ///��λ�����ջ���¼
        ///<summary>
        [EnumField("PackageInStorage")]
        ��λ�����ջ���¼,
        ///<summary>
        ///����װ�ռƻ�
        ///<summary>
        [EnumField("RePackageDaily")]
        ����װ�ռƻ�,
        ///<summary>
        ///����������
        ///<summary>
        [EnumField("PullPlanExport")]
        ����������
    }
    #endregion

    #region ��λ����
    [EnumDesc("��λ����")]
    public enum MeasurementType
    {
        ///<summary>
        ///��
        ///<summary>
        [EnumField("item")]
        ��,
        ///<summary>
        ///��
        ///<summary>
        [EnumField("box")]
        ��
    }
    #endregion

    #region �������
    [EnumDesc("�������")]
    public enum PickType
    {
        ///<summary>
        ///�������
        ///<summary>
        [EnumField("Pull")]
        �������,
        ///<summary>
        ///�ۺ��װ���
        ///<summary>
        [EnumField("Service")]
        �ۺ��װ���,
        ///<summary>
        ///�ۺ��װ���
        ///<summary>
        [EnumField("ServicePull")]
        �ۺ󷢻����,
        ///<summary>
        ///����װ�����
        ///<summary>
        [EnumField("Repackage")]
        ����װ�����,
        ///<summary>
        ///�����������
        ///<summary>
        [EnumField("Production")]
        �����������,
        ///<summary>
        ///�������
        ///<summary>
        [EnumField("Inspection")]
        �������,
        ///<summary>
        ///�˻�
        ///<summary>
        [EnumField("Return")]
        �˻�,
        ///<summary>
        ///�ƿ�
        ///<summary>
        [EnumField("Move")]
        �ƿ�
    }
    #endregion

    #region ��������
    [EnumDesc("��������")]
    public enum AdjustType
    {
        ///<summary>
        ///������
        ///<summary>
        [EnumField("InStorage")]
        ������,
        ///<summary>
        ///�������
        ///<summary>
        [EnumField("OutStorage")]
        �������,
        ///<summary>
        ///�������Ӳ���
        ///<summary>
        [EnumField("OpenAdd")]
        �������Ӳ���,
        ///<summary>
        ///������ٲ���
        ///<summary>
        [EnumField("OpenReduce")]
        ������ٲ���

    }
    #endregion

    #region ��������
    [EnumDesc("��������")]
    public enum OperateType
    {
        ///<summary>
        ///�ջ�
        ///<summary>
        [EnumField("Receipt")]
        �ջ�,
        ///<summary>
        ///���
        ///<summary>
        [EnumField("InStorage")]
        ���,
        ///<summary>
        ///�ƿ�
        ///<summary>
        [EnumField("Move")]
        �ƿ�,
        ///<summary>
        ///���
        ///<summary>
        [EnumField("Pick")]
        ���,
        ///<summary>
        ///��װ
        ///<summary>
        [EnumField("Package")]
        ��װ,
        ///<summary>
        ///����
        ///<summary>
        [EnumField("Send")]
        ����,
        ///<summary>
        ///ɸѡ
        ///<summary>
        [EnumField("Filter")]
        ɸѡ,
        ///<summary>
        ///����
        ///<summary>
        [EnumField("Scrapped")]
        ����,
        ///<summary>
        ///������
        ///<summary>
        [EnumField("AdjustIn")]
        ������,
        ///<summary>
        ///�������
        ///<summary>
        [EnumField("AdjustOut")]
        �������,
        ///<summary>
        ///�������
        ///<summary>
        [EnumField("OpenDiff")]
        �������,
        ///<summary>
        ///������
        ///<summary>
        [EnumField("Inspection")]
        ������,
        ///<summary>
        ///��Ŀ����
        ///<summary>
        [EnumField("Brrow")]
        ��Ŀ����
    }
    #endregion

    #region ��λ�����������
    [EnumDesc("��λ�����������")]
    public enum PackageInType
    {
        ///<summary>
        ///¼��
        ///<summary>
        [EnumField("Input")]
        ¼��,
        ///<summary>
        ///����
        ///<summary>
        [EnumField("Import")]
        ����
    }
    #endregion

    #region �Ƿ�ϸ�
    [EnumDesc("�Ƿ�ϸ�")]
    public enum Isqualified
    {
        ///<summary>
        ///�ϸ�
        ///<summary>
        [EnumField("0")]
        ��,
        ///<summary>
        ///���ϸ�
        ///<summary>
        [EnumField("1")]
        ��
    }
    #endregion

    #region ��������
    [EnumDesc("��������")]
    public enum InspectionType
    {
        ///<summary>
        ///���α���
        ///<summary>
        [EnumField("Batch")]
        ���α���,
        ///<summary>
        ///¯�ű���
        ///<summary>
        [EnumField("Furnace")]
        ¯�ű���
    }
    #endregion

    #region ��������
    [EnumDesc("��������")]
    public enum ScrapType
    {
        ///<summary>
        ///ɸѡ����
        ///<summary>
        [EnumField("Filter")]
        ɸѡ����,
        ///<summary>
        ///���鱨��
        ///<summary>
        [EnumField("Inspection")]
        ���鱨��,
        ///<summary>
        ///��������
        ///<summary>
        [EnumField("Other")]
        ��������
    }
    #endregion

    #region ��װ״̬
    [EnumDesc("��װ״̬")]
    public enum PackageState
    {
        ///<summary>
        ///�Ѱ�װ
        ///<summary>
        [EnumField("0")]
        �Ѱ�װ,
        ///<summary>
        ///δ��װ
        ///<summary>
        [EnumField("1")]
        δ��װ
    }
    #endregion

    #region ������״̬
    [EnumDesc("������״̬")]
    public enum BackState
    {
        ///<summary>
        ///�����
        ///<summary>
        [EnumField("0")]
        �����,
        ///<summary>
        ///δ���
        ///<summary>
        [EnumField("1")]
        δ���
    }
    #endregion

    #region ����ҵ��
    [EnumDesc("����ҵ������")]
    public enum OrderBusinessType
    {
        ///<summary>
        ///����
        ///<summary>
        [EnumField("OutStorage")]
        ����,
        ///<summary>
        ///���
        ///<summary>
        [EnumField("InStorage")]
        ���,
        ///<summary>
        ///���
        ///<summary>
        [EnumField("Pick")]
        ���,
        ///<summary>
        ///��װ
        ///<summary>
        [EnumField("Package")]
        ��װ,
        ///<summary>
        ///ɸѡ
        ///<summary>
        [EnumField("Filter")]
        ɸѡ,
        ///<summary>
        ///����
        ///<summary>
        [EnumField("Scrapped")]
        ����,
        ///<summary>
        ///����
        ///<summary>
        [EnumField("Inspection")]
        ����,
        ///<summary>
        ///�ջ�
        ///<summary>
        [EnumField("Receipt")]
        �ջ�,
        ///<summary>
        ///�ƿ�
        ///<summary>
        [EnumField("Move")]
        �ƿ�,
        ///<summary>
        ///����
        ///<summary>
        [EnumField("Send")]
        ����,

    }
    #endregion

    #region �̵�״̬
    [EnumDesc("�̵�״̬")]
    public enum CheckState
    {
        ///<summary>
        ///���̵�
        ///<summary>
        [EnumField("YES")]
        ���̵�,
        ///<summary>
        ///δ�̵�
        ///<summary>
        [EnumField("NO")]
        δ�̵�
    }
    #endregion

    #region ����״̬
    [EnumDesc("����״̬")]
    public enum ScrapState
    {
        ///<summary>
        ///��ȷ�ϱ���
        ///<summary>
        [EnumField("YES")]
        ��ȷ�ϱ���,
        ///<summary>
        ///δȷ�ϱ���
        ///<summary>
        [EnumField("NO")]
        δȷ�ϱ���
    }
    #endregion

    #region �ƿ�״̬
    [EnumDesc("�ƿ�״̬")]
    public enum MoveState
    {
        ///<summary>
        ///��ȷ���ƿ�
        ///<summary>
        [EnumField("YES")]
        ��ȷ���ƿ�,
        ///<summary>
        ///δȷ���ƿ�
        ///<summary>
        [EnumField("NO")]
        δȷ���ƿ�
    }
    #endregion

    #region ����״̬
    [EnumDesc("����״̬")]
    public enum OrderSatus
    {
        ///<summary>
        ///���
        ///<summary>
        [EnumField("0")]
        �������,
        ///<summary>
        ///����
        ///<summary>
        [EnumField("1")]
        ����δ���

    }
    #endregion


    #region �Ƿ񶳽�
    [EnumDesc("�Ƿ񶳽�")]
    public enum IsFrozen
    {
        ///<summary>
        ///��
        ///<summary>
        [EnumField("1")]
        ��,
        ///<summary>
        ///��
        ///<summary>
        [EnumField("0")]
        ��
    }
    #endregion

    #region ��λ���ֿ߲��������
    [EnumDesc("��λ���ֿ߲��������")]
    public enum PackageOperateType
    {
        ///<summary>
        ///�ջ�
        ///<summary>
        [EnumField("In")]
        �ջ�,
        ///<summary>
        ///����
        ///<summary>
        [EnumField("Out")]
        ����
    }
    #endregion

    #region �Ƿ����
    [EnumDesc("�Ƿ����")]
    public enum IsInStorage
    {
        ///<summary>
        ///�����
        ///<summary>
        [EnumField("In")]
        �����,
        ///<summary>
        ///δ���
        ///<summary>
        [EnumField("NotIn")]
        δ���
    }
    #endregion

    #region ���鵥״̬
    [EnumDesc("���鵥״̬")]
    public enum InspectionState
    {
        ///<summary>
        ///���������
        ///<summary>
        [EnumField("InspectionIn")]
        ���������,
        ///<summary>
        ///��������
        ///<summary>
        [EnumField("InspectionOut")]
        ��������
    }
    #endregion

    #region ������
    [EnumDesc("������")]
    public enum InspectionResult
    {
        ///<summary>
        ///�ϸ�
        ///<summary>
        [EnumField("Qualified")]
        �ϸ�,
        ///<summary>
        ///���ϸ�
        ///<summary>
        [EnumField("UnQualified")]
        ���ϸ�
    }
    #endregion

    #region �Ƿ�����
    [EnumDesc("�Ƿ�����")]
    public enum IsAcceptance
    {
        ///<summary>
        ///������
        ///<summary>
        [EnumField("0")]
        ������,
        ///<summary>
        ///δ����
        ///<summary>
        [EnumField("1")]
        δ����
    }
    #endregion

    #region ������
    [EnumDesc("������")]
    public enum IsQualified
    {
        ///<summary>
        ///�ϸ�
        ///<summary>
        [EnumField("0")]
        �ϸ�,
        ///<summary>
        ///���ϸ�
        ///<summary>
        [EnumField("1")]
        ���ϸ�,
        ///<summary>
        ///������
        ///<summary>
        [EnumField("2")]
        ������
    }
    #endregion

    #region ��������
    [EnumDesc("��������")]
    public enum DELIVERTYPE
    {
        ///<summary>
        ///����
        ///<summary>
        [EnumField("Pull")]
        ����,
        ///<summary>
        ///�ۻ�
        ///<summary>
        [EnumField("Customer_service")]
        �ۺ�,
        ///<summary>
        /// �˻�
        ///<summary>
        [EnumField("Return_goods")]
        �˻�,
        ///<summary>
        /// ҵ��
        ///<summary>
        [EnumField("Outside_the_industry")]
        ����,
        ///<summary>
        ///���򷢻���
        ///<summary>
        [EnumField("QueueSend")]
        ���򷢻���
    }
    #endregion

    #region �Ƿ���
    [EnumDesc("�Ƿ���")]
    public enum IsDeal
    {
        ///<summary>
        ///��
        ///<summary>
        [EnumField("0")]
        ��,
        ///<summary>
        ///��
        ///<summary>
        [EnumField("1")]
        ��
    }
    #endregion

    #region ���α���
    [EnumDesc("���α���")]
    public enum IsInspectionBatch
    {
        ///<summary>
        ///��
        ///<summary>
        [EnumField("0")]
        ��,
        ///<summary>
        ///��
        ///<summary>
        [EnumField("1")]
        ��
    }
    #endregion

    #region ¯�ű���
    [EnumDesc("¯�ű���")]
    public enum IsInspectionFurnace
    {
        ///<summary>
        ///��
        ///<summary>
        [EnumField("0")]
        ��,
        ///<summary>
        ///��
        ///<summary>
        [EnumField("1")]
        ��
    }
    #endregion

    #region �Ƿ�ӹ�
    [EnumDesc("�Ƿ�ӹ�")]
    public enum IsProcessing
    {
        ///<summary>
        ///��
        ///<summary>
        [EnumField("0")]
        ��,
        ///<summary>
        ///��
        ///<summary>
        [EnumField("1")]
        ��
    }
    #endregion

}
