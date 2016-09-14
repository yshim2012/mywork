-- Create table
create table LDV_PACKAGE_ITEM_REL
(
  ID                    INTEGER,
  PACKAGE_BARCODE_ID    INTEGER,
  PICK_TICKET_DETAIL_ID INTEGER,
  QTY                   INTEGER,
  CREATE_DATE           TIMESTAMP(6),
  CREATE_USER_ID        INTEGER,
  LAST_MODIFY_DATE      TIMESTAMP(6),
  LAST_MODIFY_USER_ID   INTEGER
)
tablespace LDVWMS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  );
-- Add comments to the columns 
comment on column LDV_PACKAGE_ITEM_REL.ID
  is 'ID';
comment on column LDV_PACKAGE_ITEM_REL.PACKAGE_BARCODE_ID
  is '��װ������ID';
comment on column LDV_PACKAGE_ITEM_REL.PICK_TICKET_DETAIL_ID
  is '�����ID';
comment on column LDV_PACKAGE_ITEM_REL.QTY
  is '��Ʒ����';
comment on column LDV_PACKAGE_ITEM_REL.CREATE_DATE
  is '����ʱ��';
comment on column LDV_PACKAGE_ITEM_REL.CREATE_USER_ID
  is '������';
comment on column LDV_PACKAGE_ITEM_REL.LAST_MODIFY_DATE
  is '����޸�ʱ��';
comment on column LDV_PACKAGE_ITEM_REL.LAST_MODIFY_USER_ID
  is '����޸���';


create sequence LDV_PACKAGE_ITEM_REL_SEQ
minvalue 1
maxvalue 99999999999999999999999999
start with 1
increment by 1
cache 20;
