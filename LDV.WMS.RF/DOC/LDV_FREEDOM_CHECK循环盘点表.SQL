----------------------------------------------------
-- Export file for user LDVWMS                    --
-- Created by Administrator on 2012-3-30, 9:52:01 --
----------------------------------------------------

spool LDV_FREEDOM_CHECK.log

prompt
prompt Creating table LDV_FREEDOM_CHECK
prompt ================================
prompt
create table LDVWMS.LDV_FREEDOM_CHECK
(
  ID                  INTEGER,
  LOC_ID              INTEGER,
  ITEM_ID             INTEGER,
  QTY                 INTEGER,
  CREATE_DATE         TIMESTAMP(6),
  CREATE_USER_ID      INTEGER,
  LAST_MODIFY_DATE    TIMESTAMP(6),
  LAST_MODIFY_USER_ID INTEGER
)
tablespace LDVWMS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
comment on column LDVWMS.LDV_FREEDOM_CHECK.LOC_ID
  is '库位ID';
comment on column LDVWMS.LDV_FREEDOM_CHECK.ITEM_ID
  is '商品ID';
comment on column LDVWMS.LDV_FREEDOM_CHECK.QTY
  is '数量';
comment on column LDVWMS.LDV_FREEDOM_CHECK.CREATE_DATE
  is '创建时间';
comment on column LDVWMS.LDV_FREEDOM_CHECK.CREATE_USER_ID
  is '创建人';
comment on column LDVWMS.LDV_FREEDOM_CHECK.LAST_MODIFY_DATE
  is '最近修改时间';
comment on column LDVWMS.LDV_FREEDOM_CHECK.LAST_MODIFY_USER_ID
  is '最近修改人';


spool off
